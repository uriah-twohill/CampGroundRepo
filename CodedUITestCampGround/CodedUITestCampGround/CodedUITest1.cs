using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace CodedUITestCampGround
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void CodedUITestLoginRegister()
        {

            this.UIMap.AssertMethod9();

            this.UIMap.AssertMethod8();

            this.UIMap.AssertMethod7();

            this.UIMap.AssertMethod6();

            this.UIMap.AssertMethod5();

            this.UIMap.AssertMethod4();

            this.UIMap.AssertMethod3();

            this.UIMap.AssertMethod2();

            this.UIMap.AssertMethod1();
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }

        [TestMethod]
        public void CodedUITestHomePage()
        {

            this.UIMap.AssertMethod10();
            this.UIMap.AssertMethod11();
            this.UIMap.AssertMethod12();
            this.UIMap.AssertMethod13();
            this.UIMap.AssertMethod14();
            this.UIMap.AssertMethod15();

        }
        [TestMethod]
        public void CodedUITestCustomers()
        {

            this.UIMap.AssertMethod16();
            this.UIMap.AssertMethod17();
            this.UIMap.AssertMethod18();
            this.UIMap.AssertMethod19();
            this.UIMap.AssertMethod20();
            this.UIMap.AssertMethod21();
            this.UIMap.AssertMethod22();
            this.UIMap.AssertMethod23();
            this.UIMap.AssertMethod24();
            this.UIMap.AssertMethod25();

        }
        [TestMethod]
        public void CodedUITestProducts()
        {

            this.UIMap.AssertMethod26();
            this.UIMap.AssertMethod27();
            this.UIMap.AssertMethod28();
            this.UIMap.AssertMethod29();
            this.UIMap.AssertMethod30();
            this.UIMap.AssertMethod31();
            this.UIMap.AssertMethod32();
            this.UIMap.AssertMethod33();
            this.UIMap.AssertMethod34();
            this.UIMap.AssertMethod35();
            this.UIMap.AssertMethod36();
            this.UIMap.AssertMethod37();
            this.UIMap.AssertMethod38();
            this.UIMap.AssertMethod39();
            this.UIMap.AssertMethod40();
            this.UIMap.AssertMethod41();

        }
        [TestMethod]
        public void CodedUITestOrders()
        {

            this.UIMap.AssertMethod42();
            this.UIMap.AssertMethod43();
            this.UIMap.AssertMethod44();
            this.UIMap.AssertMethod45();
            this.UIMap.AssertMethod46();
            this.UIMap.AssertMethod47();
            this.UIMap.AssertMethod48();
            this.UIMap.AssertMethod49();
            this.UIMap.AssertMethod50();
            this.UIMap.AssertMethod51();
            this.UIMap.AssertMethod52();
            this.UIMap.AssertMethod53();

        }


        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
