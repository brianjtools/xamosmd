using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamosmd
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DisplayScore : ContentPage
	{
		public DisplayScore (string xml)
		{
			InitializeComponent ();
            ShowScore(xml);
		}

        public async void ShowScore(string outerxml)
        {

            var src = LoadHTMLFileFromResource();
            if (src == null)
            {
                Debug.WriteLine("couldn't get index.html");
                await DisplayAlert("Error", "Couldn't load index.html", "Cancel");
                return;
            }
            webview.Source = src;

            await Task.Delay(3000); // let the page load -- needed longer for the x64

            try
            {
                var js = "var str = '" + outerxml + "'; render_osmd(); ";
                // Debug.WriteLine(js);
                string result = await webview.EvaluateJavaScriptAsync(js);

                if (result.Contains("yes"))
                    Debug.WriteLine("score rendered.");
                else
                    Debug.WriteLine("score not rendered.");
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                await DisplayAlert("Error", "Error displaying score", "Cancel");
                await Navigation.PopModalAsync();
            }
        }

 

        HtmlWebViewSource LoadHTMLFileFromResource()
        {
            var source = new HtmlWebViewSource();

            // Load the HTML file embedded as a resource in the .NET Standard library
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("xamosmd.index.html");
            try
            {
                var reader = new StreamReader(stream);
                source.Html = reader.ReadToEnd();
            }  catch(Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
                // display alert here
            }
            return source;
        }
    }
}