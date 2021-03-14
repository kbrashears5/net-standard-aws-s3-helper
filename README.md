<h1 align="center">Net Standard AWS S3 Helper</h1>

<div align="center">
    
<b>Collection of helper functions for interacting with the AWS S3 service</b>
    
[![Build Status](https://dev.azure.com/kbrashears5/github/_apis/build/status/kbrashears5.net-standard-aws-s3-helper?branchName=master)](https://dev.azure.com/kbrashears5/github/_build/latest?definitionId=6&branchName=master)
[![Tests](https://img.shields.io/azure-devops/tests/kbrashears5/github/6)](https://img.shields.io/azure-devops/tests/kbrashears5/github/6)
[![Code Coverage](https://img.shields.io/azure-devops/coverage/kbrashears5/github/6)](https://img.shields.io/azure-devops/coverage/kbrashears5/github/6)

[![nuget](https://img.shields.io/nuget/v/NetStandardAWSS3Helper.svg)](https://www.nuget.org/packages/NetStandardAWSS3Helper/)
[![nuget](https://img.shields.io/nuget/dt/NetStandardAWSS3Helper)](https://img.shields.io/nuget/dt/NetStandardAWSS3Helper)
</div>

## Usage

### Default - running in Lambda in your own account

```c#
var logger = new ConsoleLogger(logLevel: LogLevel.Information);

var helper = new S3Helper(logger: logger);

await helper.CreateBucketAsync(name: "bucket-name");
```

### Running in separate account or not in Lambda

```c#
var logger = new ConsoleLogger(logLevel: LogLevel.Information);

var options = new AmazonS3Config()
{
    RegionEndpoint = RegionEndpoint.USEast1
};

var repository = new AmazonS3Client(config: options);

var helper = new S3Helper(logger: logger);

await helper.CreateBucketAsync(name: "bucket-name");
```

## Notes

If no options are supplied, will default to `us-east-1` as the region
