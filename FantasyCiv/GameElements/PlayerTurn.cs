using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FantasyCiv
{
    class PlayerTurn : GameObject
    {
        String name;
        bool active;
        SpriteFont spriteFont;

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


        public void setActive(bool active)
        {
            this.active = active;
        }

        public bool getActive()
        {
            return this.active;
        }


        public override void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
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
            //Rectangle
            Texture2D rect = new Texture2D(graphics.GraphicsDevice, 1, 1);// (int) this.getWidth(spriteFont)+5, (int)this.getHeight(spriteFont)+5);
            rect.SetData(new[] { Color.White });
            spriteBatch.Draw(rect, new Rectangle((int) this.position.X, (int)this.position.Y,this.getWidth(),this.getHeight()), boxColor);
            spriteBatch.DrawString(spriteFont, this.getName(), position, Color.Black);
        }

        public override void load()
        {
            spriteFont = contentLoaderListener.retrieveFont("Arial");
        }
    }
}
