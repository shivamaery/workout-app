namespace WorkoutApp.Models;

public class Workout
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    public DateTime dateTime { get; set; } // Date and time of the Workout

    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
}