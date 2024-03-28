using WpfApp2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void AuthTestSuccess()
        {
            var page = new AuthPage();
            //Assert.IsTrue(page.Auth("Elizor@gmai,com", "yntiRS"));
            //Assert.IsTrue(page.Auth("Vladlena@gmai.com", "07i7Lb"));
            //Assert.IsTrue(page.Auth("Adam@gmai.com", "7SP9CV"));
            Assert.IsFalse(page.Auth("Elizor@gmai,com", "123"));
            Assert.IsFalse(page.Auth("Elizor@gmai,com", "123"));
            Assert.IsFalse(page.Auth("Elizor@gmai,com", "123"));
            Assert.IsFalse(page.Auth("Elizor@gmai,com", "yntiRS", "12345"));
        }
    }
}
