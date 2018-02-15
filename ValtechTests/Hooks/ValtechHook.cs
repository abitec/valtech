using ValtechTests.Helper;
using TechTalk.SpecFlow;

namespace ValtechTests.Hooks
{
    [Binding]
    public sealed class ValtechHook
    {
        private readonly Context _context;

        public ValtechHook(Context context)
        {
            _context = context;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _context.CloseBrowser();
        }
    }
}
