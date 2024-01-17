namespace Heals
{
    class Heal
    {
        public string Name { get; }
        public int PvHeal { get; }

        public Heal(string name, int pvHeal)
        {
            Name = name;
            PvHeal = pvHeal;
        }
    }
}