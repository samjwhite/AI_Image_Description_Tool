using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
//using Xamarin.Essentials;
using Windows.Storage;
using SRiazanov_ComputerVisionApp.Utilities;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

/// <summary>
/// 1442 Final Project - Computer Vision.
/// This UWP app allows user to upload picture; get description and objects on the picture. 
/// Author: Serge Riazanov
/// </summary>

namespace SRiazanov_ComputerVisionApp
{
    
    public sealed partial class MainPage : Page
    {
        // Add your Computer Vision subscription key and endpoint
        static string subscriptionKey = "yourkey";
        static string endpoint = "https://sriazanov-computer-vision.cognitiveservices.azure.com";
        //file with picture
        StorageFile file;
        // Create a client
        ComputerVisionClient client = Authenticate(endpoint, subscriptionKey);
        public MainPage()
        {
            this.InitializeComponent();            
        }
        /*
         * AUTHENTICATE
         * Creates a Computer Vision client used by each example.
         */
        public static ComputerVisionClient Authenticate(string endpoint, string key)
        {
            ComputerVisionClient client =
              new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
              { Endpoint = endpoint };
            return client;
        }


        private async void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            file = await FilePicker.current.GetImage();
            if (file != null)
            {
                try
                {
                    var image = new BitmapImage();
                    
                    using (var stream = await file.OpenAsync(FileAccessMode.Read))
                    {
                        
                        image.SetSource(stream);
                        imgPreview.Source = image;
                    }
                }
                catch (Exception ex)
                {

                   Jeeves.ShowMessage("Error", ex.Message);
                } 
            }
            lblDescription.Text = "";
            lblTags.Text = "";

            lbxTags.Items.Clear();
        }

        private async void btnAnalyze_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var stream = await file.OpenStreamForReadAsync())
                {
                    var result = await GetAnalysisResults(client, stream);
                    foreach (var caption in result.Description.Captions)
                    {
                        lblDescription.Text = "Description: " + caption.Text + "\n Confidence: " + Math.Round(caption.Confidence, 2) * 100 + "%" + "\n";
                    }
                    if(result.Tags != null)
                    {
                        lblTags.Text = "Tags: \n";
                        foreach (var tag in result.Tags)
                        {
                            lblTags.Text += $"\n{tag.Name} {Math.Round(tag.Confidence, 2) * 100}%";
                            
                        }
                        foreach (var obj in result.Objects)
                        {
                            lbxTags.Items.Add(obj.ObjectProperty);
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Jeeves.ShowMessage("Upload a picture first", "Click on Upload Picture and select a file");
            }

        }
        static async Task<ImageAnalysis> GetAnalysisResults(ComputerVisionClient client, Stream stream)
        {
            // Creating a list that defines the features to be extracted from the image. 
            List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
            {
                 VisualFeatureTypes.Tags, VisualFeatureTypes.Categories,
                VisualFeatureTypes.Faces, VisualFeatureTypes.Adult,
                VisualFeatureTypes.Color, VisualFeatureTypes.Brands,
                VisualFeatureTypes.Objects, VisualFeatureTypes.Description
            };

            ImageAnalysis results = await client.AnalyzeImageInStreamAsync(stream, visualFeatures: features);
            return results;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lblTags.Text = "";
            lblDescription.Text = "";
            //imageGrid.Children.Clear();
            lbxTags.Items.Clear();

        }

        //draw a rectangle on the borders of the selected object
        private async void  lbxTags_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(lbxTags.SelectedIndex == -1)) 
            { 
            //imageGrid.Children.Clear();
            var index = lbxTags.SelectedIndex;
            using (var stream = await file.OpenStreamForReadAsync())
            {
                var result = await GetAnalysisResults(client, stream);
                var rectangle = new FaceRectangle();
                var objRectangle = new Rectangle();
                    
               rectangle = new FaceRectangle(result.Objects[index].Rectangle.X, result.Objects[index].Rectangle.Y, result.Objects[index].Rectangle.W, result.Objects[index].Rectangle.H);
                objRectangle.Width = rectangle.Width;
                objRectangle.Height = rectangle.Height;
                objRectangle.Stroke = new SolidColorBrush(Windows.UI.Colors.Red);
                objRectangle.HorizontalAlignment = (HorizontalAlignment)rectangle.Left;
                objRectangle.VerticalAlignment = (VerticalAlignment)rectangle.Top;
                
                imageGrid.Children.Add(objRectangle);
                }
            }
        }
    }
}
