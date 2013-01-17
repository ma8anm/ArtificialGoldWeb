using ArtificialGold.Models.ViewModels;
using ArtificialGold.Services;
using ArtificialGold.Services.Phrases;

using NUnit.Framework;

using Rhino.Mocks;

namespace UnitTests.Services
{
    public class HomeViewModelRetrieverTests
    {
        public class Given_a_HomeViewModelRetriever
        {
            protected HomeViewModelRetriever homeViewModelRetriever;

            protected IPhrasesRetriever phrasesRetriever;

            [SetUp]
            public virtual void SetUp()
            {
                phrasesRetriever = MockRepository.GenerateMock<IPhrasesRetriever>();
                homeViewModelRetriever = new HomeViewModelRetriever(phrasesRetriever);
            }
        }

        public class When_I_call_GetModel : Given_a_HomeViewModelRetriever
        {
            protected HomeViewModel result;

            private HomePagePhrases phrasesFromRetriever= new HomePagePhrases();

            [SetUp]
            public new virtual void SetUp()
            {
                phrasesRetriever.Stub(x => x.GetPhrases()).Return(phrasesFromRetriever);
                result = homeViewModelRetriever.GetModel();
                base.SetUp();
            }

            [Test]
            public void Should_return_phrases_from_PhrasesRetriever()
            {
                Assert.AreEqual(result.Phrases, phrasesFromRetriever);
            }
        }
    }
}