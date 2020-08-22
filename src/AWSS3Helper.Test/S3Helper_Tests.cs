using Amazon.S3.Model;
using Logger;
using NetStandardTestHelper.Xunit;
using System;
using System.Collections.Generic;
using System.Net;
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

        #region CopyObjectAsync

        /// <summary>
        /// Test that the function throws on null source bucket
        /// </summary>
        [Fact]
        public async void CopyObjectAsync_Null_SourceBucket()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.CopyObjectAsync(sourceBucket: NetStandardTestHelper.TestValues.StringEmpty,
                sourceKey: TestValues.Key,
                destinationBucket: TestValues.Bucket,
                destinationKey: TestValues.Key));

            TestHelper.AssertArgumentNullException(ex,
                "sourceBucket");
        }

        /// <summary>
        /// Test that the function throws on null source key
        /// </summary>
        [Fact]
        public async void CopyObjectAsync_Null_SourceKey()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.CopyObjectAsync(sourceBucket: TestValues.Bucket,
                sourceKey: NetStandardTestHelper.TestValues.StringEmpty,
                destinationBucket: TestValues.Bucket,
                destinationKey: TestValues.Key));

            TestHelper.AssertArgumentNullException(ex,
                "sourceKey");
        }

        /// <summary>
        /// Test that the function throws on null destintation bucket
        /// </summary>
        [Fact]
        public async void CopyObjectAsync_Null_DestinationBucket()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.CopyObjectAsync(sourceBucket: TestValues.Bucket,
                sourceKey: TestValues.Key,
                destinationBucket: NetStandardTestHelper.TestValues.StringEmpty,
                destinationKey: TestValues.Key));

            TestHelper.AssertArgumentNullException(ex,
                "destinationBucket");
        }

        /// <summary>
        /// Test that the function throws on null destination key
        /// </summary>
        [Fact]
        public async void CopyObjectAsync_Null_DestinationKey()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.CopyObjectAsync(sourceBucket: TestValues.Bucket,
                sourceKey: TestValues.Key,
                destinationBucket: TestValues.Bucket,
                destinationKey: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "destinationKey");
        }

        /// <summary>
        /// Test that the function copies the object
        /// </summary>
        [Fact]
        public async void CopyObjectAsync()
        {
            var result = await TestValues.S3Helper_Mock.CopyObjectAsync(sourceBucket: TestValues.Bucket,
                sourceKey: TestValues.Key,
                destinationBucket: TestValues.Bucket,
                destinationKey: TestValues.Key);

            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK,
                result.HttpStatusCode);
        }

        #endregion CopyObjectAsync

        #region CreateBucketAsync

        /// <summary>
        /// Test that the function throws on null name
        /// </summary>
        [Fact]
        public async void CreateBucketAsync_Null_Name()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.CreateBucketAsync(name: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "name");
        }

        /// <summary>
        /// Test that the function creates the bucket
        /// </summary>
        [Fact]
        public async void CreateBucketAsync()
        {
            var result = await TestValues.S3Helper_Mock.CreateBucketAsync(name: TestValues.Bucket);

            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK,
                result.HttpStatusCode);
        }

        #endregion CreateBucketAsync

        #region DeleteBucketAsync

        /// <summary>
        /// Test that the function throws on null name
        /// </summary>
        [Fact]
        public async void DeleteBucketAsync_Null_Name()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.DeleteBucketAsync(name: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "name");
        }

        /// <summary>
        /// Test that the function deletes the bucket
        /// </summary>
        [Fact]
        public async void DeleteBucketAsync()
        {
            var result = await TestValues.S3Helper_Mock.DeleteBucketAsync(name: TestValues.Bucket);

            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK,
                result.HttpStatusCode);
        }

        #endregion DeleteBucketAsync

        #region DeleteObjectAsync

        /// <summary>
        /// Test that the function throws on null bucket
        /// </summary>
        [Fact]
        public async void DeleteObjectAsync_Null_Bucket()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.DeleteObjectAsync(bucket: NetStandardTestHelper.TestValues.StringEmpty,
                key: TestValues.Key));

            TestHelper.AssertArgumentNullException(ex,
                "bucket");
        }

        /// <summary>
        /// Test that the function throws on null key
        /// </summary>
        [Fact]
        public async void DeleteObjectAsync_Null_Key()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.DeleteObjectAsync(bucket: TestValues.Bucket,
                key: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "key");
        }

        /// <summary>
        /// Test that the function deletes the object
        /// </summary>
        [Fact]
        public async void DeleteObjectAsync()
        {
            var result = await TestValues.S3Helper_Mock.DeleteObjectAsync(bucket: TestValues.Bucket,
                key: TestValues.Key);

            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK,
                result.HttpStatusCode);
        }

        #endregion DeleteObjectAsync

        #region DeleteObjectsAsync

        /// <summary>
        /// Test that the function throws on null bucket
        /// </summary>
        [Fact]
        public async void DeleteObjectsAsync_Null_Bucket()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.DeleteObjectsAsync(bucket: NetStandardTestHelper.TestValues.StringEmpty,
                keys: new List<string>() { TestValues.Key }));

            TestHelper.AssertArgumentNullException(ex,
                "bucket");
        }

        /// <summary>
        /// Test that the function throws on null key
        /// </summary>
        [Fact]
        public async void DeleteObjectsAsync_Null_Key()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.DeleteObjectsAsync(bucket: TestValues.Bucket,
                keys: null));

            TestHelper.AssertArgumentNullException(ex,
                "keys");
        }

        /// <summary>
        /// Test that the function deletes the objects
        /// </summary>
        [Fact]
        public async void DeleteObjectsAsync()
        {
            var result = await TestValues.S3Helper_Mock.DeleteObjectsAsync(bucket: TestValues.Bucket,
                keys: new List<string>() { TestValues.Key });

            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK,
                result.HttpStatusCode);
        }

        #endregion DeleteObjectsAsync

        #region DeleteObjectTagsAsync

        /// <summary>
        /// Test that the function throws on null bucket
        /// </summary>
        [Fact]
        public async void DeleteObjectTagsAsync_Null_Bucket()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.DeleteObjectTagsAsync(bucket: NetStandardTestHelper.TestValues.StringEmpty,
                key: TestValues.Key));

            TestHelper.AssertArgumentNullException(ex,
                "bucket");
        }

        /// <summary>
        /// Test that the function throws on null key
        /// </summary>
        [Fact]
        public async void DeleteObjectTagsAsync_Null_Key()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.DeleteObjectTagsAsync(bucket: TestValues.Bucket,
                key: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "key");
        }

        /// <summary>
        /// Test that the function deletes the object tags
        /// </summary>
        [Fact]
        public async void DeleteObjectTagsAsync()
        {
            var result = await TestValues.S3Helper_Mock.DeleteObjectTagsAsync(bucket: TestValues.Bucket,
                key: TestValues.Key);

            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK,
                result.HttpStatusCode);
        }

        #endregion DeleteObjectTagsAsync

        #region GetObjectAsJsonAsync

        /// <summary>
        /// Test that the function throws on null bucket
        /// </summary>
        [Fact]
        public async void GetObjectAsJsonAsync_Null_Bucket()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.GetObjectAsJsonAsync<string>(bucket: NetStandardTestHelper.TestValues.StringEmpty,
                key: TestValues.Key));

            TestHelper.AssertArgumentNullException(ex,
                "bucket");
        }

        /// <summary>
        /// Test that the function throws on null key
        /// </summary>
        [Fact]
        public async void GetObjectAsJsonAsync_Null_Key()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.GetObjectAsJsonAsync<string>(bucket: TestValues.Bucket,
                key: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "key");
        }

        #endregion GetObjectAsJsonAsync

        #region GetObjectAsync

        /// <summary>
        /// Test that the function throws on null bucket
        /// </summary>
        [Fact]
        public async void GetObjectAsync_Null_Bucket()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.GetObjectAsync(bucket: NetStandardTestHelper.TestValues.StringEmpty,
                key: TestValues.Key));

            TestHelper.AssertArgumentNullException(ex,
                "bucket");
        }

        /// <summary>
        /// Test that the function throws on null key
        /// </summary>
        [Fact]
        public async void GetObjectAsync_Null_Key()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.GetObjectAsync(bucket: TestValues.Bucket,
                key: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "key");
        }

        /// <summary>
        /// Test that the function gets the object
        /// </summary>
        [Fact]
        public async void GetObjectAsync()
        {
            var result = await TestValues.S3Helper_Mock.GetObjectAsync(bucket: TestValues.Bucket,
                key: TestValues.Key);

            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK,
                result.HttpStatusCode);
        }

        #endregion GetObjectAsync

        #region GetObjectContentsAsync

        /// <summary>
        /// Test that the function throws on null bucket
        /// </summary>
        [Fact]
        public async void GetObjectContentsAsync_Null_Bucket()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.GetObjectContentsAsync(bucket: NetStandardTestHelper.TestValues.StringEmpty,
                key: TestValues.Key));

            TestHelper.AssertArgumentNullException(ex,
                "bucket");
        }

        /// <summary>
        /// Test that the function throws on null key
        /// </summary>
        [Fact]
        public async void GetObjectContentsAsync_Null_Key()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.GetObjectContentsAsync(bucket: TestValues.Bucket,
                key: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "key");
        }

        #endregion GetObjectContentsAsync

        #region GetObjectMetadataAsync

        /// <summary>
        /// Test that the function throws on null bucket
        /// </summary>
        [Fact]
        public async void GetObjectMetadataAsync_Null_Bucket()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.GetObjectMetadataAsync(bucket: NetStandardTestHelper.TestValues.StringEmpty,
                key: TestValues.Key));

            TestHelper.AssertArgumentNullException(ex,
                "bucket");
        }

        /// <summary>
        /// Test that the function throws on null key
        /// </summary>
        [Fact]
        public async void GetObjectMetadataAsync_Null_Key()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.GetObjectMetadataAsync(bucket: TestValues.Bucket,
                key: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "key");
        }

        /// <summary>
        /// Test that the function gets object metadata
        /// </summary>
        [Fact]
        public async void GetObjectMetadataAsync()
        {
            var result = await TestValues.S3Helper_Mock.GetObjectMetadataAsync(bucket: TestValues.Bucket,
                key: TestValues.Key);

            Assert.NotNull(result);
        }

        #endregion GetObjectMetadataAsync

        #region GetObjectTagsAsync

        /// <summary>
        /// Test that the function throws on null bucket
        /// </summary>
        [Fact]
        public async void GetObjectTagsAsync_Null_Bucket()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.GetObjectTagsAsync(bucket: NetStandardTestHelper.TestValues.StringEmpty,
                key: TestValues.Key));

            TestHelper.AssertArgumentNullException(ex,
                "bucket");
        }

        /// <summary>
        /// Test that the function throws on null key
        /// </summary>
        [Fact]
        public async void GetObjectTagsAsync_Null_Key()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.GetObjectTagsAsync(bucket: TestValues.Bucket,
                key: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "key");
        }

        /// <summary>
        /// Test that the function gets the object tags
        /// </summary>
        [Fact]
        public async void GetObjectTagsAsync()
        {
            var result = await TestValues.S3Helper_Mock.GetObjectTagsAsync(bucket: TestValues.Bucket,
                key: TestValues.Key);

            Assert.NotNull(result);
            _ = Assert.Single(result);
        }

        #endregion GetObjectTagsAsync

        #region GetSignedUrl

        /// <summary>
        /// Test that the function throws on null bucket
        /// </summary>
        [Fact]
        public void GetSignedUrl_Null_Bucket()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.S3Helper.GetSignedUrl(bucket: NetStandardTestHelper.TestValues.StringEmpty,
                key: TestValues.Key,
                type: SignedUrlType.Download,
                timeoutInMinutes: TestValues.Timeout));

            TestHelper.AssertArgumentNullException(ex,
                "bucket");
        }

        /// <summary>
        /// Test that the function throws on null key
        /// </summary>
        [Fact]
        public void GetSignedUrl_Null_Key()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TestValues.S3Helper.GetSignedUrl(bucket: TestValues.Bucket,
                key: NetStandardTestHelper.TestValues.StringEmpty,
                type: SignedUrlType.Download,
                timeoutInMinutes: TestValues.Timeout));

            TestHelper.AssertArgumentNullException(ex,
                "key");
        }

        /// <summary>
        /// Test that the function gets the signed url
        /// </summary>
        [Fact]
        public void GetSignedUrl()
        {
            var result = TestValues.S3Helper_Mock.GetSignedUrl(bucket: TestValues.Bucket,
                key: TestValues.Key,
                type: SignedUrlType.Download,
                timeoutInMinutes: TestValues.Timeout);

            Assert.NotNull(result);
        }

        #endregion GetSignedUrl

        #region MoveObjectAsync

        /// <summary>
        /// Test that the function throws on null source bucket
        /// </summary>
        [Fact]
        public async void MoveObjectAsync_Null_SourceBucket()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.MoveObjectAsync(sourceBucket: NetStandardTestHelper.TestValues.StringEmpty,
                sourceKey: TestValues.Key,
                destinationBucket: TestValues.Bucket,
                destinationKey: TestValues.Key));

            TestHelper.AssertArgumentNullException(ex,
                "sourceBucket");
        }

        /// <summary>
        /// Test that the function throws on null source key
        /// </summary>
        [Fact]
        public async void MoveObjectAsync_Null_SourceKey()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.MoveObjectAsync(sourceBucket: TestValues.Bucket,
                sourceKey: NetStandardTestHelper.TestValues.StringEmpty,
                destinationBucket: TestValues.Bucket,
                destinationKey: TestValues.Key));

            TestHelper.AssertArgumentNullException(ex,
                "sourceKey");
        }

        /// <summary>
        /// Test that the function throws on null destintation bucket
        /// </summary>
        [Fact]
        public async void MoveObjectAsync_Null_DestinationBucket()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.MoveObjectAsync(sourceBucket: TestValues.Bucket,
                sourceKey: TestValues.Key,
                destinationBucket: NetStandardTestHelper.TestValues.StringEmpty,
                destinationKey: TestValues.Key));

            TestHelper.AssertArgumentNullException(ex,
                "destinationBucket");
        }

        /// <summary>
        /// Test that the function throws on null destination key
        /// </summary>
        [Fact]
        public async void MoveObjectAsync_Null_DestinationKey()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.MoveObjectAsync(sourceBucket: TestValues.Bucket,
                sourceKey: TestValues.Key,
                destinationBucket: TestValues.Bucket,
                destinationKey: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "destinationKey");
        }

        /// <summary>
        /// Test that the function moves the object
        /// </summary>
        [Fact]
        public async void MoveObjectAsync()
        {
            var result = await TestValues.S3Helper_Mock.MoveObjectAsync(sourceBucket: TestValues.Bucket,
                sourceKey: TestValues.Key,
                destinationBucket: TestValues.Bucket,
                destinationKey: TestValues.Key);

            Assert.True(result);
        }

        #endregion MoveObjectAsync

        #region MultipartUploadCompleteAsync

        /// <summary>
        /// Test that the function throws on null bucket
        /// </summary>
        [Fact]
        public async void MultipartUploadCompleteAsync_Null_Bucket()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.MultipartUploadCompleteAsync(bucket: NetStandardTestHelper.TestValues.StringEmpty,
                key: TestValues.Key,
                uploadId: TestValues.UploadId));

            TestHelper.AssertArgumentNullException(ex,
                "bucket");
        }

        /// <summary>
        /// Test that the function throws on null key
        /// </summary>
        [Fact]
        public async void MultipartUploadCompleteAsync_Null_Key()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.MultipartUploadCompleteAsync(bucket: TestValues.Bucket,
                key: NetStandardTestHelper.TestValues.StringEmpty,
                uploadId: TestValues.UploadId));

            TestHelper.AssertArgumentNullException(ex,
                "key");
        }

        /// <summary>
        /// Test that the function throws on null uploadId
        /// </summary>
        [Fact]
        public async void MultipartUploadCompleteAsync_Null_UploadId()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.MultipartUploadCompleteAsync(bucket: TestValues.Bucket,
                key: TestValues.Key,
                uploadId: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "uploadId");
        }

        /// <summary>
        /// Test that the function completes the multi part upload
        /// </summary>
        [Fact]
        public async void MultipartUploadCompleteAsync()
        {
            var result = await TestValues.S3Helper_Mock.MultipartUploadCompleteAsync(bucket: TestValues.Bucket,
                key: TestValues.Key,
                uploadId: TestValues.UploadId);

            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK,
                result.HttpStatusCode);
        }

        #endregion MultipartUploadCompleteAsync

        #region MultipartUploadAsyncStart

        /// <summary>
        /// Test that the function throws on null bucket
        /// </summary>
        [Fact]
        public async void MultipartUploadAsyncStart_Null_Bucket()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.MultipartUploadStartAsync(bucket: NetStandardTestHelper.TestValues.StringEmpty,
                key: TestValues.Key));

            TestHelper.AssertArgumentNullException(ex,
                "bucket");
        }

        /// <summary>
        /// Test that the function throws on null key
        /// </summary>
        [Fact]
        public async void MultipartUploadAsyncStart_Null_Key()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.MultipartUploadStartAsync(bucket: TestValues.Bucket,
                key: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "key");
        }

        /// <summary>
        /// Test that the function starts the multipart upload
        /// </summary>
        [Fact]
        public async void MultipartUploadAsyncStart()
        {
            var result = await TestValues.S3Helper_Mock.MultipartUploadStartAsync(bucket: TestValues.Bucket,
                key: TestValues.Key);

            Assert.NotNull(result);
        }

        #endregion MultipartUploadAsyncStart

        #region MultipartUploadUploadPartAsync

        /// <summary>
        /// Test that the function throws on null bucket
        /// </summary>
        [Fact]
        public async void MultipartUploadUploadPartAsync_Null_Bucket()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.MultipartUploadUploadPartAsync(bucket: NetStandardTestHelper.TestValues.StringEmpty,
                key: TestValues.Key,
                uploadId: TestValues.UploadId,
                uploadPart: TestValues.UploadPart,
                contents: TestValues.Contents));

            TestHelper.AssertArgumentNullException(ex,
                "bucket");
        }

        /// <summary>
        /// Test that the function throws on null key
        /// </summary>
        [Fact]
        public async void MultipartUploadUploadPartAsync_Null_Key()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.MultipartUploadUploadPartAsync(bucket: TestValues.Bucket,
                key: NetStandardTestHelper.TestValues.StringEmpty,
                uploadId: TestValues.UploadId,
                uploadPart: TestValues.UploadPart,
                contents: TestValues.Contents));

            TestHelper.AssertArgumentNullException(ex,
                "key");
        }

        /// <summary>
        /// Test that the function throws on null uploadId
        /// </summary>
        [Fact]
        public async void MultipartUploadUploadPartAsync_Null_UploadId()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.MultipartUploadUploadPartAsync(bucket: TestValues.Bucket,
                key: TestValues.Key,
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
        public async void MultipartUploadUploadPartAsync_Zero_UploadPart()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => TestValues.S3Helper.MultipartUploadUploadPartAsync(bucket: TestValues.Bucket,
                key: TestValues.Key,
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
        public async void MultipartUploadUploadPartAsync_Null_Contents()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.MultipartUploadUploadPartAsync(bucket: TestValues.Bucket,
                key: TestValues.Key,
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
        public async void MultipartUploadUploadPartAsync_TooSmallFile()
        {
            var ex = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => TestValues.S3Helper.MultipartUploadUploadPartAsync(bucket: TestValues.Bucket,
                key: TestValues.Key,
                uploadId: TestValues.UploadId,
                uploadPart: TestValues.UploadPart,
                contents: TestValues.Contents));

            TestHelper.AssertExceptionText(ex,
                "Part size must be between 5 MB and 10 GB (Parameter 'contents')");
        }

        /// <summary>
        /// Test that the function uploads to the multipart upload
        /// </summary>
        [Fact]
        public async void MultipartUploadUploadPartAsync()
        {
            var result = await TestValues.S3Helper_Mock.MultipartUploadUploadPartAsync(bucket: TestValues.Bucket,
                key: TestValues.Key,
                uploadId: TestValues.UploadId,
                uploadPart: TestValues.UploadPart,
                contents: TestValues.Contents);

            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK,
                result.HttpStatusCode);
        }

        #endregion MultipartUploadUploadPartAsync

        #region PutObjectAsync

        /// <summary>
        /// Test that the function throws on null bucket
        /// </summary>
        [Fact]
        public async void PutObjectAsync_Null_Bucket()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.PutObjectAsync(bucket: NetStandardTestHelper.TestValues.StringEmpty,
                key: TestValues.Key,
                contents: TestValues.Contents));

            TestHelper.AssertArgumentNullException(ex,
                "bucket");
        }

        /// <summary>
        /// Test that the function throws on null key
        /// </summary>
        [Fact]
        public async void PutObjectAsync_Null_Key()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.PutObjectAsync(bucket: TestValues.Bucket,
                key: NetStandardTestHelper.TestValues.StringEmpty,
                contents: TestValues.Contents));

            TestHelper.AssertArgumentNullException(ex,
                "key");
        }

        /// <summary>
        /// Test that the function throws on null contents
        /// </summary>
        [Fact]
        public async void PutObjectAsync_Null_Contents()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.PutObjectAsync(bucket: TestValues.Bucket,
                key: TestValues.Key,
                contents: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "contents");
        }

        /// <summary>
        /// Test that the function puts the object
        /// </summary>
        [Fact]
        public async void PutObjectAsync()
        {
            var result = await TestValues.S3Helper_Mock.PutObjectAsync(bucket: TestValues.Bucket,
               key: TestValues.Key,
               contents: TestValues.Contents);

            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK,
                result.HttpStatusCode);
        }

        #endregion PutObjectAsync

        #region SetObjectTagAsync

        /// <summary>
        /// Test that the function throws on null bucket
        /// </summary>
        [Fact]
        public async void SetObjectTagAsync_Null_Bucket()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.SetObjectTagAsync(bucket: NetStandardTestHelper.TestValues.StringEmpty,
                key: TestValues.Key,
                tagName: TestValues.TagName,
                tagValue: TestValues.TagValue));

            TestHelper.AssertArgumentNullException(ex,
                "bucket");
        }

        /// <summary>
        /// Test that the function throws on null key
        /// </summary>
        [Fact]
        public async void SetObjectTagAsync_Null_Key()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.SetObjectTagAsync(bucket: TestValues.Bucket,
                key: NetStandardTestHelper.TestValues.StringEmpty,
                tagName: TestValues.TagName,
                tagValue: TestValues.TagValue));

            TestHelper.AssertArgumentNullException(ex,
                "key");
        }

        /// <summary>
        /// Test that the function throws on null key
        /// </summary>
        [Fact]
        public async void SetObjectTagAsync_Null_TagName()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.SetObjectTagAsync(bucket: TestValues.Bucket,
                key: TestValues.Key,
                tagName: NetStandardTestHelper.TestValues.StringEmpty,
                tagValue: TestValues.TagValue));

            TestHelper.AssertArgumentNullException(ex,
                "tagName");
        }

        /// <summary>
        /// Test that the function throws on null key
        /// </summary>
        [Fact]
        public async void SetObjectTagAsync_Null_TagValue()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.SetObjectTagAsync(bucket: TestValues.Bucket,
                key: TestValues.Key,
                tagName: TestValues.TagName,
                tagValue: NetStandardTestHelper.TestValues.StringEmpty));

            TestHelper.AssertArgumentNullException(ex,
                "tagValue");
        }

        /// <summary>
        /// Test that the function sets the object tag
        /// </summary>
        [Fact]
        public async void SetObjectTagAsync()
        {
            var result = await TestValues.S3Helper_Mock.SetObjectTagAsync(bucket: TestValues.Bucket,
                key: TestValues.Key,
                tagName: TestValues.TagName,
                tagValue: TestValues.TagValue);

            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK,
                result.HttpStatusCode);
        }

        #endregion SetObjectTagAsync

        #region SetObjectTagsAsync

        /// <summary>
        /// Test that the function throws on null bucket
        /// </summary>
        [Fact]
        public async void SetObjectTagsAsync_Null_Bucket()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.SetObjectTagsAsync(bucket: NetStandardTestHelper.TestValues.StringEmpty,
                key: TestValues.Key,
                tags: new List<Tag>() { TestValues.Tag }));

            TestHelper.AssertArgumentNullException(ex,
                "bucket");
        }

        /// <summary>
        /// Test that the function throws on null key
        /// </summary>
        [Fact]
        public async void SetObjectTagsAsync_Null_Key()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.SetObjectTagsAsync(bucket: TestValues.Bucket,
                key: NetStandardTestHelper.TestValues.StringEmpty,
                tags: new List<Tag>() { TestValues.Tag }));

            TestHelper.AssertArgumentNullException(ex,
                "key");
        }

        /// <summary>
        /// Test that the function throws on null key
        /// </summary>
        [Fact]
        public async void SetObjectTagsAsync_Null_Tags()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => TestValues.S3Helper.SetObjectTagsAsync(bucket: TestValues.Bucket,
                key: TestValues.Key,
                tags: null));

            TestHelper.AssertArgumentNullException(ex,
                "tags");
        }

        /// <summary>
        /// Test that the function sets the object tags
        /// </summary>
        [Fact]
        public async void SetObjectTagsAsync()
        {
            var result = await TestValues.S3Helper_Mock.SetObjectTagsAsync(bucket: TestValues.Bucket,
                key: TestValues.Key,
                tags: new List<Tag>() { TestValues.Tag });

            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK,
                result.HttpStatusCode);
        }

        #endregion SetObjectTagsAsync
    }
}