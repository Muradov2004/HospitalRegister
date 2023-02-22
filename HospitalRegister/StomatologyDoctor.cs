using Newtonsoft.Json;
using System.Collections;

class StomatologyDoctor : HospitalDoctor
{
    public string SpecializationArea { get; set; }
    public StomatologyDoctor(string? name, string? surname, DateOnly workStartedYear, string specializationArea)
        : base(name, surname, workStartedYear)
    {
        SpecializationArea = specializationArea;
    }

    public override void ShowDoctor(ConsoleColor color1 = ConsoleColor.Green, ConsoleColor color2 = ConsoleColor.White) => base.ShowDoctor(color1, color2);

    public override string ToString() => $"{base.ToString()}\nSpecialization Area : {SpecializationArea}\n----------------------\n{ShowReservedTime()}";
}

class StomatologyDoctors : IEnumerable<StomatologyDoctor>
{
    private readonly List<StomatologyDoctor> StomatologyDoctorss = new();

    public StomatologyDoctor this[int index]
    {
        get { return StomatologyDoctorss[index]; }
    }

    public IEnumerator<StomatologyDoctor> GetEnumerator() => StomatologyDoctorss.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void JsonToList()
    {

        string path = AppDomain.CurrentDomain.BaseDirectory[..^17] + @"JsonFiles\StomatologyDoctor.json";
        string StomatologyJson = File.ReadAllText(path);

        List<StomatologyDoctor>? doctors = JsonConvert.DeserializeObject<List<StomatologyDoctor>>(StomatologyJson);

        foreach (StomatologyDoctor doctor in doctors)
            StomatologyDoctorss.Add(doctor);
    }
}
