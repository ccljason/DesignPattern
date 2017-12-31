using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Pluralsight
{
   public static class RunThis
   {
      public static void Example()
      {
         ICostStrategy strategy = new UPSCostStrategy();
         var shippingCalculatorService = new ShippingCalculatorService(strategy);
         var upsCost = shippingCalculatorService.CalculateShipping();

         strategy = new DHLCostStrategy();
         shippingCalculatorService = new ShippingCalculatorService(strategy);
         var dhlCost = shippingCalculatorService.CalculateShipping();
      }
   }


   internal class ShippingCalculatorService
   {
      private readonly ICostStrategy _strategy;

      public ShippingCalculatorService(ICostStrategy strategy)
      {
         _strategy = strategy;
      }

      public double CalculateShipping()
      {
         return _strategy.Calculate();
      }
   }

   internal interface ICostStrategy
   {
      double Calculate();
   }

   internal class UPSCostStrategy : ICostStrategy
   {
      public double Calculate()
      {
         return 10.0;
      }
   }

   internal class DHLCostStrategy : ICostStrategy
   {
      public double Calculate()
      {
         return 12;
      }
   }

}
