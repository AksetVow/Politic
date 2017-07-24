using Domain;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Parser
{
    public class VotePageParser
    {

        // Should be deleted
        //public IEnumerable<Deputy> ParseDeputy(string html)
        //{
        //    HtmlDocument document = new HtmlDocument();
        //    document.LoadHtml(html);

        //    if (document.ParseErrors != null && document.ParseErrors.Count() > 0)
        //    {
        //        //throw new ArgumentException("Incorrect html");
        //    }

        //    HashSet<Deputy> deputats = new HashSet<Deputy>();

        //    var dic = new Dictionary<string, int>();
        //    foreach (HtmlNode div in document.DocumentNode.SelectNodes("//div[contains(@class,'dep')]"))
        //    {
        //        deputats.Add(new Deputy { FullName = div.InnerText });
        //        if (dic.ContainsKey(div.InnerText))
        //            dic[div.InnerText]++;
        //        else
        //            dic[div.InnerText] = 1;
        //    }
        //    var newDic = dic.OrderByDescending(x => x.Value).ToArray();

        //    var res = deputats.ToArray();
        //    return res;
        //}

        public VoteForBill ParseVoting(string html)
        {
            throw new NotImplementedException();
        }

    }
}
