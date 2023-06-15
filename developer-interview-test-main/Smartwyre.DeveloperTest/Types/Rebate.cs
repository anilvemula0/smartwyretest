using Smartwyre.DeveloperTest.Incentives;
using System;

namespace Smartwyre.DeveloperTest.Types;

public class Rebate
{
    public string Identifier { get; set; }
    public IncentiveType Incentive { get; set; }
    public decimal Amount { get; set; }
    public decimal Percentage { get; set; }

    public IIncentive IncentiveCalculator { get { return IncentiveFactory.CreateIncentive(Incentive); } }

}
