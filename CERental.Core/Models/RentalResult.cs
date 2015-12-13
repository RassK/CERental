using System.Collections.Generic;

namespace CERental.Core.Models
{
    public class RentalResult
    {
        public int PointsEarned { get; set; }
        public decimal TotalPrice { get; set; }
        public List<EquipmentRentalDetailed> Equipment { get; set; }
    }
}