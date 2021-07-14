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

        public MainController(GameController gameController)
        {
            this.setGameController(gameController);
        }

        public Texture2D retrieveImage(string imageName)
        {
            return gameController.retrieveImage(imageName);
        }

        public SpriteFont retrieveFont(string fontName)
        {
            return gameController.retrieveFont(fontName);
        }

        private void setGameController(GameController gameController)
        {
            this.gameController = gameController;
        }
    }
}
