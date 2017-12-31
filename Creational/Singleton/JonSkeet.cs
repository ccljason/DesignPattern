using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.JonSkeet
{
   /// The examples are from 
   ///   http://csharpindepth.com/Articles/General/Singleton.aspx
   /// 
   /// Note that "sealed" attribute is not used because constructor is private

   /// <summary>
   /// Version 1 - not thread safe
   /// </summary>
   [Obsolete("Should not use at all", true)]
   public class Singleton1
   {
      private static Singleton1 _instance = null;

      private Singleton1() { }

      public static Singleton1 Instance
      {
         get
         {
            if (_instance == null)
               _instance = new Singleton1();
            return _instance;
         }
      }
   }

   /// <summary>
   /// version 2 - simple thread-safe
   /// </summary>
   [Obsolete("should not use", true)]
   public class Singleton2
   {
      private static Singleton2 _instance = null;
      private static readonly object _lock = new object();

      private Singleton2() { }

      public static Singleton2 Instance
      {
         get
         {
            lock (_lock)
            {
               if (_instance == null)
                  _instance = new Singleton2();
               return _instance;
            }
         }
      }
   }

   /// <summary>
   /// Version 3 - attempted thread safe using double check locking
   /// </summary>
   [Obsolete("not too good compared to v4", true)]
   public class Singleton3
   {
      private static Singleton3 _instance = null;
      private static readonly object _lock = new object();

      private Singleton3() { }

      public static Singleton3 Instance
      {
         get
         {
            if (_instance == null)
            {
               lock (_lock)
               {
                  if (_instance == null)
                     _instance = new Singleton3();
               }
            }
            return _instance;
         }
      }
   }

   /// <summary>
   /// Version 4 - not quite as lazy, but thread-safe without using locks
   /// </summary>
   public class Singleton4
   {
      private static readonly Singleton4 _instance = new Singleton4();

      // Explicit static constructor to tell C# compiler
      // not to mark type as beforefieldinit
      static Singleton4() { }

      private Singleton4() { }

      public static Singleton4 Instance
      {
         get { return _instance; }
      }
   }

   /// <summary>
   /// Version 5 - fully lazy instantiation
   /// </summary>
   public class Singleton5
   {
      private Singleton5() { }

      public static Singleton5 Instance { get { return Nested.instance; } }

      private class Nested
      {
         // Explicit static constructor to tell C# compiler
         // not to mark type as beforefieldinit
         static Nested() { }

         internal static readonly Singleton5 instance = new Singleton5();
      }
   }

   /// <summary>
   /// Version 6 - using .NET 4's Lazy<T> type
   /// </summary>
   public class Singleton6
   {
      private static readonly Lazy<Singleton6> _lazy = new Lazy<Singleton6>(() => new Singleton6());

      public static Singleton6 Instance { get { return _lazy.Value; } }

      private Singleton6() { }
   }
}
