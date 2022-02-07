using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poc_api_feature_flag.Common
{
    public class SplitIO : IFeatureManager
    {
        bool IFeatureManager.isFeatureActivated(string featureKey)
        {
            return false;
        }
    }
}
