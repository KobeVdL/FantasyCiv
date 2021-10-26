using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv
{
    /// <summary>
    ///  Container that contains GameObject or more specific objects
    /// </summary>
    class GameObjectContainer<T> : GameObject where T : GameObject
    {
        protected ArrayList elements = new ArrayList();

        // For a static size container
        public GameObjectContainer(int x, int y, int width, int height) : base(x,y,width,height)
        {

        }

        // For a dynamic size container
        public GameObjectContainer(int x, int y) : base(x, y)
        {

        }

        /// <summary>
        /// Add an object to the container
        /// </summary>
        public void addToContainer(T gameObject)
        {
            elements.Add(gameObject);
        }

        //See GameObject
        public override void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, int x, int y)
        {
            foreach (T gameObject in elements)
            {
                gameObject.draw(spriteBatch,graphics, x + this.getX(), y + this.getY());
            }
        }
        //See GameObject
        public override void load()
        {
            foreach(T gameObject in elements)
            {
                gameObject.load();
            }
        }
        /// <summary>
        /// Removes the given GameObject in the container 
        /// </summary>
        public void removeGameObject(T gameObject)
        {
            elements.Remove(gameObject);
        }

        //See GameObject
        public override void setContentListener(ContentListener contentListener)
        {
            base.setContentListener(contentListener);
            foreach (T gameObject in elements)
            {
                gameObject.setContentListener(contentListener);
            }
        }
    }
}
