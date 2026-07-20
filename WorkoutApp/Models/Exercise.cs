namespace WorkoutApp.Models;

public class Exercise
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public List<string> PrimaryMuscleGroups { get; set; } = new List<string>(); 

    public List<string> SecondaryMuscleGroups { get; set; } = new List<string>();

    public int rest_time { get; set; } // in seconds


}