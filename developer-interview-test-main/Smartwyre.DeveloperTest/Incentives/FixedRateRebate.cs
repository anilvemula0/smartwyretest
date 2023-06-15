using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Incentives
{
    public class FixedRateRebate : IIncentive
    {
        public decimal CalculateRebateAmount(Rebate rebate, Product product, decimal volume)
        {
            return product.Price * rebate.Percentage * volume;
        }

        public bool CheckRebateSupport(Rebate rebate, Product product, decimal volume)
        {
            if (rebate == null)
            {
                return false;
            }
            else if (product == null)
            {
                return false;
            }
            else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate))
            {
                return false;
            }
            else if (rebate.Percentage == 0 || product.Price == 0 || volume == 0)
            {
                return false;
            }
            return true;
        }
    }
}
