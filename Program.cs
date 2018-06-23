using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KitchanismoDInjector;

namespace TestDInjector
{
    class Program
    {
        static void Main(string[] args)
        {
            //registering interface and classes into container
            Container container = new Container();
            container.Register<IClassA, ClassA>();
            container.Register<IClassB, ClassB>();
            container.Register<IClassC, ClassC>();

            SubMain(container);
            Console.ReadKey();
        }

        static void SubMain(Container container)
        {
            ////without dependency injection, manually inputed the object
            //ContextA contextA = new ContextA(new ClassA());
            //ContextB contextB = new ContextB(new ClassA(), new ClassB());
            //ContextC contextC = new ContextC(new ClassA(), new ClassB(), new ClassC());

            //contextA.DoSomething();
            //contextB.DoSomething();
            //contextC.DoSomething();
            
            //with dependency injection, it will automatically injected the proper object into arguments.
            ContextA _contextA = container.Resolve<ContextA>();
            ContextB _contextB = container.Resolve<ContextB>();
            ContextC _contextC = container.Resolve<ContextC>();

            _contextA.DoSomething();
            _contextB.DoSomething();
            _contextC.DoSomething();

        }

        //context

        class ContextA
        {
            IClassA _a;

            public ContextA(IClassA a)
            {
                _a = a;
            }

            public void DoSomething()
            {
                _a.Do();
            }
        }

        class ContextB
        {
            IClassA _a; IClassB _b;

            public ContextB(IClassA a, IClassB b)
            {
                _a = a;
                _b = b;
            }

            public void DoSomething()
            {
                _b.Do();
            }
        }

        class ContextC
        {
            IClassA _a; IClassB _b; IClassC _c;

            public ContextC(IClassA a, IClassB b, IClassC c)
            {
                _a = a;
                _b = b;
                _c = c;
            }

            public void DoSomething()
            {
                _c.Do();
            }
        }

        //interface

        interface IClassA
        {
            void Do();
        }

        interface IClassB
        {
            void Do();
        }

        interface IClassC
        {
            void Do();
        }

        //class

        class ClassA : IClassA
        {
            public void Do() 
            { 
                Console.WriteLine("eating ...");
            }
        }

        class ClassB : IClassB
        {
            public void Do()
            {
                Console.WriteLine("programming ...");
            }
        }

        class ClassC : IClassC
        {
            public void Do()
            {
                Console.WriteLine("sleeping ...");
            }
        }

    }
}
