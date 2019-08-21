using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleEnvioArquivoS3.AWS
{
    public class EnvioS3
    {
        //Nome do Bucket
        private const string bucketName = "bucketprod1";
        //Nome do arquivo 
        private const string keyName = "HOMOLOGACAO/teste123";

        private const string filePath = @"C:\Teste.txt";

        //Região do Bucket
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.SAEast1;
        //Client do S3
        private static IAmazonS3 s3Client;

        //Construtor
        public EnvioS3()
        {
            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials("xxx", "yyy");

            s3Client = new AmazonS3Client(awsCredentials, bucketRegion);
        }

        //Método de Upload do arquivo para o S3
        public async Task UploadFileAsync()
        {
            var fileTransferUtility =
                 new TransferUtility(s3Client);

            try
            {
                await fileTransferUtility.UploadAsync(filePath, bucketName, keyName);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Erro AWS: '{0}'", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:'{0}'", e.Message);
            }
        }



    }
}