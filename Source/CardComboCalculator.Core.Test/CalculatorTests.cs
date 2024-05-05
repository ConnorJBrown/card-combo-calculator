namespace CardComboCalculator.Core.Test;

public class CalculatorTests
{
    [Test]
    public void CalculatorTest()
    {
        var deckList = new[]
        {
            "Effect Veiler",
            "Effect Veiler",
            "Maxx \"C\"",
            "Maxx \"C\"",
            "Maxx \"C\"",
            "Ash Blossom & Joyous Spring",
            "Ash Blossom & Joyous Spring",
            "Ash Blossom & Joyous Spring",
            "Batteryman Solar",
            "Batteryman Solar",
            "Batteryman Solar",
            "Aloof Lupine",
            "Thunder Dragon",
            "Thunder Dragon",
            "Thunder Dragon",
            "Thunder Dragondark",
            "Thunder Dragondark",
            "Thunder Dragondark",
            "Thunder Dragonhawk",
            "Thunder Dragonroar",
            "Thunder Dragonroar",
            "Bystial Druiswurm",
            "Bystial Magnamhut",
            "Bystial Saronir",
            "Bystial Baldrake",
            "Bystial Baldrake",
            "Bystial Baldrake",
            "The Bystial Lubellion",
            "The Bystial Lubellion",
            "The Bystial Lubellion",
            "Sauravis, the Ancient and Ascended",
            "Gold Sarcophagus",
            "Thunder Dragon Fusion",
            "Foolish Burial",
            "Branded Regained",
            "Called by the Grave",
            "Called by the Grave",
            "Infinite Impermanence",
            "Infinite Impermanence",
            "Infinite Impermanence"
        };

        var handSize = 5;

        var goodCombinations = new List<string[]>
        {
            new[] { "Gold Sarcophagus" },

            new[] { "Batteryman Solar", "Bystial Druiswurm" },
            new[] { "Batteryman Solar", "Bystial Magnamhut" },
            new[] { "Batteryman Solar", "Bystial Saronir" },
            new[] { "Batteryman Solar", "Bystial Baldrake" },
            new[] { "Batteryman Solar", "The Bystial Lubellion" },

            new[] { "Foolish Burial", "Bystial Druiswurm" },
            new[] { "Foolish Burial", "Bystial Magnamhut" },
            new[] { "Foolish Burial", "Bystial Saronir" },
            new[] { "Foolish Burial", "Bystial Baldrake" },
            new[] { "Foolish Burial", "The Bystial Lubellion" },

            new[] { "Batteryman Solar", "Thunder Dragon" },
            new[] { "Batteryman Solar", "Thunder Dragondark" },
            new[] { "Batteryman Solar", "Thunder Dragonhawk" },
            new[] { "Batteryman Solar", "Thunder Dragonroar" },
            new[] { "Batteryman Solar", "Thunder Dragon Fusion" },

            new[] { "Aloof Lupine", "Thunder Dragon" },
            new[] { "Aloof Lupine", "Thunder Dragondark" },
            new[] { "Aloof Lupine", "Thunder Dragonhawk" },
            new[] { "Aloof Lupine", "Thunder Dragonroar" },

            new[] { "Thunder Dragon", "Bystial Druiswurm" },
            new[] { "Thunder Dragon", "Bystial Magnamhut" },
            new[] { "Thunder Dragon", "Bystial Saronir" },
            new[] { "Thunder Dragon", "Bystial Baldrake" },
            new[] { "Thunder Dragon", "The Bystial Lubellion" },

            new[] { "Thunder Dragondark", "Bystial Druiswurm" },
            new[] { "Thunder Dragondark", "Bystial Magnamhut" },
            new[] { "Thunder Dragondark", "Bystial Saronir" },
            new[] { "Thunder Dragondark", "Bystial Baldrake" },
            new[] { "Thunder Dragondark", "The Bystial Lubellion" },

            new[] { "Thunder Dragonhawk", "Thunder Dragon" },
            new[] { "Thunder Dragonhawk", "Thunder Dragondark" },
        };

        var probability = Calculator.Calculate(deckList, handSize, goodCombinations);

        Assert.That(probability, Is.EqualTo(0.747443800075379));
    }
}