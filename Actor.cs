using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformerGame;

namespace DMIT1514_Lab06_Platformer
{
    public class Actor : GameObject
    {
        internal Vector2 Velocity;

        public Actor(Game game, Transform transform, Texture2D texture) : base(game, transform, texture)
        {
            Velocity = new Vector2(0,4);
            this.transform = base.transform;
            this.texture = base.texture;
            this.rectangle = this.texture.Bounds;
        }
        public override void Update(GameTime gameTime)
        {
            //base.Update(gameTime);
            rectangle = new Rectangle(transform._position.ToPoint(), rectangle.Size);
            if (rectangle.Bottom < Game.Window.ClientBounds.Height)
            {
                transform.MovePosition(Velocity);
            }

        }
    }
}
