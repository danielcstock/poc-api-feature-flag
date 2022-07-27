using System;
using LaunchDarkly.Sdk;
using LaunchDarkly.Sdk.Server;

namespace poc_api_feature_flag.Common
{
    public class LaunchDarklyClient : IFeatureManager
    {
        public bool isFeatureActivated(string featureKey, string username)
        {
            LdClient client = new LdClient("sdk-e1f15101-084e-4ba5-9f49-c6eb0004e8d5");

            User user = User.WithKey(username);
            var response = client.BoolVariation(featureKey, user, false);
            client.Dispose();

            return response;
        }
    }
}
