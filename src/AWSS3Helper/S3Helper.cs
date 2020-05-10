using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Logger;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSS3Helper

{
    /// <summary>
    /// Implementation of <see cref="IS3Helper"/>
    /// </summary>
    public class S3Helper : IS3Helper, IDisposable
    {
        /// <summary>
        /// Logger
        /// </summary>
        public ILogger Logger { get; }

        /// <summary>
        /// Client to interact with AWS S3
        /// </summary>
        public AmazonS3Client Client { get; }

        /// <summary>
        /// Disposed
        /// </summary>
        private bool Disposed = false;

        /// <summary>
        /// Creates a new instance of <see cref="S3Helper"/>
        /// </summary>
        /// <param name="logger">ILogger</param>
        /// <param name="client"><see cref="AmazonS3Client"/> - If none is provided, will create new instance in account that lambda is running in</param>
        /// <param name="options"><see cref="AmazonS3Config"/>- Only used if the client is not supplied. Defaults to <see cref="RegionEndpoint.USEast1"/> Region</param>
        /// <exception cref="ArgumentNullException"></exception>
        public S3Helper(ILogger logger,
            AmazonS3Client client = null,
            AmazonS3Config options = null)
        {
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));

            if (options == null) options = new AmazonS3Config { RegionEndpoint = RegionEndpoint.USEast1 };

            this.Client = client ?? new AmazonS3Client(config: options);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

        public async Task<CompleteMultipartUploadResponse> CompleteMultipartUploadAsync(string bucketName,
            string s3Prefix,
            string uploadId)
        {
            this.Logger.LogDebug($"[{nameof(this.CompleteMultipartUploadAsync)}]");

            this.Logger.LogTrace(Text.BucketName(bucketName: bucketName));
            this.Logger.LogTrace(Text.S3Prefix(s3Prefix: s3Prefix));
            this.Logger.LogTrace(Text.UploadId(uploadId: uploadId));

            if (string.IsNullOrWhiteSpace(bucketName)) throw new ArgumentNullException(nameof(bucketName));
            if (string.IsNullOrWhiteSpace(s3Prefix)) throw new ArgumentNullException(nameof(s3Prefix));
            if (string.IsNullOrWhiteSpace(uploadId)) throw new ArgumentNullException(nameof(uploadId));

            var request = new Amazon.S3.Model.CompleteMultipartUploadRequest
            {
                BucketName = bucketName,
                Key = s3Prefix,
                UploadId = uploadId,
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Client.CompleteMultipartUploadAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response;
        }

        public string CreateTempFile(string contents,
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

        public async Task<DeleteObjectResponse> DeleteObjectAsync(string bucketName,
            string s3Prefix)
        {
            this.Logger.LogDebug($"[{nameof(this.DeleteObjectAsync)}]");

            this.Logger.LogTrace(Text.BucketName(bucketName: bucketName));
            this.Logger.LogTrace(Text.S3Prefix(s3Prefix: s3Prefix));

            if (string.IsNullOrWhiteSpace(bucketName)) throw new ArgumentNullException(nameof(bucketName));
            if (string.IsNullOrWhiteSpace(s3Prefix)) throw new ArgumentNullException(nameof(s3Prefix));

            var request = new Amazon.S3.Model.DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = s3Prefix,
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Client.DeleteObjectAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response;
        }

        /// <summary>
        /// Dispose the client
        /// </summary>
        public void Dispose()
        {
            this.Dispose(disposing: true);

            GC.SuppressFinalize(obj: this);
        }

        /// <summary>
        /// Dispose the client
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.Disposed)
                return;

            if (disposing)
                this.Client.Dispose();

            this.Disposed = true;
        }

        public async Task<GetObjectResponse> GetObjectAsync(string bucketName,
            string s3Prefix)
        {
            this.Logger.LogDebug($"[{nameof(this.GetObjectAsync)}]");

            this.Logger.LogTrace(Text.BucketName(bucketName: bucketName));
            this.Logger.LogTrace(Text.S3Prefix(s3Prefix: s3Prefix));

            if (string.IsNullOrWhiteSpace(bucketName)) throw new ArgumentNullException(nameof(bucketName));
            if (string.IsNullOrWhiteSpace(s3Prefix)) throw new ArgumentNullException(nameof(s3Prefix));

            var request = new Amazon.S3.Model.GetObjectRequest
            {
                BucketName = bucketName,
                Key = s3Prefix,
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Client.GetObjectAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response;
        }

        public async Task<string> StartMultipartUploadAsync(string bucketName,
            string s3Prefix,
            S3CannedACL s3CannedAcl = null)
        {
            this.Logger.LogDebug($"[{nameof(this.StartMultipartUploadAsync)}]");

            this.Logger.LogTrace(Text.BucketName(bucketName: bucketName));
            this.Logger.LogTrace(Text.S3Prefix(s3Prefix: s3Prefix));
            this.Logger.LogTrace(Text.S3CannedACL(s3CannedAcl: s3CannedAcl));

            if (string.IsNullOrWhiteSpace(bucketName)) throw new ArgumentNullException(nameof(bucketName));
            if (string.IsNullOrWhiteSpace(s3Prefix)) throw new ArgumentNullException(nameof(s3Prefix));

            if (s3CannedAcl == null) s3CannedAcl = S3CannedACL.BucketOwnerFullControl;

            var request = new Amazon.S3.Model.InitiateMultipartUploadRequest
            {
                BucketName = bucketName,
                CannedACL = s3CannedAcl,
                Key = s3Prefix,
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Client.InitiateMultipartUploadAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response.UploadId;
        }

        public async Task UploadFileAsync(string bucketName,
            string s3Prefix,
            string contents,
            S3CannedACL s3CannedAcl = null,
            Encoding encoding = null)
        {
            this.Logger.LogDebug($"[{nameof(this.UploadFileAsync)}]");

            this.Logger.LogTrace(Text.BucketName(bucketName: bucketName));
            this.Logger.LogTrace(Text.S3Prefix(s3Prefix: s3Prefix));
            this.Logger.LogTrace(Text.S3CannedACL(s3CannedAcl: s3CannedAcl));
            this.Logger.LogTrace(Text.Encoding(encoding: encoding));

            if (string.IsNullOrWhiteSpace(bucketName)) throw new ArgumentNullException(nameof(bucketName));
            if (string.IsNullOrWhiteSpace(s3Prefix)) throw new ArgumentNullException(nameof(s3Prefix));
            if (string.IsNullOrWhiteSpace(contents)) throw new ArgumentNullException(nameof(contents));

            if (s3CannedAcl == null) s3CannedAcl = S3CannedACL.BucketOwnerFullControl;

            var filePath = this.CreateTempFile(contents: contents,
                encoding: encoding);

            using (var fileTransferUtility = new Amazon.S3.Transfer.TransferUtility(this.Client))
            {
                var request = new Amazon.S3.Transfer.TransferUtilityUploadRequest
                {
                    BucketName = bucketName,
                    CannedACL = s3CannedAcl,
                    FilePath = filePath,
                    Key = s3Prefix,
                };

                this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

                await fileTransferUtility.UploadAsync(request: request);
            }
        }

        public async Task<UploadPartResponse> UploadFilePartAsync(string bucketName,
            string s3Prefix,
            string uploadId,
            int uploadPart,
            string contents,
            Encoding encoding = null)
        {
            this.Logger.LogDebug($"[{nameof(this.UploadFilePartAsync)}]");

            this.Logger.LogTrace(Text.BucketName(bucketName: bucketName));
            this.Logger.LogTrace(Text.S3Prefix(s3Prefix: s3Prefix));
            this.Logger.LogTrace(Text.UploadId(uploadId: uploadId));
            this.Logger.LogTrace(Text.UploadPart(uploadPart: uploadPart));
            this.Logger.LogTrace(Text.Encoding(encoding: encoding));

            if (string.IsNullOrWhiteSpace(bucketName)) throw new ArgumentNullException(nameof(bucketName));
            if (string.IsNullOrWhiteSpace(s3Prefix)) throw new ArgumentNullException(nameof(s3Prefix));
            if (string.IsNullOrWhiteSpace(uploadId)) throw new ArgumentNullException(nameof(uploadId));
            if (uploadPart == 0) throw new ArgumentException(nameof(uploadPart));

            var tooSmall = Encoding.Unicode.GetByteCount(contents) < Text.MinimumPartSize;
            var tooLarge = Encoding.Unicode.GetBytes(contents).LongCount() > Text.MaximumPartSize;

            if (tooSmall || tooLarge) throw new ArgumentOutOfRangeException(nameof(contents), Text.InvalidPartSize);

            var filePath = this.CreateTempFile(contents: contents,
                encoding: encoding);

            var request = new Amazon.S3.Model.UploadPartRequest
            {
                BucketName = bucketName,
                FilePath = filePath,
                Key = s3Prefix,
                PartNumber = uploadPart,
                UploadId = uploadId,
            };

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: request));

            var response = await this.Client.UploadPartAsync(request: request);

            this.Logger.LogTrace(JsonConvert.SerializeObject(value: response));

            return response;
        }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}