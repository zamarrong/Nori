using System;
using System.IO;
using System.Windows.Forms;

namespace Nori.HuellaDigital
{
    public partial class frmHuellaDigitalAgregar : frmHuellaDigital
    {
        public delegate void OnTemplateEventHandler(DPFP.Template template);
        //public event OnTemplateEventHandler OnTemplate;
        protected override void Init()
        {
            try
            {
                base.Init();
                base.Text = "Agregar huella digital";
                Enroller = new DPFP.Processing.Enrollment();            // Create an enrollment.
                UpdateStatus();
            }
            catch { }
        }

        protected override void Process(DPFP.Sample Sample)
        {
            try
            {
                base.Process(Sample);
                // Process the sample and create a feature set for the enrollment purpose.
                DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);

                // Check quality of the sample and add to enroller if it's good
                if (features != null)
                    try
                    {
                        MakeReport("Se creó el conjunto de características de huellas dactilares.");
                        Enroller.AddFeatures(features);     // Add feature set to template.
                    }
                    finally
                    {
                        UpdateStatus();

                        // Check if template has been created.
                        switch (Enroller.TemplateStatus)
                        {
                            case DPFP.Processing.Enrollment.Status.Ready:   // report success and stop capturing
                                OnTemplate(Enroller.Template);
                                Stop();
                                break;

                            case DPFP.Processing.Enrollment.Status.Failed:  // report failure and restart capturing
                                Enroller.Clear();
                                Stop();
                                UpdateStatus();
                                OnTemplate(null);
                                Start();
                                break;
                        }
                    }
                }
            catch { }
        }

        private void UpdateStatus()
        {
            // Show number of samples needed.
            SetStatus(string.Format("Muestras requeridas: {0}", Enroller.FeaturesNeeded));
        }

        private DPFP.Processing.Enrollment Enroller;
        private void OnTemplate(DPFP.Template template)
        {
            try
            {
                Template = template;
                if (Template != null)
                {
                    string NombreHuella = DateTime.Now.Ticks + ".pft";
                    string FileName = Program.Nori.Configuracion.directorio_huellas + @"\" + NombreHuella;
                    using (FileStream fs = File.Open(FileName, FileMode.Create, FileAccess.Write))
                    {
                        Template.Serialize(fs);
                        huella_digital = NombreHuella;
                    }
                    MessageBox.Show("Se guardó correctamente la muestra de la huella digital.");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("La muestra de la huella digital es invalida, por favor repita el proceso.");
                }
            }
            catch { }
        }

        private DPFP.Template Template;
    }
}
