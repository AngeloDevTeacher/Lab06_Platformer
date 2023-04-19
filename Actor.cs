using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace DMIT1514_Lab06_Platformer
{
    public class Actor : GameObject
    {
        internal Vector2 Velocity;

        public Actor(Game game, Transform transform, Texture2D texture) : base(game, transform, texture)
        {
            Velocity = new Vector2(0,0);
            this.transform = base.transform;
            this.texture = base.texture;

            this.rectangle = this.texture.Bounds;
            this.rectangle = new Rectangle(rectangle.Location, new Point(rectangle.Width * (int)transform._scale, rectangle.Height * (int)transform._scale));
            Velocity.Y += 1;
        }

        public override void Update(GameTime gameTime)
        {
            Velocity.Y += 1;
            rectangle.Offset(Velocity);
            transform.SyncRect(rectangle);
        }
        internal void Land(Rectangle landingRect)
        {
            //rectangle.X = (int)rectangle.X;
            rectangle.Y = (int)(landingRect.Top - rectangle.Height) + 1;
            Velocity.Y = 0;
            transform.SyncRect(rectangle);
        }
        internal void StandOn(Rectangle standRect)
        {
            Velocity.Y -= 1;
        }

        public void SetVelocity(int x,int y)
        {
            Velocity = new Vector2(x,y);
        }
        public void AddVelocity(int x, int y)
        {
            Velocity.X += x;
            Velocity.Y += y;
        }
    }
}
