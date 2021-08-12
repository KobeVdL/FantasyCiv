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

        Adjustable screen;
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
            map = new TileMap(50, 50, 20, 20, contentListener);
            District city = new City(0, 0);
            city.setContentListener(contentListener);
            city.load();
            map.getRandomLandTile().addDistrict(city);
            District city2 = new City(0, 0);
            city2.setContentListener(contentListener);
            city2.load();
            map.getRandomLandTile().addDistrict(city2);
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
            moveMap();
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
            map.draw(spriteBatch, graphics, 0, 0);
            playerOrder.draw(spriteBatch, graphics,0,0);
        }

        public void moveMap()
        {
            var kstate = Keyboard.GetState();
            //move left    
            if (kstate.IsKeyDown(Keys.Left))
            {
                map.moveX(1);
            }

            // move right
            if (kstate.IsKeyDown(Keys.Right))
            {
                map.moveX(-1);
            }

            // move up
            if (kstate.IsKeyDown(Keys.Up))
            {
                map.moveY(1);
            }


            // move down    
            if (kstate.IsKeyDown(Keys.Down))
            {
                map.moveY(-1);
            }

            // mouse state logic (get the current state of the mouse)
            MouseState mouseState = Mouse.GetState();

            int middleX = screen.getWidth() / 2;
            int middleY = screen.getHeight() / 2;
            int xMovementSpeed = (middleX - mouseState.X) / 60;
            int yMovementSpeed = (middleY - mouseState.Y) / 60;
            //map.moveObject(xMovementSpeed, yMovementSpeed);
            if (Math.Abs(xMovementSpeed) > 2.5)
            {
                map.moveX(xMovementSpeed);
            }
            if (Math.Abs(yMovementSpeed) > 2.5)
            {
                map.moveY(yMovementSpeed);
            }
            /*







            //move left    
            if (mouseState.X < 1)
            { // do something } // move right if (coMouseState.X > ciScreenWidth)
                map.moveX(6);
            }
            else if (mouseState.X < 100) // in the lower 10 pixels
            {
                map.moveX(3);
            }

            if(mouseState.X> screen.getWidth())
            {
                map.moveX(-6);
            }
            else if(mouseState.X > screen.getWidth()-100)
            {
                map.moveX(-3);
            }

            // move up
            if (mouseState.Y < 1)
            { // do something } // move down if (coMouseState.Y > ciScreenHeight)
                map.moveY(6);
            }
            else if (mouseState.Y < 100)
            {
                map.moveY(3);
            }

            if (mouseState.Y > screen.getHeight())
            {
                map.moveY(-6);
            }
            else if (mouseState.Y > screen.getHeight()-100)
            {
                map.moveY(-3);
            }
            */
        }

        public void setScreen(Adjustable screen)
        {
            this.screen = screen;
        }

    }
}
