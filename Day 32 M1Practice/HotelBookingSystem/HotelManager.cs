using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CAP2025.Day_32_M1Practice.HotelBookingSystem
{
    public class HotelManager
    {
        private List<Room> rooms = new List<Room>();
        public void AddRoom(int roomNumber, string type, double price)
        {
            foreach (Room r in rooms)
            {
                if (r.RoomNumber == roomNumber)
                {
                    Console.WriteLine("Room is already exists on the List.");
                    return;
                }
            }
            Room room = new Room
            {
                RoomNumber = roomNumber,
                RoomType = type,
                PricePerNight = price,
                IsAvailable = true
            };
            rooms.Add(room);
        }
        public Dictionary<string, List<Room>> GroupRoomsByType()
        {
            Dictionary<string, List<Room>> groupedRooms = new Dictionary<string, List<Room>>();
            foreach (var room in rooms)
            {
                if (!room.IsAvailable)
                {
                    continue;
                }
                if (!groupedRooms.ContainsKey(room.RoomType))
                {
                    groupedRooms[room.RoomType] = new List<Room>();
                }
                groupedRooms[room.RoomType].Add(room);
            }
            return groupedRooms;
        }
        public bool BookRoom(int roomNumber, int nights)
        {
            foreach (var room in rooms)
            {
                if (room.RoomNumber == roomNumber && room.IsAvailable)
                {
                    double totalCost = room.PricePerNight * nights;
                    room.IsAvailable = false;
                    Console.WriteLine($" Room {roomNumber} Booked Succesfully!..");
                    Console.WriteLine($" Total Cost is: ${totalCost}");
                    return true;
                }
            }
            Console.WriteLine("Room not available or does not exist...");
            return false;
        }
        public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
        {
            List<Room> result = new List<Room>();
            foreach (var room in rooms)
            {
                if (room.IsAvailable && room.PricePerNight >= min && room.PricePerNight <= max)
                {
                    result.Add(room);
                }
            }
            return result;
        }
    }
}
