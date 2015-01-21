using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsefulStaticMethods;

namespace TicTacToeGame
{
    internal class MiniMax : ISearchBehavior
    {
        private const int MAX_DEPTH = 3;
        
        public Move ComputeBestMove(GameState currentState)
        {
            SearchNode seedNode = new SearchNode(currentState);

            List<SearchNode> daughtersOfSeedNode = seedNode.Expand();

            int bestValueSoFar = -10000000;
            SearchNode bestNode = null;
            foreach (SearchNode child in daughtersOfSeedNode)
            {
                child.value = MiniMaxSearch(child, MAX_DEPTH, child.turn);
                if (child.value > bestValueSoFar)
                {
                    bestValueSoFar = child.value;
                    bestNode = child;
                }
            }

            Move bestMove = RandomizeBestMove(daughtersOfSeedNode, bestNode.value);

            return bestMove;
        }

        private int MiniMaxSearch(SearchNode seedNode, int depth, Player player)
        {
            if ((depth == 0) || (seedNode.IsTerminal()))
                return seedNode.Evaluate();

            if (player.ID == Cell.O)
            {
                return Max(seedNode, depth);
            }
            else
            {
                return Min(seedNode, depth);
            }
        }

        private int Max(SearchNode seedNode, int depth)
        {
            int bestValue = -10000;

            List<SearchNode> daughtersOfSeedNode = seedNode.Expand();

            foreach (SearchNode child in daughtersOfSeedNode)
            {
                child.value = MiniMaxSearch(child, depth - 1, new Player(Cell.X));

                bestValue = (bestValue > child.value) ? bestValue : child.value;
            }
            return bestValue;
        }

        private int Min(SearchNode seedNode, int depth)
        {
            int bestValue = 10000;

            List<SearchNode> daughtersOfSeedNode = seedNode.Expand();

            foreach (SearchNode child in daughtersOfSeedNode)
            {
                child.value = MiniMaxSearch(child, depth - 1, new Player(Cell.O));

                bestValue = (bestValue > child.value) ? child.value : bestValue;
            }
            return bestValue;
        }

        private Move RandomizeBestMove(List<SearchNode> daughtersOfSeedNode, int bestNodeValue)
        {
            List<SearchNode> bestChildren = new List<SearchNode>();

            foreach (SearchNode child in daughtersOfSeedNode)
            {
                if (child.value == bestNodeValue)
                    bestChildren.Add(child);
            }

            Random r = new Random();
            int index = r.Next(0, bestChildren.Count);

            return bestChildren[index].move;
        }
    }
}
