using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_32_M1Practice.HotelBookingSystem
{
    public class HotelMain
    {
        public static void Main(string[] args)
        {
            HotelManager hotel = new HotelManager();
            hotel.AddRoom(101, "Single", 2000);
            hotel.AddRoom(102, "Double", 3000);
            hotel.AddRoom(103, "Suite", 5000);
            hotel.AddRoom(104, "Double", 3000);
            hotel.AddRoom(105, "Single", 2000);

            Console.WriteLine("\nAvailable Rooms Grouped by Type: ");
            var groupedRooms = hotel.GroupRoomsByType();
            foreach(var type in groupedRooms)
            {
                Console.WriteLine($"\n Room Type: {type.Key}");
                foreach(var room in type.Value)
                {
                    Console.WriteLine($" Room {room.RoomNumber} - ${room.PricePerNight}");
                }
            }
            Console.WriteLine("\nBooking Room 102 for 3 nights: ");
            hotel.BookRoom(102, 3);
            Console.WriteLine("\nAvailable Rooms Between $2000 and $3000: ");
            var budgetRooms = hotel.GetAvailableRoomsByPriceRange(2000, 3000);
            foreach(var room in budgetRooms)
            {
                Console.WriteLine($" Room {room.RoomNumber} - {room.RoomType} - ${room.PricePerNight}");
            }
        }
    }
}
