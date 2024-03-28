using WpfApp2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            var page = new AuthPage();
            Assert.IsTrue(page.Auth("Vladlena@gmai.com", "07i7Lb"));
            Assert.IsTrue(page.Auth("Adam@gmai.com", "7SP9CV"));
            Assert.IsFalse(page.Auth("Kar@gmai.com", "6QF1WB"));
            Assert.IsTrue(page.Auth("Elizor@gmai,com", "yntiRS"));
            Assert.IsTrue(page.Auth("Yli@gmai.com", "GwffgE"));
            Assert.IsFalse(page.Auth("Victoria@gmai.com", "9mlPQJ"));
            Assert.IsTrue(page.Auth("Vasilisa@gmai.com", "d7iKKV"));
            Assert.IsTrue(page.Auth("Galina@gmai.com", "8KC7wJ"));
            Assert.IsTrue(page.Auth("Miron@@gmai,com", "x58OAN"));
            Assert.IsTrue(page.Auth("Anisa@gmai.com", "Wh4OYm"));
            Assert.IsFalse(page.Auth("user1", "12345"));

        }
    }
}
