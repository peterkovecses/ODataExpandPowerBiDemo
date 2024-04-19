using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataExpandPowerBiDemo.Models;

namespace ODataExpandPowerBiDemo.Controllers;

public class BooksController : ODataController
{
    private static readonly List<Book> Books = new()
    {
        new() { Id = 1, Title = "Clean Code", Authors = new() { new() { Id = 1, Name = "Robert C. Martin"}}},
        new() { Id = 2, Title = "The Pragmatic Programmer", Authors = new() { new() { Id = 2, Name = "Andrew Hunt"}, new() { Id = 3, Name = "David Thomas" }}},
        new() { Id = 3, Title = "Design Patterns: Elements of Reusable Object-Oriented Software", Authors = new() { new() { Id = 4, Name = "Erich Gamma"}, new() { Id = 5, Name = "Richard Helm" }, new() { Id = 6, Name = "Ralph Johnson" }, new() { Id = 7, Name = "John Vlissides" }}},
        new() { Id = 4, Title = "Introduction to the Theory of Computation", Authors = new() { new() { Id = 8, Name = "Michael Sipser"}}},
        new() { Id = 5, Title = "Refactoring: Improving the Design of Existing Code", Authors = new() { new() { Id = 9, Name = "Martin Fowler" }}},
    };

    [EnableQuery]
    public IActionResult Get()
        => Ok(Books);

    [EnableQuery]
    public IActionResult Get(int key)
    {
        var book = Books.SingleOrDefault(book => book.Id == key);
        if (book is null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    [EnableQuery]
    public IActionResult GetAuthors(int key)
    {
        var authors = Books.SingleOrDefault(book => book.Id == key)?.Authors;
        if (authors is null)
        {
            return NotFound();
        }

        return Ok(authors);
    }
}
