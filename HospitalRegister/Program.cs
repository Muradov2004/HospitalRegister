using System.Text;

class Program
{
    static readonly TraumatologyDoctors traumatologyDoctors = new();
    static readonly StomatologyDoctors stomatologyDoctors = new();
    static readonly PediatricDoctors pediatricDoctors = new();
    static Users users = new();
    static void Traumatology(int num = 0)
    {
        Console.Clear();
        Logo.TraumatologyLogo();
        int i = 0;
        ConsoleColor color;
        foreach (var doctor in traumatologyDoctors)
        {
            _ = i == num ? color = ConsoleColor.Green : color = ConsoleColor.White;
            Console.ForegroundColor = color;
            Console.WriteLine(color == ConsoleColor.Green ? $"☑ {doctor.Surname} {doctor.Name} " : $"☐ {doctor.Surname} {doctor.Name} ");
            i++;
        }

        ConsoleKey key = Console.ReadKey().Key;
        if (key == ConsoleKey.DownArrow)
        {
            _ = num == traumatologyDoctors.Count() - 1 ? num = 0 : num++;
            Traumatology(num);
        }
        else if (key == ConsoleKey.UpArrow)
        {
            _ = num == 0 ? num = traumatologyDoctors.Count() - 1 : num--;
            Traumatology(num);
        }
        else if (key == ConsoleKey.B) MainMenu();
        else if (key == ConsoleKey.Enter)
        {
            try
            {
                traumatologyDoctors[num].ShowDoctor();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                Traumatology();
            }
            MainMenu();
        }
        else Traumatology(num);
    }
    static void Stomatology(int num = 0)
    {
        Console.Clear();
        Logo.StomatologyLogo();
        int i = 0;
        ConsoleColor color;
        foreach (var doctor in stomatologyDoctors)
        {
            _ = i == num ? color = ConsoleColor.Green : color = ConsoleColor.White;
            Console.ForegroundColor = color;
            Console.WriteLine(color == ConsoleColor.Green ? $"☑ {doctor.Surname} {doctor.Name} " : $"☐ {doctor.Surname} {doctor.Name} ");
            i++;
        }

        ConsoleKey key = Console.ReadKey().Key;
        if (key == ConsoleKey.DownArrow)
        {
            _ = num == stomatologyDoctors.Count() - 1 ? num = 0 : num++;
            Stomatology(num);
        }
        else if (key == ConsoleKey.UpArrow)
        {
            _ = num == 0 ? num = stomatologyDoctors.Count() - 1 : num--;
            Stomatology(num);
        }
        else if (key == ConsoleKey.B) MainMenu();
        else if (key == ConsoleKey.Enter)
        {
            try
            {
                stomatologyDoctors[num].ShowDoctor();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                Stomatology();
            }
            MainMenu();
        }
        else Stomatology(num);
    }
    static void Pediatric(int num = 0)
    {
        Console.Clear();
        Logo.PediatricLogo();
        int i = 0;
        ConsoleColor color;
        foreach (var doctor in pediatricDoctors)
        {
            _ = i == num ? color = ConsoleColor.Green : color = ConsoleColor.White;
            Console.ForegroundColor = color;
            Console.WriteLine(color == ConsoleColor.Green ? $"☑ {doctor.Surname} {doctor.Name} " : $"☐ {doctor.Surname} {doctor.Name} ");
            i++;
        }

        ConsoleKey key = Console.ReadKey().Key;
        if (key == ConsoleKey.DownArrow)
        {
            _ = num == pediatricDoctors.Count() - 1 ? num = 0 : num++;
            Pediatric(num);
        }
        else if (key == ConsoleKey.UpArrow)
        {
            _ = num == 0 ? num = pediatricDoctors.Count() - 1 : num--;
            Pediatric(num);
        }
        else if (key == ConsoleKey.B) MainMenu();
        else if (key == ConsoleKey.Enter)
        {
            try
            {
                pediatricDoctors[num].ShowDoctor();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                Pediatric();
            }
            MainMenu();
        }
        else Pediatric(num);
    }


