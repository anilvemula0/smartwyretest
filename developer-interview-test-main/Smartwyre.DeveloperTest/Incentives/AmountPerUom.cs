using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Incentives
{
    public class AmountPerUom : IIncentive
    {
        public decimal CalculateRebateAmount(Rebate rebate, Product product, decimal volume)
        {
            return rebate.Amount * volume;
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
            else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom))
            {
                return false;
            }
            else if (rebate.Amount == 0 || volume == 0)
            {
                return false;
            }
            return true;
        }
    }
}
