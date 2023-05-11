using DbMiddleware;
using DbMiddlewarePostgresImpl;

namespace super_chat
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IDatabase db = new PostgresDatabase("postgres", "123456", "localhost", 5432, "os");
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new signup(db));
            Application.Run(new signup(db));
        }
    }
}