using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Pluralsight
{
   public static class RunThis
   {
      public static void Example()
      {
         IAutoFactory factory = new BMWFactory();
         IAutomobile car1 = factory.CreateEconomyCar();
         IAutomobile car2 = factory.CreateLuxuryCar();

         factory = new MiniFacotry();
         IAutomobile car3 = factory.CreateEconomyCar();
         IAutomobile car4 = factory.CreateLuxuryCar();
      }
   }



   public interface IAutomobile
   {
      string Name { get; }

      void TurnOn();
      void TurnOff();
   }

   public abstract class BMWBase : IAutomobile
   {
      public virtual string Name => "BMW";

      public virtual void TurnOn() { }
      public virtual void TurnOff() { }
   }

   public class BMWClass3 : BMWBase
   {
      public override string Name => "BMW Class 3";
      public override void TurnOn()
      {
         base.TurnOn();
      }
   }

   public class BMWClass5 : BMWBase
   {
      public override string Name => "BMW Class 5";
      public override void TurnOff()
      {
         base.TurnOff();
      }
   }

   public class Mini3Door : IAutomobile
   {
      public string Name => "Mini 3 Door";

      public virtual void TurnOn() { }
      public virtual void TurnOff() { }
   }


   public class MiniCountryMan : IAutomobile
   {
      public string Name => "Mini CountryMan";

      public virtual void TurnOn() { }
      public virtual void TurnOff() { }
   }


   public interface IAutoFactory
   {
      IAutomobile CreateEconomyCar();
      IAutomobile CreateLuxuryCar();
   }

   public class BMWFactory : IAutoFactory
   {
      public IAutomobile CreateEconomyCar()
      {
         return new BMWClass3();
      }

      public IAutomobile CreateLuxuryCar()
      {
         return new BMWClass5();
      }
   }

   public class MiniFacotry : IAutoFactory
   {
      public IAutomobile CreateEconomyCar()
      {
         return new Mini3Door();
      }

      public IAutomobile CreateLuxuryCar()
      {
         return new MiniCountryMan();
      }
   }

}
