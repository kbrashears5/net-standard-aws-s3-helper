using Amazon.S3;
using System;
using System.Text;

namespace AWSS3Helper
{
    internal static class Text
    {
        internal static string Error(Exception exception)
        {
            return $"Error:\r\n {exception}";
        }

        internal static string BucketName(string bucketName)
        {
            return $"Bucket name: {bucketName}";
        }

        internal static string S3Prefix(string s3Prefix)
        {
            return $"S3Prefix: {s3Prefix}";
        }

        internal static string S3CannedACL(S3CannedACL s3CannedAcl)
        {
            return $"S3CannedACL: {s3CannedAcl}";
        }

        internal static string Encoding(Encoding encoding)
        {
            return $"Encoding: {encoding}";
        }

        internal static string UploadId(string uploadId)
        {
            return $"UploadId: {uploadId}";
        }

        internal static string UploadPart(int uploadPart)
        {
            return $"UploadPart: {uploadPart}";
        }

        internal static long MinimumPartSize { get; } = 5000000;

        internal static long MaximumPartSize { get; } = 10000000000;

        internal static string InvalidPartSize { get; } = "Part size must be between 5 MB and 10 GB";

        internal static string TempFilePath(string tempPath)
        {
            if (string.IsNullOrWhiteSpace(tempPath)) throw new ArgumentNullException(nameof(tempPath));

            return $"Temp path: {tempPath}";
        }

        internal static string FilePath { get; } = @"C:\temp\test.json";
    }
}