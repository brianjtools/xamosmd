# xamosmd
Example of how to cross platform use the OpenSheetMusicDisplay library 
using the Xamarin Forms Webview with C#, HTML and JavaScript.
The library:
http://opensheetmusicdisplay.org

The project also depends on the Xamarin FilePicker Plugin.  This example is explained in detail at http://brianconrad.com/sheetmusic

## Usage:
* Clone or download this repository
* Download an OSMD build (`opensheetmusicdisplay.min.js`) from the [Github Releases](https://github.com/opensheetmusicdisplay/opensheetmusicdisplay/releases)
* For Android put the opensheetmusicdisplay.min.js file in the Assets folder and set Build Action as AndroidAsset.
* For iOS put the opensheetmusicdisplay.min.js file in the Resources folder and set Build Action as Content and Copy to Output Directory set to Copy if Newer.
* For UWP put the opensheetmusicdisplay.min.js file in the UWP project folder and set with Build Action as Content and Copy to Output Directory set to Copy if Newer.

Build and deploy the example.  Select any musicxml file there are example files 
in the OpenSheetMusicDisplay repository: 
https://github.com/opensheetmusicdisplay/opensheetmusicdisplay/tree/develop/test/data
Currently this project can only load files with the .musicxml and .xml extensions. 
The .mxl files are compressed (zip) files and will not work. 

This example is based on the Xamarin Working With Webviews tutorial on how to execute a JavaScript 
in the webview.  
http://developer.xamarin.com/guides/cross-platform/xamarin-forms/working-with/webview

In this example a three second Delay is added to be sure that the HTML has loaded 
and the JavaScript may then be executed (Invoked).  Currently (to my knowledge at least) the Xamarin Webview 
does provide a way to know that the HTML has finished loading.  The HTML file is in the Project folder 
as index.html. The JavaScript does return a value if the script was executed or not.

## Todos:
Add an ActivityIndicator if possible to display that the HTML file is processing as that may take some time.


