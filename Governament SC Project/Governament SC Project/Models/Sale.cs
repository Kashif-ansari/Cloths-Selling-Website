//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Governament_SC_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sale()
        {
            this.Accounts = new HashSet<Account>();
        }
    
        public int Sell_ID { get; set; }
        public Nullable<int> C_id { get; set; }
        public Nullable<int> O_id { get; set; }
        public Nullable<int> P_ID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Total_Price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Outlet Outlet { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
