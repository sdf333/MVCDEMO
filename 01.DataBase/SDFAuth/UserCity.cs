//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB.SDFAuth
{
    using System;
    using System.Collections.Generic;
    
    using DataBase;
    public partial class UserCity :BaseEntity
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public long ProvinceID { get; set; }
        public long DistrictID { get; set; }
        public long CityID { get; set; }
    
        public virtual S_City S_City { get; set; }
        public virtual S_District S_District { get; set; }
        public virtual S_Province S_Province { get; set; }
    }
}
