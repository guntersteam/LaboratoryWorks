using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using LaboratoryWork1.Models;

namespace LaboratoryWork1
{
    internal class Program
    {
        static void Main()
        {
            
            new Dormitory().Start();

        }
    }
    struct Dormitory
    {
        private int[] _floors = new int[2];
        public Dormitory(int floorsCount)
        {

        }
        public List<int> GetRoomOfFloor(int floorNumber)
        {
            List<int> Rooms = new List<int>();
            for (int i = 0; i <= _floors.Length; i++)
            {
                Rooms.Add(i + 1 + floorNumber * 100);
            }
            return Rooms;
        }
        public void GetAllInfo()
        {
            for (int i = 0; i < _floors.Length; i++)
            {
                List<int> roomsOnFloor = GetRoomOfFloor(i + 1);
                Console.WriteLine($"Этаж номер: {i + 1} комнаты: {string.Join(", ", roomsOnFloor)}");
            }
        }
        public void AddStudent(string personName, Room[] rooms, int floor)
        {
            foreach (Room room in rooms)
            {
                if (room.Floor == floor && room.StudentsInRoom.Count < 5)
                {
                    int newKey = room.StudentsInRoom.Keys.Max() + 1;
                    room.StudentsInRoom.Add(newKey, personName);
                    Console.WriteLine($"Студент {personName} был добавлен в комнату номер {room.Number}");
                    break;
                }
            }

        }
        public void RemoveStudent(string personName, Room[] rooms, int numberOfRoom)
        {
            foreach (Room room in rooms)
            {
                if (numberOfRoom == room.Number && room.StudentsInRoom.ContainsValue(personName))
                {
                    var key = room.StudentsInRoom.FirstOrDefault(x => x.Value == personName).Key;
                    room.StudentsInRoom.Remove(key);
                    Console.WriteLine($"{personName} був видалений із кімнати {numberOfRoom}");
                    break;
                }
                else 
                {
                    if (room.Number == numberOfRoom)
                        Console.WriteLine($"Студент {personName} не знайден в кімнаті {room.Number}");
                }
            }
            
        }

        public void FindAStudent(Room[] rooms, string desiredsurname)
        {
            bool Wasfound = false;
            Color newColor = new Color();
            foreach (Room room in rooms)
            {
                foreach (KeyValuePair<int, string> student in room.StudentsInRoom)
                {
                    if (student.Value.ToLower().Equals(desiredsurname.ToLower()))
                    {
                        newColor.Green();
                        Wasfound = true;
                        Console.WriteLine("Студент з призвіщем" + desiredsurname + " був/ла знайдена в кімнаті " + room.Number);
                    }
                }
            }
            if (!Wasfound)
            {
                newColor.Red();
                Console.WriteLine("Студент з призвищем " + desiredsurname + " не був/ла знайдена ні в якій з кімнат.");
            }
        }
        public Room[] GetFreeRooms(Room[] rooms)
        {

            Room newRoom = new Room();
            var sortedRoom = newRoom.SortedArray(rooms);
            foreach (Room room in sortedRoom)
            {
                if (room.StudentsInRoom.Count >= 5)
                {
                    continue;
                }
                Console.WriteLine($"Поверх номер - {room.Floor}, кімната номер - {room.Number}, кількість вільних місць - {5 - room.StudentsInRoom.Count}");
            }
            return sortedRoom;
        }
        

        public void Start()
        {
            Color newColor = new Color();
            Dormitory newDormitory = new Dormitory(2);
            Room[] RoomsInDormitory =
            {
                        new Room(1,101, new Dictionary<int, string>()
                    {
                        {1, "Гавриленко" },
                        {2, "Цимбал" },
                        {3, "Шуть" },
                        {4, "Иванов"},
                        {5,"Иванов"}

                    }),
                        new Room(1,102, new Dictionary<int, string>()
                    {
                        {1, "Шпак" },
                        {2, "Проценко"}

                    }),
                            new Room(1,103, new Dictionary<int, string>()
                    {
                        {1, "Прудкий" },
                        {2, "Голозубов" },
                        {3, "Давидов" },


                    }),
                        new Room(2,201, new Dictionary<int, string>()
                    {
                        {1, "Липка" },
                        {2, "Бут" },
                        {3, "Білозуб" },


                    }),
                        new Room(2,202, new Dictionary<int, string>()
                    {
                        {1, "Кузенко" },
                        {2, "Байкулова" },
                        {3, "Зезюлін"},

                    }),
                    new Room(2,203, new Dictionary<int, string>()
                    {
                        {1, "Ткаченко" },
                        {2, "Мкртичьян" },
                        {3, "Таранова" }
                    })
                };
            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                newColor.Blue();
                newDormitory.GetAllInfo();
                Console.WriteLine("Гуртожиток:");
                Console.WriteLine("Выберіть функцію яку бажаєте вибрати :\n========================================\n" +
                        "1 - Додати нового мешканця.\n2 - Видалити мешканця\n3 - Знайти в якій кімнаті перебуває студент за прізвищем.\n4 - Вивести список вільних кімнат");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int id))
                {
                    switch (id)
                    {
                        case 1:
                            newColor.Yellow();
                            Console.WriteLine("Введіть Прізвище студента який хоче поселитися");
                            string personName = Console.ReadLine();
                            Console.WriteLine($"На який поверх ви хочете додати {personName}?");
                            int desiredfloor = Convert.ToInt32(Console.ReadLine());
                            AddStudent(personName, RoomsInDormitory, desiredfloor);
                            break;
                        case 2:
                            newColor.Yellow();
                            Console.WriteLine("Введіть прізвище студента якого хочете видалити");
                            string input3 = Console.ReadLine();
                            Console.WriteLine($"Введите номер комнаты в которой проживает студент {input3}");
                            int numberofRoom = Convert.ToInt32(Console.ReadLine());
                            RemoveStudent(input3, RoomsInDormitory, numberofRoom);
                            break;
                        case 3:
                            newColor.Yellow();
                            Console.WriteLine("Введіть прізвище студента якого ви хочете знайти");
                            string input2 = Console.ReadLine();
                            FindAStudent(RoomsInDormitory, input2);
                            break;
                        case 4:
                            GetFreeRooms(RoomsInDormitory);
                            break;
                        default:
                            newColor.Red();
                            Console.WriteLine("Неправильно введено значення. Спробуйте знову.");
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }

                else
                {
                    newColor.Red();
                    Console.WriteLine("Неправильно введено значення. Спробуйте знову.");
                }
            }
        }
    }

}


