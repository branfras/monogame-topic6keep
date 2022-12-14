using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace monogame_topic6keep
{
    class tribble
    {
        private Rectangle _rectangle;
        private Vector2 _speed;
        private Texture2D _texture;
        public Color _color;
        private int _R;
        private int _G;
        private int _B;
        private int _Rspeed;
        private int _Gspeed;
        private int _Bspeed;
        private SoundEffect _tribblecoo;
        private bool _isDiscoTribble;

        public tribble(Rectangle rectangle, Vector2 speed, Texture2D texture, bool disco, SoundEffect soundEffect)
        {
            _rectangle = rectangle;
            _speed = speed;
            _texture = texture;
            _tribblecoo = soundEffect;
            
            if (disco)
            {
                _R = 1;
                _G = 100;
                _B = 200;
                _Rspeed = 1;
                _Gspeed = 1;
                _Bspeed = 1;
                _color = new Color(new Vector3(0, 0, 0));
               
            }
            else
                _color = Color.White;   
            
            _isDiscoTribble = disco;
        }   

        public Texture2D Texture { get { return _texture; } }

        public Rectangle Bounds 
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }



        public void Move(GraphicsDeviceManager graphics)
        {
            _rectangle.Offset(_speed);
            if (_rectangle.Right > graphics.PreferredBackBufferWidth || _rectangle.Left < 0)
            {
                _speed.X *= -1;
                _tribblecoo.Play();
            }
            if (_rectangle.Bottom > graphics.PreferredBackBufferHeight || _rectangle.Top < 0)
            { 
                _speed.Y *= -1;
                _tribblecoo.Play();
            }

            
            if (_isDiscoTribble)
            {
                _R += _Rspeed;
                _G += _Gspeed;
                _B += _Bspeed;
                if (_R == 0 || _R == 255)
                    _Rspeed *= -1;
                if (_G == 0 || _G == 255)
                    _Gspeed *= -1;
                if (_B == 0 || _B == 255)
                    _Bspeed *= -1;
                _color = new Color(_R, _G, _B);
            }
            

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, _color);
        }
    }
}
