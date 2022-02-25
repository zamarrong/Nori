using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nori
{
    public static class Extensiones
    {
        public static void SetImage(this Control ctrl, Image img)
        {
            try
            {
                if (img != null)
                {
                    var cs = ctrl.Size;
                    if (img.Size != cs)
                    {
                        float ratio = Math.Max(cs.Height / (float)img.Height, cs.Width / (float)img.Width);
                        if (ratio > 1)
                        {
                            Func<float, int> calc = f => (int)Math.Ceiling(f * ratio);
                            img = new Bitmap(img, calc(img.Width), calc(img.Height));
                        }

                        img = ScaleImage(img, cs.Width / 2, cs.Height / 2);
                    }
                    ctrl.BackgroundImageLayout = ImageLayout.Center;
                    ctrl.BackgroundImage = img;
                }
            }
            catch { }
        }


        public static async void LoadImage(this PictureBox pb, string ruta)
        {
            try
            {
                pb.Image = await Funciones.CargarImagen(ruta);
            }
            catch { }
        }

        public static async void LoadImage(this Button btn, string ruta)
        {
            try
            {
                btn.BackgroundImage = await Funciones.CargarImagen(ruta);
                btn.BackgroundImageLayout = ImageLayout.Stretch;

                if (btn.BackgroundImage != null)
                {
                    ToolTip tt = new ToolTip();
                    tt.SetToolTip(btn,  btn.Text);
                    btn.Text = string.Empty;
                }
            }
            catch { }
        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }
    }
}
