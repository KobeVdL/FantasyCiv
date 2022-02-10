using FantasyCiv.GameElements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv.MainComponents
{
    /// <summary>
    /// Manages the game elements like map et cetera
    /// </summary>
    class GameManager
    {
        private ContentListener contentListener { get; set; }
        private PlayerOrder playerOrder { get; set; }

        private TileMap map;

        private Viewport viewport;
        private Camera camera;

        bool enterPressed = false;

        MouseState oldMouseState;



        public GameManager(ContentListener contentListener, Viewport viewport)
        {
            this.viewport = viewport;
            this.contentListener = contentListener;
            this.initialize();
        }

        /// <summary>
        /// Initializes all the elements 
        /// </summary>
        private void initialize()
        {
            camera = new Camera(viewport);
            playerOrder = new PlayerOrder(0, 0);

            //            Camera.ViewportWidth = graphics.GraphicsDevice.Viewport.Width;
            //            Camera.ViewportHeight = graphics.GraphicsDevice.Viewport.Height;


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
        /// <summary>
        /// Called every Frame, respond to human interaction
        /// </summary>
        /// <param name="gameTime"> time that passed </param>
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
                Vector2 point = new Vector2(mouseState.X, mouseState.Y);
                Vector2 realWorldPoint =camera.ScreenToWorldSpace(point);
                map.handleMouseClick((int) realWorldPoint.X,(int) realWorldPoint.Y);
            }
            oldMouseState = mouseState;

            //Camera.HandleInput(kstate);
        }

        public void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            camera.UpdateCamera(viewport);
            Matrix transformMatrix = camera.Transform;
            spriteBatch.Begin();
            playerOrder.draw(spriteBatch, graphics, 0, 0);
            spriteBatch.End();


            //Named and Optional Arguments see https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments
            spriteBatch.Begin(transformMatrix: transformMatrix);
            map.draw(spriteBatch, graphics, 0, 0);
            spriteBatch.End();
        }

    

    }
}
