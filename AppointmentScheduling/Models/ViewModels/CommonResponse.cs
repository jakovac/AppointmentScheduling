using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling.Models.ViewModels
{
    public class CommonResponse<T> //kada god budemo pozivali API, a on nam vrati response, nekada ce biti int, nekada objekat nekada samo text.
    {
        public int status { get; set; }
        public string message { get; set; }
        public T dataenum { get; set; }
    }
}
