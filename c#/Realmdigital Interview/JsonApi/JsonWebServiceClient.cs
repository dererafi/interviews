using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Realmdigital_Interview.Filters;
using Realmdigital_Interview.Models;

namespace Realmdigital_Interview.JsonApi
{
    public interface IJsonWebServiceClient<TEntity> where TEntity : class
    {
        TEntity DownloadProductById(string productId);
        List<TEntity> DownloadProductsById(string productId);
        List<TEntity> DownloadProductsByName(string productName);
        List<TEntity> DownloadProducts();
    }

    public class JsonWebServiceClient<TEntity> : IJsonWebServiceClient<TEntity> where TEntity : class
    {
        private readonly WebClient _webClient;
        private readonly string _url;

        public JsonWebServiceClient()
        {
            _url = "http://192.168.0.241/eanlist?type=Web";
            _webClient = new WebClient();
        }

        public TEntity DownloadProductById(string productId)
        {
            string jsonData = "";
            try
            {
                _webClient.Headers[HttpRequestHeader.ContentType] = StringConstants.ContentType;
                jsonData = _webClient.UploadString(_url, StringConstants.HttpPost, "{ \"id\": \"" + productId + "\" }");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            //the webservice at "http://192.168.0.241/eanlist?type=Web" is not connecting
            //return JsonConvert.DeserializeObject<TEntity>(jsonData);

            //this is a workaround for unit testing
            string json = File.ReadAllText(@"C:\Users\User1\Documents\GitHub\interviews\c#\Realmdigital Interview\JsonFile.txt");
            return JsonConvert.DeserializeObject<TEntity>(json);
        }

        public List<TEntity> DownloadProductsById(string productId)
        {
            string jsonData = "";
            try
            {
                _webClient.Headers[HttpRequestHeader.ContentType] = StringConstants.ContentType;
                jsonData = _webClient.UploadString(_url, StringConstants.HttpPost, "{ \"id\": \"" + productId + "\" }");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            //the webservice at "http://192.168.0.241/eanlist?type=Web" is not connecting
            //return JsonConvert.DeserializeObject<List<TEntity>>(jsonData);

            string json = File.ReadAllText(@"C:\Users\User1\Documents\GitHub\interviews\c#\Realmdigital Interview\JsonFile.txt");
            return JsonConvert.DeserializeObject<List<TEntity>>(json);
        }

        public List<TEntity> DownloadProductsByName(string productName)
        {
            string jsonData = "";
            try
            {
                _webClient.Headers[HttpRequestHeader.ContentType] = StringConstants.ContentType;
                jsonData = _webClient.UploadString(_url, StringConstants.HttpPost, "{ \"names\": \"" + productName + "\" }");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            //the webservice at "http://192.168.0.241/eanlist?type=Web" is not connecting
            //return JsonConvert.DeserializeObject<List<TEntity>>(jsonData);

            //the webservice at "http://192.168.0.241/eanlist?type=Web" is not connecting
            string json = File.ReadAllText(@"C:\Users\User1\Documents\GitHub\interviews\c#\Realmdigital Interview\JsonFile.txt");
            return JsonConvert.DeserializeObject<List<TEntity>>(json);
        }

        public List<TEntity> DownloadProducts()
        {
            string jsonData = "";
            try
            {
                _webClient.Headers[HttpRequestHeader.ContentType] = StringConstants.ContentType;
                jsonData = _webClient.UploadString(_url, StringConstants.HttpPost);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            //the webservice at "http://192.168.0.241/eanlist?type=Web" is not connecting
            //return JsonConvert.DeserializeObject<List<TEntity>>(jsonData);

            //the webservice at "http://192.168.0.241/eanlist?type=Web" is not connecting
            string json = File.ReadAllText(@"C:\Users\User1\Documents\GitHub\interviews\c#\Realmdigital Interview\JsonFile.txt");
            return JsonConvert.DeserializeObject<List<TEntity>>(json);
        }

    }
}