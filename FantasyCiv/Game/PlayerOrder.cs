using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
//Namespace to FantasyCiv every file can retrieve it
namespace FantasyCiv
{
    class PlayerOrder: GameObject
    {
        // Queue of players
        LinkedList<PlayerTurn> order = new LinkedList<PlayerTurn>();

        public PlayerOrder(int x, int y):base(x,y)
        {

        }

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

        public void addPlayer(PlayerTurn turnOfPlayer)
        {
            if (order.First == null)
            {
                turnOfPlayer.setActive(true);
            }
            order.AddLast(turnOfPlayer);
            this.updatePositions();
        }

        public void priorityTurn(PlayerTurn turnOfPlayer)
        {
            order.AddFirst(turnOfPlayer);
        }

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

        public override void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            foreach (GameObject gameObject in order)
            {
                gameObject.draw(spriteBatch, graphics);
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
