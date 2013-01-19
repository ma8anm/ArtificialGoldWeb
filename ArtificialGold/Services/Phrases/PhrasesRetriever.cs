using ArtificialGold.Models.ViewModels;

namespace ArtificialGold.Services.Phrases
{
    public class PhrasesRetriever : IPhrasesRetriever
    {
        public HomePagePhrases GetPhrases()
        {
            return new HomePagePhrases
                       {
                           PageTitle = "Artificial Gold : Start Up Websites and Software Development",
                           HomeMenuLink = "Home",
                           AboutUsMenuLink = "About Us",
                           ServicesMenuLink = "Services",
                           ProjectsMenuLink = "Projects",
                           TestimonialsMenuLink = "Testimonials",
                           ContactMenuLink = "Contact"
                       };
        }
    }
}