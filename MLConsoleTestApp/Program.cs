using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MLConsoleTestApp
{
    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InvokeRequestResponseService().Wait();
        }

        static async Task InvokeRequestResponseService()
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, StringTable>()
                    {
                        {
                            "input1",
                            new StringTable()
                            {
                                //ColumnNames = new string[] { "age", "workclass", "fnlwgt", "education", "education-num", "marital-status", "occupation", "relationship", "race", "sex", "capital-gain", "capital-loss", "hours-per-week", "native-country", "income"},
                                ColumnNames = new string[] {"Age",
                                                            "Workclass",
                                                            "Fnlwgt",
                                                            "Education",
                                                            "Education-num",
                                                            "Marital-status",
                                                            "Occupation",
                                                            "Relationship",
                                                            "Race",
                                                            "Sex",
                                                            "Capital-gain",
                                                            "Capital-loss",
                                                            "Hours-per-week",
                                                            "Native-country",
                                                            "Income"},
                                //Values = new string[,] { { "0", "value", "0", "value", "0", "value", "value", "value", "value", "value", "0", "0", "0", "value", "value" }, { "0", "value", "0", "value", "0", "value", "value", "value", "value", "value", "0", "0", "0", "value", "value" } }
                                Values = new string[,] { { "52", "Self-emp-not-inc", "209642", "HS-grad", "12", "Married-civ-spouse", "Exec-managerial", "Husband", "White", "Male", "0", "0", "45", "United-States", "0" } }
                            }
                        }
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {

                    }
                };
                const string apiKey = "gE7GS0g98G/Kcpy/F1oWSC23BYhWIvB7rKIVv9WcXFMPFTT1jnesknXmNSYKkop6XLI0valyd/Va1s32ek5sSQ==";
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/46ac4bd491e14dc8b1edbcbb921dcea5/services/4e38080d3670486c81aac3f571d471b0/execute?api-version=2.0&details=true");
                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Result: {0}", result);
                }else
                {
                    Console.WriteLine("Failed with status code: {0}", response.StatusCode);
                }
                Console.ReadLine();
            }
        }
    }
}
