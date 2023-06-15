using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Incentives;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    readonly IRebateDataStore _rebateDataStore;
    readonly IProductDataStore _productDataStore;
    public RebateService(IRebateDataStore rebateDataStore, IProductDataStore productDataStore)
    {
        _rebateDataStore = rebateDataStore;
        _productDataStore = productDataStore;
    }
    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        Rebate rebate = _rebateDataStore.GetRebate(request.RebateIdentifier);
        Product product = _productDataStore.GetProduct(request.ProductIdentifier);

        var result = new CalculateRebateResult();

        result.Success = rebate.IncentiveCalculator.CheckRebateSupport(rebate, product, request.Volume);

        if (result.Success)
        {
            _rebateDataStore.StoreCalculationResult(rebate, rebate.IncentiveCalculator.CalculateRebateAmount(rebate, product, request.Volume));
        }

        return result;
    }
}
