namespace WorkoutApp.Models;

public class WorkoutExercise
{
    public int Id { get; set; }
    public int WorkoutId { get; set; }
    public int ExerciseId { get; set; }
    public int Sets { get; set; }
    public int Repetitions { get; set; }
    public int RestTime { get; set; } // in seconds

    public int weight { get; set; } // in kg

    // Navigation properties
    public required Workout Workout { get; set; }
    public required Exercise Exercise { get; set; }
}