using Logger;

namespace AWSS3Helper.Test
{
    internal static class TestValues
    {
        internal static ILogger Logger { get; } = new ConsoleLogger(logLevel: LogLevel.Trace,
            logName: "Log");

        internal static IS3Helper S3Helper { get; } = new S3Helper(logger: Logger);

        internal static string BucketName { get; } = nameof(BucketName);

        internal static string S3Prefix { get; } = nameof(S3Prefix);

        internal static string UploadId { get; } = nameof(UploadId);

        internal static int UploadPart { get; } = 7;

        internal static string Contents { get; } = nameof(Contents);
    }
}