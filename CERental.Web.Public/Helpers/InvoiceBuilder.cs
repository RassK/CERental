using CERental.Core.Dto;
using CERental.Core.Models;
using System.Text;

namespace CERental.Web.Public.Helpers
{
    public static class InvoiceBuilder
    {
        public static string Build(ApplicationUserDto user, RentalResult rental)
        {
            var inBuilder = new StringBuilder();

            inBuilder.AppendLine($"Invoice for: {user.Email}");
            inBuilder.AppendLine("================================================");

            inBuilder.AppendLine("Name - Type - Days - Price");
            foreach (var item in rental.Equipment)
            {
                inBuilder.AppendLine($"{item.Name} | {item.Type} | {item.Days} | {item.Price:F2} €");
            }

            inBuilder.AppendLine("================================================");
            inBuilder.AppendLine($"Total: {rental.TotalPrice:F2}");
            inBuilder.AppendLine($"Points earned: {rental.PointsEarned}");

            return inBuilder.ToString();
        }
    }
}