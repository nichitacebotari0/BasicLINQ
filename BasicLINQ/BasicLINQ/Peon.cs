using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLINQ
{
    public enum Occupation
    {
        Idle,
        Building,
        Gathering
    }

    public enum Hero
    {
        Thrall,
        Cairn
    }

    public class Peon
    {
        public decimal Health { get; set; } = 250;
        public Occupation Occupation { get; set; }
        public Hero Employer { get; set; }
        public string NextVoiceLine { get; set; } = "Orc work";
        public string[] AvailableVoicelines { get; set; } = new[]
        {
            "Orc work",
            "Ready to work.",
            "What you want?"
        };
    }
}
