using Microsoft.Owin.Hosting;
using SpaceEngineers.Game;
using System;

namespace ScriptUploaderPlugin
{
    public class ScriptUploaderPlugin : VRage.Plugins.IPlugin
    {
        IDisposable disposable;
        SpaceEngineersGame gameInstance;

        //need to start the game with -plugin <path to dll>
        public void Init(object _gameInstance)
        {
            gameInstance = _gameInstance as SpaceEngineersGame;
            disposable = WebApp.Start("http://localhost:9000", (startup) => {
                startup.UseScriptUploaderMiddleware(gameInstance);
            });
        }

        public void Update()
        {
           
        }

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}
