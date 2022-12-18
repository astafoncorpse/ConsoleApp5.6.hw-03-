using System;

namespace ConsoleApp5._6
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = GetData();
            DisplayData(data);
        }

        static (string Name, string lastName, int age, string[] pets, string[] colors) GetData()
        {
            (string Name, string lastName, int age, string[] pets, string[] colors) User;
            Console.WriteLine("Ввидите Имя: ");
            User.Name = Console.ReadLine();

            Console.WriteLine("Ввидите фамилию: ");
            User.lastName = Console.ReadLine();

            string age;
            int intage;
            do
            {
                Console.WriteLine("Ввидите Ваш возраст цифрами: ");
                age = Console.ReadLine();
            }
            while (CheckNum(age, out intage));

            User.age = intage;


            Console.WriteLine("У Вас есть домашнние животные да или нет?: ");
            var haspets = Console.ReadLine();
            string[] pets = new string[0];
            if (haspets == "Да" || haspets == "да")
            {
                string num;
                do
                {
                    Console.WriteLine("Укажите количество животных: ");
                    num = Console.ReadLine();
                }
                while (Validate(num));
                pets = CreateArrayPets(int.Parse(num));
            }

            string NumColor;
            string[] colors;
            do
            {
                Console.WriteLine("Укажите количнство любимых цветов: ");
                NumColor = Console.ReadLine();
            }
            while (Validate(NumColor));
            colors = CreateArrayColors(int.Parse(NumColor));

            var result = (User.Name, User.lastName, User.age, pets, colors);
            return result;

        }

        static bool CheckNum(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intnum))
            {
                corrnumber = intnum;
                return false;
            }
            {
                corrnumber = 0;
                return true;
            }
        }
        static string[] CreateArrayPets(int count)
        {
            var namepets = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите имя питомца {0}:", i + 1);
                namepets[i] = Console.ReadLine();
            }

            return namepets;
        }

        // Метод заполнения цветов
        static string[] CreateArrayColors(int count)
        {
            var colors = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите цвет {0}:", i + 1);
                colors[i] = Console.ReadLine();
            }

            return colors;
        }

        static bool Validate(string n )
        {
            int result;
            if (int.TryParse(n, out result) && result > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static void DisplayData((string Name, string lastName, int age, string[] pets, string[] colors) User)
        {
            Console.WriteLine("Результат: ");
            Console.WriteLine("Имя \n {0}", User.Name);
            Console.WriteLine("Фамилия \n {0}", User.lastName);
            Console.WriteLine("Возраст \n {0} ", User.age);
            Console.WriteLine("Животные \n {0} ", User.pets);
            Console.WriteLine("Цвета \n {0} ", User.colors);

            if (User.pets != null && User.pets.Length > 0)
            {
                Console.WriteLine("Домашные животные:");
                for (int i = 0; i < User.pets.Length; i++)
                {
                    Console.WriteLine(User.pets[i]);
                }
            }

            if (User.colors != null && User.colors.Length > 0)
            {
                Console.WriteLine("Цвета:");
                for (int i = 0; i < User.colors.Length; i++)
                {
                    Console.WriteLine(User.colors[i]);
                }
            }
        }
    }
}