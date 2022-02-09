namespace poc_api_feature_flag.Common
{
    public interface IFeatureManager
    {
        public bool isFeatureActivated(string featureKey);
    }
}
