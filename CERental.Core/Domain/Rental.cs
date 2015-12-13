using System;
using System.Collections.Generic;

namespace CERental.Core.Domain
{
    public class Rental : Entity
    {
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Registered { get; set; }

        // Navigational properties
        public ApplicationUser User { get; set; }
        public ICollection<EquipmentInRent> EquipmentsInRent { get; set; }
    }
}