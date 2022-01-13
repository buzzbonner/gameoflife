namespace GameOfLife.Console
{
    internal static class FileManager
    {
        internal static string[]? LoadTextFile(string fileName, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using var reader = new StreamReader(fileName);
                var all_text = reader.ReadToEnd();
                
                return all_text?.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            }
            catch (Exception ex)
            {
                errorMessage = $"Game of Life File Error: {ex.Message}";
                return null;
            }
        }
    }
}
