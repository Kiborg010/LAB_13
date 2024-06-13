using ClassLibrary1;
using LAB_12_2;
using LAB_13;
public class Program
{
    static void Main(string[] args)
    {
        MyObservableCollection<Car> collectionOne = new MyObservableCollection<Car>(2, "Первая коллекция");
        MyObservableCollection<Car> collectionTwo = new MyObservableCollection<Car>(2, "Вторая коллекция");
        Journal journalOne = new Journal();
        collectionOne.CollectionCountChanged += journalOne.WriteRecord;
        collectionOne.CollectionReferenceChanged += journalOne.WriteRecord;
        Journal journalTwo = new Journal();
        collectionOne.CollectionReferenceChanged += journalTwo.WriteRecord;
        collectionTwo.CollectionReferenceChanged += journalTwo.WriteRecord;

        static int CorrectInputInt(int left, int right, string message) //Стандартная функция для ввода числа в нужном диапазоне
        {
            Console.WriteLine($"Введите {message}: ");
            Console.Write($"Введите целое число от {left} до {right}: ");
            string input = Console.ReadLine();
            int number;
            bool numberIsCorrect = int.TryParse(input, out number);
            while (!numberIsCorrect || !((left <= number) && (number <= right)))
            {
                Console.WriteLine($"Ошибка. Вам необходимо ввести целое число от {left} до {right}");
                Console.Write($"Введите целое число от {left} до {right}: ");
                input = Console.ReadLine();
                numberIsCorrect = int.TryParse(input, out number);
            }
            return number;
        }

        static void WriteCommandsBegin() //Вывод вариантов базового меню
        {
            Console.WriteLine("1. Распечатать первую коллекцию");
            Console.WriteLine("2. Распечатать вторую коллекцию");
            Console.WriteLine("3. Добавить элемент первую коллекцию");
            Console.WriteLine("4. Добавить элемент вторую коллекцию");
            Console.WriteLine("5. Удалить элемент из первой коллекции");
            Console.WriteLine("6. Удалить элемент из второй коллекции");
            Console.WriteLine("7. Поменять элемент в первой коллекции");
            Console.WriteLine("8. Поменять элемент во второй коллекции");
            Console.WriteLine("9. Распечатать первый Journal");
            Console.WriteLine("10. Распечатать второй Journal");
            Console.WriteLine("11. Завершить работу");
        }

        static void TrashAnswer() //Ненужный вопрос, для того, чтобы просто подождать, пока пользователь будет готов вернуться в меню
        {
            Console.WriteLine();
            Console.Write("Введите что-нибудь, чтобы вернуться в меню: ");
            string trashAnswer = Console.ReadLine();
        }

        static void WriteTypesCars() //Для поиска необходимо понимать, какой именно тип машины нужно искать. Поэтому выводим варианты для выбора пользователя
        {
            Console.WriteLine("1. Базовая машина");
            Console.WriteLine("2. Легковая машина");
            Console.WriteLine("3. Внедорожник");
            Console.WriteLine("4. Грузовая машина");
        }

        static Car TakeCarInformation(MyHashTable<Car> table) //Метод для заполнения информации о машине для поиска и удаления
        {
            int typeCar;

            WriteTypesCars(); //Выводим типы машин, чтобы понять, что именно искать
            typeCar = CorrectInputInt(1, 4, "тип машины"); //Получаем номер типа машины
            Console.Write("Введите бренд: "); //Собираем базовую информацию о машине
            string brend = Console.ReadLine();
            int year = CorrectInputInt(1950, 2024, "год");
            Console.Write("Введите цвет: ");
            string colour = Console.ReadLine();
            int cost = CorrectInputInt(0, 34000000, "цену");
            int clearance = CorrectInputInt(1, 200, "дорожный просвет");
            int id = CorrectInputInt(1, 1000000, "id");

            Car car = new Car(); //Инициализируем машину для поиска
            if (typeCar == 1) //В зависимости от типа машины спрашиваем дополнительную информацию и полностью заполняем машину для поиска
            {
                car = new Car(brend, year, colour, cost, clearance, id);
            }
            if (typeCar == 2)
            {
                int maxSpeed = CorrectInputInt(0, 1228, "максимальную скорость");
                int countSeats = CorrectInputInt(1, 10, "количество сидений");
                car = new PassengerCar(brend, year, colour, cost, clearance, id, countSeats, maxSpeed);
            }
            if (typeCar == 3)
            {
                int maxSpeed = CorrectInputInt(0, 1228, "максимальную скорость");
                int countSeats = CorrectInputInt(1, 10, "количество сидений");
                int awd = CorrectInputInt(0, 1, "наличие полного привода(0 - нет, 1 - есть)");
                Console.WriteLine("Введите тип бездорожья: ");
                string typeRoad = Console.ReadLine();
                bool awdBool;
                if (awd == 0)
                {
                    awdBool = false;
                }
                else
                {
                    awdBool = true;
                }
                car = new OffRoadCar(brend, year, colour, cost, clearance, id, countSeats, maxSpeed, awdBool, typeRoad);
            }
            if (typeCar == 4)
            {
                int tonnage = CorrectInputInt(0, 450, "грузоподъёмность");
                car = new LorryCar(brend, year, colour, cost, clearance, id, tonnage);
            }
            return car;
        }

        static void Adding(MyObservableCollection<Car> collection)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Исходная таблица: ");
            Console.ResetColor();
            collection.Print();
            Console.WriteLine();

            Car addingCar = TakeCarInformation(collection);
            collection.Add(addingCar);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Изменённая таблица: ");
            Console.ResetColor();
            collection.Print();
            Console.WriteLine();

            TrashAnswer();
        }

