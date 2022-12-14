using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_topic6keep
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D tribbleBrownTexture;

        Texture2D tribbleCreamTexture;

        Texture2D tribbleGreyTexture;

        Texture2D tribbleOrangeTexture;

        tribble discotribble, tribble1, tribble2, tribble3;

        SpriteFont textFont;
        SoundEffect tribblecoo;
        Texture2D introTexture;
        Rectangle introRect;
        Screen screen;
        MouseState mouseState;

        enum Screen
        {
            Intro,
            Tribbleyard
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this.Window.Title = "Lesson 3 - Animation Part 1";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 600;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            

            introRect = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            screen = Screen.Intro;

            base.Initialize();
            discotribble = new tribble(new Rectangle(300, 10, 100, 100), new Vector2(4, 5), tribbleOrangeTexture, true, tribblecoo);
            tribble1 = new tribble(new Rectangle(400, 100, 100, 100), new Vector2(3, 1), tribbleGreyTexture, false, tribblecoo);
            tribble2 = new tribble(new Rectangle(100, 300, 100, 100), new Vector2(1, 2), tribbleCreamTexture, false, tribblecoo);
            tribble3 = new tribble(new Rectangle(600, 50, 100, 100), new Vector2(6, 6), tribbleBrownTexture, false, tribblecoo);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            textFont = Content.Load<SpriteFont>("ColorFont");
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");

            tribblecoo = Content.Load<SoundEffect>("tribble_coo");
            introTexture = Content.Load<Texture2D>("Untitled");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            

            // TODO: Add your update logic here
            mouseState = Mouse.GetState();
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.Tribbleyard;
            }
            else if (screen == Screen.Tribbleyard)
            {
                discotribble.Move(_graphics);
                tribble1.Move(_graphics);
                tribble2.Move(_graphics);
                tribble3.Move(_graphics);
            }
            
                
                
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introTexture, introRect, Color.White);
                _spriteBatch.DrawString(textFont, "Left click to go to the tribble yard", new Vector2(150, 300), Color.White);
            }
            else if (screen == Screen.Tribbleyard)
            {
                discotribble.Draw(_spriteBatch);
                tribble1.Draw(_spriteBatch);
                tribble2.Draw(_spriteBatch);
                tribble3.Draw(_spriteBatch);
            }

                _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}