using DPFP.Capture;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nori.HuellaDigital
{
    delegate void Function();
    public partial class frmHuellaDigital : DevExpress.XtraBars.Ribbon.RibbonForm, DPFP.Capture.EventHandler
    {
        public string huella_digital { get; set; } = string.Empty;
        public frmHuellaDigital()
        {
            InitializeComponent();
			this.MetodoDinamico();
        }

        protected virtual void Init()
        {
            try
            {
                Capturer = new Capture();				// Create a capture operation.

                if (null != Capturer)
                    Capturer.EventHandler = this;					// Subscribe for capturing events.
                else
                    SetPrompt("¡No se pudo inicializar la operación de captura!");
            }
            catch
            {
                MessageBox.Show("¡No se pudo inicializar la operación de captura!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void Process(DPFP.Sample Sample)
        {
            // Draw fingerprint sample image.
            DrawPicture(ConvertSampleToBitmap(Sample));
        }

        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    SetPrompt("Lector de huella digital, coloque su huella en el lector.");
                }
                catch
                {
                    SetPrompt("Imposible iniciar la captura.");
                }
            }
        }

        protected void Stop()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                    SetPrompt("No se pudo finalizar la captura.");
                }
            }
        }

        #region Form Event Handlers:

        private void CaptureForm_Load(object sender, EventArgs e)
        {
            Init();
            Start();                                                // Start capture operation.
        }

        private void CaptureForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
        }
        #endregion

        #region EventHandler Members:

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            try
            {
                MakeReport("La muestra de la huella ha sido capturada.");
                SetPrompt("Coloque nuevamente el mismo dedo en el lector.");
                Process(Sample);
            }
            catch { }
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            try
            {
                MakeReport("El dedo ha sido removido del lector.");
            }
            catch { }
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            try
            {
                MakeReport("El dedo ha sido colocado.");
            }
            catch { }
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            try
            {
                MakeReport("Lector de huella digital conectado.");
            }
            catch { }
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            try
            {
                MakeReport("Lector de huella digital desconectado.");
            }
            catch { }
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            try
            {
                if (CaptureFeedback == CaptureFeedback.Good)
                    MakeReport("La calidad de la muestra es buena.");
                else
                    MakeReport("La calidad de la muestra es deficiente.");
            }
            catch { }
        }
        #endregion

        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            try
            {
                SampleConversion Convertor = new SampleConversion();  // Create a sample convertor.
                Bitmap bitmap = null;                                                           // TODO: the size doesn't matter
                Convertor.ConvertToPicture(Sample, ref bitmap);                                 // TODO: return bitmap as a result
                return bitmap;
            }
            catch { return null; }
        }

        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            try
            {
                DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();  // Create a feature extractor
                CaptureFeedback feedback = CaptureFeedback.None;
                DPFP.FeatureSet features = new DPFP.FeatureSet();
                Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);            // TODO: return features as a result?
                if (feedback == CaptureFeedback.Good)
                    return features;
                else
                    return null;
            }
            catch { return null; }
        }

        protected void SetStatus(string status)
        {
            Invoke(new Function(delegate () {
                StatusLine.Text = status;
            }));
        }

        protected void SetPrompt(string prompt)
        {
            Invoke(new Function(delegate () {
                Prompt.Text = prompt;
            }));
        }
        protected void MakeReport(string message)
        {
            Invoke(new Function(delegate () {
                StatusText.AppendText(message + "\r\n");
            }));
        }

        private void DrawPicture(Bitmap bitmap)
        {
            Invoke(new Function(delegate () {
                Picture.Image = new Bitmap(bitmap, Picture.Size);   // fit the image into the picture box
            }));
        }

        private Capture Capturer;

        private void frmHuellaDigital_Load(object sender, EventArgs e)
        {
            Init();
            Start();
        }

        private void frmHuellaDigital_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
        }
    }
}