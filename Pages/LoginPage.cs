
using Microsoft.Playwright;
namespace SnipITAutomation.Pages
{

public class LoginPage{
    private readonly IPage _page;
     public LoginPage(IPage page) => _page = page;

        public async Task Login(string url, string email, string password)
        {
            await _page.GotoAsync(url);
            await _page.FillAsync("#username", email);
            await _page.FillAsync("#password", password);
            await _page.ClickAsync("button[type='submit']");
            //await _page.WaitForDownloadAsync();
        }

}
}