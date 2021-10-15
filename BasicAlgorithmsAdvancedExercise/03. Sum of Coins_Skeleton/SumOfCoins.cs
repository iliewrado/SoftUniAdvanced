using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        int[] availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        int targetSum = 923;

        Dictionary<int, int> selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        // TODO: Implement the method
        List<int> orderedCoins = coins.OrderByDescending(x => x).ToList();
        Dictionary<int, int> choosenCoins = new Dictionary<int, int>();
        int currentSum = 0;
        for (int i = 0; i < orderedCoins.Count; i++)
        {
            int currentCoin = orderedCoins[i];
            if (currentSum + currentCoin > targetSum)
            {
                continue;
            }
            int coinAmount = (targetSum - currentSum) / currentCoin;
            currentSum += coinAmount * currentCoin;
            choosenCoins.Add(currentCoin, coinAmount);
            if (currentSum == targetSum)
            {
                break;
            }
        }
        if (currentSum != targetSum)
        {
            throw new InvalidOperationException("Error");
        }
        return choosenCoins;
    }
}