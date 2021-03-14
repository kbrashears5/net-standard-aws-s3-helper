using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AWSS3Helper
{
    /// <summary>
    /// Functions to interact with AWS S3 service
    /// </summary>
    public interface IS3Helper : IDisposable
    {
        /// <summary>
        /// Copy an object from source to target
        /// </summary>
        /// <param name="sourceBucket">Source bucket name</param>
        /// <param name="sourceKey">Source key</param>
        /// <param name="destinationBucket">Destination bucket name</param>
        /// <param name="destinationKey">Destination key</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<CopyObjectResponse> CopyObjectAsync(string sourceBucket,
            string sourceKey,
            string destinationBucket,
            string destinationKey,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a S3 bucket
        /// </summary>
        /// <param name="name">Bucket name</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<PutBucketResponse> CreateBucketAsync(string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete a S3 bucket
        /// </summary>
        /// <param name="name">Bucket name</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<DeleteBucketResponse> DeleteBucketAsync(string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete an object
        /// </summary>
        /// <param name="bucket">Bucket name</param>
        /// <param name="key">Object key</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<DeleteObjectResponse> DeleteObjectAsync(string bucket,
            string key,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete multiple objects
        /// </summary>
        /// <param name="bucket">Bucket names</param>
        /// <param name="keys">List of object keys to delete</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<DeleteObjectsResponse> DeleteObjectsAsync(string bucket,
            IEnumerable<string> keys,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete all the object tags off of an object
        /// </summary>
        /// <param name="bucket">Bucket name</param>
        /// <param name="key">Object key</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<DeleteObjectTaggingResponse> DeleteObjectTagsAsync(string bucket,
            string key,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a JSON typed object from S3
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bucket">Bucket name</param>
        /// <param name="key">Object key</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<T> GetObjectAsJsonAsync<T>(string bucket,
            string key,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get an object from S3
        /// </summary>
        /// <param name="bucket">Bucket name</param>
        /// <param name="key">Object key</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<GetObjectResponse> GetObjectAsync(string bucket,
            string key,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the contents of an S3 object
        /// </summary>
        /// <param name="bucket">Bucket name</param>
        /// <param name="key">Object key</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<string> GetObjectContentsAsync(string bucket,
            string key,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get metadata about an object
        /// </summary>
        /// <param name="bucket">Bucket name</param>
        /// <param name="key">Object key</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<MetadataCollection> GetObjectMetadataAsync(string bucket,
            string key,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the tags for an object
        /// </summary>
        /// <param name="bucket">Bucket name</param>
        /// <param name="key">Object key</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<IEnumerable<Tag>> GetObjectTagsAsync(string bucket,
            string key,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a signed url to upload to or download from
        /// </summary>
        /// <param name="bucket">Bucket name</param>
        /// <param name="key">Object key</param>
        /// <param name="type">Type of signed url to get</param>
        /// <param name="timeoutInMinutes">Timeout for the signed url</param>
        /// <param name="acl">ACL of file if uploading</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        string GetSignedUrl(string bucket,
            string key,
            SignedUrlType type,
            int timeoutInMinutes,
            S3CannedACL acl = null);

        /// <summary>
        /// Move an object within a bucket or to a different bucket
        /// </summary>
        /// <param name="sourceBucket">Source bucket name</param>
        /// <param name="sourceKey">Source key</param>
        /// <param name="destinationBucket">Destination bucket name</param>
        /// <param name="destinationKey">Destination key</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<bool> MoveObjectAsync(string sourceBucket,
            string sourceKey,
            string destinationBucket,
            string destinationKey,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Marks the multipart upload as complete
        /// </summary>
        /// <param name="bucket">Bucket name</param>
        /// <param name="key">Object key</param>
        /// <param name="uploadId">The UploadId of the multipart object</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<CompleteMultipartUploadResponse> MultipartUploadCompleteAsync(string bucket,
            string key,
            string uploadId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Starts a multipart upload for a S3 object
        /// </summary>
        /// <param name="bucket">Bucket name</param>
        /// <param name="key">Object key</param>
        /// <param name="s3CannedAcl">ACL Permissions</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<string> MultipartUploadStartAsync(string bucket,
           string key,
           S3CannedACL s3CannedAcl = null,
           CancellationToken cancellationToken = default);

        /// <summary>
        /// Upload a part to a S3 multipart object
        /// </summary>
        /// <param name="bucket">Bucket name</param>
        /// <param name="key">Object key</param>
        /// <param name="uploadId">The UploadId for the multipart object to add to</param>
        /// <param name="uploadPart">Part number of the part being uploaded</param>
        /// <param name="contents">Contents to upload</param>
        /// <param name="encoding">Text encoding</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        Task<UploadPartResponse> MultipartUploadUploadPartAsync(string bucket,
            string key,
            string uploadId,
            int uploadPart,
            string contents,
            Encoding encoding = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Upload an object to S3
        /// </summary>
        /// <param name="bucket">Bucket name</param>
        /// <param name="key">Object key</param>
        /// <param name="contents">Object contents as a string</param>
        /// <param name="s3CannedAcl">ACL permissions</param>
        /// <param name="encoding">Text encoding</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"></exception>
        Task<PutObjectResponse> PutObjectAsync(string bucket,
            string key,
            string contents,
            S3CannedACL s3CannedAcl = null,
            Encoding encoding = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Upload an object to S3
        /// </summary>
        /// <param name="bucket">Bucket name</param>
        /// <param name="key">Object key</param>
        /// <param name="contents">Object contents as a <see cref="Stream"/></param>
        /// <param name="s3CannedAcl">ACL permissions</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"></exception>
        Task<PutObjectResponse> PutObjectAsync(string bucket,
            string key,
            Stream contents,
            S3CannedACL s3CannedAcl = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Inserts or updates a tag on an object
        /// </summary>
        /// <param name="bucket">Bucket name</param>
        /// <param name="key">Object key</param>
        /// <param name="tagName">Tag name</param>
        /// <param name="tagValue">Tag value</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<PutObjectTaggingResponse> SetObjectTagAsync(string bucket,
            string key,
            string tagName,
            string tagValue,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Set the tags on an object
        /// </summary>
        /// <param name="bucket">Bucket name</param>
        /// <param name="key">Object key</param>
        /// <param name="tags">Tags</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<PutObjectTaggingResponse> SetObjectTagsAsync(string bucket,
            string key,
            IEnumerable<Tag> tags,
            CancellationToken cancellationToken = default);
    }
}