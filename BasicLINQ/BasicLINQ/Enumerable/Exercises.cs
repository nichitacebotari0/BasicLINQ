using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace BasicLINQ.Enumerable
{
    [TestFixture]
    public class Exercises
    {
        [Test]
        public void Example_TakeOddNumbers()
        {
            // Arrange
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            var result = numbers.Where(x => x % 2 == 1);

            // Assert
            result.Should().BeEquivalentTo(1, 3, 5, 7, 9);
        }

        [Test]
        public void Problem_Skip2Elements()
        {
            // Arrange
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            var result = numbers;

            // Assert
            result.Should().BeEquivalentTo(3, 4, 5, 6, 7, 8, 9);
        }

        [Test]
        public void Problem_Take4Elements()
        {
            // Arrange
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            var result = numbers;

            // Assert
            result.Should().BeEquivalentTo(1, 2, 3, 4);
        }

        [Test]
        public void Problem_Skip2_Take4Elements()
        {
            // Arrange
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            var result = numbers.Skip(2).Take(4);

            // Assert
            result.Should().BeEquivalentTo(3, 4, 5, 6);
        }

        [Test]
        public void Problem_GetNames_LongerThan5()
        {
            // Arrange
            var names = new[] { "Chuck", "Johnathan", "Wick", "Ace", "Fenrir" };

            // Act
            var result = names;

            // Assert
            result.Should().BeEquivalentTo("Johnathan", "Fenrir");
        }

        [Test]
        public void Problem_GetFirstName_ThatContainLetterA()
        {
            // Arrange
            var names = new[] { "Chuck", "Johnathan", "Wick", "Ace", "Fenrir" };

            // Act
            var result = "";

            // Assert
            result.Should().Be("Johnathan");
        }

        [Test]
        public void Problem_GetFirstName_ThatIsInBothCollections()
        {
            // Arrange
            var names1 = new[] { "Arnold", "Micky", "Ronald", "Ace", "McDonald" };
            var names2 = new[] { "Chuck", "Johnathan", "Wick", "Ace", "Fenrir" };

            // Act
            var result = "";

            // Assert
            result.Should().Be("Ace");
        }

        [Test]
        public void Problem_GetAllStrings_AsCollectionOfStrings()
        {
            // Arrange
            var names = new List<object> { 3, "Micky", 3.14M, "Ace", new object(), "McDonald", new int[] { 1, 2 } };

            // Act
            var result = names;

            // Assert
            result.GetType().Should().BeAssignableTo<IEnumerable<string>>();
            result.Should().BeEquivalentTo("Micky", "Ace", "McDonald");
        }

        [Test]
        public void Problem_GetNumbers_Ascending()
        {
            // Arrange
            var numbers = new[] { 3, 24, 9, 1, -70 };

            // Act
            var result = numbers;

            // Assert
            result.Should().BeInAscendingOrder();
        }

        [Test]
        public void Problem_GetPeons_Idle_And_EmployerIsThrall()
        {
            // Arrange
            var peons = new List<Peon>()
            {
                new Peon() { Employer = Hero.Thrall, Occupation = Occupation.Building},
                new Peon() { Employer = Hero.Thrall, Occupation = Occupation.Gathering},
                new Peon() { Employer = Hero.Cairn, Occupation = Occupation.Idle},
                new Peon() { Employer = Hero.Thrall, Occupation = Occupation.Idle, NextVoiceLine = "Ready to work."},
                new Peon() { Employer = Hero.Cairn, Occupation = Occupation.Idle},
            };

            // Act
            var result = peons;

            // Assert
            result.Single().NextVoiceLine.Should().Be("Ready to work.");
        }

        [Test]
        public void Problem_GetAvailableVoiceLines_WithoutDuplicates()
        {
            // Arrange
            var peons = new List<Peon>()
            {
                new Peon() { AvailableVoicelines = new [] {"What you want?", "Something need doing?" } },
                new Peon() { AvailableVoicelines = new [] {"Orc work", "Be happy to", } },
                new Peon() { AvailableVoicelines = new [] { "Hmmm ?", "Orc work", } },
            };

            // Act
            var result = new[] { "" };

            // Assert
            result.Should().BeEquivalentTo(
                "What you want?",
                "Something need doing?",
                "Orc work",
                "Be happy to",
                "Hmmm ?");
        }

        [Test]
        public void Problem_GivenOccupationsAndListOfEmployers_CreatePeonsWithOccupationAndEmployer()
        {
            // Arrange
            var occupation = new[] { Occupation.Building, Occupation.Gathering, Occupation.Idle };
            var employers = new[] {  Hero.Cairn,          Hero.Cairn,           Hero.Thrall };

            // Act
            var result = new Peon[0];

            // Assert
            result.Should().BeEquivalentTo(new[]
            {
                new Peon() { Occupation =  Occupation.Building, Employer = Hero.Cairn },
                new Peon() { Occupation =  Occupation.Gathering, Employer = Hero.Cairn },
                new Peon() { Occupation =  Occupation.Idle, Employer = Hero.Thrall },
            }, opt => opt.ComparingByMembers<Peon>());
        }
    }
}
