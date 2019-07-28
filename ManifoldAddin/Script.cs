using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


	// ------------------------------- Possible errors --------------------------------------------------------
	//namespace SomeNamespace 
	// Do not put namespace here. Addin is not visible in Tools -> Add-ins -> ...
	// --------------------------------------------------------------------------------------------------------

/*
 * This class has the entry-point for running inside Manifold via Tools -> Add-ins -> ...
 * The class must be named Script and it has to have static method Main
 * Otherwise Addin is not visible in Tools -> Add-ins -> ... you cannot "run" the add-in.
 * However, the dll is still loaded and you can reference its public static methods from SQL function definitions.
 * 
 */
 
	// ------------------------------- Possible errors --------------------------------------------------------
	//public class MyScript  
	// No, the class must be named Script. Addin is not visible in Tools -> Add-ins -> ...
	// --------------------------------------------------------------------------------------------------------

public class Script
{

        // ------------------------------- Possible errors --------------------------------------------------------

        //Manifold.Context Manifold;  
        // No, the field must be static. 
        // Message: An object reference is required for the non-static field, method, or property 'Script.Manifold'

        //static Manifold.Context Mfd; 
        // No, the field must be named Manifold. 
        // Message: Object reference not set to an instance of an object.

        // --------------------------------------------------------------------------------------------------------

    // the running context of a script. Must be static field named Manifold. Can be private or public.
    private static Manifold.Context Manifold;

        // ------------------------------- Possible errors --------------------------------------------------------

        //public static void MyMain() 
        // No, the method must be named Main. Addin is not visible in Tools -> Add-ins -> ...

        //static void Main() 
        // No, the method must be public. Addin is not visible in Tools -> Add-ins -> ...

        //public void Main() 
        // No, the method must be static. Addin is not visible in Tools -> Add-ins -> ...

        //public static string Main(string s) 
        // No, Main must not take arguments. 
        // Message: Can't run script, no entry point (Script.Main).

        //public static string Main() 
        // It works, but Main should not return a value 

        // --------------------------------------------------------------------------------------------------------

    // Script.Main() must be *public*, *static* and *void*
    // This is the entry-point when this addin is started Tools -> Add-ins -> ...
    public static void Main()
    {
        // The current application context 
        Manifold.Application app = Manifold.Application;


		// Example of doing useful stuff
		// Prints mapfile path
		// 
		app.Log(MapFilePath());

        app.Log("$safeprojectname$ (re)loaded!");
        app.OpenLog();
    }


    // A static method in class Script has access to Manifold.Context.
    // This method 
    // Create a library of static functions. If they need app and/or db, make them as parameters in library
    // for SQL9 define here version that passes app and db if needed. 
    //
    // -- $manifold$
    // FUNCTION MapFilePath() VARCHAR AS SCRIPT FILE '$safeprojectname$.dll' ENTRY 'Script.MapFilePath';
    // ?MapFilePath()
    // -- varchar: m9_$safeprojectname$.map
    public static string MapFilePath()
    {
        // ------------------------------- Possible errors --------------------------------------------------------
		// GetDatabaseRoot returns null if no project open. 
		// System.NullReferenceException: 'Object reference not set to an instance of an object.'
        // --------------------------------------------------------------------------------------------------------

        Manifold.Application app = Manifold.Application;
        using (Manifold.Database db = app.GetDatabaseRoot())
        {
            return MapFilePath(app, db);
        }
    }

	public static string MapFilePath(Manifold.Application app, Manifold.Database db)
	{
		Manifold.PropertySet dbConnProps = app.CreatePropertySetParse(db.Connection);
		string path = dbConnProps.GetProperty("Source");
		return (path == "") ? "(New Project)" : path ;
	}


    // We can call only static methods from Manifold SQL
    // -- $manifold$
    // FUNCTION StaticExample() VARCHAR AS SCRIPT FILE '$safeprojectname$.dll' ENTRY 'Script.StaticExample';
    // ?StaticExample()
    // -- varchar: Static string
    public static string StaticExample() => "Static string";

    // Manifold SQL cannot call non-static methods
    // -- $manifold$
    // FUNCTION NonStaticExample() VARCHAR AS SCRIPT FILE '$safeprojectname$.dll' ENTRY 'Script.NonStaticExample';
    // ?NonStaticExample()
    // -- $safeprojectname$.dll(Script.NonStaticExample): Can't run script, no entry point (Script.NonStaticExample).
    public string NonStaticExample() => "non-static string in Script";

}

