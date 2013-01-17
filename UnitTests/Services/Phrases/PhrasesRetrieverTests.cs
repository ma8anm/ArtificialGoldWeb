using ArtificialGold.Models.ViewModels;
using ArtificialGold.Services.Phrases;

using NUnit.Framework;

namespace UnitTests.Services.Phrases
{
    public class PhrasesRetrieverTests
    {
        public class Given_a_PhrasesRetriever
        {
            protected PhrasesRetriever phrasesRetriever;

            [SetUp]
            public virtual void SetUp()
            {
                phrasesRetriever = new PhrasesRetriever();
            }
        }

        [TestFixture]
        public class When_I_call_PhrasesRetriever : Given_a_PhrasesRetriever
        {
            private HomePagePhrases result;

            [SetUp]
            public new virtual void SetUp()
            {
                base.SetUp();
                result = phrasesRetriever.GetPhrases();
            }

            [Test]
            public void should_return_phrases()
            {
                Assert.AreEqual(result.PageTitle, "Artificial Gold : Start Up Websites and Software Development");
            }
        }
    }
}