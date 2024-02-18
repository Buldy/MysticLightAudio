using System;
using System.Numerics;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Dsp;

namespace MysticLightAudio {
    public partial class Form1 : Form {

        private readonly AudioCapture audioCapture;

        public Form1() {
            InitializeComponent();
            audioCapture = new AudioCapture();
            audioCapture.AudioDataAvailable += AudioCapture_AudioDataAvailable;
        }
    }
}
