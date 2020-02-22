using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AsteroidGame
{
    class asteroid
    {
        protected Point _Position;
        protected Point _Direction;
        protected int _Size;

        public asteroid(Point Position, Point Direction, int Size)
        {
            _Position = Position;
            _Direction = Direction;
            _Size = Size;
        }


        public void Draw(Graphics g)
        {

            // лучшее решение
            g.FillEllipse(Brushes.White, new Rectangle(
                 _Position.X, _Position.Y,
                 _Size, _Size));

            // с DrawImage нагрузка на проц повышается до 25%
            //g.DrawImage(Game.AsteroidImage, _Position.X, _Position.Y, _Size, _Size);


        }

        public void Update()
        {
            _Position.Y -= _Direction.Y;
            if (_Position.Y <= 0)
            {
                
                _Position.Y = Game.Height;
            }
            if(_Position.Y > Game.Height)
            {
                _Position.Y = 0;
            }
            

        }

    }
}
