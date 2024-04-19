using System.ComponentModel.DataAnnotations;

namespace ODataExpandPowerBiDemo.Models;

public class Book
{
    [Key]
    public int Id { get; set; }

    public required string Title { get; set; }

    public List<Author> Authors { get; set; } = default!;
}
