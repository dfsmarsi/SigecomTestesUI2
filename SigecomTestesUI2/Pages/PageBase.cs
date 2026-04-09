using SigecomTestesUI2.Services;

namespace SigecomTestesUI2.Pages
{
    public class PageBase
    {
        protected readonly ManipuladorService _manipuladorService;

        public PageBase(ManipuladorService manipuladorService)
        {
            _manipuladorService = manipuladorService;
        }
    }
}