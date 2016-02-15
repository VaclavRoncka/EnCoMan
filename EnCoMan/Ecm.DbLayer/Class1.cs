using System;

namespace Ecm.DbLayer
{
    public class Class1
    {
        public event EventHandler MyEvent;

        public Class1()
        {
            MyEvent?.Invoke(null, null);
        }



        public void Metoda()
        {
            var x = new Class1();
        }
    }
}
