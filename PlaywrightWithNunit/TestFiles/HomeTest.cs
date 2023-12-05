using Microsoft.Playwright.NUnit;

namespace PlaywrightWithNunit.TestFiles
{
    public class Tests: PageTest
    {

        [Test]
        public async Task Login_With_Valid_Credentials_And_Logout()
        {
            var url = "https://magento.softwaretestingboard.com/";

            //Go to URL
            await Page.GotoAsync(url);

            // Click on Signin Button
            await Page.Locator("//div[contains(@class,'header')]//a[contains(text(),'Sign In')]").ClickAsync();

            //input Email and Password
            await Page.GetByTitle("Email").FillAsync("testing.usama06@gmail.com");
            await Page.GetByTitle("Password").FillAsync("P@ccw0rd");


            //Click on Signin
            await Page.Locator("//fieldset[@class='fieldset login']//span[contains(text(),'Sign In')]").ClickAsync();

            //Validating URL and Text on Home Page
            if (!Page.Url.Equals(url))
            {
                Assert.Fail();
            }

            var textLocator = Page.GetByText("What's New");
            await Expect(textLocator).ToHaveTextAsync("What's New");

            // Signout
            await Page.WaitForTimeoutAsync(1000);
            await Page.Locator("//div[contains(@class,'header')]//span[contains(text(),'Change')]").ClickAsync();
            await Page.Locator("//div[@aria-hidden='false']//a[normalize-space()='Sign Out']").ClickAsync();

            //Validate Signout
            var signoutLocator = Page.GetByText("You are signed out");
            await Expect(signoutLocator).ToHaveTextAsync("You are signed out");

        }
    }
}