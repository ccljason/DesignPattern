using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup
{
   class Program
   {
      static void Main(string[] args)
      {
         //==============================
         // Creational
         //==============================
         AbstractFactory.Pluralsight.RunThis.Example();




         //==============================
         // Structural
         //==============================
         Bridge.Pluralsight.RunThis.Example();


         //==============================
         // Behavioral
         //==============================

         //------------------------------
         // Observer
         //------------------------------
         Observer.Pluralsight.EventAndDelegate.RunThis.Example();
         Observer.Pluralsight.Traditional.RunThis.Example();
         Observer.Pluralsight.IObserver.RunThis.Example();

         Observer.dofactory.Examples.RunThis.Example();

         Observer.dofactory.Ideas.RunThis.Example();


         //------------------------------
         // Strategy
         //------------------------------
         Strategy.Pluralsight.RunThis.Example();
      }
   }
}
