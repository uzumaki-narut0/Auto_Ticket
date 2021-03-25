namespace AutoTicket.Logic
{
    interface IParkingLot 
    {
        void InitializeParkingLot(int lotSize);
        void AllocateParkingSlot(string vehicleNumber, ushort age);
        void FreeParkingSlot(ushort slotNumber);
        void GetSlotNumbersByDriverAge(ushort age);
        void GetVehicleNumbersByDriverAge(ushort age);
        void GetSlotNumberByVehiclenumber(string vehicleNumber);
    }
} 