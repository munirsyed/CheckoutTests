using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;

namespace CheckoutApp.Tests
{
    public class DiscountTests
    {

        [Fact]
        public void GivenListOfApples_WhenThereIs2For1Offer_AppliesCorrectyTheDiscount()
        {
            //arrange
            var listOfItems = TestVariables.GetFakeListOfItems();
            Decimal totalApplePriceInList = listOfItems.Where(x => x.ItemName.ToLower() == "apple").Sum(y => y.ItemPrice);

            var appleDiscountPercent = 0.5M;
           

            var discountedPrice = Decimal.Round(totalApplePriceInList * appleDiscountPercent, 2);

            //I know there are 2 apples

            var expectedResult = (2 * Utility.appleCost) * appleDiscountPercent; 

            Assert.Equal(expectedResult, discountedPrice);
        }


        [Fact]
        public void GivenListOfOranges_WhenThereIs3For2Offer_AppliesCorrectyTheDiscount()
        {
            //arrange
            var listOfItems = TestVariables.GetFakeListOfItems();
            Decimal totalOrangePriceInList = listOfItems.Where(x => x.ItemName.ToLower() == "orange").Sum(y => y.ItemPrice);

            var orangeDiscountPercent = Decimal.Round( 2M/3M,2) ;


            var discountedPrice = Decimal.Round(totalOrangePriceInList * orangeDiscountPercent, 2);

            //I know there are 3 oranges
            var expectedResult = Decimal.Round( (3 * Utility.orangeCost) * orangeDiscountPercent,2);

            Assert.Equal(expectedResult, discountedPrice);
        }
    }
}
