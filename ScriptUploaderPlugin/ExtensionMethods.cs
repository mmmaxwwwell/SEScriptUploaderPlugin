using Owin;
using SpaceEngineers.Game;

namespace ScriptUploaderPlugin
{
    public static partial class ExtensionMethods
    {
        public static IAppBuilder UseScriptUploaderMiddleware(
          this IAppBuilder app, SpaceEngineersGame spaceEngineersGame)
        {
            app.Use<ScriptUploaderMiddleware>(spaceEngineersGame);
            return app;
        }
    }
}
