using SeleniumFrameWorkDesign.Base;

namespace TestSolution
{
    public class HookInitialize : TestInitializeHook
    {
        public HookInitialize() : base(BrowserType.Chrome)
        {
            InitializeSettings();
            NavigateSite();
        }
    }
}