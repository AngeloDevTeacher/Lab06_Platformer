using DMIT1514_Lab06_Platformer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlatformerGame
{
    public class PlatformerGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public const int GameScale = 3;

        Texture2D playerTexture;
        Texture2D tile;
        GameObject player;
        Floor f;
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
            playerTransform = new Transform(new Vector2(128, 128), 0, GameScale);
            floorTransform = new Transform(new Vector2(400, 400), 0, GameScale);
            player = new Actor(this, playerTransform, playerTexture);
            f = new Floor(this, floorTransform, tile);
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

            // TODO: Add your update logic here

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