using System.Collections.Generic;
using System.Linq;

namespace GameStore.Domain.Entities
{
    public class CartLine
    {
        public Game Game { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        private List<CartLine> lineCollections = new List<CartLine>();

        public void AddItem(Game game, int quantity)
        {
            CartLine line = lineCollections
                .Where(z => z.Game.GameId == game.GameId)
                .FirstOrDefault();

            if (line == null)
                lineCollections.Add(new CartLine
                {
                    Game = game,
                    Quantity = quantity
                });
            else
                line.Quantity += quantity;
        }

        public void RemoveLine(Game game)
        {
            lineCollections.RemoveAll(z => z.Game.GameId == game.GameId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollections.Sum(z => z.Game.Price * z.Quantity);
        }
        
        public void Clear()
        {
            lineCollections.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollections; }
        }
    }
}