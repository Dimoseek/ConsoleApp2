using System;
using System.Collections.Generic;
using System.Linq;

class ZmeyGorynych
{
    private string nickname;
    private int heads;
    private List<int> iqList;
    private static int totalZmeyGorynych;
    private int age;
    private int weight;
    private int maxFlameTemperature;


    public ZmeyGorynych()
    {
        nickname = "Горыныч";
        heads = 3;
        iqList = new List<int>();
        for (int i = 0; i < heads; i++)
        {
            iqList.Add(100);
        }
        totalZmeyGorynych++;
    }

    public ZmeyGorynych(string nickname, int heads, List<int> iqList)
    {
        this.nickname = nickname;
        this.heads = heads;
        this.iqList = iqList;
        totalZmeyGorynych++;
    }

    public ZmeyGorynych(string nickname, int heads, int age, int weight, int maxFlameTemperature)
    {
        this.nickname = nickname;
        this.heads = heads;
        this.iqList = new List<int>();
        for (int i = 0; i < heads; i++)
        {
            iqList.Add(100);
        }
        this.age = age;
        this.weight = weight;
        this.maxFlameTemperature = maxFlameTemperature;
        totalZmeyGorynych++;
    }

    public ZmeyGorynych(ZmeyGorynych other)
    {
        this.nickname = other.nickname;
        this.heads = other.heads;
        this.iqList = new List<int>(other.iqList);
        this.age = other.age;
        this.weight = other.weight;
        this.maxFlameTemperature = other.maxFlameTemperature;
        totalZmeyGorynych++;
    }

    public void Display()
    {
        Console.WriteLine("Прозвище: {0}", nickname);
        Console.WriteLine("Количество голов: {0}", heads);
        Console.WriteLine("IQ каждой головы: {0}", string.Join(", ", iqList));
        Console.WriteLine("Возраст: {0}", age);
        Console.WriteLine("Вес: {0}", weight);
        Console.WriteLine("Максимальная температура пламени: {0}", maxFlameTemperature);
    }
    public void SetValues()
    {
        Console.Write("Введите прозвище: ");
        nickname = Console.ReadLine();
        Console.Write("Введите количество голов: ");
        while (!int.TryParse(Console.ReadLine(), out heads) || heads <= 0)
        {
            Console.Write("Некорректный ввод. Введите целое положительное число: ");
        }
        iqList = new List<int>();
        for (int i = 1; i <= heads; i++)
        {
            Console.Write("Введите IQ головы {0}: ", i);
            int iq;
            while (!int.TryParse(Console.ReadLine(), out iq) || iq < 0)
            {
                Console.Write("Некорректный ввод. Введите неотрицательное число: ");
            }
            iqList.Add(iq);
        }
        Console.Write("Введите возраст: ");
        while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
        {
            Console.Write("Некорректный ввод. Введите неотрицательное число: ");
        }
        Console.Write("Введите вес: ");
        while (!int.TryParse(Console.ReadLine(), out weight) || weight < 0)
        {
            Console.Write("Некорректный ввод. Введите неотрицательное число: ");
        }
        Console.Write("Введите максимальную температуру пламени: ");
        while (!int.TryParse(Console.ReadLine(), out maxFlameTemperature) || maxFlameTemperature < 0)
        {
            Console.Write("Некорректный ввод. Введите неотрицательное число: ");
        }
    }
    class Gorunych
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int IQ { get; set; }

        public Gorunych()
        {
            FillRandomValues();
        }

        public void FillRandomValues()
        {
            Random rnd = new Random();
            string[] names = { "Ivan", "Maria", "Alexey", "Olga", "Dmitry" };
            int nameIndex = rnd.Next(names.Length);
            Name = names[nameIndex];
            Age = rnd.Next(0, 1000);
            IQ = rnd.Next(0, 1000);
        }

        public void Battle(Gorunych opponent)
        {
            Random rand = new Random();
            int thisLoss = rand.Next(1, this.IQ + 1);
            int opponentLoss = rand.Next(1, opponent.IQ + 1);

            this.IQ -= thisLoss;
            opponent.IQ -= opponentLoss;
        }
    }
    class GorunychPopulation
    {
        private List<Gorunych> heads = new List<Gorunych>();

        public void AddHead(Gorunych head)
        {
            heads.Add(head);
        }

        public double GetAverageIQ()
        {
            if (heads.Count == 0)
            {
                return 0.0;
            }
            double sumIQ = heads.Sum(h => h.IQ);
            return sumIQ / heads.Count;
        }

        public Gorunych FindSmartest(List<Gorunych> gorunychList)
        {
            Gorunych smartest = gorunychList.First();
            double maxAvgIQ = gorunychList.Average(g => g.IQ) / gorunychList.Count;

            foreach (Gorunych gorunych in gorunychList)
            {
                double avgIQ = gorunych.IQ;
                if (avgIQ > maxAvgIQ)
                {
                    smartest = gorunych;
                    maxAvgIQ = avgIQ;
                }
            }

            return smartest;
        }
    }

public static void Main(string[] args)
    {
        // создаем несколько экземпляров класса ZmeyGorynych, используя все конструкторы
        ZmeyGorynych defaultZmey = new ZmeyGorynych();
        ZmeyGorynych namedZmey = new ZmeyGorynych("Петр", 5, new List<int> { 90, 85, 75, 80, 100 });
        ZmeyGorynych fullZmey = new ZmeyGorynych("Василий", 7, 200, 5000, 1200);
        ZmeyGorynych copyZmey = new ZmeyGorynych(fullZmey);

        // выводим информацию о каждом змее
        Console.WriteLine("Информация о змее с параметрами по умолчанию:");
        defaultZmey.Display();
        Console.WriteLine();

        Console.WriteLine("Информация о змее с именем, количеством голов и IQ голов:");
        namedZmey.Display();
        Console.WriteLine();

        Console.WriteLine("Информация о змее со всеми параметрами:");
        fullZmey.Display();
        Console.WriteLine();

        Console.WriteLine("Информация о змее, скопированной из предыдущей:");
        copyZmey.Display();
        Console.WriteLine();

        // создаем динамический вектор змеев
        List<ZmeyGorynych> zmeys = new List<ZmeyGorynych>();
        zmeys.Add(defaultZmey);
        zmeys.Add(namedZmey);
        zmeys.Add(fullZmey);

        // выводим информацию о каждом змее из вектора
        Console.WriteLine("Информация о змеях в векторе:");
        foreach (ZmeyGorynych zmey in zmeys)
        {
            zmey.Display();
            Console.WriteLine();
        }

        // заполняем всех змеев случайными значениями
        Random random = new Random();
        foreach (ZmeyGorynych zmey in zmeys)
        {
            zmey.SetValues();
            Console.WriteLine();

        }

        // выводим информацию о каждом змее из вектора после заполнения случайными значениями
        Console.WriteLine("Информация о змеях в векторе после заполнения случайными значениями:");
        foreach (ZmeyGorynych zmey in zmeys)
        {
            zmey.Display();
            Console.WriteLine();
        }
        Console.ReadLine();
    }

}
