using Plugin.FilePicker;
using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Xamarin.Forms;

namespace xamosmd
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            openbt.Clicked += Openbt_Clicked;
        }

        async void Openbt_Clicked(object sender, EventArgs e)
        {
            string[] fileTypes = null;

            if (Device.RuntimePlatform == Device.Android)
            {
                fileTypes = new string[] { "xml", "musicxml" };
            }

            if (Device.RuntimePlatform == Device.iOS)
            {
                // fileTypes = new string[] { "public.xml","public.musicxml" }; // same as iOS constant UTType.Image but didn't work
                // currently shows all files.
            }

            if (Device.RuntimePlatform == Device.UWP)
            {
                fileTypes = new string[] { ".xml", ".musicxml" };
            }

            try
            {
                var pickedFile = await CrossFilePicker.Current.PickFile(fileTypes);
                if (pickedFile != null)
                {
                    Debug.WriteLine(pickedFile.FileName);
                    var stream = pickedFile.GetStream();
                    StreamReader streamReader = new StreamReader(stream);
                    string xml = await streamReader.ReadToEndAsync();
                    streamReader.Close();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xml);
                    if (xml != null)
                        await Navigation.PushModalAsync(new DisplayScore(doc.OuterXml));
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await DisplayAlert("Error", ex.Message, "Cancel");
                return;
            }
        }
    }
}
