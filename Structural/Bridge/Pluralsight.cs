using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Pluralsight
{
    public static class RunThis
    {
      public static void Example()
      {
         IFormatter formatter = new StandardFormatter();
         List<Manuscript> documents = new List<Manuscript>()
         {
            new Book(formatter)
            {
               Title = "Book Title",
               Author = "Book Author",
               Text = "Book Text...",
            },
            new TermPaper(formatter)
            {
               Class = "TermPaper Class",
               Student = "TermPaper Student",
               Text = "TermPaper Text",
               Reference = "TermPaper Reference"
            }
         };

         Print(documents);

         formatter = new BackwardFormatter();
         documents.Clear();
         documents = new List<Manuscript>()
         {
            new Book(formatter)
            {
               Title = "Backward Book Title",
               Author = "Backward Book Author",
               Text = "Backward Book Text...",
            },
            new TermPaper(formatter)
            {
               Class = "Backward TermPaper Class",
               Student = "Backward TermPaper Student",
               Text = "Backward TermPaper Text",
               Reference = "Backward TermPaper Reference"
            }
         };

         Print(documents);


         Console.ReadKey();
      }

      private static void Print(List<Manuscript> docs)
      {
         foreach (var doc in docs)
         {
            doc.Print();
         }
      }
   }



   interface IFormatter
   {
      string Format(string key, string value);
   }

   class StandardFormatter : IFormatter
   {
      public string Format(string key, string value)
      {
         return string.Format($"{key}: {value}");
      }
   }

   class BackwardFormatter : IFormatter
   {
      public string Format(string key, string value)
      {
         return string.Format($"{key} : {new string(value.Reverse().ToArray())}");
      }
   }


   internal abstract class Manuscript
   {
      protected IFormatter _formatter = null;

      public Manuscript(IFormatter formatter)
      {
         _formatter = formatter;
      }

      public abstract void Print();
   }

   internal class Book : Manuscript
   {
      public Book (IFormatter formatter) : base(formatter) { }

      public string Title { get; set; }
      public string Author { get; set; }
      public string Text { get; set; }

      public override void Print()
      {
         Console.WriteLine(_formatter.Format("Title", Title));
         Console.WriteLine(_formatter.Format("Arthor", Author));
         Console.WriteLine(_formatter.Format("Title", Text));
         Console.WriteLine();
      }
   }

   internal class TermPaper : Manuscript
   {
      public TermPaper(IFormatter formatter) : base(formatter) { }

      public string Class { get; set; }
      public string Student { get; set; }
      public string Text { get; set; }
      public string Reference { get; set; }

      public override void Print()
      {
         Console.WriteLine(_formatter.Format("Class", Class));
         Console.WriteLine(_formatter.Format("Student", Student));
         Console.WriteLine(_formatter.Format("Text", Text));
         Console.WriteLine(_formatter.Format("Reference", Reference));
         Console.WriteLine();
      }
   }
}
