using System;
using System.IO;
using Parser;
using Domain;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Parser.Test
{
    [TestFixture]
    public class VoteForBillTests
    {
        private string _html;
        private VotePageParser _parser = new VotePageParser();

        [SetUp]
        public void Setup()
        {
            _html = File.ReadAllText("Resources/VotePageExample.txt");
        }

        [Test]
        public void TestParsingVotePage()
        {
            
        }

        [Test]
        public void TestParsingDeputy()
        {
            var deputies = _parser.ParseDeputy(_html);
            deputies.Count().Should().Be(450);
        } 
    }
}
