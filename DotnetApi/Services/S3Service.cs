using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DotnetApi.Services
{
  public class S3Service
  {
    private const string bucketName = "track-my-pack-prd";

    private readonly IAmazonS3 client;

    public S3Service()
    {
      var clientCredentials = new BasicAWSCredentials(Environment.GetEnvironmentVariable("AWS_KEY"), Environment.GetEnvironmentVariable("AWS_SECRET"));
      var config = new AmazonS3Config
      {
        RegionEndpoint = RegionEndpoint.USEast2
      };
      client = new AmazonS3Client(clientCredentials, config);
    }

    public async Task<bool> GetObjectInBucket1()
    {
      try
      {
        GetObjectRequest request = new GetObjectRequest
        {
          BucketName = $"{bucketName}",
          Key = "test.txt"
        };

        GetObjectResponse response = await client.GetObjectAsync(request);

        if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
        {
          Console.WriteLine($"Successfully got {bucketName}.");
          return true;
        }
        else
        {
          Console.WriteLine($"Could not get {bucketName}.");
          return false;
        }
      }
      catch (AmazonS3Exception e)
      {
        Console.WriteLine(
                "Error encountered ***. Message:'{0}' when getting an object"
                , e.Message);
        return false;
      }
      catch (Exception e)
      {
        Console.WriteLine(
            "Unknown encountered on server. Message:'{0}' when getting an object"
            , e.Message);
        return false;
      }
    }

    public async Task<bool> CreateTxtFileInBucket1()
    {
      try
      {
        // 1. Put object-specify only key name for the new object.
        var putRequest1 = new PutObjectRequest
        {
          BucketName = $"{bucketName}",
          Key = "test.txt",
          ContentBody = "This is a test"
          // ContentType = "text/plain",
          // FilePath = "test.txt"
        };

        PutObjectResponse response = await client.PutObjectAsync(putRequest1);

        if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
        {
          Console.WriteLine($"Successfully created {bucketName}.");
          return true;
        }
        else
        {
          Console.WriteLine($"Could not create {bucketName}.");
          return false;
        }
      }
      catch (AmazonS3Exception e)
      {
        Console.WriteLine(
                "Error encountered ***. Message:'{0}' when creating a object"
                , e.Message);
        return false;
      }
      catch (Exception e)
      {
        Console.WriteLine(
            "Unknown encountered on server. Message:'{0}' when creating a object"
            , e.Message);
        return false;
      }
    }

    // public async Task<string> WritingAnObject(Guid entityId, string imageBytes)
    // {
    //   try
    //   {
    //     // Pick a random number so that the single bucket doesn't get too big that we can't filter
    //     Random rand = new Random();
    //     string randomBucketInt = rand.Next(1, 10).ToString();

    //     // 1. Put object-specify only key name for the new object.
    //     var putRequest1 = new PutObjectRequest
    //     {
    //       BucketName = $"{bucketName}/{randomBucketInt}",
    //       Key = entityId.ToString(),
    //       ContentBody = imageBytes,
    //       ContentType = "image/jpeg"
    //     };

    //     PutObjectResponse response1 = await client.PutObjectAsync(putRequest1);

    //     if (response1.HttpStatusCode == System.Net.HttpStatusCode.OK)
    //     {
    //       Console.WriteLine($"Successfully uploaded {entityId.ToString()} to {bucketName}.");
    //       return $"{bucketName}/{randomBucketInt}";
    //     }
    //     else
    //     {
    //       Console.WriteLine($"Could not upload {entityId.ToString()} to {bucketName}.");
    //       return null;
    //     }

    //   }
    //   catch (AmazonS3Exception e)
    //   {
    //     Console.WriteLine(
    //             "Error encountered ***. Message:'{0}' when writing an object"
    //             , e.Message);
    //     return null;
    //   }
    //   catch (Exception e)
    //   {
    //     Console.WriteLine(
    //         "Unknown encountered on server. Message:'{0}' when writing an object"
    //         , e.Message);
    //     return null;
    //   }
    // }
  }
}
