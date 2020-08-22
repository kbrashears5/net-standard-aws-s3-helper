namespace AWSS3Helper
{
    /// <summary>
    /// Action to perform for signed urls
    /// </summary>
    public enum SignedUrlType
    {
        /// <summary>
        /// Download from S3
        /// </summary>
        Download = 0,

        /// <summary>
        /// Upload to S3
        /// </summary>
        Upload = 1,
    }
}