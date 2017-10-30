//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//using System.Net.Http;

//using System.Net.Http.Headers;

//using System.Text;

//using System.Threading.Tasks;

//namespace AteliwareExam.Models
//{
//    public class RestClientRequest
//    {

//        public class Product

//        {

//            public int ProductID { get; set; }

//            public string Name { get; set; }

//            public int Quantity { get; set; }

//            public int OrderMaximumQuantity { get; set; }

//            public decimal Price { get; set; }

//            public string Description { get; set; }

//            public string ImageSmall { get; set; }

//            public string ImageLarge { get; set; }

//            public decimal PriceModifier { get; set; }

//        }



//        class Program

//        {

//            static void Main()

//            {

//                RunAsync().Wait();

//                Console.ReadLine();

//            }



//            static async Task RunAsync()

//            {

//                using (var client = new HttpClient())

//                {

//                    client.BaseAddress = new Uri("http://localhost:62733/");

//                    client.DefaultRequestHeaders.Accept.Clear();

//                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



//                    // HTTP GET

//                    HttpResponseMessage response = await client.GetAsync("api/products/1");

//                    if (response.IsSuccessStatusCode)

//                    {

//                        Product product = await response.Content.ReadAsAsync<Product>();

//                        Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Quantity);

//                    }

//                    response = await client.GetAsync("api/products");

//                    if (response.IsSuccessStatusCode)

//                    {

//                        List<Product> products = await response.Content

//                            .ReadAsAsync<List<Product>>();



//                        foreach (Product product in products)

//                        {

//                            Console.WriteLine("{0}\t${1}\t{2}",

//                                product.Name, product.Price, product.Quantity);

//                        }

//                    }

//                    //return;



//                    // HTTP POST

//                    var gizmo = new Product() { Name = "Gizmo", Price = 100, Quantity = 35 };

//                    response = await client.PostAsJsonAsync("api/products", gizmo);



//                    //return;

//                    if (response.IsSuccessStatusCode)

//                    {

//                        Uri gizmoUrl = response.Headers.Location;



//                        // HTTP PUT

//                        gizmo.Price = 80;   // Update price

//                        response = await client.PutAsJsonAsync(gizmoUrl, gizmo);



//                        return;



//                        // HTTP DELETE

//                        response = await client.DeleteAsync(gizmoUrl);

//                    }

//                }

//            }

//        }

//    }
//}