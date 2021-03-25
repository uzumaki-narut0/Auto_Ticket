using System;
using System.Collections.Generic;
using System.Linq;
using AutoTicket.Entities;

namespace AutoTicket.Logic
{
    public class ParkingLot : IParkingLot
    {
        
        private int _parkingLotSize;
        private IList<Slot> _slots;
        public void InitializeParkingLot(int lotSize)
        {
            _parkingLotSize = lotSize;
            _slots = new List<Slot>();  
            // make all slots available
            for(uint i = 1 ; i <= lotSize ; i++)
            {
                _slots.Add(new Slot{
                    SlotNumber = i,
                    IsAvailable = true,
                    BookingInfo = new BookingInfo{

                    }
                });
            }
            System.Console.WriteLine(string.Format("Created parking of {0} slots", lotSize)); 
        }

        public void AllocateParkingSlot(string vehicleNumber, ushort age)
        {
            var nearestAvailableSlot = FindNearestAvailableSlot();
            if(nearestAvailableSlot != null)
            {
                nearestAvailableSlot.IsAvailable = false;
                nearestAvailableSlot.BookingInfo = new BookingInfo{
                    VehicleNumber = vehicleNumber,
                    DriverAge = age
                };

                System.Console.WriteLine(
                    string.Format(
                        "Car with vehicle registration number \"{0}\" has been parked at slot number {1}", 
                        vehicleNumber, 
                        nearestAvailableSlot.SlotNumber
                    )
                );
            }
            else
            {
                System.Console.WriteLine("Slots full, Unable to book");
            }
        }

        public void FreeParkingSlot(ushort slotNumber)
        {
            var slot = _slots.FirstOrDefault(slot => slot.SlotNumber == slotNumber);
            
            System.Console.WriteLine(
                string.Format(
                    "Slot number {0} vacated, the car with vehicle registration number \"{1}\" left the space, the driver of the car was of age {2}", 
                    slotNumber, 
                    slot.BookingInfo.VehicleNumber,
                    slot.BookingInfo.DriverAge
                )
            );
            
            // Reset Slot Info
            slot.IsAvailable = true;
            slot.BookingInfo = new BookingInfo{};
        }

        public void GetSlotNumbersByDriverAge(ushort age)
        {
           var slots = _slots.Where(slot => slot.BookingInfo.DriverAge == age);
           System.Console.WriteLine(string.Join(",", slots.Select(slot => slot.SlotNumber)));
        }

        public void GetVehicleNumbersByDriverAge(ushort age)
        {
            var slots = _slots.Where(slot => slot.BookingInfo.DriverAge == age);
            System.Console.WriteLine(string.Join(",", slots.Select(slot => slot.BookingInfo.VehicleNumber)));
        }

        public void GetSlotNumberByVehiclenumber(string vehicleNumber)
        {
            var slotNumber = _slots.FirstOrDefault(slot => slot.BookingInfo.VehicleNumber == vehicleNumber).SlotNumber;
            System.Console.WriteLine(slotNumber);
        }

        private Slot FindNearestAvailableSlot()
        {
            return _slots.FirstOrDefault(slot => slot.IsAvailable == true);
        }

    }
}