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
        
        // ------------------------------- Possible errors --------------------------------------------------------
        // 'System.BadImageFormatException' occurs if build target is x86 or AnyCPU with Prefer 32bit checked.
        // 'Invalid API operation' without [STAThread] attribute
        // --------------------------------------------------------------------------------------------------------

        [STAThread] // important
        static void Main(string[] args)
        {
        // ------------------------------- Possible errors --------------------------------------------------------
        // 'Invalid API operation' if mis-spelled EXT.DLL (easy to confuse with EXTNET.DLL)
        // --------------------------------------------------------------------------------------------------------

        // Path to EXT.DLL required when using portable install
        //  If the path is left empty, the Root object will try to locate EXT.DLL in the default installation path automatically.
            String extdll = @"C:\Program Files\Manifold\v9.0\bin64\ext.dll";
            using (Manifold.Root root = new Manifold.Root())
            {
                Manifold.Application app = root.Application;
                Console.WriteLine(app.Name);
	            String mapfile = Path.GetFullPath(@"m9_$safeprojectname$.map");

                using (Manifold.Database db = app.CreateDatabaseForFile(mapfile, true))  
					// app.CreateDatabase() would create a (New Project)

                    // ------------------------------- Possible errors --------------------------------------------------------
					// 'Null reference' error if Manifold not activated.
                    // --------------------------------------------------------------------------------------------------------

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
