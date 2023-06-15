using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Incentives
{
    public static class IncentiveFactory
    {
        public static IIncentive CreateIncentive(IncentiveType incentive)
        {
            IIncentive incentiveService = null;
            switch (incentive)
            {
                case IncentiveType.FixedRateRebate:
                    incentiveService = new FixedRateRebate();
                    break;
                case IncentiveType.AmountPerUom:
                    incentiveService = new AmountPerUom();
                    break;
                case IncentiveType.FixedCashAmount:
                    incentiveService = new FixedCashAmount();
                    break;
            }
            return incentiveService;
        }
    }
}
