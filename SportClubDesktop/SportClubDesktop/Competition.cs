//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SportClubDesktop
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public partial class Competition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Competition()
        {
            this.Members = new HashSet<Member>();
        }
    
        public short gkey { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<decimal> cost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Member> Members { get; set; }

        public override string ToString()
        {
            return $"Date: {date}\nCost: {((decimal)cost).ToString("C", CultureInfo.CurrentCulture)}\n";
        }
    }
}