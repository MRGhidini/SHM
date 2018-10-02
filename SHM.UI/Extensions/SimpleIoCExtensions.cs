using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.UI.Extensions
{
    public static class SimpleIocExtensions
    {
        public static void Reregister<TClass>(this SimpleIoc self)
            where TClass : class
        {
            if (self.IsRegistered<TClass>()) self.Unregister<TClass>();
            self.Register<TClass>();
        }
    }
}
