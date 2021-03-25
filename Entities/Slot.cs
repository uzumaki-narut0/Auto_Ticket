using System;

namespace AutoTicket.Entities
{
    public class Slot
    {
        public uint SlotNumber { get; set; }
        public bool IsAvailable { get; set; }
        public BookingInfo BookingInfo { get; set; }
    }
}