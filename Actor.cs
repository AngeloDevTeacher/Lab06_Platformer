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
            //this.rectangle.Inflate(transform._scale, transform._scale);
        }

        public override void Update(GameTime gameTime)
        {
 
            if (transform._position.Y + transform._scale*(rectangle.Height/2) > Game.Window.ClientBounds.Height)
            {
                transform.SetPosition(transform._position.X, Game.Window.ClientBounds.Height - (transform._scale*(rectangle.Height / 2)));
                Velocity.Y = 0;
            }
            else
            {
                transform.MovePosition(Velocity);
                //Velocity.Y = 3;
            }
            rectangle.Offset(Velocity);
        }
    }
}
