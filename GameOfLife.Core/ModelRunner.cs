namespace GameOfLife.Core
{
    public static class ModelRunner
    {
        public static bool[,] EvolveComplete(bool[,] model)
        {
            bool isComplete;
            do
            {
                isComplete = Evolve(model);
            } while (!isComplete);

            return model;
        }

        private static bool Evolve(bool[,] model)
        {
            int neighbours = 0;
            var totalRowCount = model.GetLength(0);
            var totalColumnCount = model.GetLength(1);
            bool modelStateChanged = false;

            for (var rowNumber = 0; rowNumber < totalRowCount; rowNumber++)
            {
                for (var columnNumber = 0; columnNumber < totalColumnCount; columnNumber++)
                {
                    if (model[rowNumber - 1 < 0 ? totalRowCount - 1 : rowNumber - 1, columnNumber - 1 < 0 ? totalColumnCount - 1 : columnNumber - 1]) neighbours++;
                    if (model[rowNumber - 1 < 0 ? totalRowCount - 1 : rowNumber - 1, columnNumber]) neighbours++;
                    if (model[rowNumber - 1 < 0 ? totalRowCount - 1 : rowNumber - 1, columnNumber + 1 == totalColumnCount ? 0 : columnNumber + 1]) neighbours++;

                    if (model[rowNumber, columnNumber - 1 < 0 ? totalColumnCount - 1 : columnNumber - 1]) neighbours++;
                    if (model[rowNumber, columnNumber + 1 == totalColumnCount ? 0 : columnNumber + 1]) neighbours++;

                    if (model[rowNumber + 1 == totalRowCount ? 0 : rowNumber + 1, columnNumber - 1 < 0 ? totalColumnCount - 1 : columnNumber - 1]) neighbours++;
                    if (model[rowNumber + 1 == totalRowCount ? 0 : rowNumber + 1, columnNumber]) neighbours++;
                    if (model[rowNumber + 1 == totalRowCount ? 0 : rowNumber + 1, columnNumber + 1 == totalColumnCount ? 0 : columnNumber + 1]) neighbours++;

                    modelStateChanged = UpdateState(ref model[rowNumber, columnNumber], neighbours, modelStateChanged);
                }
            }

            return !modelStateChanged;
        }

        private static bool UpdateState(ref bool cell, int neighbours, bool modelStateChanged)
        {
            if (cell && neighbours < 2)
            {
                cell = false;
                modelStateChanged = true;
            }
            if (cell && (neighbours == 2 || neighbours == 3))
            {
                cell = true;
                modelStateChanged = true;
            }
            if (cell && neighbours > 3)
            {
                cell = false;
                modelStateChanged = true;
            }
            if (!cell && neighbours == 3)
            {
                cell = true;
                modelStateChanged = true;
            }

            return modelStateChanged;
        }
    }
}
