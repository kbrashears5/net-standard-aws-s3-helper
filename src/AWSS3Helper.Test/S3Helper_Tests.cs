using Logger;
using NetStandardTestHelper.Xunit;
using System;
using Xunit;

namespace AWSS3Helper.Test
{
    /// <summary>
    /// Tests the <see cref="S3Helper"/> class
    /// </summary>
    public class S3Helper_Tests
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Test that the constructor throws on null <see cref="ILogger"/>
        /// </summary>
        [Fact]
        public void Constructor_Null_Logger()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new S3Helper(logger: null));

            TestHelper.AssertArgumentNullException(ex,
                "logger");
        }

        /// <summary>
        /// Test that the constructor is created successfully
        /// </summary>
        [Fact]
        public void Constructor()
        {
            var helper = TestValues.S3Helper;

            Assert.NotNull(helper);
        }

        #endregion CONSTRUCTOR

        #region CompleteMultipartUploadAsync

        /// <summary>
        /// Test that the function throws on null bucketName
        /// </summary>
        [Fact]
        public async void CompleteMultipartUploadAsync_Null_BucketName()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.CompleteMultipartUploadAsync(bucketName: NetStandardTestHelper.TestValues.StringEmpty,
                s3Prefix: TestValues.S3Prefix,
                uploadId: TestValues.UploadId));

            TestHelper.AssertArgumentNullException(ex,
                "bucketName");
        }

        /// <summary>
        /// Test that the function throws on null s3Prefix
        /// </summary>
        [Fact]
        public async void CompleteMultipartUploadAsync_Null_S3Prefix()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.CompleteMultipartUploadAsync(bucketName: TestValues.BucketName,
                s3Prefix: NetStandardTestHelper.TestValues.StringEmpty,
                uploadId: TestValues.UploadId));

            TestHelper.AssertArgumentNullException(ex,
                "s3Prefix");
        }

        /// <summary>
        /// Test that the function throws on null uploadId
        /// </summary>
        [Fact]
        public async void CompleteMultipartUploadAsync_Null_UploadId()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.CompleteMultipartUploadAsync(bucketName: TestValues.BucketName,
                s3Prefix: TestValues.S3Prefix,
                uploadId: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "uploadId");
        }

        /// <summary>
        /// Test that the function completes the multi part upload
        /// </summary>
        [Fact]
        public async void CompleteMultipartUploadAsync()
        {
            // TODO
        }

        #endregion CompleteMultipartUploadAsync

        #region CreateTempFile

        /// <summary>
        /// Test that the function throws on null contents
        /// </summary>
        [Fact]
        public void CreateTempFile_Null_Contents()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.S3Helper.CreateTempFile(contents: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "contents");
        }

        /// <summary>
        /// Test that the function creates the temp file
        /// </summary>
        [Fact]
        public void CreateTempFile()
        {
            // TODO
        }

        #endregion CreateTempFile

        #region DeleteObjectAsync

        /// <summary>
        /// Test that the function throws on null bucketName
        /// </summary>
        [Fact]
        public async void DeleteObjectAsync_Null_BucketName()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.DeleteObjectAsync(bucketName: NetStandardTestHelper.TestValues.StringEmpty,
                s3Prefix: TestValues.S3Prefix));

            TestHelper.AssertArgumentNullException(ex,
                "bucketName");
        }

        /// <summary>
        /// Test that the function throws on null s3Prefix
        /// </summary>
        [Fact]
        public async void DeleteObjectAsync_Null_S3Prefix()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.DeleteObjectAsync(bucketName: TestValues.BucketName,
                s3Prefix: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "s3Prefix");
        }

        /// <summary>
        /// Test that the function deletes the object
        /// </summary>
        [Fact]
        public async void DeleteObjectAsync()
        {
            // TODO
        }

        #endregion DeleteObjectAsync

        #region GetObjectAsync

        /// <summary>
        /// Test that the function throws on null bucketName
        /// </summary>
        [Fact]
        public async void GetObjectAsync_Null_BucketName()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.GetObjectAsync(bucketName: NetStandardTestHelper.TestValues.StringEmpty,
                s3Prefix: TestValues.S3Prefix));

            TestHelper.AssertArgumentNullException(ex,
                "bucketName");
        }

        /// <summary>
        /// Test that the function throws on null s3Prefix
        /// </summary>
        [Fact]
        public async void GetObjectAsync_Null_S3Prefix()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.GetObjectAsync(bucketName: TestValues.BucketName,
                s3Prefix: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "s3Prefix");
        }

        /// <summary>
        /// Test that the function gets the object
        /// </summary>
        [Fact]
        public async void GetObjectAsync()
        {
            // TODO
        }

        #endregion GetObjectAsync

        #region StartMultipartUploadAsync

        /// <summary>
        /// Test that the function throws on null bucketName
        /// </summary>
        [Fact]
        public async void StartMultipartUploadAsync_Null_BucketName()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.StartMultipartUploadAsync(bucketName: NetStandardTestHelper.TestValues.StringEmpty,
                s3Prefix: TestValues.S3Prefix));

            TestHelper.AssertArgumentNullException(ex,
                "bucketName");
        }

        /// <summary>
        /// Test that the function throws on null s3Prefix
        /// </summary>
        [Fact]
        public async void StartMultipartUploadAsync_Null_S3Prefix()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.StartMultipartUploadAsync(bucketName: TestValues.BucketName,
                s3Prefix: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "s3Prefix");
        }

        /// <summary>
        /// Test that the function starts the multipart upload
        /// </summary>
        [Fact]
        public async void StartMultipartUploadAsync()
        {
            // TODO
        }

        #endregion StartMultipartUploadAsync

        #region UploadFileAsync

        /// <summary>
        /// Test that the function throws on null bucketName
        /// </summary>
        [Fact]
        public async void UploadFileAsync_Null_BucketName()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.UploadFileAsync(bucketName: NetStandardTestHelper.TestValues.StringEmpty,
                s3Prefix: TestValues.S3Prefix,
                contents: TestValues.Contents));

            TestHelper.AssertArgumentNullException(ex,
                "bucketName");
        }

        /// <summary>
        /// Test that the function throws on null s3Prefix
        /// </summary>
        [Fact]
        public async void UploadFileAsync_Null_S3Prefix()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.UploadFileAsync(bucketName: TestValues.BucketName,
                s3Prefix: NetStandardTestHelper.TestValues.StringEmpty,
                contents: TestValues.Contents));

            TestHelper.AssertArgumentNullException(ex,
                "s3Prefix");
        }

        /// <summary>
        /// Test that the function throws on null contents
        /// </summary>
        [Fact]
        public async void UploadFileAsync_Null_Contents()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.UploadFileAsync(bucketName: TestValues.BucketName,
                s3Prefix: TestValues.S3Prefix,
                contents: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "contents");
        }

        /// <summary>
        /// Test that the function starts the multipart upload
        /// </summary>
        [Fact]
        public async void UploadFileAsync()
        {
            // TODO
        }

        #endregion UploadFileAsync

        #region UploadFilePartAsync

        /// <summary>
        /// Test that the function throws on null bucketName
        /// </summary>
        [Fact]
        public async void UploadFilePartAsync_Null_BucketName()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.UploadFilePartAsync(bucketName: NetStandardTestHelper.TestValues.StringEmpty,
                s3Prefix: TestValues.S3Prefix,
                uploadId: TestValues.UploadId,
                uploadPart: TestValues.UploadPart,
                contents: TestValues.Contents));

            TestHelper.AssertArgumentNullException(ex,
                "bucketName");
        }

        /// <summary>
        /// Test that the function throws on null s3Prefix
        /// </summary>
        [Fact]
        public async void UploadFilePartAsync_Null_S3Prefix()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.UploadFilePartAsync(bucketName: TestValues.BucketName,
                s3Prefix: NetStandardTestHelper.TestValues.StringEmpty,
                uploadId: TestValues.UploadId,
                uploadPart: TestValues.UploadPart,
                contents: TestValues.Contents));

            TestHelper.AssertArgumentNullException(ex,
                "s3Prefix");
        }

        /// <summary>
        /// Test that the function throws on null uploadId
        /// </summary>
        [Fact]
        public async void UploadFilePartAsync_Null_UploadId()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.UploadFilePartAsync(bucketName: TestValues.BucketName,
                s3Prefix: TestValues.S3Prefix,
                uploadId: NetStandardTestHelper.TestValues.StringEmpty,
                uploadPart: TestValues.UploadPart,
                contents: TestValues.Contents));

            TestHelper.AssertArgumentNullException(ex,
                "uploadId");
        }

        /// <summary>
        /// Test that the function throws on uploadPart being 0
        /// </summary>
        [Fact]
        public async void UploadFilePartAsync_Zero_UploadPart()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => TestValues.S3Helper.UploadFilePartAsync(bucketName: TestValues.BucketName,
                s3Prefix: TestValues.S3Prefix,
                uploadId: TestValues.UploadId,
                uploadPart: 0,
                contents: TestValues.Contents));

            TestHelper.AssertExceptionText(ex,
                "uploadPart");
        }

        /// <summary>
        /// Test that the function throws on null contents
        /// </summary>
        [Fact]
        public async void UploadFilePartAsync_Null_Contents()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.UploadFilePartAsync(bucketName: TestValues.BucketName,
                s3Prefix: TestValues.S3Prefix,
                uploadId: TestValues.UploadId,
                uploadPart: TestValues.UploadPart,
                contents: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "contents");
        }

        /// <summary>
        /// Test that the function throws on too small of a file
        /// </summary>
        [Fact]
        public async void UploadFilePartAsync_TooSmallFile()
        {
            var ex = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => TestValues.S3Helper.UploadFilePartAsync(bucketName: TestValues.BucketName,
                s3Prefix: TestValues.S3Prefix,
                uploadId: TestValues.UploadId,
                uploadPart: TestValues.UploadPart,
                contents: TestValues.Contents));

            TestHelper.AssertExceptionText(ex,
                "Part size must be between 5 MB and 10 GB (Parameter 'contents')");
        }

        /// <summary>
        /// Test that the function starts the multipart upload
        /// </summary>
        [Fact]
        public async void UploadFilePartAsync()
        {
            // TODO
        }

        #endregion UploadFilePartAsync
    }
}