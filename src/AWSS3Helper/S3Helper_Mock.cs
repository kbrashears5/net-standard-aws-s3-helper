using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Net;
using System.Text;
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

        public Task<CompleteMultipartUploadResponse> CompleteMultipartUploadAsync(string bucketName,
            string s3Prefix,
            string uploadId)
        {
            var response = new CompleteMultipartUploadResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
            };

            return Task.FromResult(response);
        }

        public string CreateTempFile(string contents,
            Encoding encoding = null)
        {
            return Text.FilePath;
        }

        public Task<DeleteObjectResponse> DeleteObjectAsync(string bucketName,
            string s3Prefix)
        {
            var response = new DeleteObjectResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
            };

            return Task.FromResult(response);
        }

        public Task<GetObjectResponse> GetObjectAsync(string bucketName,
            string s3Prefix)
        {
            var response = new GetObjectResponse()
            {
                BucketName = bucketName,
                HttpStatusCode = HttpStatusCode.OK,
                Key = s3Prefix,
            };

            return Task.FromResult(response);
        }

        public Task<string> StartMultipartUploadAsync(string bucketName,
            string s3Prefix,
            S3CannedACL s3CannedAcl = null)
        {
            var response = nameof(Text.UploadId);

            return Task.FromResult(response);
        }

        public Task UploadFileAsync(string bucketName,
            string s3Prefix,
            string contents,
            S3CannedACL s3CannedAcl = null,
            Encoding encoding = null)
        {
            return Task.FromResult(string.Empty);
        }

        public Task<UploadPartResponse> UploadFilePartAsync(string bucketName,
            string s3Prefix,
            string uploadId,
            int uploadPart,
            string contents,
            Encoding encoding = null)
        {
            var response = new UploadPartResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
            };

            return Task.FromResult(response);
        }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}