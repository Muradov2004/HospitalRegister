using Newtonsoft.Json;
using System.Collections;

class PediatricDoctor : HospitalDoctor
{
    public DateOnly YearsOfExperienceWithChildren { get; set; }
    public PediatricDoctor(string? name, string? surname, DateOnly workStartedYear, DateOnly yearsOfExperienceWithChildren)
        : base(name, surname, workStartedYear)
    {
        YearsOfExperienceWithChildren = yearsOfExperienceWithChildren;
    }

    public override void ShowDoctor(ConsoleColor color1 = ConsoleColor.Green, ConsoleColor color2 = ConsoleColor.White) => base.ShowDoctor(color1, color2);

    public override string ToString() => $"{base.ToString()}\nYears of experience with children : {CalculateExperience(YearsOfExperienceWithChildren)}\n----------------------\n{ShowReservedTime()}";
}

class PediatricDoctors : IEnumerable<PediatricDoctor>
{
    private readonly List<PediatricDoctor> PediatricDoctorss = new();

    public PediatricDoctor this[int index]
    {
        get { return PediatricDoctorss[index]; }
    }


    public IEnumerator<PediatricDoctor> GetEnumerator() => PediatricDoctorss.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void JsonToList()
    {
        string path = AppDomain.CurrentDomain.BaseDirectory[..^17] + @"JsonFiles\PediatricDoctor.json";
        string PediatricJson = File.ReadAllText(path);

        List<PediatricDoctor>? doctors = JsonConvert.DeserializeObject<List<PediatricDoctor>>(PediatricJson);

        foreach (PediatricDoctor doctor in doctors)
            PediatricDoctorss.Add(doctor);

    }
}



