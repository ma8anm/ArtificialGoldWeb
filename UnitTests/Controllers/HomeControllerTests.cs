using System.Web.Mvc;

using ArtificialGold.Controllers;
using ArtificialGold.Models.ViewModels;
using ArtificialGold.Services;

using NUnit.Framework;

using Rhino.Mocks;

namespace UnitTests.Controllers
{
    public class HomeControllerTests
    {
        public class Given_a_HomeController
        {
            protected IHomeViewModelRetriever homeViewModelRetriever;

            protected HomeController HomeController;

            [SetUp]
            public virtual void SetUp()
            {
                homeViewModelRetriever = MockRepository.GenerateMock<IHomeViewModelRetriever>();
                HomeController = new HomeController(homeViewModelRetriever);
            }
        }

        public class When_I_call_index : Given_a_HomeController
        {
            private ViewResult result;

            private HomeViewModel modelFromRetriever= new HomeViewModel();

            [SetUp]
            public new virtual void SetUp()
            {
                homeViewModelRetriever.Stub(x => x.GetModel()).Return(modelFromRetriever);
                result = HomeController.Index();
                base.SetUp();
            }

            [Test]
            public void should_return_ViewModel_from_ViewModelRetreiver()
            {
               Assert.AreEqual(modelFromRetriever, result.Model);
            }
        }
    }
}