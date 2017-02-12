﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TeamFormation.Services
{
    public interface IDataService
    {
        Task<T> GetData<T>(string url) where T : class, new();
    }

    public class DataService : IDataService
    {
        private const string Key = "c36f8649711646c9984736346cb99d40";
        private const string Header = "X-Auth-Token";

        public async Task<T> GetData<T>(string url) where T : class, new()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Accept.Clear();

                    client.DefaultRequestHeaders.Add(Header, Key);

                    using (var response = await client.GetAsync(url))
                    {
                        var stringData = await response.Content.ReadAsStringAsync();

                        if (!string.IsNullOrWhiteSpace(stringData))
                        {
                            return JsonConvert.DeserializeObject<T>(stringData);
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw;
                }
            }

            return default(T);
        }
    }
}