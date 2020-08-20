using Dakota.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailNotification.Machine
{
    public class ArduinoMachine : AbstractMachine
    {
        public ArduinoMachine(string Name) : base(new Guid().ToString(), Name)
        {

        }
    }
}
