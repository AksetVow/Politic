using Domain;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Parser
{
    public class DepytatyParser
    {
        private const int CurrentParlamentNumber = 8;
        private const int FirstOfflineDocIndex = 4;
        private const string LastParlamentsBaseUrl = @"http://w1.c1.rada.gov.ua/pls/radan_gs09/d_index_arh?skl=";
        private const string ParlamentFileTemplate = @"rada_deputies_0.txt";
        private int _idIterator = 1;
             
        public Deputy[] ParseDeputies()
        {
            var deputies = ParseOffline(CurrentParlamentNumber);
            var uniqueDeputaties = new HashSet<Deputy>(deputies);
            for (int i = 1; i < FirstOfflineDocIndex; i++)
            {
                deputies = ParseOnline(i);
                MergeDeputies(uniqueDeputaties, deputies, i);
            }
            for (int i = FirstOfflineDocIndex; i < CurrentParlamentNumber; i++)
            {
                deputies = ParseOffline(i);
                MergeDeputies(uniqueDeputaties, deputies, i);
            }

            return uniqueDeputaties.ToArray();
        }

        private Deputy[] ParseOnline(int number)
        {
            var html = LoadHtml(LastParlamentsBaseUrl + number);
            var result = ParseOnline(html, number);
            return result;
        }

        private Deputy[] ParseOffline(int number)
        {
            var html = File.ReadAllText($"Resources\\{ParlamentFileTemplate.Replace("0",number.ToString())}");
            var result = ParseOffline(html, number);
            return result;
        }

        private Deputy[] ParseOnline(string html, int number)
        {
            var doc = LoadDocument(html);
            HashSet<Deputy> deputats = new HashSet<Deputy>();
            foreach (HtmlNode depElement in doc.DocumentNode.SelectNodes("//tr[contains(@bordercolor,'#B9CDE2')]"))
            {
                var fullName = depElement.ChildNodes["td"].InnerText;
                var deputy = CreateDeputy(fullName, number);
                deputats.Add(deputy);
            }

            return deputats.ToArray();
        }


        private Deputy[] ParseOffline(string html, int number)
        {
            var doc = LoadDocument(html);
            HashSet<Deputy> deputats = new HashSet<Deputy>();
            foreach (HtmlNode depElement in doc.DocumentNode.SelectNodes("//p[contains(@class,'title')]/a"))
            {
                var fullName = depElement.InnerText;
                var deputy = CreateDeputy(fullName, number);
                var url = depElement.Attributes?["href"];
                if (!string.IsNullOrWhiteSpace(url.Value))
                    deputy.Url = url.Value;

                deputats.Add(deputy);
            }

            return deputats.ToArray();
        }

        private void MergeDeputies(HashSet<Deputy> uniqueDeputies, Deputy[] deputies, int parlamentNumber)
        {
            foreach (var deputy in deputies)
            {
                if (uniqueDeputies.Contains(deputy))
                    uniqueDeputies.First(x => x.FullName.Equals(deputy.FullName)).ParlamentNumbers.Add(parlamentNumber);
                else
                    uniqueDeputies.Add(deputy);
            }
        }

        private HtmlDocument LoadDocument(string html)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            return document;
        }

        private Deputy CreateDeputy(string fullName, int parlamentNumber)
        {
            var all = fullName.Split(' ');
            return new Deputy
            {
                Id = _idIterator++,
                LastName = all[0].Trim(),
                FirstName = all[1].Trim(),
                MiddleName = all[2].Trim(),
                ParlamentNumbers = new List<int> { parlamentNumber}
            };
        }


        private string LoadHtml(string url)
        {
            using (WebClient client = new WebClient())
            {
                string htmlCode = client.DownloadString(url);
                return htmlCode;
            }
        }
    }
}
