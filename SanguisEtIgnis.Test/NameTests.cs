using Microsoft.VisualStudio.TestTools.UnitTesting;
using SanguisEtIgnis.Core.Data;

namespace SanguisEtIgnis.Test
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void TestNameOverrides()
        {
            Commander c = new Commander() { ShortName = "Smith", LongName = "Fred Smith" };
            Assert.AreEqual("Smith", c.ShortName);
            Assert.AreEqual("Smith", c.Name);
            c.Name = "Bloggs";
            Assert.AreEqual("Bloggs", c.Name);
            // remove the name override
            c.Name = "";
            Assert.AreEqual("Smith", c.Name);
        }
    }
}