using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{

    public class MockCommanderRepo : ICommanderRepo
    {
        public void addCommand(Command cmd)
        {

        }

        public IEnumerable<Command> getAppCommands()
        {

            var commands = new List<Command>()
            {
                new Command{Id=0 , HowTo="hello",Line="ahmed",Platform="afhkafa"},
                new Command{Id=1 , HowTo="okkkkk",Line="mohamed",Platform="sdkhfk"},
                new Command{Id=2 , HowTo="thanks",Line="ali",Platform="lfjlsfs"},
                new Command{Id=3 , HowTo="mashey",Line="sayed",Platform="scysfsif"}
            };

            return commands;


        }

        public Command getCommandById(int id)
        {

            return new Command { Id = 3, HowTo = "mashey", Line = "sayed", Platform = "scysfsif" };

        }

        public bool saveChanges()
        {
            throw new NotImplementedException();
        }

        public void updateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
