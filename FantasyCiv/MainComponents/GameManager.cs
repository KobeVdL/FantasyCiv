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

        MouseState oldMouseState;
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
            map = new TileMap(50, 50, 7, 7, contentListener);
        }

        public void load()
        {

        }

        // GOOD WEBSITE http://rbwhitaker.wikidot.com/mouse-input
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

            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                int x = mouseState.X;
                int y = mouseState.Y;
                map.handleMouseClick(x, y);
            }
            oldMouseState = mouseState;
        }

        public void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            playerOrder.draw(spriteBatch, graphics);
            map.draw(spriteBatch, graphics);
        }


    }
}
