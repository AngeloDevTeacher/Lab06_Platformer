using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


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
            Velocity.Y += 1;
        }

        public override void Update(GameTime gameTime)
        {

            Velocity.Y += 1;
            rectangle.Offset(Velocity);
            transform.MovePosition(Velocity);

        }
        internal void Land(Rectangle landingRect)
        {
            transform.SetPosition(transform._position.X, landingRect.Top - rectangle.Height+1);
            Velocity.Y = 0;
        }
        internal void StandOn(Rectangle standRect)
        {
            Velocity.Y -= 1;
        }

        public void SetVelocity(int x,int y)
        {
            Velocity = new Vector2(x,y);
        }
    }
}
