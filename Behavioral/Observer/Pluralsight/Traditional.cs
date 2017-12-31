using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Pluralsight.Traditional
{
   public static class RunThis
   {
      public static void Example()
      {
         StockTicker subject = new StockTicker();

         GoogleObserver ms = new GoogleObserver(subject);

         // Events that happen...
         // Evnet 1:
         Stock s = new Stock();
         s.Symbol = "MSFT";
         s.Price = 10.0;

         subject.Stock = s;

         // Event 2:
         s = new Stock();
         s.Symbol = "GOOG";
         s.Price = 11.5;

         subject.Stock = s;
      }
   }


   abstract class AbstractObserver
   {
      public abstract void Update();
   }

   class GoogleObserver : AbstractObserver
   {
      public GoogleObserver(StockTicker subject)
      {
         DataSource = subject;
         subject.Register(this);
      }

      private StockTicker DataSource { get; set; }
      public override void Update()
      {
         double price = DataSource.Stock.Price;
         string symbol = DataSource.Stock.Symbol;

         // filters
         if (symbol == "GOOG")
            Console.WriteLine($"Google's new price: {price}");
      }
   }



   abstract class AbstractSubject
   {
      List<AbstractObserver> _observers = new List<AbstractObserver>();

      public void Register(AbstractObserver observer)
      {
         _observers.Add(observer);
      }

      public void Unregister(AbstractObserver observer)
      {
         _observers.Remove(observer);
      }

      public void Notify()
      {
         foreach (var obj in _observers)
            obj.Update();
      }
   }

   class StockTicker : AbstractSubject
   {
      private Stock _stock;
      public Stock Stock
      {
         get { return _stock; }
         set
         {
            _stock = value;
            Notify();
         }
      }
   }

   class Stock
   {
      public string Symbol { get; set; }
      public double Price { get; set; }
   }


}

