using Newtonsoft.Json;
using System.Collections;
using System.Reflection;

class TraumatologyDoctor : HospitalDoctor
{
    public string EmergencyCertification { get; set; }
    public TraumatologyDoctor(string? name, string? surname, DateOnly workStartedYear, string emergencyCertification)
        : base(name, surname, workStartedYear)
    {
        EmergencyCertification = emergencyCertification;
    }

    public override void ShowDoctor(ConsoleColor color1 = ConsoleColor.Green, ConsoleColor color2 = ConsoleColor.White) => base.ShowDoctor(color1, color2);

    public override string ToString() => $"{base.ToString()}\nEmergency Certification : {EmergencyCertification}\n----------------------\n {ShowReservedTime()}";
}

class TraumatologyDoctors : IEnumerable<TraumatologyDoctor>
{
    private readonly List<TraumatologyDoctor> TraumatologyDoctorss = new();

    public TraumatologyDoctor this[int index]
    {
        get { return TraumatologyDoctorss[index]; }
    }

    public IEnumerator<TraumatologyDoctor> GetEnumerator() => TraumatologyDoctorss.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void JsonToList()
    {
        string path = AppDomain.CurrentDomain.BaseDirectory[..^17] + @"JsonFiles\TraumatologyDoctor.json";
        string TraumatologyJson = File.ReadAllText(path);

        List<TraumatologyDoctor>? doctors = JsonConvert.DeserializeObject<List<TraumatologyDoctor>>(TraumatologyJson);

        foreach (TraumatologyDoctor doctor in doctors)
            TraumatologyDoctorss.Add(doctor);
    }
}




