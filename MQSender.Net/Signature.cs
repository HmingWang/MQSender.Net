using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;


namespace MQSender.Net
{
    class Signature
    {
        private string keyFilePath;
        private string crtFilePath;
        private string password;

        public Signature(string certPath,string keyPath,string pwd)
        {
            keyFilePath = keyPath;
            crtFilePath = certPath;
            password = pwd;
        }

        public string HashAndSign(string plainText)
        {
            X509Certificate2 x509Certificate2 = new X509Certificate2(keyFilePath,password);
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            //将明文转byte[]
            byte[] dataToEncrypt = ByteConverter.GetBytes(plainText);
            //将证书中私钥转为rsa对象
            RSACryptoServiceProvider RSAalg = x509Certificate2.PrivateKey as RSACryptoServiceProvider;
            //使用SHA1哈希进行摘要算法，
            byte[] encryptedData = RSAalg.SignData(dataToEncrypt, new SHA1CryptoServiceProvider());
            //得到签名
            //string signStr = Convert.ToBase64String(encryptedData);
            string signStr = BytesToHexString(encryptedData);
            RSAalg.Clear();
            RSAalg.Dispose();
            return signStr;
        }

        public bool VerifySigned(string plaintext, string signedData)
        {
            //根据证书友好名称查找证书
            X509Certificate2 x509Certificate2 = new X509Certificate2(crtFilePath);

            //将证书公钥转为rsa对象
            RSACryptoServiceProvider RSAalg = x509Certificate2.PublicKey.Key as RSACryptoServiceProvider;
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            //将明文转byte[]
            byte[] dataToVerifyBytes = ByteConverter.GetBytes(plaintext);
            //将签名转byte[]
            byte[] signedDataBytes = Convert.FromBase64String(signedData);
            //验证签名
            bool isSuccess = RSAalg.VerifyData(dataToVerifyBytes, new SHA1CryptoServiceProvider(), signedDataBytes);
            RSAalg.Clear();
            RSAalg.Dispose();
            return isSuccess;
        }

        public string BytesToHexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.AppendFormat("{0:x2}", b);
            }

            return sb.ToString();
        }
    }
}
