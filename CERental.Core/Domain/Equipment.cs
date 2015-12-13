using CERental.Core.Enums;
using System.Collections.Generic;

namespace CERental.Core.Domain
{
    public class Equipment : Entity
    {
        public EquipmentType Type { get; set; }
        public string Name { get; set; }

        /* Navigational properties */
        public virtual ICollection<EquipmentInRent> EquipmentInRent { get; set; }
    }
}