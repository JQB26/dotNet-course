using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WikipediaCrawler
{
    internal class Finder
    {
        private string _startingPage;
        private readonly string _destinationPage;

        private List<string>[] _links;

        private const int MaxDepth = 10;

        public Finder(string startingPage, string destinationPage)
        {
            _startingPage = startingPage;
            _destinationPage = destinationPage;

            _links = new List<string>[MaxDepth];
            for (var i = 0; i < MaxDepth; i++)
            {
                _links[i] = new List<string>();
            }
        }

        public Finder(string destinationPage)
        {
            _startingPage = "";
            _destinationPage = destinationPage;

            _links = new List<string>[MaxDepth];
            for (var i = 0; i < MaxDepth; i++)
            {
                _links[i] = new List<string>();
            }
        }

        public void SetStartingPage(string startingPage)
        {
            _startingPage = startingPage;

            for (var i = 0; i < MaxDepth; i++)
            {
                _links[i].Clear();
            }
        }

        public int Find()
        {
            // first iteration
            //Console.WriteLine("depth: 1");
            var crawler0 = new Crawler(_startingPage, _destinationPage);
            crawler0.Analyze();
            if (crawler0.CheckForDestination())
            {
                return 1;
            }

            var links = crawler0.Links;
            foreach (var link in links)
            {
                _links[0].Add(link);
            }

            bool found = false;
            // next iterations
            for (int depth = 0; depth < MaxDepth; depth++)
            {
                //Console.WriteLine($"depth: {depth+2}");
                var threads = new List<Thread>();
                var foundLinks = new List<string>();
                
                var currentLinkNumber = 0;
                foreach (var link in _links[depth])
                {
                    //Console.WriteLine($"    {currentLinkNumber+1}/{_links[depth].Count}");
                    var thread = new Thread(() =>
                    {
                        var crawler = new Crawler(link, _destinationPage);
                        var isFound = crawler.Analyze();
                        if (isFound)
                        {
                            found = true;
                        }

                        foreach (var crawlerLink in crawler.Links)
                        {
                            foundLinks.Add(crawlerLink);
                        }
                    });
                    threads.Add(thread);
                    thread.Start();

                    if (currentLinkNumber % 250 == 0)
                    {
                        foreach (var t in threads)
                        {
                            t.Join();
                        }
                        threads.Clear();
                    }

                    if (found)
                    {
                        return depth + 2;
                    }

                    

                    currentLinkNumber++;
                }

                foreach (var foundLink in foundLinks)
                {
                    _links[depth + 1].Add(foundLink);
                }
            }

            return -1;
        }
    }
}
