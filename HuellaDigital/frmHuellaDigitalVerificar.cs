using System.IO;
using System.Windows.Forms;

namespace Nori.HuellaDigital
{
    public partial class frmHuellaDigitalVerificar : frmHuellaDigital
    {
        int enrolls = 1;

        public void Verify(DPFP.Template template)
        {
            Template = template;
            ShowDialog();
        }

        protected override void Init()
        {
            try
            {
                base.Init();
                base.Text = Text;
                using (FileStream fs = File.OpenRead(Program.Nori.Configuracion.directorio_huellas + @"\" + huella_digital))
                {
                    DPFP.Template template = new DPFP.Template(fs);
                    Template = template;
                }
                Verificator = new DPFP.Verification.Verification();     // Create a fingerprint template verificator
                SetStatus("Coloque su huella dactilar en el lector.");
            }
            catch { }
        }

        protected override void Process(DPFP.Sample Sample)
        {
            try
            {
                base.Process(Sample);

                // Process the sample and create a feature set for the enrollment purpose.
                DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

                // Check quality of the sample and start verification if it's good
                // TODO: move to a separate task
                if (features != null)
                {
                    // Compare the feature set with our template
                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                    Verificator.Verify(features, Template, ref result);
                    if (result.Verified)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        SetStatus("Verificación(es) incorrecta(s) (" + enrolls + ")");
                    }
                    enrolls++;
                }
            }
            catch { }
        }

        private DPFP.Template Template;
        private DPFP.Verification.Verification Verificator;
    }
}
