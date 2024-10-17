using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiamondKata;
using System.Collections.Generic;

namespace DiamondKataTests
{
    [TestClass]
    public class TestDiamond
    {
        List<string> args = new List<string>();

        [TestMethod]
        public void TestCharIsValid()
        {
            Assert.IsFalse(Diamond.CharIsValid(""), "Empty string is invalid");

            Assert.IsFalse(Diamond.CharIsValid("?"), "Non alphabetic character is invalid");

            Assert.IsFalse(Diamond.CharIsValid("AA"), "More than one character is invalid");

            Assert.IsFalse(Diamond.CharIsValid("a"), "Lower case is invalid by default");

            Assert.IsTrue(Diamond.CharIsValid("a", false), "Lower case is valid by if checkCaase is set false");

            Assert.IsTrue(Diamond.CharIsValid("A"), "Upper case alphabetic is valid");
        }

        [TestMethod]
        public void TestMakeDiamond()
        {
            var rows = new List<string>();

            Diamond.DiamondChar = "E";
            rows = Diamond.MakeDiamond();

            Assert.AreEqual(9, rows.Count, "Incorrect number of rows");

            Assert.AreEqual(9, rows[4].Length, "Middle row is incorrect length");

            Assert.AreEqual("E       E", rows[4], "Middle row has incorrect value");

            Assert.AreEqual(rows[3], rows[5], "Rows 3 and 5 are different");
        }

        [TestMethod]
        public void TestShowDiamond()
        {

            args.Clear();
            Assert.IsFalse(Diamond.ShowDiamond(args.ToArray()), "Args cannot be empty");

            SetArg(string.Empty);
            Assert.IsFalse(Diamond.ShowDiamond(args.ToArray()), "Empty string is invalid");

            SetArg("?");
            Assert.IsFalse(Diamond.ShowDiamond(args.ToArray()), "Non alphabetic characters are invalid");

            SetArg("A");
            Assert.IsTrue(Diamond.ShowDiamond(args.ToArray()), "Upper case alphabetic characters are valid");

            SetArg("a");
            Assert.IsTrue(Diamond.ShowDiamond(args.ToArray()), "Lower case alphabetic characters are valid");

            SetArg("A");
            args.Add("?");
            Assert.IsTrue(Diamond.ShowDiamond(args.ToArray()), "Extra parameters will be ignored");
        }

        [TestMethod]
        public void TestMakeDiamondRow()
        {
            Diamond.DiamondChar = "A";
            Assert.AreEqual("A", Diamond.MakeDiamondRow("A"), "Invalid row for A, A");

            Diamond.DiamondChar = "E";
            Assert.AreEqual("  C   C", Diamond.MakeDiamondRow("C"), "Invalid row for E, C");
        }

        private void SetArg(string val)
        {
            args.Clear();
            args.Add(val);
        }

    }
}
