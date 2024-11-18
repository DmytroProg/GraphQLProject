namespace GraphQLProject.Models;

public class Hero
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Town { get; set; }

    public Weapon? Weapon { get; set; }
}