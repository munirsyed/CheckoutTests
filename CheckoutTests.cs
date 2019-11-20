using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;

namespace CheckoutApp.Tests
{
    public class CheckoutTests
    {



        [Fact]
        public void GivenListOfItems_WhenItemssAreValid_ReturnsTotalCost()
        {
            //arrange
            var listOfItems = TestVariables.GetFakeListOfItems();
            Decimal totalApplePriceInList = listOfItems.Where(x => x.ItemName.ToLower() == "apple").Sum(y => y.ItemPrice);
            Decimal totalOrangePriceInList = listOfItems.Where(x => x.ItemName.ToLower() == "orange").Sum(y => y.ItemPrice);
            var totalPriceInLIst = listOfItems.Sum(x => x.ItemPrice);

            var sut = new Checkout();
            //add


            //act
            var result = sut.CalculateTotalPrice(listOfItems);

            //Assert
            Assert.Equal((Decimal)totalPriceInLIst, (Decimal)result);


        }
        [Fact]
        public void GivenListOfItems_WhenListIsNull_ThrowsArgumentException()
        {
            //arrange
            List<item> listWithNoItems = null;

            //act
            var sut = new Checkout();
                       
        
            //Assert
            Assert.Throws<ArgumentException>(() => { sut.CalculateTotalPrice(listWithNoItems); });


        }
        [Fact]
        public void GivenListOfItems_WhenListHasNoItem_ReturnsZeroTotalCost()
        {
            //arrange
            List<item> listWithNoItems = new List<item>();

            //act
            var sut = new Checkout();


            //Assert
            Assert.Equal(0, sut.CalculateTotalPrice(listWithNoItems));


        }






        [Fact]
        public void GivenListOfItems_WhenItemssAreValid_ReturnsTotalCostWithDiscounts()
        {
            //arrange
            var listOfItems = TestVariables.GetFakeListOfItems();
            Decimal totalApplePriceInList = listOfItems.Where(x => x.ItemName.ToLower() == "apple").Sum(y => y.ItemPrice);
            Decimal totalOrangePriceInList = listOfItems.Where(x => x.ItemName.ToLower() == "orange").Sum(y => y.ItemPrice);

            var appleDiscountPercent = 0.5M;
            var orangeDiscountPercent = 2M / 3M;

            var totalPriceInLIst = listOfItems.Sum(x => x.ItemPrice);

            var totalDiscountedPrice = totalPriceInLIst - ((totalApplePriceInList * appleDiscountPercent) + (totalOrangePriceInList * orangeDiscountPercent));


            var sut = new Checkout();

            //act
            var result = Decimal.Round(sut.CalculateTotalPriceAndApplyDiscounts(listOfItems),2);

            //Assert
            Assert.Equal(Decimal.Round(totalDiscountedPrice,2), result);


        }





    }
}
