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
        protected ContentListener contentListener;

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
        public abstract void  draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, int x, int y);

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

        public void moveX(int xMove)
        {
            this.setX(this.getX() + xMove);
        }

        public int getY()
        {
            return (int)this.getPosition().Y;
        }

        public void moveY(int yMove)
        {
            this.setY(this.getY() + yMove);
        }

        public void moveObject(int xMove, int yMove)
        {
            this.moveX(xMove);
            this.moveY(yMove);
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public Vector2 getAbsolutePosition(int x, int y)
        {
            Vector2 moveVector = new Vector2(x, y);
            return Vector2.Add(this.getPosition(), moveVector);
        }

        public virtual void setContentListener(ContentListener contentListener)
        {
            this.contentListener = contentListener;
        }

        public ContentListener getContentListener()
        {
            return contentListener;
        }

        public virtual void  handleMouseClick(int x, int y)
        {

        }
    }
}
