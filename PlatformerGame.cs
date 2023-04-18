using DMIT1514_Lab06_Platformer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace DMIT1514_Lab06_Platformer
{
    public class PlatformerGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private const int GameScale = 1;

        Texture2D playerTexture;
        Texture2D tile;
        Actor player;
        Collider f;

        List<Collider> platformTests =new List<Collider>();

        Transform floorTransform;
        Transform playerTransform;

        public PlatformerGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            Window.Title = "Platformer Game";
            _graphics.PreferredBackBufferWidth = 360 * GameScale;
            _graphics.PreferredBackBufferHeight = 240 * GameScale;
            _graphics.ApplyChanges();
            playerTransform = new Transform(new Vector2(0, 0), 0, GameScale);
            floorTransform = new Transform(new Vector2(0, 200), 0, GameScale);
            player = new Actor(this, playerTransform, playerTexture);
            f = new Collider(this, floorTransform, tile);

            platformTests.Add(f);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            playerTexture = Content.Load<Texture2D>("character_0004");
            tile = Content.Load<Texture2D>("tile_0001");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if(Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                player.transform.SetPosition(Mouse.GetState().X,Mouse.GetState().Y);
            }
            // TODO: Add your update logic here
            foreach (Collider c in platformTests)
            {
                c.ProcessCollision(player);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                player.SetVelocity(0, -5);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}