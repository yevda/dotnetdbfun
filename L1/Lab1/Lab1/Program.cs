namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting DB seed");
            using (SpacecraftContext db = new SpacecraftContext())
            {
                db.Combats.Add(new Combat() { Name = "Millennium Falcon", CombatType = "Interceptor" });
                db.Combats.Add(new Combat() { Name = "Death Star", CombatType = "battle station" });

                db.Researchs.Add(new Research() { Name = "Prometheus", IsColonist = false });
                db.Researchs.Add(new Research() { Name = "Endurance", IsColonist = true });


                db.Logistics.Add(new Logistic() { Name = "Nostromo", HasTerraform = true, CargoWeight = 15000 });

                db.SaveChanges();

                Console.WriteLine("Do you want to delete Endurance? (y/n)");
                var IsDelete = Console.ReadLine();

                if (IsDelete == "y")
                {
                    db.Researchs.Remove(db.Researchs.Where(r => r.Name == "Endurance").First());

                    db.SaveChanges();
                    Console.WriteLine("Endurance deleted.");
                }

                Console.WriteLine("DB seeded");


            }
        }
    }
}