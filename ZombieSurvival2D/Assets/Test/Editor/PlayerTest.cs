using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;


    class PlayerTest
    {
        Vector3 vector3;
        ICharacter character;
        IPlayer player;


        [SetUp]
        public void InitStats()
        {
            vector3 = new Vector3(0, 0, 0);
            character = Substitute.For<ICharacter>();
            player = Substitute.For<IPlayer>();
        }

        [Test]
        [TestCase(true,false,false,false,false)]
        [TestCase(false, true, false, false, false)]
        [TestCase(false, false, true, false, false)]
        [TestCase(false, false, false, true, false)]
        public void CheckPlayerMovement(bool w, bool s, bool a, bool d, bool shift)
        {
            PlayerMovementController playerMovement = new PlayerMovementController();
            playerMovement.InputKeys(character, player, w, s, a, d, shift);
            Assert.AreNotEqual(vector3, character.Direction);
        }
    }
