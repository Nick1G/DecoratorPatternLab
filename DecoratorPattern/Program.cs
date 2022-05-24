using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Weapon normalWeapon = new BasicWeapon();

            Console.WriteLine("The hero begins their quest!");

            Enemy normal = new NormalEnemy();
            Console.WriteLine("A normal enemy approaches! Press any key to attack!");

            Console.ReadKey(true);
            normalWeapon.Attack();
            Console.WriteLine("The enemy is defeated!");

            Enemy bloodKnight = new BloodKnight();
            Console.WriteLine("A Blood Knight approaches! Your weapon is too weak... Press any key to upgrade and learn Blood Edge!");

            Console.ReadKey(true);
            normalWeapon = new BloodEdge(normalWeapon);
            Console.WriteLine("You learned Blood Edge! Press any key again to attack!");

            Console.ReadKey(true);
            normalWeapon.Attack();
            Console.WriteLine("The Blood Knight kneels, defeated!");

            Enemy wyvern = new FlyingWyvern();
            Console.WriteLine("A Flying Wyvern approaches! Your weapon is still too weak... Press any key to upgrade and learn True Charged Slash!");

            Console.ReadKey(true);
            normalWeapon = new TrueChargedSlash(normalWeapon);
            Console.WriteLine("You learned True Charged Slash! Press any key again to attack!");

            Console.ReadKey(true);
            normalWeapon.Attack();
            Console.WriteLine("The Wyvern plummets from the sky, sealing your victory!");

            Enemy tyrant = new Tyrant();
            Console.WriteLine("At last you reach the capital. The evil Tyrant King approaches! But you realize you are still too weak... Press any key to upgrade and learn the ultimate attack!");

            Console.ReadKey(true);
            normalWeapon = new Aether(normalWeapon);
            Console.WriteLine("You learned the ultimate art! Aether! Press any key again to attack!");

            Console.ReadKey(true);
            normalWeapon.Attack();
            Console.WriteLine("The Tyrant falls upon the Earth, having faced the power of Aether! The world is saved and peace returns!");

            Console.WriteLine("The journey is now over. Press any key to exit.");
            Console.ReadKey(true);
        }

        public abstract class Weapon
        {
            public string WeaponDescription { get; set; } = "A mighty weapon.";
            public Weapon()
            {
                WeaponDescription = "A mighty weapon.";
            }

            public abstract string GetDescription();

            public abstract void Attack();
        }

        public class BasicWeapon : Weapon
        {
            public override string GetDescription()
            {
                return this.WeaponDescription;
            }

            public override void Attack()
            {
                Console.WriteLine("The player attacks!");
            }
        }

        public abstract class SpecialAbility : Weapon
        {
            public abstract string AbilityName { get; set; }
        }

        public class Aether : SpecialAbility
        {
            public Weapon Weapon { get; set; }
            public override string AbilityName { get; set; } = "Aether";
            public Aether(Weapon weapon)
            {
                Weapon = weapon;
            }

            public override string GetDescription()
            {
                return Weapon.GetDescription() + $" With the special ability {AbilityName}.";
            }

            public override void Attack()
            {
                Console.WriteLine("The player uses Aether, the ultimate art! The player attacks with an overwhelming and unrelenting combo!");
            }
        }

        public class TrueChargedSlash : SpecialAbility
        {
            public Weapon Weapon { get; set; }
            public override string AbilityName { get; set; } = "True Charged Slash";
            public TrueChargedSlash(Weapon weapon)
            {
                Weapon = weapon;
            }

            public override string GetDescription()
            {
                return Weapon.GetDescription() + $" With the special ability {AbilityName}.";
            }

            public override void Attack()
            {
                Console.WriteLine("The player charges a True Charged Slash. The attack is unleashed dealing devestating damage!");
            }
        }

        public class BloodEdge : SpecialAbility
        {
            public Weapon Weapon { get; set; }
            public override string AbilityName { get; set; } = "BloodEdge";
            public BloodEdge(Weapon weapon)
            {
                Weapon = weapon;
            }

            public override string GetDescription()
            {
                return Weapon.GetDescription() + $" With the special ability {AbilityName}";
            }

            public override void Attack()
            {
                Console.WriteLine("The player unleashes Blood Edge!");
            }
        }

        public abstract class Enemy
        {
            public abstract EnemyType EnemyType { get; set; }
            public abstract SpecialAbility Weakness { get; set; }
        }

        public class NormalEnemy : Enemy
        {
            public override EnemyType EnemyType { get; set; }
            public override SpecialAbility Weakness { get; set; } = null;

            public NormalEnemy()
            {
                EnemyType = EnemyType.Standard;
            }
        }

        public class BloodKnight : Enemy
        {
            public override EnemyType EnemyType { get; set; }
            public override SpecialAbility Weakness { get; set; }

            public BloodKnight()
            {
                EnemyType = EnemyType.Boss;
                Weakness = new BloodEdge(new BasicWeapon());
            }
        }

        public class Tyrant : Enemy
        {
            public override EnemyType EnemyType { get; set; }
            public override SpecialAbility Weakness { get; set; }

            public Tyrant()
            {
                EnemyType = EnemyType.Boss;
                Weakness = new Aether(new BasicWeapon());
            }
        }

        public class FlyingWyvern : Enemy
        {
            public override EnemyType EnemyType { get; set; }
            public override SpecialAbility Weakness { get; set; }

            public FlyingWyvern()
            {
                EnemyType = EnemyType.Boss;
                Weakness = new TrueChargedSlash(new BasicWeapon());
            }
        }

        public enum EnemyType
        {
            Standard,
            Boss,
        }
    }
}
