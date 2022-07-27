using System;
using Splitio.Services.Client.Classes;

namespace poc_api_feature_flag.Common
{
    public class SplitIO : IFeatureManager
    {
        bool IFeatureManager.isFeatureActivated(string featureKey, string user)
        {
            var config = new ConfigurationOptions();

            var factory = new SplitFactory("r791mub8dc1qfqul8gd34g9fua9cbu4qgci4", config);

            var splitClient = factory.Client();
            try
            {
                splitClient.BlockUntilReady(10000);
            }
            catch (Exception ex)
            {
                // log & handle 
            }

            var treatment = splitClient.GetTreatment(user, featureKey);

            var response = treatment == "alive";

            splitClient.Destroy();

            return response;
        }
    }
}