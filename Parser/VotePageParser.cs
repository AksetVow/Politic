using Domain;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Parser
{
    public class VotePageParser
    {
        public IEnumerable<Deputy> ParseDeputy(string html)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);

            if (document.ParseErrors != null && document.ParseErrors.Count() > 0)
            {
                throw new ArgumentException("Incorrect html");
            }


            throw new NotImplementedException();
        }

        public VoteForBill ParseVoting(string html)
        {
            throw new NotImplementedException();
        }

    }
}
