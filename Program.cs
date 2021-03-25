using System;
using AutoTicket.Logic;

namespace AutoTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            int counter = 0;
            IParkingLot _parkingLot = new ParkingLot();
            

            System.IO.StreamReader file = new System.IO.StreamReader(@"input.txt");  
            while((line = file.ReadLine()) != null)  
            {  
                var inputArr = line.Split(" ");  

                
                switch (inputArr[0])
                {
                    case "Create_parking_lot":
                        _parkingLot.InitializeParkingLot(Convert.ToInt32(inputArr[1]));
                        break;
                    case "Park":
                        _parkingLot.AllocateParkingSlot(inputArr[1],Convert.ToUInt16(inputArr[3]));
                        break;
                    case "Slot_number_for_car_with_number":
                        _parkingLot.GetSlotNumberByVehiclenumber(inputArr[1]);
                        break;
                    case "Slot_numbers_for_driver_of_age":
                        _parkingLot.GetSlotNumbersByDriverAge(Convert.ToUInt16(inputArr[1]));
                        break;
                    case "Vehicle_registration_number_for_driver_of_age":
                        _parkingLot.GetVehicleNumbersByDriverAge(Convert.ToUInt16(inputArr[1]));
                        break;
                    case "Leave":
                        _parkingLot.FreeParkingSlot(Convert.ToUInt16(inputArr[1])); 
                        break;
                    default:
                        System.Console.WriteLine("Invalid Command, Check input once");
                        break;
                }

                counter++;  
            }  
            file.Close();  
        }
    }
}
