using Monsters;
using Spells;
using Heals;

namespace Players
{
    class Player
    {
        public string? Name { get; }
        public int Health { get; private set; }
        public int Mana { get; private set; }

        public string? MonsterStatus { get; private set; }

        public List<Spell> Spells { get; } = new List<Spell>();
        public List<Heal> Heals { get; } = new List<Heal>();

        public Player(string name, int health, int mana, string status)
        {
            Name = name;
            Health = health;
            Mana = mana;
            MonsterStatus = status;
        }

        public void CastSpell(Spell spell, Monster target)
        {
            if (Mana < spell.ManaCost)
            {
                Console.WriteLine("pas assez de mana");
                return;
            }

            Mana -= spell.ManaCost;

            target.ApplyDamage(spell.Damage);
            MonsterStatus = spell.Status;
        }

        public void CastHeal(Heal heal)
        {
            Health += heal.PvHeal;
        }

        public void ApplyDamage(int damage)
        {
            Health -= damage;
        }

        public bool IsAlivePlayer()
        {
            return Health > 0;
        }

        public string GetStatusPlayer()
        {
            return $"{Name}: PV = {Health}, Mana = {Mana}";
        }

        public void Bonus()
        {
            Health += 10;
            Mana += 10;
        }

        public void ResetMonsterStatus()
        {
            MonsterStatus = "aucun";
        }
    }
}