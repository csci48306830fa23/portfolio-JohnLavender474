using System;
using TMPro;
using UnityEngine;

namespace Coins
{
    public class CoinUIScript : MonoBehaviour
    {
        private PlayerCoinCollectionScript _coinCollectionScript;
        [SerializeField] private TMP_Text coinText;

        private void Start()
        {
            if (!coinText)
            {
                throw new Exception("Coin UI Script: Coin text not set");
            }

            var playerObject = GameObject.Find("Game Logic");
            _coinCollectionScript = playerObject.GetComponent<PlayerCoinCollectionScript>();

            if (!_coinCollectionScript)
            {
                throw new Exception("Coin UI Script: Not coin collection script found");
            }
        }

        private void Update()
        {
            coinText.text = "Coins: " + _coinCollectionScript.GetAmountOfCoins();
        }
    }
}