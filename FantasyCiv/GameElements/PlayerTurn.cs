using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FantasyCiv
{
    /// <summary>
    ///  PlayerTurn of the civ game
    /// </summary>
    class PlayerTurn : GameObject
    {
        String name;
        bool active;
        SpriteFont spriteFont;
        /// <summary>
        /// Creates the playerturn of the civ game
        /// </summary>
        /// <param name="name"> The name of the player</param>
        public PlayerTurn(string name): base(0,0) // this is the same as super(0,0) in java
        {
            setName(name);
        }

    
        /**
         * Executes the players turn  
         */
        public void execute()
        {
            this.setActive(true);
        }

        /// <summary>
        /// Sets this player inActive
        /// </summary>
        public void passTurn()
        {
            this.setActive(false);
        }

        /**
         * Setter and getter for name 
         */
        public void setName(String name)
        {
            this.name = name;
        }

        /// <summary>
        /// Returns the name of this playerTurn
        /// </summary>
        public String getName()
        {
            return this.name;
        }


        public override int getWidth()
        {
            return (int) spriteFont.MeasureString(this.getName()).X ;
        }
        
        public override int getHeight()
        {
            return (int) spriteFont.MeasureString(this.getName()).Y;
        }

        /// <summary>
        /// Sets this playerTurn Active
        /// </summary>
        public void setActive(bool active)
        {
            this.active = active;
        }

        /// <summary>
        /// Returns if this playerTurn is active or not
        /// </summary>
        public bool getActive()
        {
            return this.active;
        }


        public override void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics,int x, int y)
        {
            Color boxColor;
            if (this.getActive())
            {
                boxColor = Color.Red;
            }
            else
            {
                boxColor = Color.Green;
            }
            Vector2 absPosition = this.getAbsolutePosition(x, y);
            //Rectangle
            Texture2D rect = new Texture2D(graphics.GraphicsDevice, 1, 1);// (int) this.getWidth(spriteFont)+5, (int)this.getHeight(spriteFont)+5);
            rect.SetData(new[] { Color.White });
            spriteBatch.Draw(rect, new Rectangle((int)absPosition.X, (int)absPosition.Y,this.getWidth(),this.getHeight()), boxColor);
            spriteBatch.DrawString(spriteFont, this.getName(), position, Color.Black);
        }

        public override void load()
        {
            spriteFont = contentListener.retrieveFont("Arial");
        }
    }
}
