using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public interface ICommanderRepo
    {

        IEnumerable<Command> getAppCommands();
        Command getCommandById(int id);

        void addCommand(Command cmd);
        bool saveChanges();
        void updateCommand(Command cmd);

        void deleteCommand(Command cmd);

    }
}
