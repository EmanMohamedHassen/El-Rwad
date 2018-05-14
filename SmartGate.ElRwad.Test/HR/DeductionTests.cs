using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGate.ElRwad.BLL.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Tests
{
    [TestClass()]
    public class DeductionTests
    {
        [TestMethod()]
        public void GetAllDeductionsTest()
        {
           var test =  DeductionManager.Instance.GetAllDeductions();

            Assert.IsNotNull(test);
        }
    }
}