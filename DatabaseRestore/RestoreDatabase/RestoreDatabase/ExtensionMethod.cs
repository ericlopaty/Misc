using System;
using System.Windows;
using System.Windows.Threading;

namespace RestoreDatabase
{
    public static class ExtensionMethod
    {
        private static Action EmptyDelegate = delegate() { };

        public static void Refresh(this UIElement element)
        {
            element.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}
