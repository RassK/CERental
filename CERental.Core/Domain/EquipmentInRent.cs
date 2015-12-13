namespace CERental.Core.Domain
{
    public class EquipmentInRent : Entity
    {
        public int EquipmentId { get; set; }
        public int RentalId { get; set; }
        public int Days { get; set; }

        /* Navigational properties */
        public virtual Equipment Equipment { get; set; }
        public virtual Rental Rental { get; set; }
    }
}