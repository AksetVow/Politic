using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser;
using System.IO;
using System.Linq;

namespace Parser.Test
{
    [TestClass]
    public class VoteForBillTests
    {
        private string _html;
        private VotePageParser _parser = new VotePageParser();

        [TestMethod]
        public void Setup()
        {
            _html = File.ReadAllText("Resources/VotePageExample.txt");
        }

        [TestMethod]
        public void TestParsingVotePage()
        {
            
        }

        [TestMethod]
        public void TestParsingDeputy()
        {
            var deputies = _parser.ParseDeputy(_html);
            deputies.Count().Should().Be(450);
        } 
    }
}
