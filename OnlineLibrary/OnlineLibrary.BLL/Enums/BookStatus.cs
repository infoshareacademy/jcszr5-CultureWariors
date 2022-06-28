using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BLL.Enums
{
    public enum BookStatus
    {
        [Display(Name="W przygotowaniu")]
        Processing,

        [Display(Name = "Gotowa do odbioru")]
        Ready,

        [Display(Name = "Wydana")]
        Rented,

        [Display(Name = "Zwrócona")]
        Returned,

        [Display(Name = "Spóźnienie")]
        Delayed
        

       

    }
}
