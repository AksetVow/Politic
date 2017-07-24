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

        [TestInitialize]
        public void Setup()
        {
            _html = File.ReadAllText("Resources//VotePageExample.txt");
        }

        [TestMethod]
        public void TestParsingVotePage()
        {
            
        }

        [TestMethod]
        public void TestParsingDeputy()
        {

        } 
    }
}