        static void Removing(MyObservableCollection<Car> collection)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Исходная таблица: ");
            Console.ResetColor();
            collection.Print();
            Console.WriteLine();
            Car carToSearch = TakeCarInformation(collection);
            int index = collection.FindItem(carToSearch);
            if (index == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nЭлемент не найден");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nЭлемент найден в позиции: {index}");
                Console.WriteLine("Элемент удалён");
                collection.Remove(carToSearch); //По значению  удаляем машину
                Console.WriteLine("\nИзменённая таблица: \n");
                Console.ResetColor();
                collection.Print();
            }
            TrashAnswer();
        }

        static void Replacing(MyObservableCollection<Car> collection)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Исходная таблица: ");
            Console.ResetColor();
            collection.Print();
            Console.WriteLine();
            Console.WriteLine("Введите элемент для замены");
            Car carToSearch = TakeCarInformation(collection);
            int index = collection.FindItem(carToSearch);
            if (index == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nЭлемент не найден");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nЭлемент найден в позиции: {index}");
                Console.ResetColor();
                Console.WriteLine("Введите заменяющий элемент");
                Car carToAdd = TakeCarInformation(collection);
                if (collection.tableValue.Contains(carToAdd)) //Нельзя добавлять элемент точно с такими же параметрами
                {
                    throw new Exception($"Такой элемент уже есть: \n{carToAdd.ToString()} \nОн добавлен не будет");
                }
                collection[carToSearch] = carToAdd;
                Console.WriteLine("\nИзменённая таблица: \n");
                collection.Print();
            }
            TrashAnswer();
        }

        int numberAnswerOne = -1;
        while (numberAnswerOne != 11)
        {
            Console.Clear();
            WriteCommandsBegin();
            numberAnswerOne = CorrectInputInt(1, 11, "номер выбранной команды");
            switch (numberAnswerOne)
            {
                case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("Первая коллекция: ");
                        collectionOne.Print();
                        TrashAnswer();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("Вторая коллекция: ");
                        collectionTwo.Print();
                        TrashAnswer();
                        break;
                    }
                case 3:
                    {
                        try
                        {
                            Adding(collectionOne);
                            journalOne.PrintJournal();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                            TrashAnswer();
                        }
                        break;
                    }
                case 4:
                    {
                        try
                        {
                            Adding(collectionTwo);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                            TrashAnswer();
                        }
                        break;
                    }
                case 5:
                    {
                        Removing(collectionOne);
                        break;
                    }
                case 6:
                    {
                        Removing(collectionTwo);
                        break;
                    }
                case 7:
                    {
                        try
                        {
                            Replacing(collectionTwo);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                            TrashAnswer();
                        }
                        break;
                    }
                case 8:
                    {
                        try
                        {
                            Replacing(collectionTwo);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                            TrashAnswer();
                        }
                        break;
                    }
                case 9: 
                    {
                        Console.Clear();
                        journalOne.PrintJournal();
                        TrashAnswer();
                        break;
                    }
                case 10:
                    {
                        Console.Clear();
                        journalTwo.PrintJournal();
                        TrashAnswer();
                        break;
                    }
                case 11:
                    {
                        Console.Clear();
                        Console.WriteLine("Завершение работы");
                        break;
                    }
            }
        }
    }
}