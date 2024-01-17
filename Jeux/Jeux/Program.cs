using Spells;
using Players;
using Monsters;
using Heals;
using Potions;

public class Program
{
    static void Main()
    {
        Player player = new Player("Joueur", 20, 20, "aucun", 1);
        player.Spells.Add(new Spell("Fireball", 10, 15, "brulure"));
        player.Spells.Add(new Spell("Freeze", 5, 10, "gelure"));
        player.Spells.Add(new Spell("Poison", 15, 10, "empoisonné"));
        player.Spells.Add(new Spell("trempette", 0, 1, "aucun"));

        player.Heals.Add(new Heal("soin", 15));

        player.Potions.Add(new Potion("potion de mana", 15));

        Game(player);
    }

    static void Game(Player player)
    {
        int monsterLevel = 1;
        Monster monster = null;

        while (player.IsAlivePlayer())
        {
            if (monster == null || !monster.IsAliveMonster())
            {
                if (monster != null)
                {
                    Console.WriteLine($"Vous avez vaincu le {monster.GetStatusMonster()}");
                    Console.WriteLine();

                    player.Bonus();
                    Console.WriteLine($"Vous avez reçu un bonus de PV et de Mana pour avoir tué un gobelin niveau {monsterLevel}");
                    Console.WriteLine();

                    // monster.MonsterDropPotion(player, new Random());
                    // Console.WriteLine($"le {monster.Name} a Drop une potion de mana, le {player.Name} a récupérer la potion de mana");
                    // Console.WriteLine($"le {player.Name} possède {player.NbPotion} potion de mana");
                    // Console.WriteLine();

                    player.ResetMonsterStatus();
                    monsterLevel++;
                }

                if (player.IsAlivePlayer())
                {
                    monster = new Monster($"gobelin niveau {monsterLevel}", 10 * monsterLevel, 20 * monsterLevel, "aucun");
                    Console.WriteLine($"Attention, un gobelin niveau {monsterLevel} est arrivé");
                    Console.WriteLine($"Le {monster.Name} n'a pas pu vous attaquer");
                    Console.WriteLine();
                }
            }

            Console.WriteLine($"État actuel du joueur: {player.GetStatusPlayer()}, effet de status = {monster.PlayerStatus}");
            Console.WriteLine($"État actuel du monstre: {monster.GetStatusMonster()}, effet de status = {player.MonsterStatus}");
            Console.WriteLine();

            Action();

            string userAction = Console.ReadLine();

            switch (userAction.ToLower())
            {
                case "1":
                    if (player.Spells.Any(spell => spell.Name == "Fireball"))
                    {
                        Spell fireballSpell = player.Spells.First(spell => spell.Name == "Fireball");
                        player.CastSpell(fireballSpell, monster);

                        if (player.Mana >= fireballSpell.ManaCost)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Vous avez lancé {fireballSpell.Name} et infligé {fireballSpell.Damage} points de dégâts au {monster.Name}!");
                        }
                    }
                    if (monster.IsAliveMonster())
                    {
                        monster.MonsterAttack(player);
                    }
                    break;
                case "2":
                    if (player.Spells.Any(spell => spell.Name == "Freeze"))
                    {
                        Spell FreezeSpell = player.Spells.First(spell => spell.Name == "Freeze");
                        player.CastSpell(FreezeSpell, monster);
                        if (player.Mana >= FreezeSpell.ManaCost)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Vous avez lancé {FreezeSpell.Name} et infligé {FreezeSpell.Damage} points de dégâts au {monster.Name}!");
                        }
                    }
                    if (monster.IsAliveMonster())
                    {
                        monster.MonsterAttack(player);
                    }
                    break;
                case "3":
                    if (player.Spells.Any(spell => spell.Name == "Poison"))
                    {
                        Spell PoisonSpell = player.Spells.First(spell => spell.Name == "Poison");
                        player.CastSpell(PoisonSpell, monster);
                        if (player.Mana >= PoisonSpell.ManaCost)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Vous avez lancé {PoisonSpell.Name} et infligé {PoisonSpell.Damage} points de dégâts au {monster.Name}!");
                        }
                    }
                    if (monster.IsAliveMonster())
                    {
                        monster.MonsterAttack(player);
                    }
                    break;
                case "4":
                    if (player.Heals.Any(heal => heal.Name == "soin"))
                    {
                        Heal SoinHeal = player.Heals.First(Heal => Heal.Name == "soin");
                        player.CastHeal(SoinHeal);
                        Console.WriteLine();
                        Console.WriteLine($"vous avez utilisé {SoinHeal.Name} vos pv ont été augmenter de {SoinHeal.PvHeal}");
                    }
                    if (monster.IsAliveMonster())
                    {
                        monster.MonsterAttack(player);
                    }
                    break;
                case "5":
                    if (player.Potions.Any(potion => potion.Name == "potion de mana"))
                    {
                        Potion ManaPotion = player.Potions.First(potion => potion.Name == "potion de mana");
                        player.ComsumePotion(ManaPotion);
                        player.DecrementNbPotion(ManaPotion);
                        Console.WriteLine();
                        Console.WriteLine($"Vous avez utilisé une {ManaPotion.Name}, votre mana a augmenter de {ManaPotion.ManaRestaure}");
                    }
                    if (monster.IsAliveMonster())
                    {
                        monster.MonsterAttack(player);
                    }
                    break;
            }
        }
        Console.WriteLine($"État actuel du joueur: {player.GetStatusPlayer()}");
        Console.WriteLine("Vous êtes mort");
    }

    public static void Action()
    {
        Console.WriteLine("Action Possible");
        Console.WriteLine("1: lancer Fireball");
        Console.WriteLine("2: lancer Freeze");
        Console.WriteLine("3: lancer Poison");
        Console.WriteLine("4: se soigner");
        Console.WriteLine("5: potion de Mana");
    }
}
