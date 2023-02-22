abstract class HospitalDoctor
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateOnly WorkStartedYear { get; set; }
    public Dictionary<DateTime, List<string>> ReservedTime { get; set; } = new();
    protected HospitalDoctor(string? name, string? surname, DateOnly workStartedYear)
    {
        Name = name;
        Surname = surname;
        WorkStartedYear = workStartedYear;
    }

    protected string ShowReservedTime()
    {
        string text = "";
        if (ReservedTime.Count == 0)
        {
            text += "Not reserved!\n";
        }
        else
        {
            foreach (var item in ReservedTime)
            {
                text += item.Key.ToString("D") + " : ";
                foreach (var value in item.Value)
                {
                    text += value + " ";
                }
                text += "\n";
            }
        }
        return text;
    }


    public void ChooseHour(DateTime date, int num = 1)
    {
        Console.Clear();
        Console.WriteLine("");
        ConsoleColor color;
        _ = num == 1 ? color = ConsoleColor.Green : color = ConsoleColor.White;
        Console.ForegroundColor = color;
        Console.Write(color == ConsoleColor.Green ? "☑ 09:00 - 11:00" : "☐ 09:00 - 11:00");
        if (ReservedTime.ContainsKey(date) && ReservedTime[date].Contains("09:00 - 11:00")) Console.Write("(Reserved)");
        _ = num == 2 ? color = ConsoleColor.Green : color = ConsoleColor.White;
        Console.ForegroundColor = color;
        Console.Write(color == ConsoleColor.Green ? "\n☑ 12:00 - 14:00" : "\n☐ 12:00 - 14:00");
        if (ReservedTime.ContainsKey(date) && ReservedTime[date].Contains("12:00 - 14:00")) Console.Write("(Reserved)");
        _ = num == 3 ? color = ConsoleColor.Green : color = ConsoleColor.White;
        Console.ForegroundColor = color;
        Console.Write(color == ConsoleColor.Green ? "\n☑ 15:00 - 17:00" : "\n☐ 15:00 - 17:00");
        if (ReservedTime.ContainsKey(date) && ReservedTime[date].Contains("15:00 - 17:00")) Console.Write("(Reserved)");
        Console.ForegroundColor = ConsoleColor.White;
        ConsoleKey key = Console.ReadKey().Key;
        if (key == ConsoleKey.DownArrow)
        {
            _ = num == 3 ? num = 1 : num++;
            ChooseHour(date, num);
        }
        else if (key == ConsoleKey.UpArrow)
        {
            _ = num == 1 ? num = 3 : num--;
            ChooseHour(date, num);
        }
        else if (key == ConsoleKey.Enter)
        {
            if (!ReservedTime.ContainsKey(date)) ReservedTime[date] = new();
            bool condition = true;
            if (num == 1 && !ReservedTime[date].Contains("09:00 - 11:00"))
            {
                ReservedTime[date].Add("09:00 - 11:00");
                condition = false;
            }
            else if (num == 2 && !ReservedTime[date].Contains("12:00 - 14:00"))
            {
                ReservedTime[date].Add("12:00 - 14:00");
                condition = false;
            }
            else if (num == 3 && !ReservedTime[date].Contains("15:00 - 17:00"))
            {
                ReservedTime[date].Add("15:00 - 17:00");
                condition = false;
            }
            if (condition)
            {
                Console.Clear();
                if (num == 1) Console.WriteLine("Time reserved you can not choose!");
                else if (num == 2) Console.WriteLine("Time reserved you can not choose!");
                else Console.WriteLine("Time reserved you can not choose!");
                Thread.Sleep(600);
            }
        }
        else ChooseHour(date, num);
    }


    public void Reserve()
    {
        Console.Clear();
        Console.Write("Enter the date in the format 'yyyy.MM.dd': ");
        string? dateString = Console.ReadLine();
        DateTime date;
        if (DateTime.TryParseExact(dateString, "yyyy.MM.dd", null, System.Globalization.DateTimeStyles.None, out date))
        {
            Console.Clear();
            if (ReservedTime.ContainsKey(date) && (ReservedTime[date].Contains("09:00 - 11:00") && ReservedTime[date].Contains("12:00 - 14:00") && ReservedTime[date].Contains("15:00 - 17:00")))
            {
                Console.WriteLine("The choosen day is fully reserved!");
                Thread.Sleep(600);
            }
            else if (date <= DateTime.Now)
            {
                throw new ArgumentException("The date input is from the past.");
            }
            else ChooseHour(date);
        }
        else throw new ArgumentException("Invalid date format");

    }

    public virtual void ShowDoctor(ConsoleColor color1 = ConsoleColor.Green, ConsoleColor color2 = ConsoleColor.White)
    {
        Console.Clear();
        Console.WriteLine(ToString());
        Console.ForegroundColor = color1;
        Console.WriteLine(color1 == ConsoleColor.Green ? "☑ Reserve time" : "☐ Reserve time");
        Console.ForegroundColor = color2;
        Console.WriteLine(color2 == ConsoleColor.Green ? "☑ Back" : "☐ Back");
        Console.ForegroundColor = ConsoleColor.White;
        ConsoleKey key = Console.ReadKey().Key;
        if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow) ShowDoctor(color2, color1);
        else if (key == ConsoleKey.Enter)
        {
            if (color1 == ConsoleColor.Green) Reserve();
            else Program.MainMenu();
        }
        else ShowDoctor(color1, color2);
    }

    protected int CalculateExperience(DateOnly StartedYear) => DateTime.Now.Year - StartedYear.Year;

    public override string ToString() => $"----------------------\nName : {Name}\nSurname : {Surname}\nExperience(years) : {CalculateExperience(WorkStartedYear)}";

}




