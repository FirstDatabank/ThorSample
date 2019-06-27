using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ThorSample.Model;

namespace ThorSample
{
    class Program
    {
            //Note:  Make this address configurable in your app.  It is almost certainly going to change for our thor services.
            //Also note that right now this url and parameter names are case sensitive.
            const string baseAddress = "https://qm.fdbcloudconnector.com/thor/api/v1_4/";

            //Update these two variables with the credentials provided by FDB
            //const string clientId = "REPLACE_THIS_TEXT_WITH_YOUR_PROVIDED_CLIENT_ID";
            //const string secret = "REPLACE_THIS_TEXT_WITH_YOUR_PROVIDED_SECRET";

            const string clientId = "REPLACE_THIS_TEXT_WITH_YOUR_PROVIDED_CLIENT_ID";
            const string secret = "REPLACE_THIS_TEXT_WITH_YOUR_PROVIDED_SECRET";

            static void Main(string[] args)
            {
                GetDrugNames().Wait();
            }

            static async Task GetDrugNames()
            {
                using (var client = new HttpClient())
                {
                    //Here we're adding two headers:  An Authorization header and an accept header.  The authorization header
                    //takes the following format, where xx is the clientId and yyyyyyy is the secret.
                    //Authorization: SHAREDKEY xx:yyyyyyyyyyyyyyyy
                    client.BaseAddress = new Uri(baseAddress);
                    client.DefaultRequestHeaders.Add("Authorization", "SHAREDKEY " + clientId + ":" + secret);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Now structure the request so that it searches on the fields you want.
                    //Here is a request that returns the top 100 drugnames in the database for thor
                    var request = "DrugNames?limit=100&offset=1&callSystemName=ConsoleAppExample";

                //OTHER EXAMPLES:
                //Here is an example of searching for a GTIN14
                //var request = "DrugNames?searchFilter=DrugNameID:11589&callSystemName=ConsoleAppExample";


                //We always recommend calling API services asynchronously
                HttpResponseMessage response = await client.GetAsync(request);

                //Look for a 200 status code.  400 level status codes indicate something went wrong that a client could potentially fix.
                // For example, 401 unauthorized, or 404 not found.
                // 500 level errors indicate that something went wrong on the server side.
                if (response.IsSuccessStatusCode)
                {

                    var r = await response.Content.ReadAsAsync<SearchDrugNamesResponse>();
                    foreach (var drugName in r.Items)
                    {
                        Console.WriteLine("DrugNameID: " +drugName.DrugNameID);
                        Console.WriteLine("DrugNameDescriptions:");
                        foreach (var drugDesc in drugName.DrugNameDescriptions)
                        {
                            Console.WriteLine(" DrugNameDesc: " + drugDesc.DrugNameDesc);
                            Console.WriteLine(" DrugNameLanguage: " + drugDesc.DrugNameLanguage);
                        }
                        Console.WriteLine("GenericDrugNameID: " + drugName.GenericDrugNameID);
                        Console.WriteLine("NameTypeCode: " + drugName.NameTypeCode);
                        Console.WriteLine("NameTypeCodeDesc: " + drugName.NameTypeCodeDesc);
                        Console.WriteLine("StatusCode: " + drugName.StatusCode);
                        Console.WriteLine("StatusCodeDesc: " + drugName.StatusCodeDesc);
                        Console.WriteLine("");
                    }
                    Console.WriteLine("TotalResultCount: " + r.TotalResultCount);
                    Console.WriteLine("");

                }
                else
                {
                    Console.WriteLine("Call Failed, reason: " + response.ReasonPhrase);
                    Console.WriteLine("");
                }

                Console.WriteLine("Press Enter to Exit.");
                    Console.ReadLine();
                }
            }
        }
}
