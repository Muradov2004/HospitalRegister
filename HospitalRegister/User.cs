using Newtonsoft.Json;
using System.Collections;

class User
{
    public string? Name { get; set; }
    public string? Surname { get; set; }

    private string? email;

    public string? Email
    {
        get { return email; }
        set
        {
            if (value == null || !value.Contains('@'))
                throw new ArgumentException("Incorrect email!");
            email = value;
        }
    }

    private string? phoneNumber;

    public string? PhoneNumber
    {
        get { return phoneNumber; }
        set
        {
            if (value == null || value.Length != 13 || value[0] != '+')
                throw new ArgumentException("Incorrect phone number!");
            phoneNumber = value;
        }
    }

    public string? Password { get; set; }

    public User(string? name, string? surname, string? email, string? phoneNumber, string? password)
    {
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
        Password = password;
    }


}
class Users : IEnumerable<User>
{
    private readonly List<User> Userss = new();

    public void AddUser(User user)
    {
        bool condition = true;
        foreach (var item in Userss)
            if (item.PhoneNumber == user.PhoneNumber || item.Email == user.Email)
                condition = false;
        if (condition) Userss.Add(user);
        else throw new ArgumentException("Phone number or email registered you can not enter again!");
    }

    public IEnumerator<User> GetEnumerator() => Userss.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void ListToJson()
    {
        string json = JsonConvert.SerializeObject(Userss, Newtonsoft.Json.Formatting.Indented);

        string path = AppDomain.CurrentDomain.BaseDirectory[..^17] + @"JsonFiles\Users.json";
        File.WriteAllText(path, json);
    }

    public void JsonToList()
    {
        string path = AppDomain.CurrentDomain.BaseDirectory[..^17] + @"JsonFiles\Users.json";
        string UsersJson = File.ReadAllText(path);

        List<User>? users = JsonConvert.DeserializeObject<List<User>>(UsersJson);
        if (users != null)
        {
            foreach (User user in users)
                Userss.Add(user);
        }
    }
}


