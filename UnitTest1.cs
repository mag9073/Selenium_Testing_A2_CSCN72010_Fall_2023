//*/////////////////////////////////////////////*//
// CSCN72010 F23 Assignment 2, Part B            //
// Selenium Testing OCT 30, 2023                 //   
// Michelle Gordon                               //
//*/////////////////////////////////////////////*//

// please note : 
// this website does allow users to register for the event called "THE Event!" and does registrants to provide their first name, last name, address, city, province, postal code,
// phone number and email address. Registrants are able to provice the number of participants attending and the day(s) they want to attend.

// HOWEVER
//
// Number of participants allowed - negative and 0 participants can be selected in the field, but error safeguards won't allow it in the end. 
//
// Prices incorrect on Registration Details page : should be 450$ for day 1 (site says 350.67) and 350$ for day 2 (site says 450.67).
// Prices incorrect on Registration Details page : day 2 shows up incorrectly on Registration Details page as day 3 
// Prices incorrect on Registration Details page : for 2 days is incorrect at 7500.67, should be 750 (also shouldn't be 800)
//
// Discounts incorrect : day 1 for more than 5 participants (we will use 6 participants here) should be around 2430 (2700-270), but shows up as 1890.67 on Registration Details page
// Discounts incorrect: day 2 for 6 participants should be around 1890 (2100-210), but shows up as 2430.67
// Discounts incorrect : day 1 and 2 for 6 participants should be around 4050 (assuming it is 750 for both days, should be 4500-450), but shows up at 40500.67
// (including the double day discount and the 10% discount for more than 5 participants). Also, it would be helpful to notify registrants there is a discount.
//
// links at top: clicking on "THE Event!" link after registering returns back to the first index page. this is also true for the view registration page.
// links at top: clicking on the home page returns error "500 Internal Server Error" from the index page (not correct). the link returns to the index page if on the view registration page.
// links at top: clicking on the Conestoga College (should be the main page) is in fact a link to Conestoga College's "College policies, procedures, practices and guidelines" page and 
// the link is only visible on the index page and is missing from the view registration page.

//
// Provinces list: provinces are not in increasing alphabetical order in the drop down list. Also Manitoba is missing, Alberta is misspelled, Newfoundland usually includes Labrador
// as the name (if we are being picky), British Columbia is transposed, Northwest Territories is written as "NorthWest Territories" (if we are being picky), Yukon is written as "Yukon Territory"
// (Nunavut is not written as "Nunavut Territory" if we are being picky). 
//
// Phone number field: The label for phone number is incorrect: "fone" is incorrect spelling of the word phone.
// Phone number field: Phone Number must follow the patterns 111-111-1111 or (111)111-1111 per the requirements. The phone error label states the two variations are acceptable,
// but the field only accepts the 111-111-1111 form (and not the (111)111-1111 form).
//
// The postal code field accepts postal codes in the format of A1A 1A1
//
// Registration Details page: after registering, the number of participants is correctly shown on the Registration Details page.
// Registration Details page: after registering, the days selected is correctly shown on the Registration Details page for Day 1 and Both Days, but incorrectly for Day 2 (it shows up as "Day 3").
// Registration Details page: after registering, the total price is incorrectly shown on the Registration Details page for all choices. There appears to be an extra fee or tax of .67 also. 
//
// Prices incorrect on Registration Details page : should be 450$ for day 1 (site says 350.67) and 350$ for day 2 (site says 450.67). 
// Prices incorrect on Registration Details page : for 2 days is incorrect at 7500.67, should be 750 (also shouldn't be 800).
//
// Registration Details page: after registering, the registrant should be able to go back to the main page after registering through the link. There are two links at the top right: When you click on "Home" it sends you back to the registration
// page, but it is blank. When you click on the "THE Event!" link, it also sends you back to the registration page, and it is also blank. If the registrant were to use the "back button"  of the browser, they would be able to return to the previous page with the data they filled out.
//
// There is also no "undo" button when the registrant fills out information and would like to change their mind about number of attendees (etc...).


