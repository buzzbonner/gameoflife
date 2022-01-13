using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Core.Tests
{
    [TestClass]
    public class ModelBuilderShould
    {
        [TestMethod]
        public void CreateModelUsingRawRepresentation()
        {
            var rawSample = new string[5];
            rawSample[0] = "_____";
            rawSample[1] = "__*__";
            rawSample[2] = "_***_";
            rawSample[3] = "__*__";
            rawSample[4] = "_____";

            var model = ModelBuilder.Build(rawSample, out string errorMessage);

            Assert.IsTrue(model![1, 2]);
            Assert.IsTrue(model![2, 1]);
            Assert.IsTrue(model![2, 2]);
            Assert.IsTrue(model![2, 3]);
            Assert.IsTrue(model![3, 2]);

            Assert.IsFalse(model![1, 0]);
            Assert.IsFalse(model![1, 1]);
            Assert.IsFalse(model![1, 3]);
            Assert.IsFalse(model![1, 4]);
            Assert.IsFalse(model![2, 0]);
            Assert.IsFalse(model![2, 4]);
            Assert.IsFalse(model![3, 0]);
            Assert.IsFalse(model![3, 1]);
            Assert.IsFalse(model![3, 3]);
            Assert.IsFalse(model![3, 4]);

            Assert.AreEqual(string.Empty, errorMessage);
        }

        [TestMethod]
        public void FailCreateModelWhenRawInvalidCharacters()
        {
            var rawSample = new string[5];
            rawSample[0] = "__£__";
            rawSample[1] = "__*__";
            rawSample[2] = "_***_";
            rawSample[3] = "__*__";
            rawSample[4] = "_____";

            var model = ModelBuilder.Build(rawSample, out string errorMessage);

            Assert.IsNull(model);
            Assert.AreEqual(errorMessage, "Invalid raw model");
        }
    }
}