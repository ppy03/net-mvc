//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopQuanAo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            this.sale = new HashSet<sale>();
        }
    
        public int stt { get; set; }
        public string id_product { get; set; }
        public string name_product { get; set; }
        public string images { get; set; }
        public Nullable<decimal> price_new { get; set; }
        public Nullable<decimal> price_old { get; set; }
        public string describe { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public string id_subcate { get; set; }
        public Nullable<int> id_brand { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual subCategory subCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sale> sale { get; set; }
    }
}