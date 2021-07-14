using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv
{
    abstract class GameObject
    {
        protected Vector2 position;
        protected int width;
        protected int height;
        protected ContentListener contentLoaderListener;

        public GameObject(int x, int y)
        {
            this.setPosition(x, y);
        }

        public GameObject(int x, int y, int width, int height)
        {
            this.setPosition(x, y);
            this.setWidth(width);
            this.setHeight(height);
        }

        public abstract void load();
        public abstract void  draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics);

        public virtual int getWidth()
        {
            return this.width;
        }

        public virtual int getHeight()
        {
            return this.height;
        }

        protected virtual void setWidth(int width)
        {
            this.width = width;
        }

        protected virtual void setHeight(int height)
        {
            this.height = height;
        }

        public void setX(float x)
        {
            this.position.X = x;
        }

        public void setY(float y)
        {
            this.position.Y = y;
        }

        public void setPosition(int x, int y)
        {
            this.setX(x);
            this.setY(y);
        }
        public int getX()
        {
            return (int)this.getPosition().X;
        }

        public int getY()
        {
            return (int)this.getPosition().Y;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public virtual void setContentListener(ContentListener contentListener)
        {
            contentLoaderListener = contentListener;
        }

        public ContentListener getContentListener()
        {
            return contentLoaderListener;
        }
    }
}
