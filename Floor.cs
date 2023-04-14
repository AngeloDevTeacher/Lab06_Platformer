using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformerGame;

namespace DMIT1514_Lab06_Platformer
{
    public class Floor: GameObject
    {

        public Floor(Game game, Transform transform, Texture2D texture2D) : base(game, transform, texture2D)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

    }
}
