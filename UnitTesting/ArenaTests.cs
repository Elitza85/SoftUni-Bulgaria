//using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void TestIfAddingWarriorToArenaWorksCorrectly()
        {
            Warrior warrior = new Warrior("Pesho", 40, 80);

            this.arena.Enroll(warrior);

            Assert.That(this.arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void TestIfAddingWorriorWithExistingNameThrowsException()
        {
            Warrior warrior = new Warrior("Pesho", 40, 80);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
           {
               this.arena.Enroll(warrior);
           });
        }

        [Test]
        public void TestCountWorksCorrectly()
        {
            Warrior warrior = new Warrior("Pesho", 20, 100);

            this.arena.Enroll(warrior);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.arena.Count);
        }

        [Test]
        public void TestIfFightWorksCorrectly()
        {
            Warrior attacker = new Warrior("Pesho", 40, 100);
            Warrior defender = new Warrior("Gosho", 20, 80);

            int expAttackerHp = 80;
            int expDefenderHp = 40;

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(expAttackerHp, attacker.HP);
            Assert.AreEqual(expDefenderHp, defender.HP);
        }

        [Test]
        public void MissingDefenderUnableToFight()
        {
            Warrior attacker= new Warrior("Pesho", 40, 100);
            Warrior defender= new Warrior("Gosho", 40, 50);
            
            this.arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() =>
           {
               this.arena.Fight(attacker.Name, defender.Name);
           });
        }

        [Test]
        public void MissingAttackerUnableToFight()
        {
            Warrior attacker = new Warrior("Pesho", 40, 100);
            Warrior defender = new Warrior("Gosho", 40, 50);

            this.arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(attacker.Name, defender.Name);
            });
        }
    }
}
