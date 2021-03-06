//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlySkyServices.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class M_FlightInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public M_FlightInfo()
        {
            this.T_FlightsTable = new HashSet<T_FlightsTable>();
        }
    
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public string RegistrationNo { get; set; }
        public Nullable<int> FlightStatus { get; set; }
        public bool IsEconomy { get; set; }
        public bool IsPremiumEconomy { get; set; }
        public bool IsBusiness { get; set; }
        public Nullable<int> NoOfSeat { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string Desc { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    
        public virtual M_AviationCompanyMaster M_AviationCompanyMaster { get; set; }
        public virtual M_MasterTable M_MasterTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_FlightsTable> T_FlightsTable { get; set; }
    }
}
