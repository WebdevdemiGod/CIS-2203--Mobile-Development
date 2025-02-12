using System;
using System.Collections.Generic;
using System.Linq;

class Program{
    static List<(string Suit, string Rank)> deck = new List<(string, string)>();
    static Random random = new Random();

    static void Main(string[] args){
        bool exit = false;
        while (!exit){
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create Deck");
            Console.WriteLine("2. Shuffle Deck");
            Console.WriteLine("3. Deal Cards");
            Console.WriteLine("4. Display Deck");
            Console.WriteLine("5. Exit");
            Console.Write("Select an action: ");
            string choice = Console.ReadLine();

            switch (choice){
                case "1":
                    CreateDeck();
                    break;
                case "2":
                    ShuffleDeck();
                    break;
                case "3":
                    DealCards();
                    break;
                case "4":
                    DisplayDeck();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateDeck(){
        deck.Clear();
        string[] suits = { "Cloves", "Diamond", "Heart", "Spade" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Ace", "Jack", "Queen", "King" };

        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                deck.Add((suit, rank));
            }
        }

        Console.WriteLine("Deck created successfully!");
    }

    static void ShuffleDeck(){
        if (deck.Count == 0)
        Console.WriteLine("Error: No deck created.");
        else
        {
            deck = deck.OrderBy(card => random.Next()).ToList();
            Console.WriteLine("Deck shuffled successfully!");
        }
    }

    static void DealCards(){
        if (deck.Count == 0)
        {
            Console.WriteLine("Error: No deck created.");
            return;
        }

        Console.Write("Enter the number of cards to deal: ");
        if (int.TryParse(Console.ReadLine(), out int numCards))
        {
            if (numCards > deck.Count)
            {
                Console.WriteLine("Error: Not enough cards in the deck.");
                return;
            }

            for (int i = 0; i < numCards; i++)
            {
                var card = deck[0];
                deck.RemoveAt(0);
                Console.WriteLine($"Suit: {card.Suit}; Rank: {card.Rank}");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    static void DisplayDeck(){
        if (deck.Count == 0)
        {
            Console.WriteLine("Error: No deck created.");
            return;
        }

        Console.WriteLine($"Cards in the deck ({deck.Count} remaining):");
        foreach (var card in deck)
        {
            Console.WriteLine($"Suit: {card.Suit}; Rank: {card.Rank}");
        }
    }
}