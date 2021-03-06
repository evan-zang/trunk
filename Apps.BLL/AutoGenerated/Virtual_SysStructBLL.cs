//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Apps.Models;
using Apps.Common;
using Microsoft.Practices.Unity;
using System.Transactions;
using Apps.IBLL;
using Apps.IDAL;
using Apps.BLL.Core;
using Apps.Locale;
using Apps.Models.Sys;
namespace Apps.BLL
{
	public class Virtual_SysStructBLL
	{
        [Dependency]
        public ISysStructRepository m_Rep { get; set; }

		public virtual List<SysStructModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<SysStruct> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(
								a=>a.Id.Contains(queryStr)
								|| a.Name.Contains(queryStr)
								|| a.ParentId.Contains(queryStr)
								
								|| a.Higher.Contains(queryStr)
								
								|| a.Remark.Contains(queryStr)
								
								);
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            pager.totalRows = queryData.Count();
            //排序
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        public virtual List<SysStructModel> CreateModelList(ref IQueryable<SysStruct> queryData)
        {

            List<SysStructModel> modelList = (from r in queryData
                                              select new SysStructModel
                                              {
													Id = r.Id,
													Name = r.Name,
													ParentId = r.ParentId,
													Sort = r.Sort,
													Higher = r.Higher,
													Enable = r.Enable,
													Remark = r.Remark,
													CreateTime = r.CreateTime,
          
                                              }).ToList();

            return modelList;
        }

        public virtual bool Create(ref ValidationErrors errors, SysStructModel model)
        {
            try
            {
                SysStruct entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Resource.PrimaryRepeat);
                    return false;
                }
                entity = new SysStruct();
               				entity.Id = model.Id;
				entity.Name = model.Name;
				entity.ParentId = model.ParentId;
				entity.Sort = model.Sort;
				entity.Higher = model.Higher;
				entity.Enable = model.Enable;
				entity.Remark = model.Remark;
				entity.CreateTime = model.CreateTime;
  

                if (m_Rep.Create(entity))
                {
                    return true;
                }
                else
                {
                    errors.Add(Resource.InsertFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }



         public virtual bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public virtual bool Delete(ref ValidationErrors errors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        if (m_Rep.Delete(deleteCollection) == deleteCollection.Length)
                        {
                            transactionScope.Complete();
                            return true;
                        }
                        else
                        {
                            Transaction.Current.Rollback();
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

		
       

        public virtual bool Edit(ref ValidationErrors errors, SysStructModel model)
        {
            try
            {
                SysStruct entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Resource.Disable);
                    return false;
                }
                              				entity.Id = model.Id;
				entity.Name = model.Name;
				entity.ParentId = model.ParentId;
				entity.Sort = model.Sort;
				entity.Higher = model.Higher;
				entity.Enable = model.Enable;
				entity.Remark = model.Remark;
				entity.CreateTime = model.CreateTime;
 


                if (m_Rep.Edit(entity))
                {
                    return true;
                }
                else
                {
                    errors.Add(Resource.NoDataChange);
                    return false;
                }

            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

      

        public virtual SysStructModel GetById(string id)
        {
            if (IsExists(id))
            {
                SysStruct entity = m_Rep.GetById(id);
                SysStructModel model = new SysStructModel();
                              				model.Id = entity.Id;
				model.Name = entity.Name;
				model.ParentId = entity.ParentId;
				model.Sort = entity.Sort;
				model.Higher = entity.Higher;
				model.Enable = entity.Enable;
				model.Remark = entity.Remark;
				model.CreateTime = entity.CreateTime;
 
                return model;
            }
            else
            {
                return null;
            }
        }

        public virtual bool IsExists(string id)
        {
            return m_Rep.IsExist(id);
        }
		  public void Dispose()
        { 
            
        }

	}
}
