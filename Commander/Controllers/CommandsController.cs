using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{

    [ApiController]
    [Route("API/[controller]")]
    public class CommandsController : ControllerBase
    {


        private readonly ICommanderRepo repo;
        private readonly IMapper _mapper;
        public CommandsController(ICommanderRepo repo , IMapper mapper)
        {
            this.repo = repo;
            _mapper = mapper;
        }


        //get api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandsModel>> getAllCommands()
        {
            var cmds = repo.getAppCommands();

            return Ok(_mapper.Map<IEnumerable<CommandsModel>>(cmds));


        }

        //get api/commands/4
        [HttpGet("{id}" , Name = "getCommandById")]
        public ActionResult<CommandsModel>getCommandById(int id)
        {
            

            var cmd = repo.getCommandById(id);
            
            if(cmd != null)
                return Ok(_mapper.Map<CommandsModel>(cmd));

            return NotFound();
        }


        //post api/commands
        [HttpPost]
        public ActionResult<CommandsModel>CreateCommand(CommandsModel cmd)
        {
            var command = _mapper.Map<Command>(cmd);
            repo.addCommand(command);


            cmd = _mapper.Map<CommandsModel>(command);

            return CreatedAtRoute(nameof(getCommandById), new { ID = cmd.Id }, cmd);

        }

        //put api/commands/id
        [HttpPut("{id}")]
        public ActionResult<CommandUpdateModel>UpdateCommand(int id , CommandUpdateModel Ucmd)
        {
            var cmd = repo.getCommandById(id);
            if(cmd == null)
            {
                return NotFound();

            }

            _mapper.Map(Ucmd, cmd);
            repo.updateCommand(cmd);
            repo.saveChanges();

            return NoContent();
        }


        // patch api/commands/4
        [HttpPatch("{id}")]
        public ActionResult partialUpdataCommand(int id , JsonPatchDocument<CommandUpdateModel> UCmd)
        {

            var cmd = repo.getCommandById(id);
            if(cmd == null)
            {
                return NotFound();
            }

            var fromCmdToUCmd = _mapper.Map<CommandUpdateModel>(cmd);

            UCmd.ApplyTo(fromCmdToUCmd, ModelState);

            if (!TryValidateModel(fromCmdToUCmd))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(fromCmdToUCmd, cmd);
            repo.updateCommand(cmd);
            repo.saveChanges();

            return NoContent();

        }


        //delete api/commands/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var cmd = repo.getCommandById(id);
            if (cmd == null)
                return NotFound();


            repo.deleteCommand(cmd);
            repo.saveChanges();

            return NoContent();

        }


    }
}