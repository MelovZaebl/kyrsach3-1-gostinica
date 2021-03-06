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
    
    public partial class Rooms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rooms()
        {
            this.OrdersReg = new HashSet<OrdersReg>();
        }
    
        public int Room { get; set; }
        public int Class { get; set; }
        public string Photo { get; set; }
        public bool Status { get; set; }
        public int ID { get; set; }

        public string StatusText
        {
            get
            {
                if (this.Status == false) return "Свободна";
                else return "Занята";
            }
        }
    
        public virtual Classes Classes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersReg> OrdersReg { get; set; }
    }
}
