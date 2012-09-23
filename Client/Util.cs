﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SFML.Window;
using SFML.Graphics;

namespace FTLOverdrive.Client
{
    public static class Util
    {
        public static Vector2f Scale(Sprite spr, Vector2f pixelsize)
        {
            return new Vector2f(pixelsize.X / (float)spr.Texture.Size.X, pixelsize.Y / (float)spr.Texture.Size.Y);
        }

        public static IntRect ScreenRect(uint w, uint h, float aspect)
        {
            float a = w / (float)h;
            if (a > aspect)
            {
                // Screen is too wide
                int neww = (int)(aspect * h);
                return new IntRect((int)(w / 2) - (neww / 2), 0, neww, (int)h);
            }
            else if (a < aspect)
            {
                // Screen is too tall
                int newh = (int)(w / aspect);
                return new IntRect(0, (int)(h / 2) - (newh / 2), (int)w, newh);
            }
            else
                return new IntRect(0, 0, (int)w, (int)h);
        }

        public static void LayoutControl(UI.Control ctrl, int x, int y, int w, int h, IntRect screenrect)
        {
            // x,y,w,h are relative to 1280x720
            ctrl.X = (int)((x / 1280.0f) * screenrect.Width);
            ctrl.Y = (int)((y / 720.0f) * screenrect.Height);
            ctrl.Width = (int)((w / 1280.0f) * screenrect.Width);
            ctrl.Height = (int)((h / 720.0f) * screenrect.Height);
        }

    }
}
