using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Incentives
{
    public class FixedCashAmount : IIncentive
    {
        public decimal CalculateRebateAmount(Rebate rebate, Product product, decimal volume)
        {
            return rebate.Amount;
        }

        public bool CheckRebateSupport(Rebate rebate, Product product, decimal volume)
        {
            if (rebate == null)
            {
                return false;
            }
            else if (rebate.Amount == 0)
            {
                return false;
            }
            else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount))
            {
                return false;
            }
            return true;
        }
    }
}
