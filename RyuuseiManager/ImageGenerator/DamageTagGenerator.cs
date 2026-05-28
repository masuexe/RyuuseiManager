using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace RyuuseiManager.ImageGenerator
{
    public class DamageTagGenerator
    {
        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        private static BitmapSource ToBitmapSource(Bitmap bitmap)
        {
            IntPtr hBitmap = bitmap.GetHbitmap();

            try
            {
                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                DeleteObject(hBitmap);
            }
        }

        private static Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            int width = bitmapImage.PixelWidth;
            int height = bitmapImage.PixelHeight;
            int stride = width * 4;

            byte[] pixelData = new byte[height * stride];
            bitmapImage.CopyPixels(pixelData, stride, 0);

            var bmp = new Bitmap(width, height, PixelFormat.Format32bppPArgb);

            var bmpData = bmp.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly,
                bmp.PixelFormat);

            System.Runtime.InteropServices.Marshal.Copy(pixelData, 0, bmpData.Scan0, pixelData.Length);
            bmp.UnlockBits(bmpData);

            return bmp;
        }

        public static BitmapSource GetDamageTag(int damage, int tier)
        {
            if (damage > 999) return null;
            BitmapImage tierBg = new BitmapImage();
            switch (tier)
            {
                default:
                case 0: tierBg = new BitmapImage(new Uri("pack://application:,,,/GameResource;component/Resources/BattleCard/Common/Standard.png", UriKind.Absolute)); break;
                case 1: tierBg = new BitmapImage(new Uri("pack://application:,,,/GameResource;component/Resources/BattleCard/Common/Mega.png", UriKind.Absolute)); break;
                case 2: tierBg = new BitmapImage(new Uri("pack://application:,,,/GameResource;component/Resources/BattleCard/Common/Giga.png", UriKind.Absolute)); break;
            }
            if (damage > 0)
            {
                Bitmap tierBmp = BitmapImage2Bitmap(tierBg);
                Bitmap damageNumber = new Bitmap(23, 11);
                using (Graphics g = Graphics.FromImage(damageNumber))
                {
                    string num = damage.ToString().PadLeft(3, ' ');
                    for (int i = 0; i < num.Length; i++)
                    {
                        DrawNumber(g, num[i], i);
                    }
                }
                using (Graphics g = Graphics.FromImage(tierBmp))
                {
                    g.DrawImage(damageNumber, 8, 2, new Rectangle(0, 0, 23, 11), GraphicsUnit.Pixel);
                }
                return ToBitmapSource(tierBmp);
            }
            else if (damage < 0)
            {
                Bitmap tierBmp = BitmapImage2Bitmap(tierBg);
                Bitmap damageNumber = new Bitmap(23, 11);
                using (Graphics g = Graphics.FromImage(damageNumber))
                {
                    string num = "???";
                    for (int i = 0; i < num.Length; i++)
                    {
                        DrawNumber(g, num[i], i);
                    }
                }
                using (Graphics g = Graphics.FromImage(tierBmp))
                {
                    g.DrawImage(damageNumber, 8, 2, new Rectangle(0, 0, 23, 11), GraphicsUnit.Pixel);
                }
                return ToBitmapSource(tierBmp);
            }
            else
            {
                return ToBitmapSource(new Bitmap(1, 1));
            }
        }

        private static void DrawNumber(Graphics g, char number, int location)
        {
            int x = location * 8;
            DamageNumber dmgNum = new DamageNumber();
            Bitmap targetNum = null;
            switch (number)
            {
                default: targetNum = dmgNum._q;  break;
                case ' ': return;
                case '0': targetNum = dmgNum._0; break;
                case '1': targetNum = dmgNum._1; break;
                case '2': targetNum = dmgNum._2; break;
                case '3': targetNum = dmgNum._3; break;
                case '4': targetNum = dmgNum._4; break;
                case '5': targetNum = dmgNum._5; break;
                case '6': targetNum = dmgNum._6; break;
                case '7': targetNum = dmgNum._7; break;
                case '8': targetNum = dmgNum._8; break;
                case '9': targetNum = dmgNum._9; break;
            }
            g.DrawImage(targetNum, x, 0, new Rectangle(0, 0, targetNum.Width, targetNum.Height), GraphicsUnit.Pixel);
        }

        private class DamageNumber
        {
            public DamageNumber()
            {
                _0 = BitmapImage2Bitmap(new BitmapImage(new Uri("pack://application:,,,/GameResource;component/Resources/BattleCard/Common/0.png", UriKind.Absolute)));
                _1 = BitmapImage2Bitmap(new BitmapImage(new Uri("pack://application:,,,/GameResource;component/Resources/BattleCard/Common/1.png", UriKind.Absolute)));
                _2 = BitmapImage2Bitmap(new BitmapImage(new Uri("pack://application:,,,/GameResource;component/Resources/BattleCard/Common/2.png", UriKind.Absolute)));
                _3 = BitmapImage2Bitmap(new BitmapImage(new Uri("pack://application:,,,/GameResource;component/Resources/BattleCard/Common/3.png", UriKind.Absolute)));
                _4 = BitmapImage2Bitmap(new BitmapImage(new Uri("pack://application:,,,/GameResource;component/Resources/BattleCard/Common/4.png", UriKind.Absolute)));
                _5 = BitmapImage2Bitmap(new BitmapImage(new Uri("pack://application:,,,/GameResource;component/Resources/BattleCard/Common/5.png", UriKind.Absolute)));
                _6 = BitmapImage2Bitmap(new BitmapImage(new Uri("pack://application:,,,/GameResource;component/Resources/BattleCard/Common/6.png", UriKind.Absolute)));
                _7 = BitmapImage2Bitmap(new BitmapImage(new Uri("pack://application:,,,/GameResource;component/Resources/BattleCard/Common/7.png", UriKind.Absolute)));
                _8 = BitmapImage2Bitmap(new BitmapImage(new Uri("pack://application:,,,/GameResource;component/Resources/BattleCard/Common/8.png", UriKind.Absolute)));
                _9 = BitmapImage2Bitmap(new BitmapImage(new Uri("pack://application:,,,/GameResource;component/Resources/BattleCard/Common/9.png", UriKind.Absolute)));
                _q = BitmapImage2Bitmap(new BitmapImage(new Uri("pack://application:,,,/GameResource;component/Resources/BattleCard/Common/q.png", UriKind.Absolute)));
            }

            public Bitmap _0 { get; private set; }
            public Bitmap _1 { get; private set; }
            public Bitmap _2 { get; private set; }
            public Bitmap _3 { get; private set; }
            public Bitmap _4 { get; private set; }
            public Bitmap _5 { get; private set; }
            public Bitmap _6 { get; private set; }
            public Bitmap _7 { get; private set; }
            public Bitmap _8 { get; private set; }
            public Bitmap _9 { get; private set; }
            public Bitmap _q { get; private set; }
        }
    }
}
