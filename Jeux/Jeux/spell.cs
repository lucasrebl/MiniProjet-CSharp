namespace Spells
{
    public class Spell
    {
        public string Name { get; }
        public int Damage { get; }
        public int ManaCost { get; }

        public string Status { get; }

        // public static List<string> spellNames = new List<string> {"Fireball", "Freeze", "Poison", "trempette"};
        
        public Spell(string name, int damage, int manaCost, string status)
        {
            Name = name;
            Damage = damage;
            ManaCost = manaCost;
            Status = status;
        }
    }

}