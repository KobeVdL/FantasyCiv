using FantasyCiv.MainComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FantasyCiv
{
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




        public GameController()
        {
            graphics = new GraphicsDeviceManager(this);
            // point to the content root directory for all images and fonts
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            graphics.PreferredBackBufferWidth = gameScreenWidth;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = gameScreenHeight;   // set this value to the desired height of your window
            graphics.ApplyChanges();

        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // #########TUTORIAL############################


            // use this.Content to load your game content here
            /*coTexture2DTile = this.Content.Load & lt; Texture2D & gt; ("Grass_72x72");
            coSpriteFont = this.Content.Load & lt; SpriteFont & gt; ("MySpriteFont");

            coHexTexture2D = new MGWorkBench_ScrollingHexMap.Structures.HexTexture2D();

            coHexTexture2D.TEXTURE2D_ID = 1;
            coHexTexture2D.TEXTURE2D_IMAGE_TILE = coTexture2DTile;

            MGWorkBench_ScrollingHexMap.Structures.Global.TEXTURE2D_ARRAY_LIST.Add(coHexTexture2D);

            */
            //#########END################################



            //  PlayerTurn
            mainController = new MainController(this);
            manager = new GameManager(mainController);
            // TODO: use this.Content to load your game content here
        }

       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
           
            // ############TUTORIAL############################
            // user-defined update logic here

            /* csScrollDirection = "";
             coKeyboardState = Keyboard.GetState();

             //move left
             if (coKeyboardState.IsKeyDown(Keys.Left))
             {
                 csScrollDirection = "L";
                 ciRowPosition = ciRowPosition + 0;          // maintain current row position
                 ciColumnPosition = ciColumnPosition - 1;    // decrease column position by 1

                 MGWorkBench_ScrollingHexMap.Classes.Camera.coCameraVector2Location.X = MathHelper.Clamp(MGWorkBench_ScrollingHexMap.Classes.Camera.coCameraVector2Location.X - 2, 0, (MGWorkBench_ScrollingHexMap.Structures.Global.ACTUAL_TILE_WIDTH_IN_PIXELS – 14));
             }

             // move right
             if (coKeyboardState.IsKeyDown(Keys.Right))
             {
                 csScrollDirection = "R";
                 ciRowPosition = ciRowPosition + 0;          // maintain current row position
                 ciColumnPosition = ciColumnPosition + 1;    // increase column position by 1

                 MGWorkBench_ScrollingHexMap.Classes.Camera.coCameraVector2Location.X = MathHelper.Clamp(MGWorkBench_ScrollingHexMap.Classes.Camera.coCameraVector2Location.X + 2, 0, (MGWorkBench_ScrollingHexMap.Structures.Global.ACTUAL_TILE_WIDTH_IN_PIXELS + 14));
             }

             // move up
             if (coKeyboardState.IsKeyDown(Keys.Up))
             {
                 csScrollDirection = "U";
                 ciRowPosition = ciRowPosition + 1;          // decrease row position by 1
                 ciColumnPosition = ciColumnPosition + 0;    // maintain current column position by 1

                 MGWorkBench_ScrollingHexMap.Classes.Camera.coCameraVector2Location.Y = MathHelper.Clamp(MGWorkBench_ScrollingHexMap.Classes.Camera.coCameraVector2Location.Y - 2, 0, ((MGWorkBench_ScrollingHexMap.Structures.Global.MAP_TILE_OFFSET_Y * 14) + 14));
             }

             // move down
             if (coKeyboardState.IsKeyDown(Keys.Down))
             {
                 csScrollDirection = "D";
                 ciRowPosition = ciRowPosition - 1;          // increase row position by 1
                 ciColumnPosition = ciColumnPosition + 0;    // maintain current column position by 1

                 MGWorkBench_ScrollingHexMap.Classes.Camera.coCameraVector2Location.Y = MathHelper.Clamp(MGWorkBench_ScrollingHexMap.Classes.Camera.coCameraVector2Location.Y + 2, 0, ((MGWorkBench_ScrollingHexMap.Structures.Global.MAP_TILE_OFFSET_Y * 14) + 14));
             }*/
            //##################END#########################


            // TODO: Add your update logic here
            manager.update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            //playerOrder.draw(spriteBatch, spriteFont);
            //################TUTORIAL#################"
            // set screen background color
            GraphicsDevice.Clear(Color.Black);

            //coTileMap = new MGWorkBench_ScrollingHexMap.Classes.TileMap(coSpriteBatch, coSpriteFont, coGraphicsDeviceManager, coTexture2DTile);
            //coTileMap.Draw_SampleTileMap(csScrollDirection, ciRowPosition, ciColumnPosition);
            // ---

            //###################END###############
            spriteBatch.Begin();
            manager.draw(spriteBatch,graphics);
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

        public int getScreenHeight()
        {
            return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }

        public int getScreenWidth()
        {
            return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        }
    }
}
