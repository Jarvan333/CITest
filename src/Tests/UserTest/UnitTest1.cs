using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserTest {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            Assert.IsTrue(1 == 1);
        }
        [TestMethod]
        public void TestMethod2() {
            Assert.IsTrue(1 == 2);
        }
    }
}
