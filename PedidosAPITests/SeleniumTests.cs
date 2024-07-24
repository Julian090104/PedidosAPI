using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

public class RegistrarClientesTests : IDisposable
{
    private IWebDriver driver;
    private WebDriverWait wait;
    private Random random = new Random();

    public RegistrarClientesTests()
    {
        driver = new ChromeDriver();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        driver.Manage().Window.Size = new System.Drawing.Size(963, 728);
    }

    [Fact]
    public void RegistrarClientes()
    {
        int numeroDeClientes = 14; // Cambia este valor para insertar más clientes
        int idInicial = 1196; // Cambia este valor al ID inicial deseado

        // Abrir la página
        driver.Navigate().GoToUrl("http://localhost:4200");

        for (int i = 0; i < numeroDeClientes; i++)
        {
            int idActual = idInicial + i;

            // Hacer clic en el primer campo de entrada
            IWebElement firstInput = wait.Until(driver => driver.FindElement(By.CssSelector(".input-group:nth-child(1) > .form-control")));
            firstInput.Click();

            // Escribir en el primer campo (ID)
            IWebElement firstField = wait.Until(driver => driver.FindElement(By.CssSelector(".input-group > .ng-touched")));
            firstField.SendKeys(idActual.ToString());

            // Hacer clic en el segundo campo de entrada
            IWebElement secondInput = wait.Until(driver => driver.FindElement(By.CssSelector(".input-group:nth-child(2) > .form-control")));
            secondInput.Click();

            // Escribir en el segundo campo (nombre)
            IWebElement secondField = wait.Until(driver => driver.FindElement(By.CssSelector(".input-group:nth-child(2) > .form-control")));
            secondField.SendKeys(GenerateRandomString(5));

            // Hacer clic en el tercer campo de entrada
            IWebElement thirdInput = wait.Until(driver => driver.FindElement(By.CssSelector(".input-group:nth-child(3) > .form-control")));
            thirdInput.Click();

            // Escribir en el tercer campo (dirección)
            IWebElement thirdField = wait.Until(driver => driver.FindElement(By.CssSelector(".input-group:nth-child(3) > .form-control")));
            thirdField.SendKeys(GenerateRandomString(10));

            // Hacer clic en el cuarto campo de entrada
            IWebElement fourthInput = wait.Until(driver => driver.FindElement(By.CssSelector(".ng-pristine")));
            fourthInput.Click();

            // Escribir en el cuarto campo (teléfono)
            IWebElement fourthField = wait.Until(driver => driver.FindElement(By.CssSelector(".ng-pristine")));
            fourthField.SendKeys(GenerateRandomPhoneNumber());

            // Esperar un poco para asegurarse de que la confirmación se procese
            System.Threading.Thread.Sleep(20);

            // Hacer clic en el botón de agregar
            IWebElement addButton = wait.Until(driver => driver.FindElement(By.CssSelector(".btn")));
            addButton.Click();

            // Esperar un poco para asegurarse de que la confirmación se procese
            System.Threading.Thread.Sleep(1000);

            // Confirmar la acción
            IWebElement confirmButton = wait.Until(driver => driver.FindElement(By.CssSelector(".swal2-confirm")));
            confirmButton.Click();

            // Esperar un poco para asegurarse de que la confirmación se procese
            System.Threading.Thread.Sleep(1000);
        }
    }

    private string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    private string GenerateRandomPhoneNumber()
    {
        const string digits = "123456789";
        return new string(Enumerable.Repeat(digits, 10)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public void Dispose()
    {
        driver.Quit();
    }
}
