
using Bill.Core;
using Bill.Core.Interfaces;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Bill.API.Module
{
    namespace Modules
    {
        public class Module : NinjectModule
        {
            public override void Load()
            {
                Bind<IBillService>().To<BillService>().InRequestScope();
            }
        }
    }
}