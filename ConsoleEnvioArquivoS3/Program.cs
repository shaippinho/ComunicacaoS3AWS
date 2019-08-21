using System;

namespace ConsoleEnvioArquivoS3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Envia um arquivo para o S3
            AWS.EnvioS3 s3 = new AWS.EnvioS3();
            s3.UploadFileAsync().Wait();
            
            //Busca um arquivo no S3
            AWS.GetS3 get = new AWS.GetS3();
            get.ReadObjectDataAsync().Wait();
           
        }
    }
}
