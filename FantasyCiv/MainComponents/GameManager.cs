using FantasyCiv.GameElements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv.MainComponents
{
    class GameManager
    {
        private ContentListener contentListener { get; set; }
        private PlayerOrder playerOrder { get; set; }

        private GrassTile grass;
        private GrassTile grass2;
        private GrassTile grass3;

        bool enterPressed = false;
        public GameManager(ContentListener contentListener)
        {
            this.contentListener = contentListener;
            this.initialize();
        }

        private void initialize()
        {
            playerOrder = new PlayerOrder(0, 0);


            //spriteFont = Content.Load<SpriteFont>("Fonts/Arial");
            //Initialize players 
            playerOrder.setContentListener(contentListener);

            PlayerTurn player1 = new PlayerTurn("Kobe");
            PlayerTurn player2 = new PlayerTurn("William");
            PlayerTurn player3 = new PlayerTurn("Tomas");
            player1.setContentListener(contentListener);
            player2.setContentListener(contentListener);
            player3.setContentListener(contentListener);
            player1.load();
            player2.load();
            player3.load();
            playerOrder.addPlayer(player1);
            playerOrder.addPlayer(player2);
            playerOrder.addPlayer(player3);
            playerOrder.load();
            grass = new GrassTile(50, 50);
            grass.setContentListener(contentListener);
            grass.load();
            grass2 = new GrassTile(grass.getWidth()+50, 50);
            grass2.setContentListener(contentListener);
            grass2.load();
            grass3 = new GrassTile(grass.getWidth()/2 + 50, 50+(grass.getHeight()*3/4));
            grass3.setContentListener(contentListener);
            grass3.load();
        }

        public void load()
        {

        }

        public void update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Enter) && !enterPressed)
            {
                playerOrder.nextPlayer();
                enterPressed = true;
            }
            if (kstate.IsKeyUp(Keys.Enter) && enterPressed)
            {
                enterPressed = false;
            }

        }

        public void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            playerOrder.draw(spriteBatch, graphics);
            grass.draw(spriteBatch, graphics);
            grass2.draw(spriteBatch, graphics);
            grass3.draw(spriteBatch, graphics);
        }


    }
}
