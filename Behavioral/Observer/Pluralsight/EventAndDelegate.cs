using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Pluralsight.EventAndDelegate
{
   public static class RunThis
   {
      public static void Example()
      {
         StockTicker subject = new StockTicker();

         MicrosoftMonitor ms = new MicrosoftMonitor(subject);

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


   class Stock
   {
      public string Symbol { get; set; }
      public double Price { get; set; }
   }

   class StockChangeEventArgs : EventArgs
   {
      public StockChangeEventArgs(Stock s)
      {
         Stock = s;
      }

      public Stock Stock { get; set; }
   }

   class StockTicker
   {
      private Stock _stock;
      public Stock Stock
      {
         get { return _stock; }
         set
         {
            _stock = value;
            StockChangeEventArgs args = new StockChangeEventArgs(_stock);
            OnStockChange(args);
         }
      }

      // This part is to register the observer
      public event EventHandler<StockChangeEventArgs> StockChange;
      protected virtual void OnStockChange(StockChangeEventArgs e)
      {
         if (StockChange != null)
            StockChange(this, e);
      }
   }


   // This is the observer
   class MicrosoftMonitor
   {
      public MicrosoftMonitor(StockTicker st)
      {
         st.StockChange += new EventHandler<StockChangeEventArgs>(st_StockChange);
      }

      void st_StockChange(object sender, StockChangeEventArgs e)
      {
         Filter(e.Stock);
      }

      void Filter(Stock stock)
      {
         if (stock.Symbol == "MSFT")
            Console.WriteLine("MSFT has been called.");
      }
   }
}
