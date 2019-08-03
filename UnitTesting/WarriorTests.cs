using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckIfConstructorWorksCorrectly()
        {
            string expName = "Pesho";
            int expDamage = 15;
            int expHp = 100;

            Warrior warrior = new Warrior("Pesho", 15, 100);

            Assert.AreEqual(expName, warrior.Name);
            Assert.AreEqual(expDamage, warrior.Damage);
            Assert.AreEqual(expHp, warrior.HP);
        }

        [Test]
        public void TestWithWhitespaceInputName()
        {
            Assert.Throws<ArgumentException>(() =>
           {
               Warrior warrior = new Warrior("  ", 25, 100);
           });
        }

        [Test]
        public void TestWithZeroDamage()
        {
            Assert.Throws<ArgumentException>(() =>
           {
               Warrior warrior = new Warrior("Pesho", 0, 100);
           });
        }

        [Test]
        public void TestWithNegativeHp()
        {
            Assert.Throws<ArgumentException>(() =>
           {
               Warrior warrior = new Warrior("Pesho", 10, -1);
           });
        }

        [Test]
        public void TestAttackingWorriorWorksCorrectly()
        {
            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 20, 80);

            int expectedAttackerHp = 80;
            int expectedDefenderHp = 70;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }


        [Test]
        public void TestAttackingWithLowHp()
        {
            Warrior attacker = new Warrior("Pesho", 10, 25);
            Warrior defender = new Warrior("Gosho", 5, 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void AttackingDefenderWithLowHp()
        {
            Warrior attacker = new Warrior("Pesho", 10, 35);
            Warrior defender = new Warrior("Gosho", 8, 20);

            Assert.Throws<InvalidOperationException>(() =>
           {
               attacker.Attack(defender);
           });
        }

        [Test]
        public void AttackingDefenderWithLowAttackerHp()
        {
            Warrior attacker = new Warrior("Pesho", 30, 35);
            Warrior defender = new Warrior("Gosho", 80, 40);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void TestIfDefenderIsDead()
        {
            Warrior attacker = new Warrior("Pesho", 50, 100);
            Warrior defender = new Warrior("Gosho", 80, 40);

            int expAttackerHealth = 20;
            int expectedDefenderHealth = 0;

            attacker.Attack(defender);

            Assert.AreEqual(expAttackerHealth, attacker.HP);
            Assert.AreEqual(expectedDefenderHealth, defender.HP);
        }

        
    }
}