    public static void MainMenu(int num = 1)
    {
        Console.Clear();
        Logo.HospitalLogo();
        ConsoleColor color;
        _ = num == 1 ? color = ConsoleColor.Green : color = ConsoleColor.White;
        Console.ForegroundColor = color;
        Console.WriteLine(color == ConsoleColor.Green ? "☑ Traumatology doctors" : "☐ Traumatology doctors");
        _ = num == 2 ? color = ConsoleColor.Green : color = ConsoleColor.White;
        Console.ForegroundColor = color;
        Console.WriteLine(color == ConsoleColor.Green ? "☑ Stomatology doctors" : "☐ Stomatology doctors");
        _ = num == 3 ? color = ConsoleColor.Green : color = ConsoleColor.White;
        Console.ForegroundColor = color;
        Console.WriteLine(color == ConsoleColor.Green ? "☑ Pediatric doctors" : "☐ Pediatric doctors");
        Console.ForegroundColor = ConsoleColor.White;
        ConsoleKey key = Console.ReadKey().Key;
        if (key == ConsoleKey.DownArrow)
        {
            _ = num == 3 ? num = 1 : num++;
            MainMenu(num);
        }
        else if (key == ConsoleKey.UpArrow)
        {
            _ = num == 1 ? num = 3 : num--;
            MainMenu(num);
        }
        else if (key == ConsoleKey.Enter)
        {
            if (num == 1) Traumatology();
            else if (num == 2) Stomatology();
            else Pediatric();
        }
        else MainMenu(num);
    }


    static void Registration()
    {

        Console.Clear();
        Logo.HospitalRegistrationLogo();

        string? name, surname, email, phoneNumber, password;

        Console.Write("Name : ");
        name = Console.ReadLine();
        Console.Write("Surname : ");
        surname = Console.ReadLine();
        Console.Write("Phone Number : ");
        phoneNumber = Console.ReadLine();
        Console.Write("Email : ");
        email = Console.ReadLine();
        Console.Write("Password : ");
        password = Console.ReadLine();
        try
        {
            User user = new(name, surname, email, phoneNumber, password);
            users.AddUser(user);
        }
        catch (ArgumentException ex)
        {
            Console.Clear();
            Console.WriteLine("You can not register!");
            Console.WriteLine(ex.Message);
            Thread.Sleep(1000);
            LoginRegistrationMenu();
        }
        users.ListToJson();
        LoginRegistrationMenu();
    }

    static void Login()
    {
        Console.Clear();
        Logo.HospitalLoginLogo();
        string? email, password;
        Console.Write("Email : ");
        email = Console.ReadLine();
        Console.Write("Password : ");
        password = Console.ReadLine();
        bool condition = true;
        foreach (var user in users)
        {
            if (user.Email == email)
            {
                if (user.Password == password)
                {
                    condition = false;
                    MainMenu();
                }
                else throw new MemberAccessException("Password wrong!Try again!");
            }
        }
        if (condition) throw new MemberAccessException("Email not exist!");

    }

    static void LoginRegistrationMenu(ConsoleColor color1 = ConsoleColor.Green, ConsoleColor color2 = ConsoleColor.White)
    {
        Console.Clear();
        Logo.HospitalLogo();
        Console.ForegroundColor = color1;
        Console.WriteLine(color1 == ConsoleColor.Green ? "☑ Registration" : "☐ Registration");
        Console.ForegroundColor = color2;
        Console.WriteLine(color2 == ConsoleColor.Green ? "☑ Login" : "☐ Login");
        Console.ForegroundColor = ConsoleColor.White;
        ConsoleKey key = Console.ReadKey().Key;
        if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow)
            LoginRegistrationMenu(color2, color1);
        else if (key == ConsoleKey.Enter)
        {
            try
            {
                if (color1 == ConsoleColor.Green) Registration();
                else Login();
            }
            catch (MemberAccessException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                LoginRegistrationMenu();
            }
        }
        else LoginRegistrationMenu(color1, color2);
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        traumatologyDoctors.JsonToList();
        stomatologyDoctors.JsonToList();
        pediatricDoctors.JsonToList();
        users.JsonToList();
        LoginRegistrationMenu();
    }
}