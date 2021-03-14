namespace AWSS3Helper
{
    internal static class Text
    {
        internal static long MinimumPartSize { get; } = 5000000;

        internal static long MaximumPartSize { get; } = 10000000000;

        internal static string InvalidPartSize { get; } = "Part size must be between 5 MB and 10 GB";

        internal static string TempFilePath(string tempPath) => $"Temp path: {tempPath}";

        internal static string FilePath { get; } = @"C:\temp\test.json";

        internal static string UploadId { get; } = nameof(UploadId);
    }
}