namespace SeleniumtestingA2
{
    using Microsoft.VisualBasic;
    using OpenQA.Selenium; // these three references have to be created for selenium to work with VS/MSTest 
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Data;

    [TestClass]
    public class ProvincesUnitTests // this will test the provinces in the drop down. all other selections will remain the same. 
    {
        IWebDriver driver; // create an iwebdriver class and a driver object (for selenium)

        [TestMethod]
        public void province_AB_Fail() // Alberta - will fail because of spellling 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe");  // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith");    // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South");   // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo");          // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province")));   // find provinces and select province element given.
            dropDown1.SelectByText("Alberta");                                         // test provinces in this section

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2");    // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555");   // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com");   // find email and enter selction sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));
            numfield1.SendKeys("1");    // find participants and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));
            dropDown2.SelectByText("Day 1");  // find days and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click();  // find register button and click on it. 

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html"  // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare 

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void province_BC_Fail()  // British Columbia - will fail because name transposed
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe");    // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith");   // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South");  // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo");  // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province")));  // find province and select province element given.
            dropDown1.SelectByText("British Columbia");                                         // test provinces in this section

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2");  // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555");  // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));
            numfield1.SendKeys("1"); // find participants and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));
            dropDown2.SelectByText("Day 1"); // find days and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find register element and click on it.

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html"  // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare.

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void province_MB_Fail() // Manitoba - will fail because missing from drop-down (extra test)
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line


            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); // find province drop-down and select element given.
            dropDown1.SelectByText("Manitoba");                                         // test provinces in this section

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));
            numfield1.SendKeys("1"); // find participants and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));
            dropDown2.SelectByText("Day 1"); // find days and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find register element and then click on it. 

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html"  // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void province_NB_Pass() // New Brunswick - will pass
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 


            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); //select province from drop-down.
            dropDown1.SelectByText("New Brunswick");                                         // test provinces in this section

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com");  // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));
            numfield1.SendKeys("1");  // find participants and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));
            dropDown2.SelectByText("Day 1"); // find days and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click it.

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html"  // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void province_NL_Pass() // Newfoundland - will pass
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe");   // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent.  

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South");  // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province")));  // select province from the drop-down.
            dropDown1.SelectByText("Newfoundland");                                         // test provinces in this section

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));
            numfield1.SendKeys("1"); // find participants and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));
            dropDown2.SelectByText("Day 1"); // find days and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it.

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html"  // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }


        [TestMethod]
        public void province_NT_Pass() // NorthWest Territories - will pass
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province")));  // select province from drop-down.
            dropDown1.SelectByText("NorthWest Territories");                                         // test provinces in this section NorthWest Territories

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));
            numfield1.SendKeys("1"); // find participants and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));
            dropDown2.SelectByText("Day 1"); // find days and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it.

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html"  // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare. 

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void province_NS_Pass() // Nova Scotia - will pass
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); // find provinces and enter selection.
            dropDown1.SelectByText("Nova Scotia");                                         // test provinces in this section

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));
            numfield1.SendKeys("1");  // find participants and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));
            dropDown2.SelectByText("Day 1"); // // find days and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html"  // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare
             
            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void province_NU_Pass() // Nunavut Territory - will pass
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); // find provinces and enter selection. 
            dropDown1.SelectByText("Nunavut");                                         // test provinces in this section

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));
            numfield1.SendKeys("1"); // find participants and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));
            dropDown2.SelectByText("Day 1"); // find days and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html"  // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void province_ON_Pass() // Ontario - will pass
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line


            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); // find provinces and select from drop-down.
            dropDown1.SelectByText("Ontario");                                         // test provinces in this section

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));
            numfield1.SendKeys("1"); // find participants and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));
            dropDown2.SelectByText("Day 1"); // find days and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html"  // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void province_PE_Pass() // Prince Edward Island - will pass
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); // find provinces and select from drop-down.
            dropDown1.SelectByText("Prince Edward Island");                                         // test provinces in this section

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal codes and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));
            numfield1.SendKeys("1"); // find participants and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));
            dropDown2.SelectByText("Day 1"); // find days and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html"  // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare. 

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void province_QC_Pass() // Quebec - will pass
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe");  // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); // find provinces and select from drop-down.
            dropDown1.SelectByText("Quebec");                                         // test provinces in this section

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));
            numfield1.SendKeys("1"); // find participants and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered"))); // find provinces and select from drop-down.
            dropDown2.SelectByText("Day 1");

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html"  // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare. 

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void province_SK_Pass() // Saskatechewan- will pass
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South");  // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); // find provinces and select from drop-down.
            dropDown1.SelectByText("Saskatchewan");                                         // test provinces in this section

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));
            numfield1.SendKeys("1"); // find participants and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));
            dropDown2.SelectByText("Day 1"); // find days and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html"  // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void province_YT_Pass() // Yukon Territory - will pass
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); // find provinces and select from drop-down. 
            dropDown1.SelectByText("Yukon Territory");                                         // test provinces in this section

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));
            numfield1.SendKeys("1"); // find participants and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));
            dropDown2.SelectByText("Day 1"); // find days and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html"  // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare. 

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }
    }

    [TestClass]
    public class ParticipantsUnitTests // these tests look at the participant numbers and will select from 1-6 
    {
        IWebDriver driver; // create an iwebdriver class and a driver object (for selenium)

        [TestMethod]
        public void participant_1_ON_Pass() // participant 1 Ontario will pass because numbers correct, only testing it opens 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); // find provinces and select from drop-down.
            dropDown1.SelectByText("Ontario");

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants")); // find participants and enter selection sent. 
            numfield1.SendKeys("1");                                     // test participant number here 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered"))); 
            dropDown2.SelectByText("Day 1"); // find days and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html"  // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void participant_2_ON_Pass() // participant 2 Ontario will pass because numbers correct, only testing it opens 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province")));
            dropDown1.SelectByText("Ontario"); // find provinces and select from drop-down. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants")); // find participants and enter selection sent. 
            numfield1.SendKeys("2");                                     // test participant number here 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));
            dropDown2.SelectByText("Day 1"); // find days and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html"  // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void participant_3_ON_Pass() // participant 3 Ontario will pass because numbers correct, only testing it opens 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe");  // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province")));
            dropDown1.SelectByText("Ontario"); // find provinces and select from drop-down.

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information
             
            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants")); // find participants and enter selection sent. 
            numfield1.SendKeys("3");                                     // test participant number here 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));
            dropDown2.SelectByText("Day 1"); // find days and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html"  // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void participant_4_ON_Pass() // participant 4 Ontario will pass because numbers correct, only testing it opens 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent.  

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province")));
            dropDown1.SelectByText("Ontario"); // find provinces and select from drop-down. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2");  // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information
             
            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants")); // find participants and enter selection sent. 
            numfield1.SendKeys("4");                                     // test participant number here 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));
            dropDown2.SelectByText("Day 1"); // find days and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html" // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }


        [TestMethod]
        public void participant_5_ON_Pass() // participant 5 Ontario will pass because numbers correct, only testing it opens 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); // find provinces and select from drop-down. 
            dropDown1.SelectByText("Ontario");

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants")); // find participants and enter selection sent. 
            numfield1.SendKeys("5");                                     // test participant number here 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));
            dropDown2.SelectByText("Day 1"); // find days and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html"  // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare. 

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void participant_6_ON_Pass() // participant 6 Ontario will pass because numbers correct, only testing it opens 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo");  // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province")));
            dropDown1.SelectByText("Ontario"); // find provinces and select from drop-down.

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com");// find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants")); // find participants and enter selection sent. 
            numfield1.SendKeys("6");                                     // test participant number here 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));
            dropDown2.SelectByText("Day 1"); // find days and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            String actual = driver.Url; // "https://localhost/register/index.html"  // driver.url
            String expected = "https://localhost/register/viewRegistration.html";
            Assert.AreEqual(actual, expected); // compare. 

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }
    }


    [TestClass]
    public class PricesandLinksUnitTests // this tests the pricing schedule and then the links on the viewRegistration page. 
    {
        IWebDriver driver; // create an iwebdriver class and a driver object (for selenium)

        [TestMethod]
        public void day_1_Person_1_Price_Fail() // price for 1 person, day 1, fail =  wrong price in site. 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South");  // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province")));
            dropDown1.SelectByText("Ontario"); // find provinces and enter in the drop-down. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555");  // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants")); // find participants and enter selection sent. 
            numfield1.SendKeys("1");                // 1 person attending                 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered"))); // find days and enter selection sent. 
            dropDown2.SelectByText("Day 1");   // Day 1

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            IWebElement valPrice = driver.FindElement(By.Name("price")); // this is the price element on the view registration page
            String actualVal = valPrice.GetAttribute("value");     // this is the actual value found 
            String expectedVal = "$450"; // calculation $450 * 1, this is the expected value for 1 person
            Assert.AreEqual(expectedVal, actualVal);  // compare the expected and actual

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void day_1_Person_2_Price_Fail() // price for 2 people, day 1, fail =  wrong price in site. 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province")));
            dropDown1.SelectByText("Ontario"); // find the provinces and select from the drop-down. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information
             
            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants")); // find participants and enter selection sent. 
            numfield1.SendKeys("2");  // 2 people attending

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered"))); // find days and enter selection sent. 
            dropDown2.SelectByText("Day 1");  // Day 1

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and then click on it. 

            // Assert
            IWebElement valPrice = driver.FindElement(By.Name("price")); // this is the price element on the view registration page
            String actualVal = valPrice.GetAttribute("value");     // this is the actual value found 
            String expectedVal = "$900"; // calculation $450 * 2, this is the expected value for 2 people
            Assert.AreEqual(expectedVal, actualVal);  // compare the expected and actual

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }
        [TestMethod]
        public void day_1_Person_4_Price_Fail() // price for 4 people, day 1, fail =  wrong price in site. 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province")));
            dropDown1.SelectByText("Ontario"); // find provinces and select from drop-down.

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants")); // find participants and enter selection sent. 
            numfield1.SendKeys("4");  // 4 people attending

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected  
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered"))); // find days and enter selection sent. 
            dropDown2.SelectByText("Day 1");  // Day 1

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            IWebElement valPrice = driver.FindElement(By.Name("price")); // this is the price element on the view registration page
            String actualVal = valPrice.GetAttribute("value");     // this is the actual value found 
            String expectedVal = "$1800"; // calculation $450 * 4, this is the expected value for 2 people
            Assert.AreEqual(expectedVal, actualVal);  // compare the expected and actual

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }
        [TestMethod]
        public void day_2_Person_1_Price_Fail() // price for 1 person, day 2, fail =  wrong price in site. 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe");  // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province")));
            dropDown1.SelectByText("Ontario"); // find provinces and select from drop-down.

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));  // find participants and enter selection sent. 
            numfield1.SendKeys("1");                // 1 person attending                 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered"))); // find days and enter selection sent. 
            dropDown2.SelectByText("Day 2");   // Day 2

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            IWebElement valPrice = driver.FindElement(By.Name("price")); // this is the price element on the view registration page
            String actualVal = valPrice.GetAttribute("value");     // this is the actual value found 
            String expectedVal = "$350"; // calculation $350 * 1, this is the expected value for 1 person
            Assert.AreEqual(expectedVal, actualVal);  // compare the expected and actual

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void day_2_Person_2_Price_Fail() // price for 2 people, day 2, fail =  wrong price in site. 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province")));
            dropDown1.SelectByText("Ontario"); // find provinces and select from drop-down. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants")); // find participants and enter selection sent. 
            numfield1.SendKeys("2");  // 2 people attending

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered"))); // find days and enter selection sent. 
            dropDown2.SelectByText("Day 2");  // Day 2

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmimt and click on it. 

            // Assert
            IWebElement valPrice = driver.FindElement(By.Name("price")); // this is the price element on the view registration page
            String actualVal = valPrice.GetAttribute("value");     // this is the actual value found 
            String expectedVal = "$700"; // calculation $350 * 2, this is the expected value for 2 people
            Assert.AreEqual(expectedVal, actualVal);  // compare the expected and actual

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }
        [TestMethod]
        public void day_2_Person_4_Price_Fail() // price for 4 people, day 2, fail =  wrong price in site. 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe");  // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province")));
            dropDown1.SelectByText("Ontario"); // find provinces and select from drop-down. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2");  // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants")); // find participants and enter selection sent. 
            numfield1.SendKeys("4");  // 4 people attending

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered"))); // find days and enter selection sent. 
            dropDown2.SelectByText("Day 2");  // Day 2

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            IWebElement valPrice = driver.FindElement(By.Name("price")); // this is the price element on the view registration page
            String actualVal = valPrice.GetAttribute("value");     // this is the actual value found 
            String expectedVal = "$1400"; // calculation $350 * 4, this is the expected value for 2 people
            Assert.AreEqual(expectedVal, actualVal);  // compare the expected and actual

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void both_Days_Person_1_Price_Fail() // price for 1 person, both days, fail =  wrong price in site. 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith");  // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); // find provinces and select from drop-down.
            dropDown1.SelectByText("Ontario");

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants")); // find participants and enter selection sent. 
            numfield1.SendKeys("1");                // 1 person attending                 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered"))); // find days and enter selection sent. 
            dropDown2.SelectByText("Both days");   // Both Days

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            IWebElement valPrice = driver.FindElement(By.Name("price")); // this is the price element on the view registration page
            String actualVal = valPrice.GetAttribute("value");     // this is the actual value found 
            String expectedVal = "$750"; // calculation $750 * 1, this is the expected value for 1 person
            Assert.AreEqual(expectedVal, actualVal);  // compare the expected and actual

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void both_Days_Person_2_Price_Fail() // price for 2 people, both days, fail =  wrong price in site. 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe"); // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South"); // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo"); // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); // find provinces and select from drop-down.
            dropDown1.SelectByText("Ontario");

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2");  // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));   // find participants and enter selection sent. 
            numfield1.SendKeys("2");  // 2 people attending

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered"))); // find days and enter selection sent. 
            dropDown2.SelectByText("Both days");  // Both Days

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            IWebElement valPrice = driver.FindElement(By.Name("price")); // this is the price element on the view registration page
            String actualVal = valPrice.GetAttribute("value");     // this is the actual value found 
            String expectedVal = "$1500"; // calculation $750 * 2, this is the expected value for 2 people
            Assert.AreEqual(expectedVal, actualVal);  // compare the expected and actual

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }
        [TestMethod]
        public void both_Days_Person_4_Price_Fail() // price for 4 people, both days, fail =  wrong price in site. 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe");   // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith");  // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South");  // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo");  // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); // find provinces and select from drop-down.
            dropDown1.SelectByText("Ontario"); 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2");  // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555");  // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com");  // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));    // find participants and enter selection sent. 
            numfield1.SendKeys("4");  // 4 people attending 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));   // find days and enter selection sent. 
            dropDown2.SelectByText("Both days");  // Both Days

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            IWebElement valPrice = driver.FindElement(By.Name("price")); // this is the price element on the view registration page
            String actualVal = valPrice.GetAttribute("value");     // this is the actual value found 
            String expectedVal = "$3000"; // calculation $750 * 4, this is the expected value for 2 people
            Assert.AreEqual(expectedVal, actualVal);  // compare the expected and actual

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }
        //
        [TestMethod]
        public void day_1_Person_6_Price_Fail() // price for 6 people, day 1, fail =  wrong price in site. 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe");    // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith");   // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South");  // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo");  // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); // find province and select from drop-down.
            dropDown1.SelectByText("Ontario");

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2");   // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555");  // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com");  // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));  // find participants and enter selection sent. 
            numfield1.SendKeys("6");                // 6 person attending                 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));   // find days and enter selection sent. 
            dropDown2.SelectByText("Day 1");   // Both Days

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));  
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            IWebElement valPrice = driver.FindElement(By.Name("price")); // this is the price element on the view registration page
            String actualVal = valPrice.GetAttribute("value");     // this is the actual value found 
            String expectedVal = "$2430"; // calculation $450 * 0.9 * 6, this is the expected value for 6 person
            Assert.AreEqual(expectedVal, actualVal);  // compare the expected and actual

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void day_2_Person_6_Price_Fail() // price for 6 people, day 2, fail =  wrong price in site. 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe");  // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith");  // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South");  // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo");  // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); // find provinces and select from drop-down.
            dropDown1.SelectByText("Ontario");

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2");  // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555");  // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com");  // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));  // find participants and enter selection sent. 
            numfield1.SendKeys("6");  // 6 people attending

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));  // find days and enter selection sent. 
            dropDown2.SelectByText("Day 2");  // Day 2

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            IWebElement valPrice = driver.FindElement(By.Name("price")); // this is the price element on the view registration page
            String actualVal = valPrice.GetAttribute("value");     // this is the actual value found 
            String expectedVal = "$1890"; // calculation $350 * 0.9 * 6, this is the expected value for 6 people
            Assert.AreEqual(expectedVal, actualVal);  // compare the expected and actual

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }
        [TestMethod]
        public void both_Days_Person_6_Price_Fail() // price for 6 people, both days, fail =  wrong price in site. 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe");  // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith");  // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South");  // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo");  // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); // find provinces and select from drop-down.
            dropDown1.SelectByText("Ontario");

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2");  // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555");  // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com");  // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));  // find participants and enter selection sent. 
            numfield1.SendKeys("6");  // 6 people attending

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));  // find days and enter selection sent. 
            dropDown2.SelectByText("Both days");  // Both Days

            Thread.Sleep(1000); // give it time to enter information

            // Act 
            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Assert
            IWebElement valPrice = driver.FindElement(By.Name("price")); // this is the price element on the view registration page
            String actualVal = valPrice.GetAttribute("value");     // this is the actual value found 
            String expectedVal = "$4050"; // calculation $750 * 0.9 * 6, this is the expected value for 6 people
            Assert.AreEqual(expectedVal, actualVal);  // compare the expected and actual


            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void day_1_Person_1_Event_Link_Pass() // price for 1 person, day 1, test for THE Event, assume index = home = event. this works from the viewRegistration page and the index page
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe");  // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith"); // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South");  // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo");  // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); // find provinces and select from drop-down.
            dropDown1.SelectByText("Ontario");

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2");  // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555");  // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com");  // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));  // find participants and enter selection sent. 
            numfield1.SendKeys("1");                // 1 person attending                 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));  // find days and enter selection sent. 
            dropDown2.SelectByText("Day 1");   // Day 1

            Thread.Sleep(1000); // give it time to enter information


            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it.


            // Act

            IWebElement homeLink = driver.FindElement(By.LinkText("THE Event!"));
            homeLink.Click(); // find the "THE Event!" link and click on it. 


            // Assert 

            String actual = driver.Url;  // driver.url  (actual link) 
            String expected = "https://localhost/register/index.html"; // this is what is expected
            Assert.AreEqual(actual, expected); // compare the two links 


            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void day_1_Person_1_Home_Link_Pass() // price for 1 person, day 1, test for home link, assume index = home = event. this works from the viewRegistration page, but not the index page. 
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe");   // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith");  // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South");  // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo");  // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province")));
            dropDown1.SelectByText("Ontario"); // find provinces and select from the drop-down.

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2");   // find postal code and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555");  // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com");  // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants"));   // find participants and enter selection sent. 
            numfield1.SendKeys("1");                // 1 person attending                 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered")));  // find days and enter selection sent. 
            dropDown2.SelectByText("Day 1");   // Day 1

            Thread.Sleep(1000); // give it time to enter information


            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find the btnSubmit and click on it. 


            // Act 

            IWebElement homeLink = driver.FindElement(By.LinkText("Home"));
            homeLink.Click(); // find the Home page link and click on it. 

            // Assert

            String actual = driver.Url;  // driver.url  (actual link) 
            String expected = "https://localhost/register/index.html"; // this is the expected link 
            Assert.AreEqual(actual, expected); // compare



            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

        [TestMethod]
        public void day_1_Person_1_CC_Link_Fail() // price for 1 person, day 1, test for CC link, will fail as it's not there on the viewRegistration page. It is the wrong link from the index page also.
        {
            ChromeOptions handlingSSL = new ChromeOptions();                       // may need this if ssl issues (4 lines) 
            handlingSSL.AcceptInsecureCertificates = true;                         // 2nd 
            driver = new ChromeDriver(handlingSSL);                                // 3rd 
            driver.Navigate().GoToUrl("https://localhost/register/index.html");    // 4th line

            // Arrange
            IWebElement inputField1 = driver.FindElement(By.Name("firstName")); // can identify fields by id or name. for simplicity, will use name only
            inputField1.SendKeys("Joe");   // find first name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information 

            IWebElement inputField2 = driver.FindElement(By.Name("lastName"));
            inputField2.SendKeys("Smith");  // find last name and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField3 = driver.FindElement(By.Name("address"));
            inputField3.SendKeys("100 Main St South");  // find address and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField4 = driver.FindElement(By.Name("city"));
            inputField4.SendKeys("Waterloo");   // find city and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            // put these in alphabetical order please! 
            String[] provinceValues = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland", "NorthWest Territories", "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon Territory" };
            SelectElement dropDown1 = new SelectElement(driver.FindElement(By.Name("province"))); // find provinces and select from drop-down.
            dropDown1.SelectByText("Ontario");

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField5 = driver.FindElement(By.Name("postalCode"));
            inputField5.SendKeys("N2J 2W2"); // find postal code  and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField6 = driver.FindElement(By.Name("phone"));
            inputField6.SendKeys("519-555-5555"); // find phone and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement inputField7 = driver.FindElement(By.Name("email"));
            inputField7.SendKeys("js@email.com"); // find email and enter selection sent. 

            Thread.Sleep(1000); // give it time to enter information

            IWebElement numfield1 = driver.FindElement(By.Name("numberOfParticipants")); // find participants and enter selection sent. 
            numfield1.SendKeys("1");                // 1 person attending                 

            Thread.Sleep(1000); // give it time to enter information

            String[] daysValues = { "Day 1", "Day 2", "Both days" }; // these are the strings expected 
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Name("daysRegistered"))); // find days and enter selection sent. 
            dropDown2.SelectByText("Day 1");   // Day 1

            Thread.Sleep(1000); // give it time to enter information


            IWebElement registerNowButton = driver.FindElement(By.Id("btnSubmit"));
            registerNowButton.Click(); // find btnSubmit and click on it. 

            // Act 
            IWebElement homeLink = driver.FindElement(By.LinkText("Conestoga College Main Page")); // this is missing, so it will fail
            homeLink.Click(); // find the Conestoga College link and click on it. 

            // Assert

            String actual = driver.Url;  // driver.url  (actual link) 
            String expected = "https://www.conestogac.on.ca/"; // this is what is expected 
            Assert.AreEqual(actual, expected); // compare

            Thread.Sleep(6000); // let's have extra time to see that it worked! 

            // please close 

            driver.Close();

        }

    }

}