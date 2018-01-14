using TalkingJournal.model;

namespace TalkingJournal_Tests
{
    public class TestConstants
    {
        public static readonly Journal Tdg = BuildTdg();
        public static readonly Journal LeMonde = BuildLeMonde();

        public const string TdgXpath = 
            "//div[@id=\"mainContent\"]/p/text()|//div[@id=\"mainContent\"]/p/b/text()";

        public const string LeMondeXpath = 
            "//div[@itemprop = \"articleBody\"]/p/text()|//div[@itemprop = \"articleBody\"]//strong/text()";

        private static Journal BuildLeMonde()
        {
            var journal = new Journal
            {
                Title = "Le Monde",
                Xpath = LeMondeXpath
            };
            
            journal.AddCategory(
                new Category
                {
                    Name = "Eurppe",
                    UrlRss = "http://www.lemonde.fr/europe/rss_full.xml"
                }
            );

            return journal;

        }


        private static Journal BuildTdg()
        {
            var journal = new Journal
            {
                Title = "Tribune de Genève",
                Xpath = TdgXpath
            };

            journal.AddCategory(
                new Category
                {
                    Name = "Suisse",
                    UrlRss = "https://www.tdg.ch/suisse/rss.html"
                }
            );
            journal.AddCategory(
                new Category
                {
                    Name = "Genève",
                    UrlRss = "https://www.tdg.ch/geneve/rss.html"
                }
            );
            journal.AddCategory(
                new Category
                {
                    Name = "Le Monde",
                    UrlRss = "https://www.tdg.ch/monde/rss.html"
                }
            );
            return journal;
        }
    }
}
