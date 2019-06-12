using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystem.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string IdentityId { get; set; }

        public virtual ApplicationUser Identity { get; set; }

        public string Location { get; set; }
    }
}
