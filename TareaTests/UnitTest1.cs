namespace TareaTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string result = Tarea2.Program.Something();
            Assert.AreEqual("algo", result);
        }
    }
}