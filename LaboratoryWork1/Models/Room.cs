using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork1.Models
{
    struct Room
    {
        public int Floor;
        const int MAXSTUDENTSINROOM = 5;
        public int Number { get; set; }
        public Dictionary<int, string> StudentsInRoom = new Dictionary<int, string>(MAXSTUDENTSINROOM);
        public Room(int floor, int number, Dictionary<int, string> studentsInRoom)
        {
            Floor = floor;
            Number = number;
            StudentsInRoom = studentsInRoom;
        }
        public  void ShowRoomsByFloor(Room[] rooms, int floor)
        {
            Console.WriteLine($"Rooms on floor {floor}:");
            foreach (Room room in rooms)
            {
                if (room.Floor == floor)
                {
                    Console.WriteLine($"Room {room.Number}:");
                    foreach (KeyValuePair<int, string> student in room.StudentsInRoom)
                    {
                        Console.WriteLine($"    Student {student.Key}: {student.Value}");
                    }
                }
            }
        }
        public Room[] SortedArray(Room[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j].StudentsInRoom.Count < arr[j + 1].StudentsInRoom.Count)
                    {
                        (arr[j], arr[i]) = (arr[i], arr[j]);
                    }
                }
            }
            return arr;
        }

    }


}
