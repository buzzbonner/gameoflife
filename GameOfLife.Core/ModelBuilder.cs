namespace GameOfLife.Core
{
    public static class ModelBuilder
    {
        private const char alive = '*';
        private const char dead = '_';

        public static bool[,]? Build(string[] rawModel, out string errorMessage)
        {
            errorMessage = string.Empty;
            var model = new bool[rawModel.Length, rawModel[0].Length];

            try
            {
                for (int lineNumber = 0; lineNumber < rawModel.Length; lineNumber++)
                {
                    for (int linePosition = 0; linePosition < rawModel[lineNumber].Length; linePosition++)
                    {
                        model[lineNumber, linePosition] = rawModel[lineNumber][linePosition].Equals(alive) ? true : (rawModel[lineNumber][linePosition].Equals(dead) ? false : throw new ArgumentException("Invalid raw model"));
                    }
                }
                return model;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return null;
            }
        }

        public static string[] BuildRaw(bool[,] model)
        {
            var totalRowCount = model.GetLength(0);
            var totalColumnCount = model.GetLength(1);
            var rawModel = new string[totalRowCount];

            string line;
            for (var rowNumber = 0; rowNumber < totalRowCount; rowNumber++)
            {
                line = string.Empty;
                for (var columnNumber = 0; columnNumber < totalColumnCount; columnNumber++)
                {
                    line = line + (model[rowNumber, columnNumber] ? alive : dead);
                }
                rawModel[rowNumber] = line;
            }

            return rawModel;
        }
    }
}