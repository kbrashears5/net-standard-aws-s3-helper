using Amazon.S3;
using Amazon.S3.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AWSS3Helper
{
    /// <summary>
    /// Mock implementation of <see cref="IS3Helper"/>
    /// </summary>
    public class S3Helper_Mock : IS3Helper
    {
        #region IDisposable

        /// <summary>
        /// Disposed
        /// </summary>
        private bool Disposed { get; set; } = false;

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                }

                this.Disposed = true;
            }
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~S3Helper_Mock() => this.Dispose(disposing: false);

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            this.Dispose(disposing: true);

            GC.SuppressFinalize(this);
        }

        #endregion IDisposable

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

        public Task<CopyObjectResponse> CopyObjectAsync(string sourceBucket,
            string sourceKey,
            string destinationBucket,
            string destinationKey,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new CopyObjectResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
            });
        }

        public Task<PutBucketResponse> CreateBucketAsync(string name,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new PutBucketResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
            });
        }

        public Task<DeleteBucketResponse> DeleteBucketAsync(string name,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new DeleteBucketResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
            });
        }

        public Task<DeleteObjectResponse> DeleteObjectAsync(string bucketName,
            string s3Prefix,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new DeleteObjectResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
            });
        }

        public Task<DeleteObjectsResponse> DeleteObjectsAsync(string bucket,
            IEnumerable<string> keys,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new DeleteObjectsResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
            });
        }

        public Task<DeleteObjectTaggingResponse> DeleteObjectTagsAsync(string bucket,
            string key,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new DeleteObjectTaggingResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
            });
        }

        public Task<T> GetObjectAsJsonAsync<T>(string bucket,
            string key,
            CancellationToken cancellationToken = default)
        {
            var str = this.GetObjectContentsAsync(bucket: null,
                key: null).Result;

            return Task.FromResult(JsonConvert.DeserializeObject<T>(str));
        }

        public Task<GetObjectResponse> GetObjectAsync(string bucketName,
            string s3Prefix,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new GetObjectResponse()
            {
                BucketName = bucketName,
                HttpStatusCode = HttpStatusCode.OK,
                Key = s3Prefix,
            });
        }

        public Task<string> GetObjectContentsAsync(string bucket,
            string key,
            CancellationToken cancellationToken = default)
        {
            var dictionary = new Dictionary<string, string>()
            {
                { "key1", "value1" },
                { "key2", "value2" },
            };

            return Task.FromResult(JsonConvert.SerializeObject(dictionary));
        }

        public Task<MetadataCollection> GetObjectMetadataAsync(string bucket,
            string key,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new MetadataCollection());
        }

        public Task<IEnumerable<Tag>> GetObjectTagsAsync(string bucket,
            string key,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new List<Tag>() { new Tag() { Key = "Key", Value = "Value" } }.AsEnumerable());
        }

        public string GetSignedUrl(string bucket,
            string key,
            SignedUrlType type,
            int timeoutInMinutes,
            S3CannedACL acl)
        {
            return Text.FilePath;
        }

        public Task<bool> MoveObjectAsync(string sourceBucket,
            string sourceKey,
            string destinationBucket,
            string destinationKey,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }

        public Task<CompleteMultipartUploadResponse> MultipartUploadCompleteAsync(string bucketName,
            string s3Prefix,
            string uploadId,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new CompleteMultipartUploadResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
            });
        }

        public Task<string> MultipartUploadStartAsync(string bucketName,
            string s3Prefix,
            S3CannedACL s3CannedAcl = null,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Text.UploadId);
        }

        public Task<UploadPartResponse> MultipartUploadUploadPartAsync(string bucketName,
            string s3Prefix,
            string uploadId,
            int uploadPart,
            string contents,
            Encoding encoding = null,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new UploadPartResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
            });
        }

        public Task<PutObjectResponse> PutObjectAsync(string bucket,
            string key,
            string contents,
            S3CannedACL s3CannedAcl = null,
            Encoding encoding = null,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new PutObjectResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
            });
        }

        public Task<PutObjectResponse> PutObjectAsync(string bucket,
            string key,
            Stream contents,
            S3CannedACL s3CannedAcl = null,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new PutObjectResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
            });
        }

        public Task<PutObjectTaggingResponse> SetObjectTagAsync(string bucket,
            string key,
            string tagName,
            string tagValue,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new PutObjectTaggingResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
            });
        }

        public Task<PutObjectTaggingResponse> SetObjectTagsAsync(string bucket,
            string key,
            IEnumerable<Tag> tags,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new PutObjectTaggingResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
            });
        }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}