# Visual Studio Template for Manifold Release 9 add-in in C#.

### What's it for?
This template gets you started with Manifold Release 9 add-in. It helps you to avoid many common mistakes along the way.


## Quick Usage

1. **Download** zip from [here](https://raw.githubusercontent.com/rkolka/Manifold-Release-9-Add-in-CSharp/master/Manifold%20Release%209%20Add-in%20C%23.zip) and put it into your Visual Studio Project Templates directory, usually %userprofile%\Documents\Visual Studio 2019\Templates\ProjectTemplates
2. **Unblock** the zip file.
3. Do **not** unpack the zip.
4. Assuming default install location C:\Program Files\Manifold\v9.0\
5. **Create a new project** in Visual Studio using this template that should appear under Visual C#. Pick a name for your add-in and click OK. 
6. After successful project creation you can **build the project** without modifying anything. It fails with Error CS0103 The name 'Script' does not exist in the current context.
7. Under *projectname*Test there is missing reference. **Remove** it and **Add** new reference to *projectname*. Build should succeed.
8. Browse to *projectdirectory*\bin\Release directory. **Run install_*projectname*.bat**. It copies required files into Manifold's shared directory. NB! You have to have permission to modify shared directory. 
9. In Manifold 9 go to Tools->Add-Ins. Your add-in shuld be listed there. Click on the name.
10. Some text and your chosen name should appear on Log pane.


Read [The Fine Manual](https://manifold.net/doc/mfd9/read_me_first.htm) for more information about Manifold 9!

API docs is [here](https://manifold.net/doc/api/scripts-net.html).

## Custom Usage

Two files, those starting with triple underscore, are not part of template per se but useful if you want to modify this template. Download or clone these source files and use ___filestozip.txt and ___Install_This_Template.bat to ease your efforts.
The latter assumes you have 7-Zip installed.
