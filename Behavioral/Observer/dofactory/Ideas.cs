using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.dofactory.Ideas
{
   public static class RunThis
   {
      public static void Example()
      {
         ConcreteSubject sub = new ConcreteSubject();
         ConcreteObserver obs = new ConcreteObserver(sub, "con obs");

         sub.SubjectState = "updated...";
      }
   }


   public abstract class Subject
   {
      private List<Observer> _observers = new List<Observer>();

      public void Register(Observer observer)
      {
         _observers.Add(observer);
      }

      public void UnRegister(Observer observer)
      {
         _observers.Remove(observer);
      }

      public void Notify()
      {
         foreach (Observer o in _observers)
         {
            o.Update();
         }
      }
   }

   public class ConcreteSubject : Subject
   {
      private string _state;
      /// <summary>
      /// The state of the subject that changes and have to notify observer.
      /// </summary>
      public string SubjectState
      {
         get { return _state; }
         set
         {
            _state = value;
            Notify();
         }
      }
   }

   public abstract class Observer
   {
      public abstract void Update();
   }

   public class ConcreteObserver : Observer
   {
      public ConcreteObserver(Subject subject, string name)
      {
         Subject = subject;
         Name = name;

         Subject.Register(this);
      }

      public Subject Subject { get; set; }
      public string Name { get; set; }

      public override void Update()
      {
         Console.WriteLine($"This concrete observer, {Name}, is being updated.");
      }
   }
}
