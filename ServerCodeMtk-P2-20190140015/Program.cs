using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using FirstWCFService_015;
using System.ServiceModel.Description;
using System.ServiceModel.Channels; // mex

namespace ServerCodeMtk_P2_20190140015
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostObj = null;
            Uri address = new Uri("http://localhost:8888/Matematika");
            BasicHttpBinding bind = new BasicHttpBinding();

            try
            {
                hostObj = new ServiceHost(typeof(Matematika), address); // BASE ADDRESS
                hostObj.AddServiceEndpoint(typeof(IMatematika), bind, ""); // ENDPOINT

                // wsdl
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior(); // SERVICE RUNTIME PLAYER
                smb.HttpGetEnabled = true; // AKTIVASI WSDL
                hostObj.Description.Behaviors.Add(smb);

                // mex
                Binding mexBind = MetadataExchangeBindings.CreateMexHttpBinding();
                hostObj.AddServiceEndpoint(typeof(IMetadataExchange), mexBind, "mex");
                hostObj.Open();
                Console.WriteLine("Server is Ready!");
                Console.ReadLine();

                hostObj.Close();
            }
            catch(Exception ex)
            {
                hostObj = null;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
