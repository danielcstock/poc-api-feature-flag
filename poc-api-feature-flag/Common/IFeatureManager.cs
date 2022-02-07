using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poc_api_feature_flag.Common
{
    public interface IFeatureManager
    {
        public bool isFeatureActivated(string featureKey);
    }
}
