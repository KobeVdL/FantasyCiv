using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
//Namespace to FantasyCiv every file can retrieve it
namespace FantasyCiv
{
    /// <summary>
    /// The playerOrder of the civ game, lets players see which player is currently playing and which player is next
    /// </summary>
    class PlayerOrder: GameObject
    {
        // Queue of players
        LinkedList<PlayerTurn> order = new LinkedList<PlayerTurn>();

        public PlayerOrder(int x, int y):base(x,y)
        {

        }

        /// <summary>
        /// Put the next player on front and the current layer last in the queue
        /// </summary>
        public void nextPlayer()
        {
            if (order.First != null)
            {
                PlayerTurn playersTurn = order.First.Value;
                order.RemoveFirst();
                order.AddLast(playersTurn); // adds turn to the back
                this.updatePositions();
                playersTurn.passTurn();
                order.First.Value.execute();
            }
            else
            {
                throw new NullReferenceException("No players included");
            }
        }

        /// <summary>
        /// Adds a player to the player order at the back of the list
        /// </summary>
        public void addPlayer(PlayerTurn turnOfPlayer)
        {
            if (order.First == null)
            {
                turnOfPlayer.setActive(true);
            }
            order.AddLast(turnOfPlayer);
            this.updatePositions();
        }

        /// <summary>
        /// Adds a new player to the player order but adds it to the front of the turn order (could be used for special events)
        /// </summary>
        public void priorityTurn(PlayerTurn turnOfPlayer)
        {
            order.AddFirst(turnOfPlayer);
            this.updatePositions();
        }

        /// <summary>
        /// Updates the positions of all player orders
        /// </summary>
        private void updatePositions()
        {
            int offset = 0;
            foreach (PlayerTurn turn in order)
            {
                turn.setX(offset);
                offset += turn.getWidth() + 10;
            }
        }

        public override int getWidth()
        {
            PlayerTurn turn = order.Last.Value;
            return (int) turn.getPosition().X + turn.getWidth(); //TODO ik weet niet of we float of int moeten gebruiken
        }

        public override int getHeight()
        {
            PlayerTurn turn = order.Last.Value;
            return (int)turn.getPosition().Y + turn.getHeight(); //TODO ik weet niet of we float of int moeten gebruiken
        }

        public override void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics,int x, int y)
        {
            Color boxColor = Color.Green;
            Vector2 absPosition = this.getAbsolutePosition(x, y);
            Texture2D rect = new Texture2D(graphics.GraphicsDevice, 1, 1);
            rect.SetData(new[] { Color.White });
            spriteBatch.Draw(rect, new Rectangle((int)absPosition.X, (int)absPosition.Y, this.getWidth(), this.getHeight()), boxColor);

            foreach (GameObject gameObject in order)
            {
                gameObject.draw(spriteBatch, graphics, x + this.getX(), y + this.getY());
            }
        }

        public override void load()
        {
            foreach (GameObject gameObject in order)
            {
                gameObject.load();
            }
        }

    }
}
