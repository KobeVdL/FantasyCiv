using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FantasyCiv
{
    public class GameController : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private PlayerOrder playerOrder;
        private MainController mainController;
        bool enterPressed = false;
        public GameController()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //  PlayerTurn
            playerOrder = new PlayerOrder(0,0);
            mainController = new MainController(this);


            //spriteFont = Content.Load<SpriteFont>("Fonts/Arial");
            //Initialize players 
            playerOrder.setContentListener(mainController);
            base.Initialize();

        }

        protected override void LoadContent()
        {
            PlayerTurn player1 = new PlayerTurn("Kobe");
            PlayerTurn player2 = new PlayerTurn("William");
            PlayerTurn player3 = new PlayerTurn("Tomas");
            player1.setContentListener(mainController);
            player2.setContentListener(mainController);
            player3.setContentListener(mainController);
            player1.load();
            player2.load();
            player3.load();
            playerOrder.addPlayer(player1);
            playerOrder.addPlayer(player2);
            playerOrder.addPlayer(player3);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            playerOrder.load();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown( Keys.Enter) && !enterPressed)
            {
                playerOrder.nextPlayer();
                enterPressed = true;
            }
            if (kstate.IsKeyUp(Keys.Enter) && enterPressed)
            {
                enterPressed = false;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            //playerOrder.draw(spriteBatch, spriteFont);
            spriteBatch.Begin();
            playerOrder.draw(spriteBatch,graphics);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public SpriteFont retrieveFont(string fontName)
        {
            return Content.Load<SpriteFont>("Fonts/" + fontName);
        }

        public Texture2D retrieveImage(string imageName)
        {
            return Content.Load<Texture2D>("Images/" + imageName);
        }
    }
}
