using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Spacecraft
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Combat: Spacecraft
    {
        public string CombatType { get; set; }
    }

    public class Research: Spacecraft 
    {
        public bool IsColonist { get; set; } 
    }

    public class Logistic: Research
    {
        public int CargoWeight { get; set; }
        public bool HasTerraform { get; set;} 
    }
}
