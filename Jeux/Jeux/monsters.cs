using Spells;
using Players;

namespace Monsters
{
    class Monster
    {
        public string? Name { get; }
        public int Health { get; private set; }
        public int Mana { get; private set; }
        public string? PlayerStatus { get; private set; }

        public Monster(string name, int health, int mana, string status)
        {
            Name = name;
            Health = health;
            Mana = mana;
            PlayerStatus = status;
        }

        public void MonsterAttack(Player player)
        {
            if (!IsAliveMonster() || Mana < 5)
            {
                return;
            }

            Random random = new Random();
            List<Spell> availableSpells = player.Spells;

            if (availableSpells.Count > 0)
            {
                Spell randomSpell = availableSpells[random.Next(availableSpells.Count)];
                Console.WriteLine();
                Console.WriteLine($"{Name} a lancé {randomSpell.Name} et infligé {randomSpell.Damage} points de dégâts à {player.Name}!");
                Console.WriteLine();
                player.ApplyDamage(randomSpell.Damage);
                Mana -= randomSpell.ManaCost;
                PlayerStatus = randomSpell.Status;
            }
        }

        public void ApplyDamage(int damage)
        {
            Health -= damage;
        }

        public bool IsAliveMonster()
        {
            return Health > 0;
        }

        public string GetStatusMonster()
        {
            return $"{Name}: PV = {Health}, Mana = {Mana}";
        }

        // public void MonsterDropPotion(Player player, Random randomDropPotion)
        // {
        //     int dropChance = randomDropPotion.Next(1, 4);

        //     if (dropChance == 1)
        //     {
        //         player.IncrementNbPotion();
        //         player.GetStatusPlayer();
        //     }
        // }
    }
}