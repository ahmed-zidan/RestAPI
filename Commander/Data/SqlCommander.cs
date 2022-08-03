using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class SqlCommander : ICommanderRepo
    {

        private readonly CommanderContext context;
        public SqlCommander(CommanderContext context)
        {
            this.context = context;
        }

        public void addCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            context.commands.Add(cmd);
            saveChanges();
            
        }

        public void deleteCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            context.commands.Remove(cmd);
            
        }

        public IEnumerable<Command> getAppCommands()
        {
            return context.commands.ToList();
        }

        public Command getCommandById(int id)
        {
            return context.commands.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool saveChanges()
        {
            
            return (context.SaveChanges()>=0);
        }

        public void updateCommand(Command cmd)
        {
            
        }
    }
}
