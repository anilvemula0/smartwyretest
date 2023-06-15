using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Incentives
{
    public interface IIncentive
    {
        bool CheckRebateSupport(Rebate rebate, Product product, decimal volume);
        decimal CalculateRebateAmount(Rebate rebate, Product product, decimal volume);
    }
}
