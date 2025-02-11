using Vinca_Projekat;
using Windows.Foundation.Metadata;

namespace Vinca_Projekat.Test
{
    [TestClass]
    public sealed class XLMethodsTest
    {
        private MainForm form_;
        [TestInitialize]
        public void InitializeTest()
        {
            form_ = new MainForm();
            form_.setupTest();
        }

        [TestMethod]
        public void ReadMethods()
        {
            form_.Show();
            form_.setupTest();
            form_.ImportExperimentData();
            List<int> result = form_.readData();

            int x = 0;
            foreach (int val in result) 
            {
               Assert.AreEqual(x+1, val);
               x = (x + 1) % 3;
            }
            form_.Dispose();
        }

        [TestMethod]
        public void WriteMethods()
        {
            MainForm form = new MainForm();

            form_.FillData();
            
        }
    }
}
