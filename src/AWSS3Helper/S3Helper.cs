using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Logger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSS3Helper

{
    /// <summary>
    /// Implementation of <see cref="IS3Helper"/>
    /// </summary>
    public class S3Helper : IS3Helper
    {
        /// <summary>
        /// Logger
        /// </summary>
        private ILogger Logger { get; }

        /// <summary>
        /// Client to interact with AWS S3
        /// </summary>
        private AmazonS3Client Repository { get; }

        /// <summary>
        /// Creates a new instance of <see cref="S3Helper"/>
        /// </summary>
        /// <param name="logger">ILogger</param>
        /// <param name="repository"><see cref="AmazonS3Client"/> - If none is provided, will create new instance in account that lambda is running in</param>
        /// <param name="options"><see cref="AmazonS3Config"/>- Only used if the repository is not supplied. Defaults to <see cref="RegionEndpoint.USEast1"/> Region</param>
        /// <exception cref="ArgumentNullException"></exception>
        public S3Helper(ILogger logger,
            AmazonS3Client repository = null,
            AmazonS3Config options = null)
        {
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));

            if (options == null) options = new AmazonS3Config { RegionEndpoint = RegionEndpoint.USEast1 };

            this.Repository = repository ?? new AmazonS3Client(config: options);
        }

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
                    this.Repository?.Dispose();

                    this.Logger?.Dispose();
                }

                this.Disposed = true;
            }
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~S3Helper() => this.Dispose(disposing: false);

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

        public async Task<CopyObjectResponse> CopyObjectAsync(string sourceBucket,
            string sourceKey,
            string destinationBucket,
            string destinationKey)
        {
            this.Logger.LogDebug($"[{nameof(this.CopyObjectAsync)}]");

            this.Logger.LogTrace(JsonConvert.SerializeObject(new { sourceBucket, sourceKey, destinationBucket, destinationKey }));

            if (string.IsNullOrWhiteSpace(sourceBucket)) throw new ArgumentNullException(nameof(sourceBucket));
            if (string.IsNullOrWhiteSpace(sourceKey)) throw new ArgumentNullException(nameof(sourceKey));
            if (string.IsNullOrWhiteSpace(destinationBucket)) throw new ArgumentNullException(nameof(destinationBucket));
            if (string.IsNullOrWhiteSpace(destinationKey)) throw new ArgumentNullException(nameof(destinationKey));

            var request = new Amazon.S3.Model.CopyObjectRequest
            {
                SourceBucket = sourceBucket,
                DestinationBucket = destinationBucket,
                SourceKey = sourceKey,
                DestinationKey = destinationKey,
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Repository.CopyObjectAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response;
        }

        public async Task<PutBucketResponse> CreateBucketAsync(string name)
        {
            this.Logger.LogDebug($"[{nameof(this.CreateBucketAsync)}]");

            this.Logger.LogTrace(JsonConvert.SerializeObject(new { name }));

            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            var request = new Amazon.S3.Model.PutBucketRequest
            {
                BucketName = name,
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Repository.PutBucketAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response;
        }

        /// <summary>
        /// Create a temporary file for functions that need a file path instead of a stream or string
        /// </summary>
        /// <param name="contents">File contents</param>
        /// <param name="encoding">Text encoding</param>
        /// <returns></returns>
        private string CreateTempFile(string contents,
            Encoding encoding = null)
        {
            this.Logger.LogDebug($"[{nameof(this.CreateTempFile)}]");

            if (string.IsNullOrWhiteSpace(contents)) throw new ArgumentNullException(nameof(contents));

            var tempPath = Path.GetTempFileName();

            this.Logger.LogTrace(Text.TempFilePath(tempPath: tempPath));

            var encodingType = encoding ?? Encoding.Unicode;

            using (var stream = new FileStream(tempPath,
                FileMode.Create))
            {
                var contentsAsBytes = encodingType.GetBytes(contents);

                stream.Write(contentsAsBytes,
                    0,
                    contentsAsBytes.Length);
            }

            return tempPath;
        }

        public async Task<DeleteBucketResponse> DeleteBucketAsync(string name)
        {
            this.Logger.LogDebug($"[{nameof(this.DeleteBucketAsync)}]");

            this.Logger.LogTrace(JsonConvert.SerializeObject(new { name }));

            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            var request = new Amazon.S3.Model.DeleteBucketRequest
            {
                BucketName = name,
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Repository.DeleteBucketAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response;
        }

        public async Task<DeleteObjectResponse> DeleteObjectAsync(string bucket,
            string key)
        {
            this.Logger.LogDebug($"[{nameof(this.DeleteObjectAsync)}]");

            this.Logger.LogTrace(JsonConvert.SerializeObject(new { bucket, key }));

            if (string.IsNullOrWhiteSpace(bucket)) throw new ArgumentNullException(nameof(bucket));
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            var request = new Amazon.S3.Model.DeleteObjectRequest
            {
                BucketName = bucket,
                Key = key,
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Repository.DeleteObjectAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response;
        }

        public async Task<DeleteObjectsResponse> DeleteObjectsAsync(string bucket,
            IEnumerable<string> keys)
        {
            this.Logger.LogDebug($"[{nameof(this.DeleteObjectsAsync)}]");

            this.Logger.LogTrace(JsonConvert.SerializeObject(new { bucket, keys }));

            if (string.IsNullOrWhiteSpace(bucket)) throw new ArgumentNullException(nameof(bucket));
            if (keys == null) throw new ArgumentNullException(nameof(keys));

            var keyVersions = new List<KeyVersion>();

            keyVersions.AddRange(keys.Select(k => new KeyVersion() { Key = k }));

            var request = new Amazon.S3.Model.DeleteObjectsRequest
            {
                BucketName = bucket,
                Objects = keyVersions,
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Repository.DeleteObjectsAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response;
        }

        public async Task<DeleteObjectTaggingResponse> DeleteObjectTagsAsync(string bucket,
            string key)
        {
            this.Logger.LogDebug($"[{nameof(this.DeleteObjectTagsAsync)}]");

            this.Logger.LogTrace(JsonConvert.SerializeObject(new { bucket, key }));

            if (string.IsNullOrWhiteSpace(bucket)) throw new ArgumentNullException(nameof(bucket));
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            var request = new Amazon.S3.Model.DeleteObjectTaggingRequest
            {
                BucketName = bucket,
                Key = key,
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Repository.DeleteObjectTaggingAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response;
        }

        public async Task<T> GetObjectAsJsonAsync<T>(string bucket,
            string key)
        {
            this.Logger.LogDebug($"[{nameof(this.GetObjectAsJsonAsync)}]");

            var data = await this.GetObjectContentsAsync(bucket: bucket,
                key: key);

            return JsonConvert.DeserializeObject<T>(value: data);
        }

        public async Task<GetObjectResponse> GetObjectAsync(string bucket,
            string key)
        {
            this.Logger.LogDebug($"[{nameof(this.GetObjectAsync)}]");

            this.Logger.LogTrace(JsonConvert.SerializeObject(new { bucket, key }));

            if (string.IsNullOrWhiteSpace(bucket)) throw new ArgumentNullException(nameof(bucket));
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            var request = new Amazon.S3.Model.GetObjectRequest
            {
                BucketName = bucket,
                Key = key,
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Repository.GetObjectAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response;
        }

        public async Task<string> GetObjectContentsAsync(string bucket,
            string key)
        {
            this.Logger.LogDebug($"[{nameof(this.GetObjectContentsAsync)}]");

            var data = await this.GetObjectAsync(bucket: bucket,
                key: key);

            using (var stream = data.ResponseStream)
            using (var streamReader = new StreamReader(stream: stream))
            {
                return streamReader.ReadToEnd();
            }
        }

        public async Task<MetadataCollection> GetObjectMetadataAsync(string bucket,
            string key)
        {
            this.Logger.LogDebug($"[{nameof(this.GetObjectMetadataAsync)}]");

            this.Logger.LogTrace(JsonConvert.SerializeObject(new { bucket, key }));

            if (string.IsNullOrWhiteSpace(bucket)) throw new ArgumentNullException(nameof(bucket));
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            var request = new Amazon.S3.Model.GetObjectMetadataRequest
            {
                BucketName = bucket,
                Key = key,
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Repository.GetObjectMetadataAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response.Metadata;
        }

        public async Task<IEnumerable<Tag>> GetObjectTagsAsync(string bucket,
            string key)
        {
            this.Logger.LogDebug($"[{nameof(this.GetObjectTagsAsync)}]");

            this.Logger.LogTrace(JsonConvert.SerializeObject(new { bucket, key }));

            if (string.IsNullOrWhiteSpace(bucket)) throw new ArgumentNullException(nameof(bucket));
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            var request = new Amazon.S3.Model.GetObjectTaggingRequest
            {
                BucketName = bucket,
                Key = key,
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Repository.GetObjectTaggingAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response.Tagging;
        }

        public string GetSignedUrl(string bucket,
            string key,
            SignedUrlType type,
            int timeoutInMinutes,
            S3CannedACL acl = null)
        {
            this.Logger.LogDebug($"[{nameof(this.GetSignedUrl)}]");

            this.Logger.LogTrace(JsonConvert.SerializeObject(new { bucket, key, type, timeoutInMinutes, acl }));

            if (string.IsNullOrWhiteSpace(bucket)) throw new ArgumentNullException(nameof(bucket));
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            var request = new Amazon.S3.Model.GetPreSignedUrlRequest
            {
                BucketName = bucket,
                Key = key,
                Expires = DateTime.UtcNow.AddMinutes(value: timeoutInMinutes),
                Verb = type == SignedUrlType.Download ? HttpVerb.GET : HttpVerb.PUT,
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = this.Repository.GetPreSignedURL(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response;
        }

        public async Task<bool> MoveObjectAsync(string sourceBucket,
            string sourceKey,
            string destinationBucket,
            string destinationKey)
        {
            this.Logger.LogDebug($"[{nameof(this.MoveObjectAsync)}]");

            this.Logger.LogTrace(JsonConvert.SerializeObject(new { sourceBucket, sourceKey, destinationBucket, destinationKey }));

            var copyResult = await this.CopyObjectAsync(sourceBucket: sourceBucket,
                sourceKey: sourceKey,
                destinationBucket: destinationBucket,
                destinationKey: destinationKey);

            if (copyResult != null)
                _ = await this.DeleteObjectAsync(bucket: sourceBucket,
                    key: sourceKey);

            return true;
        }

        public async Task<CompleteMultipartUploadResponse> MultipartUploadCompleteAsync(string bucket,
            string key,
            string uploadId)
        {
            this.Logger.LogDebug($"[{nameof(this.MultipartUploadCompleteAsync)}]");

            this.Logger.LogTrace(JsonConvert.SerializeObject(new { bucket, key, uploadId }));

            if (string.IsNullOrWhiteSpace(bucket)) throw new ArgumentNullException(nameof(bucket));
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(uploadId)) throw new ArgumentNullException(nameof(uploadId));

            var request = new Amazon.S3.Model.CompleteMultipartUploadRequest
            {
                BucketName = bucket,
                Key = key,
                UploadId = uploadId,
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Repository.CompleteMultipartUploadAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response;
        }

        public async Task<string> MultipartUploadStartAsync(string bucket,
            string key,
            S3CannedACL s3CannedAcl = null)
        {
            this.Logger.LogDebug($"[{nameof(this.MultipartUploadStartAsync)}]");

            this.Logger.LogTrace(JsonConvert.SerializeObject(new { bucket, key, s3CannedAcl }));

            if (string.IsNullOrWhiteSpace(bucket)) throw new ArgumentNullException(nameof(bucket));
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            if (s3CannedAcl == null) s3CannedAcl = S3CannedACL.BucketOwnerFullControl;

            var request = new Amazon.S3.Model.InitiateMultipartUploadRequest
            {
                BucketName = bucket,
                CannedACL = s3CannedAcl,
                Key = key,
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Repository.InitiateMultipartUploadAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response.UploadId;
        }

        public async Task<UploadPartResponse> MultipartUploadUploadPartAsync(string bucket,
            string key,
            string uploadId,
            int uploadPart,
            string contents,
            Encoding encoding = null)
        {
            this.Logger.LogDebug($"[{nameof(this.MultipartUploadUploadPartAsync)}]");

            this.Logger.LogTrace(JsonConvert.SerializeObject(new { bucket, key, uploadId, uploadPart, encoding }));

            if (string.IsNullOrWhiteSpace(bucket)) throw new ArgumentNullException(nameof(bucket));
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(uploadId)) throw new ArgumentNullException(nameof(uploadId));
            if (uploadPart == 0) throw new ArgumentException(nameof(uploadPart));
            if (string.IsNullOrWhiteSpace(contents)) throw new ArgumentNullException(nameof(contents));

            var tooSmall = Encoding.Unicode.GetByteCount(contents) < Text.MinimumPartSize;
            var tooLarge = Encoding.Unicode.GetBytes(contents).LongCount() > Text.MaximumPartSize;

            if (tooSmall || tooLarge) throw new ArgumentOutOfRangeException(nameof(contents), Text.InvalidPartSize);

            var filePath = this.CreateTempFile(contents: contents,
                encoding: encoding);

            var request = new Amazon.S3.Model.UploadPartRequest
            {
                BucketName = bucket,
                FilePath = filePath,
                Key = key,
                PartNumber = uploadPart,
                UploadId = uploadId,
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Repository.UploadPartAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response;
        }

        public async Task<PutObjectResponse> PutObjectAsync(string bucket,
            string key,
            string contents,
            S3CannedACL s3CannedAcl = null,
            Encoding encoding = null)
        {
            this.Logger.LogDebug($"[{nameof(this.PutObjectAsync)}]");

            this.Logger.LogTrace(JsonConvert.SerializeObject(new { bucket, key, s3CannedAcl, encoding }));

            if (string.IsNullOrWhiteSpace(bucket)) throw new ArgumentNullException(nameof(bucket));
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(contents)) throw new ArgumentNullException(nameof(contents));

            if (s3CannedAcl == null) s3CannedAcl = S3CannedACL.BucketOwnerFullControl;

            var filePath = this.CreateTempFile(contents: contents,
                encoding: encoding);

            var request = new Amazon.S3.Model.PutObjectRequest
            {
                BucketName = bucket,
                CannedACL = s3CannedAcl,
                FilePath = filePath,
                Key = key,
            };

            return await this.PutObjectAsync(request: request);
        }

        public async Task<PutObjectResponse> PutObjectAsync(string bucket,
            string key,
            Stream contents,
            S3CannedACL s3CannedAcl = null)
        {
            this.Logger.LogDebug($"[{nameof(this.PutObjectAsync)}]");

            this.Logger.LogTrace(JsonConvert.SerializeObject(new { bucket, key, s3CannedAcl }));

            if (string.IsNullOrWhiteSpace(bucket)) throw new ArgumentNullException(nameof(bucket));
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            if (contents == null) throw new ArgumentNullException(nameof(contents));

            if (s3CannedAcl == null) s3CannedAcl = S3CannedACL.BucketOwnerFullControl;

            var request = new Amazon.S3.Model.PutObjectRequest
            {
                BucketName = bucket,
                CannedACL = s3CannedAcl,
                InputStream = contents,
                Key = key,
            };

            return await this.PutObjectAsync(request: request);
        }

        /// <summary>
        /// Put object
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task<PutObjectResponse> PutObjectAsync(Amazon.S3.Model.PutObjectRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Repository.PutObjectAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response;
        }

        public async Task<PutObjectTaggingResponse> SetObjectTagAsync(string bucket,
            string key,
            string tagName,
            string tagValue)
        {
            this.Logger.LogDebug($"[{nameof(this.SetObjectTagAsync)}]");

            this.Logger.LogTrace(JsonConvert.SerializeObject(new { bucket, key, tagName, tagValue }));

            if (string.IsNullOrWhiteSpace(bucket)) throw new ArgumentNullException(nameof(bucket));
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(tagName)) throw new ArgumentNullException(nameof(tagName));
            if (string.IsNullOrWhiteSpace(tagValue)) throw new ArgumentNullException(nameof(tagValue));

            var tags = new List<Tag>()
            {
                new Tag(){Key = tagName, Value = tagValue}
            };

            return await this.SetObjectTagsAsync(bucket: bucket,
                key: key,
                tags: tags);
        }

        public async Task<PutObjectTaggingResponse> SetObjectTagsAsync(string bucket,
            string key,
            IEnumerable<Tag> tags)
        {
            this.Logger.LogDebug($"[{nameof(this.SetObjectTagAsync)}]");

            this.Logger.LogTrace(JsonConvert.SerializeObject(new { bucket, key, tags }));

            if (string.IsNullOrWhiteSpace(bucket)) throw new ArgumentNullException(nameof(bucket));
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            if (tags == null) throw new ArgumentNullException(nameof(tags));

            var request = new Amazon.S3.Model.PutObjectTaggingRequest
            {
                BucketName = bucket,
                Key = key,
                Tagging = new Tagging() { TagSet = tags.ToList() }
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Repository.PutObjectTaggingAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response;
        }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}