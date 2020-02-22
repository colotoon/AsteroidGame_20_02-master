using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Game
    {
        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        public static int Width { get; set; }

        public static int Height { get; set; }

        public static string AsteroidPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\asteroid.png";
        public static Image AsteroidImage = Image.FromFile(AsteroidPath);

        public static List<asteroid> __asteroids = new List<asteroid>();

        //static Game()
        //{

        //}

        public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            var timer = new Timer { Interval = 100 };
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        public static void Load()
        {
                      
            Random rnd = new Random();
            int a_x, a_y, a_s = 0;           

            for (var i = 0; i < 50; i++)
            {
                a_s = rnd.Next(1, 5); // размер
                a_x = rnd.Next(a_s, Width - a_s); // позиция х
                a_y = rnd.Next(a_s, Height - a_s); // у

                __asteroids.Add(new asteroid(
                    new Point(a_x, a_y), // позиция
                    new Point(0, -a_s), // направление(скорость), 
                                        // больше размер - быстрее летит, эффект 3D 
                     a_s) // размер
                     ); 
            }
            

        }

        public static void Draw()
        {
            var g = __Buffer.Graphics;
            g.Clear(Color.Black);
            
                foreach (var visual_object in __asteroids)
                visual_object.Draw(g);

            __Buffer.Render();
        }

        public static void Update()
        {
            foreach (var visual_object in __asteroids)
                visual_object.Update();
        }
    }
}
