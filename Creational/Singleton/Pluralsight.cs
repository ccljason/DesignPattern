using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.Pluralsight
{
   /// <summary>
   /// This singleton is thread safe and fast - based on Pluralsight comments
   /// </summary>
   /// <remarks> See Version 5 of JonSkeet.cs - same </remarks>
   public class LazySingleton
   {
      private LazySingleton() { }

      public static LazySingleton Instance
      {
         get { return Nested._instance; }
      }

      private class Nested
      {
         static Nested() { }

         internal static readonly LazySingleton _instance = new LazySingleton();
      }
   }
}
