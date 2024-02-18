using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace MysticLightAudio {
    public class AudioCapture {
        private readonly MMDeviceEnumerator enumerator;
        private readonly MMDevice device;
        private readonly WasapiCapture capture;
        private int sampleRate;

        public event EventHandler<AudioDataEventArgs> AudioDataAvailable;

        public int SampleRate => sampleRate;

        public AudioCapture() {
            enumerator = new MMDeviceEnumerator();
            device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
            sampleRate = device.AudioClient.MixFormat.SampleRate;
            capture = new WasapiLoopbackCapture(device);
            capture.DataAvailable += Capture_DataAvailable;
        }

        public void StartCapture() {
            capture.StartRecording();
        }

        public void StopCapture() {
            capture.StopRecording();
        }

        private void Capture_DataAvailable(object sender, WaveInEventArgs e) {
        }
    }

    public class AudioDataEventArgs : EventArgs {
        public byte[] AudioData {
            get;
        }

        public AudioDataEventArgs(byte[] audioData) {
            AudioData = audioData;
        }
    }
}
