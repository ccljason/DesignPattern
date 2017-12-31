using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Pluralsight.IObserver
{
   public static class RunThis
   {
      public static void Example()
      {
         StockTicker subject = new StockTicker();

         MicrosoftObserver ms = new MicrosoftObserver();

         using (subject.Subscribe(ms))
         {
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
   }



   class Stock
   {
      public string Symbol { get; set; }
      public double Price { get; set; }
   }


   class MicrosoftObserver : IObserver<Stock>
   {
      public void OnCompleted() { Console.WriteLine("end of trading day"); }

      public void OnError(Exception error) { Console.WriteLine("error happened!"); }

      public void OnNext(Stock stock)
      {
         if (stock.Symbol == "MSFT")
            Console.WriteLine("MSFT has been called");
      }
   }



   class StockTicker : IObservable<Stock>
   {
      List<IObserver<Stock>> _observers = new List<IObserver<Stock>>();

      private Stock _stock;
      public Stock Stock
      {
         get { return _stock; }
         set
         {
            _stock = value;
            Notify(_stock);
         }
      }

      private void Notify(Stock stock)
      {
         foreach(var obj in _observers)
         {
            if (stock.Symbol == null || stock.Price < 0.0)
               obj.OnError(new Exception("bad error data"));
            else
               obj.OnNext(stock);
         }
      }

      private void Stop()
      {
         foreach (var observer in _observers.ToArray())
         {
            if (_observers.Contains(observer))
               observer.OnCompleted();
         }
         _observers.Clear();
      }

      public IDisposable Subscribe(IObserver<Stock> observer)
      {
         if (!_observers.Contains(observer))
            _observers.Add(observer);
         return new Unsubscriber(_observers, observer);
      }
   }
   class Unsubscriber : IDisposable
   {
      private List<IObserver<Stock>> _observers;
      private IObserver<Stock> _observer;

      public Unsubscriber(List<IObserver<Stock>> observers, IObserver<Stock> observer)
      {
         _observers = observers;
         _observer = observer;
      }

      public void Dispose()
      {
         if (_observer != null && _observers.Contains(_observer))
            _observers.Remove(_observer);
      }
   }

}
