using CERental.Core.Contract.Repository;
using CERental.Core.Contract.Services;
using CERental.Core.Domain;
using CERental.Core.Enums;
using CERental.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CERental.ApplicationServices.Services
{
    public class RentalService : IRentalService
    {
        public IEquipmentRepository EquipmentRepository { get; set; }
        public IRentalRepository RentalRepository { get; set; }

        private const int ONE_TIME_FEE = 100;
        private const int PREMIUM_DAILY = 60;
        private const int REGULAR_DAILY = 40;

        public RentalResult RentEquipment(string userId, IEnumerable<EquipmentRental> rentals)
        {
            var rental = new Rental()
            {
                UserId = userId,
                Registered = DateTime.UtcNow,
                EquipmentsInRent = new List<EquipmentInRent>()
            };

            var equipmentIds = rentals.Select(x => x.EquipmentId);
            var equipments = EquipmentRepository.All.Where(x => equipmentIds.Contains(x.Id)).ToList();

            // Result list
            var rentalEquipmentDetails = new List<EquipmentRentalDetailed>();
            
            foreach (var item in equipments)
            {
                var days = rentals.First(x => x.EquipmentId == item.Id).Days;
                rental.EquipmentsInRent.Add(new EquipmentInRent()
                {
                    EquipmentId = item.Id,
                    Days = days
                });

                // fill details as well
                rentalEquipmentDetails.Add(new EquipmentRentalDetailed()
                {
                    Days = days,
                    Name = item.Name,
                    Price = CalculatePrice(item, days),
                    Type = item.Type.ToString()
                });
            }

            rental.TotalPrice = rentalEquipmentDetails.Sum(x => x.Price);

            int points = CalculateLoyaltyPoints(equipments);

            RentalRepository.Add(rental);
            RentalRepository.Save();

            return new RentalResult()
            {
                PointsEarned = points,
                TotalPrice = rental.TotalPrice,
                Equipment = rentalEquipmentDetails
            };
        }

        private decimal CalculatePrice(Equipment item, int days)
        {
            switch (item.Type)
            {
                case EquipmentType.Heavy:
                    return ONE_TIME_FEE + (PREMIUM_DAILY * days);
                case EquipmentType.Regular:
                    return days > 2 ?
                        ONE_TIME_FEE + (PREMIUM_DAILY * 2) + (REGULAR_DAILY * (days - 2)) :
                        ONE_TIME_FEE + (PREMIUM_DAILY * days);
                case EquipmentType.Specialized:
                    return days > 3 ?
                        (PREMIUM_DAILY * 3) + (REGULAR_DAILY * (days - 3)) :
                        (PREMIUM_DAILY * days);
                default:
                    throw new Exception($"Unknow equipment type: {item.Type}");
            }
        }

        private int CalculateLoyaltyPoints(List<Equipment> equipments)
        {
            int points = 0;

            foreach (var item in equipments)
            {
                switch (item.Type)
                {
                    case EquipmentType.Heavy:
                        points += 2;
                        break;
                    case EquipmentType.Regular:
                    case EquipmentType.Specialized:
                        points += 1;
                        break;
                    default:
                        throw new Exception($"Unknow equipment type: {item.Type}");
                }
            }

            return points;
        }
    }
}