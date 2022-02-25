using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using NoriCFDI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Nori
{
    public static class Program
    {
        public static NoriSDK.Nori Nori = new NoriSDK.Nori();
        public static List<NoriSDK.Sucursal> sucursales = new List<NoriSDK.Sucursal>();
        public static NoriSAPB1SDK.NoriSAPSQL NoriSAP;
        public static CFDI CFDI;
        public static object ObjetoDinamico = null;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("Office 2016 Colorful");

            Application.Run(new frmAcceder());
        }
    }
}