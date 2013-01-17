using ArtificialGold.Models.ViewModels;
using ArtificialGold.Services.Phrases;

namespace ArtificialGold.Services
{
    public interface IHomeViewModelRetriever
    {
        HomeViewModel GetModel();
    }

    public class HomeViewModelRetriever : IHomeViewModelRetriever
    {
        private readonly IPhrasesRetriever phrasesRetriever;

        public HomeViewModelRetriever(IPhrasesRetriever phrasesRetriever)
        {
            this.phrasesRetriever = phrasesRetriever;
        }

        public HomeViewModel GetModel()
        {
            return new HomeViewModel{Phrases = phrasesRetriever.GetPhrases()};
        }
    }
}