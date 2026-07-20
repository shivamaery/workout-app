namespace WorkoutApp.Models;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }

    // Navigation property for the workouts associated with this user
    public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}