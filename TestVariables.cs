using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutApp.Tests
{
    public class TestVariables
    {
        public static Decimal appleCost = 0.60M;
        public static Decimal orangeCost = 0.25M;

        public static List<item> GetFakeListOfItems()
        {
            return new List<item>()
            {
                new item(){ItemName="Apple", ItemPrice=appleCost},
                new item(){ItemName="Apple", ItemPrice=appleCost},
                 new item(){ItemName="Orange", ItemPrice=orangeCost},
                  new item(){ItemName="Orange", ItemPrice=orangeCost},
                   new item(){ItemName="Orange", ItemPrice=orangeCost}
            };
        }
    }
}
