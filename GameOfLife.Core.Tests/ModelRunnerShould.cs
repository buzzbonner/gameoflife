using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Core.Tests
{
    [TestClass]
    public class ModelRunnerShould
    {
        [TestMethod]
        public void CreateEvolvedModelWithAllDeadCells()
        {
            var rawSample = new string[5];
            rawSample[0] = "_____";
            rawSample[1] = "__*__";
            rawSample[2] = "_***_";
            rawSample[3] = "__*__";
            rawSample[4] = "_____";

            var model = ModelBuilder.Build(rawSample, out string errorMessage);
            var evolvedModel = ModelRunner.EvolveComplete(model!);

            Assert.IsFalse(evolvedModel![1, 2]);
            Assert.IsFalse(evolvedModel![2, 1]);
            Assert.IsFalse(evolvedModel![2, 2]);
            Assert.IsFalse(evolvedModel![2, 3]);
            Assert.IsFalse(evolvedModel![3, 2]);

            Assert.IsFalse(evolvedModel![1, 0]);
            Assert.IsFalse(evolvedModel![1, 1]);
            Assert.IsFalse(evolvedModel![1, 3]);
            Assert.IsFalse(evolvedModel![1, 4]);
            Assert.IsFalse(evolvedModel![2, 0]);
            Assert.IsFalse(evolvedModel![2, 4]);
            Assert.IsFalse(evolvedModel![3, 0]);
            Assert.IsFalse(evolvedModel![3, 1]);
            Assert.IsFalse(evolvedModel![3, 3]);
            Assert.IsFalse(evolvedModel![3, 4]);
        }
    }
}