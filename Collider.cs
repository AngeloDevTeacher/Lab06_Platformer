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
