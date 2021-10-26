using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyCiv
{
    //This class controls all the high-level events
    class MainController : ContentListener
    {
        private GameController gameController;

        /// <summary>
        /// Creates a GameController
        /// </summary>
        public MainController(GameController gameController)
        {
            this.setGameController(gameController);
        }

        /// <summary>
        ///  Retrieve the image on given filePath
        /// </summary>
        /// <param name="imageName"> the filePath of the image </param>
        public Texture2D retrieveImage(string imageName)
        {
            return gameController.retrieveImage(imageName);
        }

        /// <summary>
        /// Retrieve the font on given filePath
        /// </summary>
        /// <param name="fontName"> the filePath of the font </param>
        public SpriteFont retrieveFont(string fontName)
        {
            return gameController.retrieveFont(fontName);
        }

        /// <summary>
        /// Sets the gameController
        /// </summary>
        private void setGameController(GameController gameController)
        {
            this.gameController = gameController;
        }
    }
}
