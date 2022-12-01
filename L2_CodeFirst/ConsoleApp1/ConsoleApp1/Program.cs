using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1

//Install-Package Microsoft.EntityFrameworkCore.SqlServer
//Install-Package EntityFrameworkCore.SqlServer.HierarchyId
//Install-Package Microsoft.EntityFrameworkCore.Tools
//Install-Package Microsoft.EntityFrameworkCore.Relational
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DataContext db = new DataContext();
            var root = db.Tree.Add
                (
                    new Tree
                    {
                        TreeId = HierarchyId.GetRoot(),
                        Name = "Root"
                    }

                );

            var nodeA = db.Tree.Add
                (
                    new Tree
                    {
                        TreeId = root.Entity.TreeId.GetDescendant(null, null),
                        Name = "A"
                    }

                );
            var nodeB = db.Tree.Add
                (
                    new Tree
                    {
                        TreeId = root.Entity.TreeId.GetDescendant(nodeA.Entity.TreeId, null),
                        Name = "B"
                    }

                );
            db.Tree.Add
                (
                    new Tree
                    {
                        TreeId = nodeA.Entity.TreeId.GetDescendant(null, null),
                        Name = "AA"
                    }

                );
            db.SaveChanges();
            var result = db.Tree
                .Where(n => n.TreeId.IsDescendantOf(root.Entity.TreeId))
                .Select(n => n.Name)
                .ToList();

            Console.WriteLine(string.Join('\n', result));
            Console.WriteLine();
            Console.WriteLine("Done!");


        }
    }
}