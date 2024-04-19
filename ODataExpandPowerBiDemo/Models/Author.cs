using System.ComponentModel.DataAnnotations;

namespace ODataExpandPowerBiDemo.Models;

public class Author
{
    [Key]
    public int Id { get; set; }

    public required string Name { get; set; }
}
