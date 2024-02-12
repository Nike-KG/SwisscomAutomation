using NUnit.Framework.Internal;
using OpenQA.Selenium.Chrome;
using SwisscomAutomation.Pages;
using SwisscomAutomation.Utilities;

namespace SwisscomAutomation.Tests;

[TestFixture]
public class PurchaseHeadphoneTest : IDisposable
{
    private WebDriver _driver;

    // Pages
    private HomePage _homePage;
    private NavigationBar _navigationBar;
    private HeadphonesPage _headphonesPage;
    private DetailsPage _detailsPage;
    private CartPage _cartPage;

    // Base Url
    private string Url = "https://www.swisscom.ch/";

    // Store the Title value of selected product in Headphone page
    // to compare the listed product type of shopping cart in Cart page.
    private string _productTitleFromHeadphonePage = string.Empty;

    private ChromeOptions _chromeOption;
 

    public PurchaseHeadphoneTest()
    {
        // Initialize Chrome Option and add Incognito as an argument.
        _chromeOption = new ChromeOptions();
        _chromeOption.AddArgument("Incognito");

        // Initialize the Driver and Maximize browser window.
        _driver = new ChromeDriver(_chromeOption);
        _driver.Manage().Window.Maximize();

        //Initialize page objects.
        _homePage = new HomePage(_driver);
        _navigationBar = new NavigationBar(_driver);
        _headphonesPage = new HeadphonesPage(_driver);
        _detailsPage = new DetailsPage(_driver);
        _cartPage = new CartPage(_driver);
    }

    // Navigate to the website.
    [Test]
    [Order(1)]
    public void NavigateToWebsite()
    { 
        //Arrange
        var url = Url;
        var expectedTitle = "Mobile, TV, Internet: Swisscom Residential Customers | Swisscom";

        //Act
        _homePage.NavigateToPage(url);
        _homePage.ClickToAcceptCookie();
      
        //Assert
         Assert.That(_homePage.GetPageTitle(), Is.EqualTo(expectedTitle));
    }

    // Navigate to Headphone page.
    [Test]
    [Order(2)]
    public void NavigateToHeadphones()
    {
        //Arrange
        var expectedDevicesText = "Devices";
        var expectedAccessoriesText = "Accessories";
        var expectedHeadphonesText = "Headphones";
        var expectedHeadphonePageTitle = "Buy earphones & headphones | Swisscom";

        //Act
        var actualDevicesText = _navigationBar.ClickDevicesNavigation();
        var actualAccessoriesText = _navigationBar.ClickAccessoriesNavigation();
        var actualHeadphonesText = _navigationBar.ClickHeadphonesNavigation();

        //Assert
        Assert.That(actualDevicesText, Is.EqualTo(expectedDevicesText));
        Assert.That(actualAccessoriesText, Is.EqualTo(expectedAccessoriesText));
        Assert.That(actualHeadphonesText, Is.EqualTo(expectedHeadphonesText));
        Assert.That(_navigationBar.GetPageTitle(), Is.EqualTo(expectedHeadphonePageTitle));
    }
    
    // Select Brand filter option and filter headphones by the 1st item in Brand list.
    [Test]
    [Order(3)]
    public void FilterHeadPhonesByFirstBrandOfList()
    {
        //Arrange
        var expectedBrandText = "Brand";
        var expectedFirstBrandOptionText = "Apple";

        // Act
        var actualBrandText = _headphonesPage.SelectBrandMenuOption();
        var actualFirstBrandOptionText = _headphonesPage.SelectFirstBrandName();

        //Assert
        Assert.That(actualBrandText.Contains(expectedBrandText));
        Assert.That(actualFirstBrandOptionText, Is.EqualTo(expectedFirstBrandOptionText));
    }

    // Select last items of the Headphone list.
    [Test]
    [Order(4)]
    public void SelectLastHeadphoneItem()
    {
        //Arrange
        var expectedProductTitle = "Apple EarPods (USB-C)";

        //Act
        var actualProductTitle = _headphonesPage.SelectLastHeadphone();
        _productTitleFromHeadphonePage = actualProductTitle;

        //Assert
        Assert.That(actualProductTitle, Is.EqualTo(expectedProductTitle));
    }

    // Add selected item to cart.
    [Test]
    [Order(5)]
    public void AddItemToCart()
    {
        //Arrange
        var expectedDetailsPageTitle = "Apple EarPods (USB-C) – Headphones | Swisscom";
        
        //Act
        _detailsPage.AddProductToCart();
        _detailsPage.ContinueShopping();

        //Assert
        Assert.That(_detailsPage.GetPageTitle(), Is.EqualTo(expectedDetailsPageTitle));
    }

    // Click Shopping Cart option in Navigation menu and verify the Product Title from Headphone page and Cart page.
    [Test]
    [Order(6)]
    public void ClickTroleyIconFromNavBar() 
    {
        //Act
        _navigationBar.ClickShoppingBasket();
        var allProducts = _cartPage.GetShoppingCartItems();

        Assert.True((allProducts.Any(x => x.Text == _productTitleFromHeadphonePage)));
    }

    public void Dispose() => _driver.Dispose();
    
}


