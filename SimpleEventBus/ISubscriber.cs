using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEventBus
{
    public interface ISubscriber
    {
        public void Inform(IEvent e);
    }
}
