using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.IO;
using System.Threading.Tasks;


namespace ConsoleEnvioArquivoS3.AWS
{
    public class GetS3
    {


        //Nome do bucket
        private const string bucketName = "bucketprod1";
        //Nome do arquivo 
        private const string keyName = "HOMOLOGACAO/teste123";

        //Region
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.SAEast1;
        //Client do S3
        private static IAmazonS3 s3Client;

        public GetS3()
        {
            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials("xxx", "yyy");

            s3Client = new AmazonS3Client(awsCredentials, bucketRegion);
        }

        public async Task ReadObjectDataAsync()
        {
            string responseBody = "";

            try
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName
                };
                using (GetObjectResponse response = await s3Client.GetObjectAsync(request))
                using (Stream responseStream = response.ResponseStream)
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    string title = response.Metadata["x-amz-meta-title"]; // Assume you have "title" as medata added to the object.
                    string contentType = response.Headers["Content-Type"];
                    Console.WriteLine("Object metadata, Title: {0}", title);
                    Console.WriteLine("Content type: {0}", contentType);

                    responseBody = reader.ReadToEnd(); // Now you process the response body.
                }
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Erro AWS:'{0}'", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro:'{0}' ", e.Message);
            }
        }
    }
}