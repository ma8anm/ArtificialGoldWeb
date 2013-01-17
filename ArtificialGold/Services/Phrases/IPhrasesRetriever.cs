using ArtificialGold.Models.ViewModels;

namespace ArtificialGold.Services.Phrases
{
    public interface IPhrasesRetriever
    {
        Models.ViewModels.HomePagePhrases GetPhrases();
    }

    public class PhrasesRetriever : IPhrasesRetriever
    {
        public HomePagePhrases GetPhrases()
        {
            return new HomePagePhrases { PageTitle = "Artificial Gold : Start Up Websites and Software Development" };
        }
    }
}