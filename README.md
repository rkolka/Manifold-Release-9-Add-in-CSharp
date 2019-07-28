# Visual Studio Template for Manifold Release 9 add-in in C#.

### What's it for?
This template gets you started with Manifold Release 9 add-in. It helps you to avoid many common mistakes along the way.


## Quick Usage

1. **Download** zip from [here](https://raw.githubusercontent.com/rkolka/Manifold-Release-9-Add-in-CSharp/master/Manifold%20Release%209%20Add-in%20C%23.zip) and put it into your Visual Studio Project Templates directory e.g. %userprofile%\Documents\Visual Studio 2019\Templates\ProjectTemplates
2. **Unblock** the zip file.
3. **Define environment variable** using command SETX MANIFOLD9_HOME C:\Path\To\Manifold-9.0.nnn.n-x64.
4. **Create a new project** in Visual Studio using this template that should appear under Visual C#. Pick a name for your add-in and click OK. 
5. After successful project creation you can **build the project** without modifying anything. It fails with Error CS0103 The name 'Script' does not exist in the current context.
6. Under $projectname$Test References there is missing reference Addin. **Remove** it and **Add** new reference to *projectname*. Build should succeed.

7. Browse to *projectdirectory*\bin\Release directory. **Run install_*projectname*.bat**. It copies required files into Manifold's shared directory. NB! You have to have permission to modify shared directory. 
7. In Manifold 9 go to Tools->Add-Ins. Your add-in shuld be listed there. Click on the name.
8. Some text and your chosen name should appear on Log pane.
9. If problem occurs, let me know.

Read [The Fine Manual](http://www.manifold.net/doc/mfd9/) for more information about Manifold 9!

## Custom Usage

Two files, those starting with triple underscore, are not part of template per se but useful if you want to modify this template. Download or clone these source files and use ___filestozip.txt and ___Install_This_Template.bat to ease your efforts.
The latter assumes you have 7-Zip installed.
