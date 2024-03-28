using WpfApp2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void TestMethod1()
        {
            var page = new RegPage();
            Assert.IsTrue(page.reg("Хелин Кирюха Твичов", "helin139@gmai.com", "122133", true, "Менеджер А", "72224651234", "https://i.ytimg.com/vi/u6IFFUuzqe0/maxresdefault.jpg"));
            Assert.IsFalse(page.reg("Филенкова*Владлена*Олеговна", "Vladlena@gmai.com", "07i7Lb", false, "Менеджер А", "3341460151", "https://zashutki.ru/wp-content/uploads/8/f/4/8f449cd3c2ad51f56155aded3d82aac2.jpeg"));
            Assert.IsFalse(page.reg("Блеб", "sasavotik@gmail.com", "235246", true, "Администратор", "", ""));
        }
    }
}
