using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{
    public Text coinText;
    private int coins;
    // Start is called before the first frame update
    void Start()
    {
        coins = 1000;
        UpdateCoinText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateCoinText()
    {
        coinText.text = "Coins: " + coins.ToString(); // Update the UI Text with the current number of coins
    }
    public void AddCoins(int amount)
    {
        coins += amount; // Add the specified amount of coins
        UpdateCoinText(); // Update the UI Text to display the updated number of coins
    }
    public void SpendCoins(int amount)
    {
        if (coins >= amount) // Check if the player has enough coins to spend
        {
            coins -= amount; // Subtract the spent coins from the total
            UpdateCoinText(); // Update the UI Text to display the updated number of coins
            // Perform tower purchase or upgrade here
        }
        else
        {
            Debug.Log("Not enough coins!"); // Display a message if the player doesn't have enough coins
        }
    }
}
