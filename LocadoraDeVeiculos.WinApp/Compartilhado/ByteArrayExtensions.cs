using System;
using System.Drawing;

namespace LocadoraDeVeiculos.WinApp.Compartilhado
{
    public static class ByteArrayExtensions
    {
        public static Image ParaImagem(this byte[] data)
        {
            try
            {
                ImageConverter ic = new();

                return ic.ConvertFrom(data) as Image;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
