using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.Compartilhado
{
    public static class PictureBoxExtensions
    {
        public static byte[] ParaByteArray(this PictureBox pb)
        {
            MemoryStream ms = new();
            if (pb.Image != null)
                pb.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}
