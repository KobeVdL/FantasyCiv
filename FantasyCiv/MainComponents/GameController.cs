using FantasyCiv.MainComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FantasyCiv
{
    /// <summary>
    /// GameController controls all the low-level events of the game and pass them through the correct class
    /// The first class that is created and can retrieve fonts and images.
    /// </summary>
    public class GameController : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GameManager manager;
        private MainController mainController;

        #region Class Level Declarations
        // Gehaald van tutorial https://blackfalconsoftware.wordpress.com/2016/08/22/part-i-creating-a-digital-hexagonal-tile-map/

        private int gameScreenHeight = 600;
        private int gameScreenWidth = 800;

        /*
        private int ciRowPosition = 0;
        private int ciColumnPosition = 0;

        private string csScrollDirection = "";  // R,L,U,D
        */

        /*private MGWorkBench_ScrollingHexMap.Classes.TileMap coTileMap;
        private MGWorkBench_ScrollingHexMap.Structures.HexTexture2D coHexTexture2D;
        private Microsoft.Xna.Framework.Input.KeyboardState coKeyboardState;*/
        private Microsoft.Xna.Framework.Graphics.Texture2D coTexture2DTile;


        #endregion



        /// <summary>
        /// Creates a GameController class, Initialize the pointers 
        /// </summary>
        public GameController()
        {
            graphics = new GraphicsDeviceManager(this);
            // point to the content root directory for all images and fonts
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        /// <summary>
        /// Initializes the gameScreen, this is called at the start of running the program once
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            graphics.PreferredBackBufferWidth = gameScreenWidth;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = gameScreenHeight;   // set this value to the desired height of your window
            graphics.ApplyChanges();

            // make the mouse standard pointer visible
            this.IsMouseVisible = true;
            // set the mouse top the center of screen 
            //   * will also prevent automatic screen movement when the screen is displayed and the
            //   * mouse position is calculated during the Update event; since it will be within any
            //   * of the tested bounds no sudden screen movement will occur
            Mouse.SetPosition(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
        }

        /// <summary>
        /// Also called at the first frame but focuses more on initializing other classes
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //  PlayerTurn
            mainController = new MainController(this);
            manager = new GameManager(mainController, GraphicsDevice.Viewport);
        }

       /// <summary>
       /// Called every Frame, in this phase all classes are updated, 
       /// </summary>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
           
            manager.update(gameTime);


            base.Update(gameTime);
        }

        /// <summary>
        /// Called every Frame, in this phase all classes are drawn on the screen. 
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {

            // set screen background color
            GraphicsDevice.Clear(Color.Black);
            //spriteBatch.Begin();
            manager.draw(spriteBatch,graphics);
            //spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Retrieves the given front
        /// </summary>
        /// <param name="fontName"> The name of the font to retrieve</param>
        public SpriteFont retrieveFont(string fontName)
        {
            return Content.Load<SpriteFont>("Fonts/" + fontName);
        }

        /// <summary>
        /// Retrieves the given image
        /// </summary>
        /// <param name="imageName"> The name of the image to retrieve </param>
        /// <returns></returns>
        public Texture2D retrieveImage(string imageName)
        {
            return Content.Load<Texture2D>("Images/" + imageName);
        }


        
    }
}
