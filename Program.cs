namespace Final_project
{
    internal class Program
    {
        static void Main(string[] args) //Вся логика программы через Main
        {
            var info = Info(); // Получаем информацию от пользователя
            var colors = Color();  // Получаем список любимых цветов
            DisplayInfo(info, colors);  // Отображаем полученную информацию
            Console.ReadKey();
        }
        static (string Name, string Surname, int Age, bool Pet, string[] PetNames) Info() //Важно: клички - это массив
        {
            Console.WriteLine("Напишите Ваше имя: ");
            string Name = Console.ReadLine();

            Console.WriteLine("Напишите Вашу фамилию: ");
            string Surname = Console.ReadLine();
           
            Console.WriteLine("Напишите Ваш возраст: ");
            var Age = ReadPositiveInt();
            /*string ageString = Console.ReadLine();
            int Age;

            if (int.TryParse(ageString, out Age) && Age >= 0)
            { Console.WriteLine("Продолжим"); }
            else
            {
                Console.WriteLine("Введите данные еще раз");
                return Info(); // Рекурсия
            }
            */
            //Перенесла проверку в отдельный метод.

            Console.WriteLine("Есть ли у Вас питомец (да = 1/нет = 0): "); //Консоль почему-то не поддерживает русскоязычный ввод, поэтому заменила на 1 и 0
            string petResponse = Console.ReadLine();

            if (petResponse == "1")
            {
                Console.WriteLine("Сколько у Вас животных: ");
                int petAmount;
                string petAmountString = Console.ReadLine();

                if (int.TryParse(petAmountString, out petAmount) && petAmount > 0)
                {
                    string[] petNames = PetNames(petAmount);
                    return (Name, Surname, Age, true, petNames);
                }
                else
                {
                    Console.WriteLine("Введите положительное количество питомцев");
                    return Info();
                }
            }
            else if (petResponse == "0")
            {
                Console.WriteLine("Продолжаем");
                return (Name, Surname, Age, false, new string[0]);
            }
            else
            {
                Console.WriteLine("Введите данные еще раз");
                return Info();
            }

        }

        static int ReadPositiveInt()
        {
            int result;
            string input;
            do
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out result) && result >= 0)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Введите положительное число.");
                }
            } while (true);
        }

        static string[] PetNames(int petAmount)
        {

            string[] PetNames = new string[petAmount];
            for (int i = 0; i < petAmount; i++)
            {
                Console.WriteLine("Введите кличку " + (i + 1) + "-го питомца: ");
                PetNames[i] = Console.ReadLine();

            }
            return PetNames;
        }

        static string[] Color()
        {
            Console.WriteLine("Введите количество любимых цветов:");
            string ColorString = Console.ReadLine();
            int colorCount;

            if (int.TryParse(ColorString, out colorCount) && colorCount > 0)
            {
                var colors = new string[colorCount];
                for (int i = 0; i < colorCount; i++)
                {
                    Console.WriteLine("Введите любимый цвет " + (i + 1) + ":");
                    colors[i] = Console.ReadLine();
                }
                return colors;
            }
            else
            {
                Console.WriteLine("Введите положительное количество цветов.");
                return Color();
            }
        }



        static void DisplayInfo((string Name, string Surname, int Age, bool Pet, string[] PetNames) info, string[] colors)
        {
            Console.WriteLine("Имя: " + info.Name);
            Console.WriteLine("Фамилия: " + info.Surname);
            Console.WriteLine("Возраст: " + info.Age);
            Console.WriteLine("Наличие питомца: " + (info.Pet ? "да" : "нет"));
            if (info.Pet)
            {
                Console.WriteLine("Клички питомцев:");
                foreach (string petName in info.PetNames)
                {
                    Console.WriteLine(petName);

                }
            }
            Console.WriteLine("Любимые цвета:");
            foreach (var color in colors)
            {
                Console.WriteLine(color);

            }



        }
    }
}
