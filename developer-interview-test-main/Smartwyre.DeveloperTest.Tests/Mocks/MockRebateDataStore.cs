using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Tests.Mocks
{
    public class MockRebateDataStore : IRebateDataStore
    {
        private Rebate _rebate;
        public Rebate Rebate
        {
            get
            { return _rebate; }
            set
            { _rebate = value; }
        }
        public MockRebateDataStore(Rebate rebate)
        {
            Rebate = rebate;
        }
        public Rebate GetRebate(string rebateIdentifier)
        {
            // Access database to retrieve account, code removed for brevity 
            return Rebate;
        }

        public void StoreCalculationResult(Rebate account, decimal rebateAmount)
        {
            account.Amount = rebateAmount;
            _rebate = account;
            // Update account in database, code removed for brevity
        }
    }
}
