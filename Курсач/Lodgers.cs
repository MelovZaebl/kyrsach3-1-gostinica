//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Курсач
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lodgers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lodgers()
        {
            this.Lodgers_Kids = new HashSet<Lodgers_Kids>();
            this.OrdersReg = new HashSet<OrdersReg>();
        }
    
        public string FIO { get; set; }
        public int Passport { get; set; }
        public int Room { get; set; }
        public string Phone { get; set; }
        public bool Pol { get; set; }
        public int ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lodgers_Kids> Lodgers_Kids { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersReg> OrdersReg { get; set; }
    }
}
