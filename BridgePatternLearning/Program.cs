using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePatternLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class warrior = new WarriorClass(new SwordWeapon());
            warrior.FightEnemy();
            warrior.TrainClass();

            Console.WriteLine(new string('-', 25));

            warrior.Weapon = new Bow();
            warrior.FightEnemy();
            warrior.TrainClass();

            Console.WriteLine(new string('-', 25));

            warrior.Weapon = new Dagger();
            warrior.FightEnemy();
            warrior.TrainClass();

        }
    }
    //Implemention
    interface IWeapon
    {
        void Attack();
        void UseSkill();
    }
    //concrete implementation of a sword
    class SwordWeapon : IWeapon
    {
        public void Attack()
        {
            Console.WriteLine("You attack enemy with the sword");
        }

        public void UseSkill()
        {
            Console.WriteLine("You charge on enemy with roar");
        }
    }
    //concrete implementation of a bow
    class Bow : IWeapon
    {
        public void Attack()
        {
            Console.WriteLine("You attack enemy with the bow");
        }

        public void UseSkill()
        {
            Console.WriteLine("You shoot multiple arrows");
            Console.WriteLine("You launch arrows on the enemy crowd");
        }
    }
    //concrete implementation of a dagger
    class Dagger : IWeapon
    {
        private int DaggerCount = 10;
        public void Attack()
        {
            Console.WriteLine("You attack enemy with the dagger");
        }

        public void UseSkill()
        {
            while (DaggerCount > 1)
            {
                Console.WriteLine("You throw 1 dagger in enemy");
                DaggerCount--;
                Console.WriteLine("Remain daggers " + DaggerCount);
            }
            Console.WriteLine("The flying daggers attack was perfomed");
        }
    }
    //abstraction
    abstract class Class
    {
        protected IWeapon _weapon;
        public IWeapon Weapon
        {
            set { _weapon = value; }
        }
        public Class(IWeapon weapon)
        {
            _weapon = weapon;
        }
        public virtual void FightEnemy()
        {
            _weapon.Attack();
            _weapon.UseSkill();
        }
        public abstract void TrainClass();
    }
    //refined abstraction of warrior
    class WarriorClass : Class
    {
        public WarriorClass(IWeapon weapon) : base(weapon)
        {
        }
        public override void TrainClass()
        {
            Console.WriteLine("You training at the knight's guild");
        }
    }
    //refined abstraction of mage
    class HunterClass : Class
    {
        public HunterClass(IWeapon weapon) : base(weapon)
        {
        }
        public override void TrainClass()
        {
            Console.WriteLine("You training at the hunter's house");
        }
    }
   
}
