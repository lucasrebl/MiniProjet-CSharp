namespace Potions
{
    class Potion
    {
        public string Name { get; }
        public int ManaRestaure { get; }


        public Potion(string name, int manaRestaure)
        {
            Name = name;
            ManaRestaure = manaRestaure;
        }
    }
}