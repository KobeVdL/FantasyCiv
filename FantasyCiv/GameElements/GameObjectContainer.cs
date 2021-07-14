using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv
{
    class GameObjectContainer: GameObject
    {
        protected ArrayList gameObjectList = new ArrayList();

        // For a static size container
        public GameObjectContainer(int x, int y, int width, int height) : base(x,y,width,height)
        {

        }

        // For a dynamic size container
        public GameObjectContainer(int x, int y) : base(x, y)
        {

        }


        public void addGameObject(GameObject gameObject)
        {
            gameObjectList.Add(gameObject);
        }

        public override void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            foreach (GameObject gameObject in gameObjectList)
            {
                gameObject.draw(spriteBatch,graphics);
            }
        }

        public override void load()
        {
            foreach(GameObject gameObject in gameObjectList)
            {
                gameObject.load();
            }
        }

        public void removeGameObject(GameObject gameObject)
        {
            gameObjectList.Remove(gameObject);
        }

        public override void setContentListener(ContentListener contentListener)
        {
            base.setContentListener(contentListener);
            foreach (GameObject gameObject in gameObjectList)
            {
                gameObject.setContentListener(contentListener);
            }
        }
    }
}
