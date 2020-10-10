using System;
using System.Collections.Generic;
using System.Text;

namespace Enzo.Business
{
    public interface INavigator
    {
        public void Goto(object destination);
        void GoBack();
    }
}
