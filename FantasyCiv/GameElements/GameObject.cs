using FantasyCiv.MainComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv
{
    /// <summary>
    /// Base class of objects in Civ game, basically every game object has a position, size and drawing properties
    /// </summary>
    abstract class GameObject
    {
        protected Vector2 position;
        protected int width;
        protected int height;
        protected ContentListener contentListener;


        /// <summary>
        /// Dynamic size constructor
        /// </summary>
        /// <param name="x"> relative x position of GameObject  </param>
        /// <param name="y"> relative y position of GameObject </param>
        public GameObject(int x, int y)
        {
            this.setPosition(x, y);
        }

        /// <summary>
        /// Static size constructor
        /// </summary>
        /// <param name="x"> relative x position of GameObject </param>
        /// <param name="y"> relative y position of GameObject </param>
        /// <param name="width"> width of GameObject </param>
        /// <param name="height"> height of GameObject </param>
        public GameObject(int x, int y, int width, int height)
        {
            this.setPosition(x, y);
            this.setWidth(width);
            this.setHeight(height);
        }

        /// <summary>
        /// Loads all textures for the gameObject
        /// </summary>
        public abstract void load();

        /// <summary>
        /// Draws the current GameObject 
        /// </summary>
        /// <param name="spriteBatch"> Helper class for drawing text strings and sprites in one or more optimized batches.</param>
        /// <param name="graphics"> Graphics class </param>
        /// <param name="x"> the absolute X position </param>
        /// <param name="y"> the absolute Y position </param>
        public abstract void  draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, int x, int y);

        /// <summary>
        /// Returns the width of this GameObject
        /// </summary>
        public virtual int getWidth()
        {
            return this.width;
        }

        /// <summary>
        /// Returns the height of this GameObject
        /// </summary>
        public virtual int getHeight()
        {
            return this.height;
        }

        /// <summary>
        /// Sets the width of this GameObject
        /// </summary>
        protected virtual void setWidth(int width)
        {
            this.width = width;
        }

        /// <summary>
        /// Sets the height of this GameObject
        /// </summary>
        protected virtual void setHeight(int height)
        {
            this.height = height;
        }

        /// <summary>
        /// Sets the relative X position of this Object
        /// </summary>
        public void setX(float x)
        {
            this.position.X = x;
        }

        /// <summary>
        /// Sets the relative Y position of this object
        /// </summary>
        public void setY(float y)
        {
            this.position.Y = y;
        }

        /// <summary>
        /// Sets the relative position of this object
        /// </summary>
        /// <param name="x"> the relative x </param>
        /// <param name="y"> the relative y </param>
        public void setPosition(int x, int y)
        {
            this.setX(x);
            this.setY(y);
        }
        /// <summary>
        /// Returns the relative X of this GameObject
        /// </summary>
        public int getX()
        {
            return (int)this.getPosition().X;
        }

        /// <summary>
        /// Move the x position with a X vector
        /// </summary>
        public void moveX(int xMove)
        {
            this.setX(this.getX() + xMove);
        }

        /// <summary>
        /// Returns the relative Y of this GameObject
        /// </summary>
        public int getY()
        {
            return (int)this.getPosition().Y;
        }

        /// <summary>
        /// Move the y position with a Y vector
        /// </summary>
        public void moveY(int yMove)
        {
            this.setY(this.getY() + yMove);
        }

        /// <summary>
        /// Move the position with given 2D vector
        /// </summary>
        public void moveObject(int xMove, int yMove)
        {
            this.moveX(xMove);
            this.moveY(yMove);
        }

        /// <summary>
        /// Returns the position of this GameObject
        /// </summary>
        public Vector2 getPosition()
        {
            return position;
        }

        /// <summary>
        /// Returns the gameObject relative position added with the given vector to calculate the absolute position
        /// </summary>
        /// <param name="x"> the x position of the vector to add </param>
        /// <param name="y"> the y position of the vector to add </param>
        public Vector2 getAbsolutePosition(int x, int y)
        {
            Vector2 moveVector = new Vector2(x, y);
            return Vector2.Add(this.getPosition(), moveVector);
        }

        /// <summary>
        /// Sets the contentListener of this GameObject (used to retrieve textures)
        /// </summary>
        /// <param name="contentListener"> the contentListener to retrieve </param>
        public virtual void setContentListener(ContentListener contentListener)
        {
            this.contentListener = contentListener;
        }

        /// <summary>
        /// Returns the contentListener of this GameObject
        /// </summary>
        /// <returns></returns>
        public ContentListener getContentListener()
        {
            return contentListener;
        }

        public void draw(Texture2D texture , SpriteBatch spriteBatch, GraphicsDeviceManager graphics, int x, int y)
        {
            float scale = 1;//TODO Camera.getScale();
            spriteBatch.Draw(texture, this.getAbsolutePosition(x, y), null, Color.White, 0.0f, new Vector2(0, 0), new Vector2(scale, scale), SpriteEffects.None, 0.0f);
        }

        public void draw(Texture2D texture, SpriteBatch spriteBatch, GraphicsDeviceManager graphics, int x, int y,float scale)
        {
            spriteBatch.Draw(texture, this.getAbsolutePosition(x, y), null, Color.White, 0.0f, new Vector2(0, 0), new Vector2(scale, scale), SpriteEffects.None, 0.0f);
        }


        /// <summary>
        ///  Descibes what has to be done when a mouse is clicked on the object
        /// </summary>
        /// <param name="x"> the edited x position </param>
        /// <param name="y"> the edited y position </param>
        public virtual void  handleMouseClick(int x, int y, KeyboardState kstate)
        {

        }
    }
}
