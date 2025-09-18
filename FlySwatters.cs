using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace GameDevGame1
{
    public class FlySwatters : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private FlySprite[] flies;
        public FlySwatters()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
			// TODO: Add your initialization logic here
            Random random = new Random();
			flies = new FlySprite[]
{
				new FlySprite(){ Position = new Vector2(100,100), Velocity = new Vector2((float)random.NextDouble(), (float)random.NextDouble())},
				new FlySprite(){ Position = new Vector2(400,400), Velocity = new Vector2((float)random.NextDouble(), (float)random.NextDouble())},
				new FlySprite(){ Position = new Vector2(100,400), Velocity = new Vector2((float)random.NextDouble(), (float)random.NextDouble())},
				new FlySprite(){ Position = new Vector2(300,100), Velocity = new Vector2((float)random.NextDouble(), (float)random.NextDouble())},
				new FlySprite(){ Position = new Vector2(200,200), Velocity = new Vector2((float)random.NextDouble(), (float)random.NextDouble())}

};

			base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
			foreach (var fly in flies) fly.LoadContent(Content);

			// TODO: use this.Content to load your game content here
		}

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			// TODO: Add your update logic here
			foreach (var fly in flies) fly.Update(gameTime, _graphics);

			base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
			foreach (var fly in flies) fly.Draw(gameTime, spriteBatch);
            spriteBatch.End();
			base.Draw(gameTime);
        }
    }
}
