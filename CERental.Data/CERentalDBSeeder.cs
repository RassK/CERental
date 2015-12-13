using CERental.Core.Domain;
using CERental.Core.Enums;
using System.Linq;

namespace CERental.Data
{
    public class CERentalDBSeeder
    {
        private CERentalDbContext _context;

        public void Seed(CERentalDbContext context)
        {
            _context = context;

            // Make sure its empty
            if (!context.Equipments.Any())
            {
                InsertEquipment("Caterpillar bulldozer", EquipmentType.Heavy);
                InsertEquipment("KamAZ truck", EquipmentType.Regular);
                InsertEquipment("Komatsu crane", EquipmentType.Heavy);
                InsertEquipment("Volvo steamroller", EquipmentType.Regular);
                InsertEquipment("Bosch jackhammer", EquipmentType.Specialized);
            }
        }

        private void InsertEquipment(string name, EquipmentType type)
        {
            _context.Equipments.Add(new Equipment()
            {
                Name = name,
                Type = type
            });
        }
    }
}