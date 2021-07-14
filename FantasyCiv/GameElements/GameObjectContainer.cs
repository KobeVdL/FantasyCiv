using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv
{
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


        public void addToContainer(T gameObject)
        {
            elements.Add(gameObject);
        }

        public override void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            foreach (T gameObject in elements)
            {
                gameObject.draw(spriteBatch,graphics);
            }
        }

        public override void load()
        {
            foreach(T gameObject in elements)
            {
                gameObject.load();
            }
        }

        public void removeGameObject(T gameObject)
        {
            elements.Remove(gameObject);
        }

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
