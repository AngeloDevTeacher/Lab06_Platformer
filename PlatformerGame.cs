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
        private const int GameScale = 4;

        Texture2D playerTexture;
        Texture2D tile;
        Actor player;
        Collider f;
        Collider f2;
        bool inBlock;

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
            playerTransform = new Transform(new Vector2(20*GameScale, 0*GameScale), 0, GameScale);
            floorTransform = new Transform(new Vector2(20*GameScale, 200*GameScale), 0, GameScale);
            player = new Actor(this, playerTransform, playerTexture);
            f = new Collider(this, floorTransform, tile);
            floorTransform = new Transform(new Vector2(20 * GameScale, 130 * GameScale), 0, GameScale);
            f2 = new Collider(this, floorTransform, tile);
            platformTests.Add(f);
            platformTests.Add(f2);
            f2.SetType(Collider.ColliderType.Bottom);
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
                //player.transform.SetPosition(Mouse.GetState().X,Mouse.GetState().Y);
                player.SetVelocity(0, 0);
                player.rectangle.Location = Mouse.GetState().Position;
            }
            // TODO: Add your update logic here
            foreach (Collider c in platformTests)
            {
                inBlock = c.ProcessCollision(player);
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !inBlock)
            {
                player.AddVelocity(0, -4);
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