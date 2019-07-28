using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    class Program
    {

        [STAThread] // important
        static void Main(string[] args)
        {
        // Path to EXT.DLL required when using portable install
        //  If the path is left empty, the Root object will try to locate EXT.DLL in the default installation path automatically.
            String extdll = Environment.ExpandEnvironmentVariables(@"%MANIFOLD9_HOME%\bin64\ext.dll");  
            using (Manifold.Root root = new Manifold.Root(extdll))
            {
                Manifold.Application app = root.Application;
                Console.WriteLine(app.Name);
	            String mapfile = Path.GetFullPath(@"m9_$safeprojectname$.map");

                using (Manifold.Database db = app.CreateDatabaseForFile(mapfile, true))  
					// Null reference error if Manifold not activated.
					// app.CreateDatabase() would create a (New Project)
                {
                    Console.WriteLine(db.Technology);

                    Console.WriteLine(Script.MapFilePath(app, db));

                    using (Manifold.Table table = db.Search("mfd_root"))
                    {
                        Console.WriteLine("Fields in mfd_root:");
                        Manifold.Schema schema = table.GetSchema();
                        foreach (Manifold.Schema.Field field in schema.Fields)
                            Console.WriteLine(field.Name);
                    }
                }
            }
        }



    }
}
