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
        public int Room { get; set; }
        public int Class { get; set; }
        public string Photo { get; set; }
        public bool Status { get; set; }
        public int ID { get; set; }

        public string StatusText
        {
            get
            {
                if (Status == true) return "Занята";
                else return "Свободна";
            }
        }
    
        public virtual Classes Classes { get; set; }
    }
}
