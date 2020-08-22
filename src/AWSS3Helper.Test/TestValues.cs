using Amazon.S3.Model;
using Logger;

namespace AWSS3Helper.Test
{
    internal static class TestValues
    {
        internal static ILogger Logger { get; } = new ConsoleLogger(logLevel: LogLevel.Off,
            logName: "Log");

        internal static IS3Helper S3Helper { get; } = new S3Helper(logger: Logger);

        internal static IS3Helper S3Helper_Mock { get; } = new S3Helper_Mock();

        internal static string Bucket { get; } = nameof(Bucket);

        internal static string Key { get; } = nameof(Key);

        internal static string UploadId { get; } = nameof(UploadId);

        internal static int UploadPart { get; } = 7;

        internal static string Contents { get; } = nameof(Contents);

        internal static int Timeout { get; } = 7;

        internal static string TagName { get; } = nameof(TagName);

        internal static string TagValue { get; } = nameof(TagValue);

        internal static Tag Tag { get; } = new Tag()
        {
            Key = TagName,
            Value = TagValue
        };
    }
}