using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace time_and_sound
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        SpriteFont TimeFont;

        MouseState mouseState;

        Texture2D bombTexture;
        Rectangle bombRect;
        Texture2D boomText;
        Rectangle boombRect;

        SoundEffect explosion;

        float seconds;
        bool exploaded;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            seconds = 0f;    
            bombRect = new Rectangle(50, 50, 700, 400);
            boombRect = new Rectangle(50, 50, 700, 400);
            exploaded = false;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            bombTexture = Content.Load<Texture2D>("bomb");
            boomText = Content.Load<Texture2D>("boom");
            TimeFont = Content.Load <SpriteFont> ("timeFont");
            explosion = Content.Load<SoundEffect>("explosion");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                seconds = 0;
            }

            if (seconds >= 10 && !exploaded)
            {
                explosion.Play();
                exploaded = true;
                
            }
            if (seconds >= 20)
            {
                System.Environment.Exit(0);
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            
            _spriteBatch.Draw(bombTexture, bombRect, Color.White);
            _spriteBatch.DrawString(TimeFont,(10 - seconds).ToString(), new Vector2(270, 200), Color.Black);
            if (exploaded)
            {
                _spriteBatch.Draw(boomText, boombRect, Color.White);

            }


            _spriteBatch.End();



            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}