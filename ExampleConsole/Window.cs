using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleConsole
{
    public static class InheritanceTesting
    {
        public static void BasicInheritance()
        {
            //Window w = new Window(5, 10);
            //w.DrawWindow();

            ListBoxWidget lb = new ListBoxWidget(20, 30, "Hello World");
            lb.DrawWindow();
        }

        public static void Polymorph()
        {
            //Window win = new Window(1, 2);
            ListBoxWidget lb = new ListBoxWidget(3, 4, "lb contents");
            ButtonWidget b = new ButtonWidget(5, 6);
            //win.DrawWindow();
            lb.DrawWindow();
            b.DrawWindow();
            Window[] winArray = new Window[3];
            winArray[0] = lb; //win;
            winArray[1] = lb;
            winArray[2] = b;
            for (int i = 0; i < winArray.Length; i++)
                winArray[i].DrawWindow();
            foreach (Window window in winArray)
                window.DrawWindow();
        }
    }


    abstract public class Window
    {
        protected int top;
        protected int left;

        public Window(int top, int left)
        {
            this.top = top;
            this.left = left;
        }

        abstract public void DrawWindow();

        //public virtual void DrawWindow()
        //{
        //    Console.WriteLine("drawing window at {0}, {1}", top, left);
        //}
    }

    public class ListBoxWidget : Window
    {
        private string mListBoxContents;

        public ListBoxWidget(int top, int left, string contents)
            : base(top, left)
        {
            mListBoxContents = contents;
        }

        public override void DrawWindow()
        {
            //base.DrawWindow();
            Console.WriteLine("writing contents to the listbox: {0}", mListBoxContents);
        }
    }

    public class ButtonWidget : Window
    {
        public ButtonWidget(int top, int left)
            : base(top, left)
        {
        }

        public override void DrawWindow()
        {
            Console.WriteLine("drawing button at {0}, {1}", top, left);
        }
    }
}
