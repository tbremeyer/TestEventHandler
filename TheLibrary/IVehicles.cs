using System;
using System.ComponentModel;

namespace TheLibrary
{
    public interface IVehicles
    {
        void ListVehicles(string category, MyAsyncCompletedEventHandler callback);
    }

    public delegate void MyAsyncCompletedEventHandler(object sender, MyAsyncCompletedEventArgs e);

    public class MyAsyncCompletedEventArgs : AsyncCompletedEventArgs
    {
        public MyAsyncCompletedEventArgs(Exception ex) : base(ex, true, null)
        {
        }

        public object Result { get; set; }
    }
}