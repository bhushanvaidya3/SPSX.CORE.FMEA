using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPSX.CORE.FMEA.API.Implementation;

namespace SPSX.CORE.FMEA.TESTS
{
    [TestClass]
    public class ControlMethodFormTests
    {

        private ManageControlMethodForm _SystemUnderTest;

        public ManageControlMethodForm SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new ManageControlMethodForm();
                }
                return _SystemUnderTest;
            }
        }

        [TestInitialize]
        public void TestInitialize(){
            _SystemUnderTest = null;
        }

        [TestMethod]
        public void GetMessage_TEST()
        {
            //arrange
            string expected = "Hello from interface!";

            //act
            string actual = SystemUnderTest.GetMessage(); //"Hello message!";

            //assert
            Assert.AreEqual(expected, actual, "Messages do not match");
        }
    }
}
