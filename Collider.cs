using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace DMIT1514_Lab06_Platformer
{
    public class Collider: GameObject
    {
        public enum ColliderType
        {
            Left, Right, Top, Bottom
        }
        protected ColliderType type;

        public Collider(Game game, Transform transform, Texture2D texture) : base(game, transform, texture)
        {
            this.transform = base.transform;
            this.texture = base.texture;
            this.rectangle = this.texture.Bounds;

            this.rectangle.Location = this.transform._position.ToPoint();
            this.rectangle = new Rectangle(rectangle.Location, new Point(rectangle.Width*(int)transform._scale,rectangle.Height*(int)transform._scale));
            //transform.SyncRect(this.rectangle);
            type = ColliderType.Top;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        internal bool ProcessCollision(Actor actor)
        {
            bool didCollide = false;
            if (rectangle.Intersects(actor.rectangle))
            {
                didCollide = true;
                switch(type) 
                { 
                    case ColliderType.Left:
                        break;
                    case ColliderType.Right:
                        break;
                    case ColliderType.Top:
                        actor.Land(rectangle);
                        actor.StandOn(rectangle);
                        break;
                    case ColliderType.Bottom:
                        break;
                }
            }
            return didCollide;
        }


    }
}
