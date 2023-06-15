using System;
using Xunit;
using Moq;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Tests.Mocks;

namespace Smartwyre.DeveloperTest.Tests;

public class PaymentServiceTests
{
    private IRebateService rebateService;
    public PaymentServiceTests()
    {
    }

    [Fact]
    public void FixedCashAmountIncetiveTest()
    {
        //Arrange
        var mockProductDataStore = new Mock<IProductDataStore>();
        mockProductDataStore.Setup(x => x.GetProduct(It.IsAny<string>()))
            .Returns(new Product() { Id = 1, Identifier = "CATI", Price = 230, SupportedIncentives = SupportedIncentiveType.FixedCashAmount, Uom = "U1" });
        var rebate = new Rebate() { Amount = 120, Identifier = "REB", Incentive = IncentiveType.FixedCashAmount, Percentage = 50 };
        var mockRebateDataStore = new MockRebateDataStore(rebate);

        //mockRebateDataStore.Setup(x => x.StoreCalculationResult(rebate, It.IsAny<decimal>())).Callback(new Action<Rebate, decimal>((x, y) => { x.Amount = y;mockRebateDataStore.Object.Rebates.Add(y) }));
        rebateService = new RebateService(mockRebateDataStore, mockProductDataStore.Object);

        //Act
        var rebateRequest = new CalculateRebateRequest() { ProductIdentifier = "CATI", RebateIdentifier = "REB", Volume = 100 };
        var result = rebateService.Calculate(rebateRequest);

        //Assert
        Assert.True(result.Success);
        Assert.Equal<decimal>((decimal)120.0, rebate.Amount);
    }

    [Fact]
    public void FixedRateRebateIncetiveTest()
    {
        //Arrange
        var mockProductDataStore = new Mock<IProductDataStore>();
        mockProductDataStore.Setup(x => x.GetProduct(It.IsAny<string>()))
            .Returns(new Product() { Id = 1, Identifier = "CATI", Price = 230, SupportedIncentives = SupportedIncentiveType.FixedRateRebate, Uom = "U1" });
        var rebate = new Rebate() { Amount = 120, Identifier = "REB", Incentive = IncentiveType.FixedRateRebate, Percentage = (decimal)0.5 };
        var mockRebateDataStore = new MockRebateDataStore(rebate);

        //mockRebateDataStore.Setup(x => x.StoreCalculationResult(rebate, It.IsAny<decimal>())).Callback(new Action<Rebate, decimal>((x, y) => { x.Amount = y;mockRebateDataStore.Object.Rebates.Add(y) }));
        rebateService = new RebateService(mockRebateDataStore, mockProductDataStore.Object);

        //Act
        var rebateRequest = new CalculateRebateRequest() { ProductIdentifier = "CATI", RebateIdentifier = "REB", Volume = 5 };
        var result = rebateService.Calculate(rebateRequest);

        //Assert
        Assert.True(result.Success);
        Assert.Equal<decimal>((decimal)575.0, rebate.Amount);
    }

    [Fact]
    public void AmountPerUomIncetiveTest()
    {
        //Arrange
        var mockProductDataStore = new Mock<IProductDataStore>();
        mockProductDataStore.Setup(x => x.GetProduct(It.IsAny<string>()))
            .Returns(new Product() { Id = 1, Identifier = "CATI", Price = 230, SupportedIncentives = SupportedIncentiveType.AmountPerUom, Uom = "U1" });
        var rebate = new Rebate() { Amount = 120, Identifier = "REB", Incentive = IncentiveType.AmountPerUom, Percentage = (decimal)0.65 };
        var mockRebateDataStore = new MockRebateDataStore(rebate);

        //mockRebateDataStore.Setup(x => x.StoreCalculationResult(rebate, It.IsAny<decimal>())).Callback(new Action<Rebate, decimal>((x, y) => { x.Amount = y;mockRebateDataStore.Object.Rebates.Add(y) }));
        rebateService = new RebateService(mockRebateDataStore, mockProductDataStore.Object);

        //Act
        var rebateRequest = new CalculateRebateRequest() { ProductIdentifier = "CATI", RebateIdentifier = "REB", Volume = 3 };
        var result = rebateService.Calculate(rebateRequest);

        //Assert
        Assert.True(result.Success);
        Assert.Equal<decimal>((decimal)360.0, rebate.Amount);
    }
}
