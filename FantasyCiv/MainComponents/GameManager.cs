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

        private TileMap map;

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
            map = new TileMap(50, 50, 5, 8, contentListener);
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
            map.draw(spriteBatch, graphics);
        }


    }
}
