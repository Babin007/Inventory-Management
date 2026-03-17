1. ICollection

public class CategoryEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    // Navigation
    public ICollection<ProductEntity> Products { get; set; }
        = new List<ProductEntity>();
}
Think of ICollection as a smart bucket for your data.
In .NET, it is an interface that sits between a simple "read-only" list (IEnumerable) and a very specific "heavy" list (List).
Why use it?
It gives you the perfect balance of features for managing a group of objects:
Modify: You can Add() or Remove() items.
Count: it knows exactly how many items are inside (.Count).
Check: You can see if an item exists (.Contains()).

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

2.Migration

Action      	  |  Package Manager Console (VS)	|   .NET CLI (VS Code Terminal)
-------------------------------------------------------------------------
Add Migration	  |  Add-Migration [Name]	        |   dotnet ef migrations add [Name]
Update Database	  |  Update-Database	            |   dotnet ef database update
Remove Migration  |  Remove-Migration               |   dotnet ef migrations remove
Install Package	  |  Install-Package [Name]         |   dotnet add package [Name]

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~