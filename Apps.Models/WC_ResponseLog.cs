//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Apps.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class WC_ResponseLog
    {
        public string Id { get; set; }
        public string OfficalAccountId { get; set; }
        public string OpenId { get; set; }
        public Nullable<int> RequestType { get; set; }
        public string RequestContent { get; set; }
        public Nullable<int> ResponseType { get; set; }
        public string ResponseContent { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public string ModifyBy { get; set; }
    
        public virtual WC_OfficalAccounts WC_OfficalAccounts { get; set; }
    }
}
