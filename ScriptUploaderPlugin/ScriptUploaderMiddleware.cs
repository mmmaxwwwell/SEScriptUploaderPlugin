using Microsoft.Owin;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using SpaceEngineers.Game;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptUploaderPlugin
{
    public class ScriptUploaderMiddleware : OwinMiddleware
    {
        SpaceEngineersGame spaceEngineersGame;

        public ScriptUploaderMiddleware(OwinMiddleware next, SpaceEngineersGame _spaceEngineersGame) : base(next)
        {
            spaceEngineersGame = _spaceEngineersGame;
        }

        public async override Task Invoke(IOwinContext context)
        {
            if (!context.Request.Path.Value.Contains("favico"))
            {
                var path = context.Request.Path.Value.Split('/');
                var grid = MyEntities.GetEntities().OfType<MyCubeGrid>().FirstOrDefault(x => x.DisplayName == path[1]);
                var pbs = grid.CubeBlocks.Where(x => x.FatBlock?.BlockDefinition?.ToString()?.Contains("rogrammable") ?? false);
                var pb = pbs.FirstOrDefault(x => (x.FatBlock as IMyTerminalBlock)?.CustomName == path[2]);
                (pb?.FatBlock as IMyProgrammableBlock).ProgramData = new StreamReader(context.Request.Body).ReadToEndAsync().Result;//.FirstOrDefault(x => x.CustomName == path);
            }
        }
    }
}
