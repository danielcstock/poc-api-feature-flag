using System;
using Splitio.Services.Client.Classes;

namespace poc_api_feature_flag.Common
{
    public class SplitIO : IFeatureManager
    {
        bool IFeatureManager.isFeatureActivated(string featureKey)
        {
            var config = new ConfigurationOptions();
            
            var factory = new SplitFactory("d5ku640jvdbhufo15pb441sk310is0eeriit", config);

            var splitClient = factory.Client();
            try
            {
                splitClient.BlockUntilReady(10000);
            }
            catch (Exception ex)
            {
                // log & handle 
            }

            var treatment = splitClient.GetTreatment("daniel.stock", "test_split");

            var response = treatment == "on";
            
            splitClient.Destroy();

            return response;
        }
    }
}
