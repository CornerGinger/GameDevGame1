using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevGame1
{
	public class Swatter
	{
		private Texture2D texture;
		private double animationTimer;
		private short animationFrame;

		/// <summary>
		/// The position of the fly swatter
		/// </summary>
		public Vector2 Position;

		/// <summary>
		/// Loads the fly swatter texture
		/// </summary>
		/// <param name="content">The ContentManager to load with</param>
		public void LoadContent(ContentManager content)
		{
			texture = content.Load<Texture2D>("swatter");
		}

		/// <summary>
		/// Updates the fly sprite to fly in a pattern
		/// </summary>
		/// <param name="gameTime">The game time</param>
		public void Update(GameTime gameTime, InputManager manager)
		{
			Position = manager.Direction;
		}

		/// <summary>
		/// Draws the animated sprite
		/// </summary>
		/// <param name="gameTime">The game time</param>
		/// <param name="spriteBatch">The SpriteBatch to draw with</param>
		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			// Update animation timer
			animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

			// Update animation frame
			if (animationTimer > 0.1)
			{
				animationFrame++;
				if (animationFrame > 3) animationFrame = 0;
				animationTimer -= 0.3;
			}
			var source = new Rectangle(0, 0, 64, 64);
			spriteBatch.Draw(texture, Position, source, Color.White, 0f, new Vector2(32,32), 1.5f, SpriteEffects.None, 0);
		}
	}
}
