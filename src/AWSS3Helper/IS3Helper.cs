using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AWSS3Helper
{
    /// <summary>
    /// Functions to interact with AWS S3 service
    /// </summary>
    public interface IS3Helper
    {
        /// <summary>
        /// Marks the multipart upload as complete
        /// </summary>
        /// <param name="bucketName">Bucket name</param>
        /// <param name="s3Prefix">Prefix and file name to upload to</param>
        /// <param name="uploadId">The UploadId for the multipart object to add to</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<CompleteMultipartUploadResponse> CompleteMultipartUploadAsync(string bucketName,
            string s3Prefix,
            string uploadId);

        /// <summary>
        /// Creates a temporary file to upload to S3
        /// </summary>
        /// <param name="contents">File contents</param>
        /// <param name="encoding">Text encoding</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        string CreateTempFile(string contents,
            Encoding encoding = null);

        /// <summary>
        /// Deletes a given S3 object
        /// </summary>
        /// <param name="bucketName">Bucket name</param>
        /// <param name="s3Prefix">Prefix and file name to upload to</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<DeleteObjectResponse> DeleteObjectAsync(string bucketName,
            string s3Prefix);

        /// <summary>
        /// Retrieves the contents of an S3 object
        /// </summary>
        /// <param name="bucketName">Bucket name</param>
        /// <param name="s3Prefix">Prefix and file name to upload to</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<GetObjectResponse> GetObjectAsync(string bucketName,
            string s3Prefix);

        /// <summary>
        /// Starts a multipart upload for a S3 object
        /// </summary>
        /// <param name="bucketName">Bucket name</param>
        /// <param name="s3Prefix">Prefix and file name to upload to</param>
        /// <param name="s3CannedAcl">ACL Permissions</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<string> StartMultipartUploadAsync(string bucketName,
           string s3Prefix,
           S3CannedACL s3CannedAcl = null);

        /// <summary>
        /// Uploads a file to S3
        /// </summary>
        /// <param name="bucketName">Bucket name</param>
        /// <param name="s3Prefix">Prefix and file name to upload to</param>
        /// <param name="contents">Contents to upload</param>
        /// <param name="s3CannedAcl">ACL Permissions</param>
        /// <param name="encoding">Text encoding</param>
        /// <exception cref="ArgumentNullException"></exception>
        Task UploadFileAsync(string bucketName,
              string s3Prefix,
              string contents,
              S3CannedACL s3CannedAcl = null,
              Encoding encoding = null);

        /// <summary>
        /// Uploads a file as a part to an S3 multipart object
        /// </summary>
        /// <param name="bucketName">Bucket name</param>
        /// <param name="s3Prefix">Prefix and file name to upload to</param>
        /// <param name="uploadId">The UploadId for the multipart object to add to</param>
        /// <param name="uploadPart">Part number of the part being uploaded</param>
        /// <param name="contents">Contents to upload</param>
        /// <param name="encoding">Text encoding</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        Task<UploadPartResponse> UploadFilePartAsync(string bucketName,
            string s3Prefix,
            string uploadId,
            int uploadPart,
            string contents,
            Encoding encoding = null);
    }
}