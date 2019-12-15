using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.SpeechRecognition;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SpeechApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool isRecognising;
        public MainPage()
        {
            this.InitializeComponent();
            isRecognising = false;

        }
        private async void startRec_Click(object sender, RoutedEventArgs e)
        {
            isRecognising = true;
            var speechRecognizer = new Windows.Media.SpeechRecognition.SpeechRecognizer();
            // Compile the dictation grammar by default.
            await speechRecognizer.CompileConstraintsAsync();

            // Start recognition.
            Windows.Media.SpeechRecognition.SpeechRecognitionResult speechRecognitionResult = await speechRecognizer.RecognizeAsync();

            /*Recognition with UI
            Windows.Media.SpeechRecognition.SpeechRecognitionResult speechRecognitionResult = await speechRecognizer.RecognizeWithUIAsync();
            */

            // Do something with the recognition result.
            TextBlock textBlock1 = new TextBlock();
            textBlock1.Text = speechRecognitionResult.Text;
            textBlock1.FontSize = 30;
            myStackPanel.Children.Add(textBlock1);

        }
        private async void stopRec_Click(object sender, RoutedEventArgs e)
        {
            isRecognising = false;
        }

    }
}
