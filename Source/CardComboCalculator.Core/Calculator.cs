using Combinatorics.Collections;

namespace CardComboCalculator.Core
{
    public static class Calculator
    {
        public static double Calculate(string[] deck, int handSize, List<string[]> goodCombinations)
        {
            var deckCardCount = deck.GroupBy(l => l).ToDictionary(grp => grp.Key, grp => grp.Count());
            var uniqueCards = deckCardCount.Keys.ToList();
            Dictionary<string, byte> deckListIds = new Dictionary<string, byte>();
            for (byte cardId = 0; cardId < uniqueCards.Count; cardId++)
            {
                deckListIds[uniqueCards[cardId]] = cardId;
            }

            var byteDeck = deck.Select(card => deckListIds[card]).ToArray();
            var byteGoodCombinations =
                goodCombinations.Select(combo => combo.Select(card => deckListIds[card]).ToArray()).ToList();
            return Calculate(byteDeck, handSize, byteGoodCombinations);
        }

        public static double Calculate(byte[] deck, int handSize, List<byte[]> goodCombinations)
        {
            var goodCards = goodCombinations.SelectMany(i => i).Distinct().ToList();
            var goodCardsInDeck = deck.Where(goodCards.Contains).ToList();
            var numberOfBadCardsInDeck = deck.Length - goodCardsInDeck.Count;

            var combinations = Combinations(goodCardsInDeck, handSize).ToList();

            var allGoodHandCombinations = combinations.Where(hand => IsHandGood(hand, goodCombinations))
                .GroupBy(hand => hand.Count)
                .ToDictionary(group => group.Key, group => (uint)group.Count());

            ulong comboCount = 0;
            foreach (var item in allGoodHandCombinations)
            {
                var numberOfGoodCardsInHand = item.Key;
                var numberOfHandsWithThisAmountOfGoodCards = item.Value;
                comboCount += MathExtras.NChooseK(numberOfBadCardsInDeck, handSize - numberOfGoodCardsInHand) * numberOfHandsWithThisAmountOfGoodCards;
            }

            var totalNumberOfOutcomes = MathExtras.NChooseK(deck.Length, handSize);

            return (double)comboCount / totalNumberOfOutcomes;
        }

        private static bool IsHandGood<T>(IEnumerable<T> hand, IEnumerable<T[]> goodCombinations)
        {
            var i = 0;
            foreach (var goodCombination in goodCombinations)
            {
                if (hand.ContainsAllItems(goodCombination))
                {
                    return true;
                }
            }

            return false;
        }

        public static IEnumerable<IReadOnlyList<T>> Combinations<T>(ICollection<T> source, int maxSize)
        {
            for (int i = 1; i <= maxSize; i++)
            {
                var c = new Combinations<T>(source, i, GenerateOption.WithoutRepetition);
                foreach (var combination in c)
                {
                    yield return combination;
                }
            }
        }
    }
}
