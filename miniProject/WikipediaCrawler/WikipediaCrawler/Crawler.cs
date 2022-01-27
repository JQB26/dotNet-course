using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WikipediaCrawler
{
    internal class Crawler
    {
        private readonly string _currentPage;
        private readonly string _destinationPage;
        private string _html;
        public List<string> Links;

        public Crawler(string currentPage, string destinationPage)
        {
            _currentPage = currentPage;
            _destinationPage = destinationPage;
            Links = new List<string>();
        }

        private void ReadPage()
        {
            var web = new WebClient();
            Stream stream = null;
            try
            {
                stream = web.OpenRead(_currentPage);
            }
            catch (Exception)
            {
                // ignored
            }

            if (stream == null) return;
            using var reader = new StreamReader(stream);
            _html = reader.ReadToEnd();
        }

        private void GetLinks()
        {
            var links = new List<string>();
            Links = new List<string>();
            const string pattern = @"<a href\s*=\s*(?:[""'](?<1>[^""']*)[""']|(?<1>[^>\s]+))";
            try
            {
                if (_html == null)
                {
                    return;
                }

                var regexMatch = Regex.Match(_html, pattern,
                    RegexOptions.IgnoreCase | RegexOptions.Compiled,
                    TimeSpan.FromSeconds(1));
                while (regexMatch.Success)
                {
                    links.Add(regexMatch.Groups[1].Value);
                    regexMatch = regexMatch.NextMatch();
                }
            }
            catch (RegexMatchTimeoutException)
            {
                Console.WriteLine("Matching operation timed out");
            }

            var l = links.Where(l => l.StartsWith("/wiki/")).Select(x => "https://en.wikipedia.org" + x);

            foreach (var link in l)
            {
                Links.Add(link);
            }
        }

        public bool Analyze()
        {
            ReadPage();
            GetLinks();
            return CheckForDestination();
        }

        public bool CheckForDestination()
        {
            if (Links.Count > 0)
            {
                return Links.Any(link => link.Equals(_destinationPage));
            }

            return false;
        }
    }
}
