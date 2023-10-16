using UnityEngine;

namespace Coins
{
    public class PlayerCoinCollectionScript : MonoBehaviour
    {
        private int _coins;
        private int _maxCoins;

        private void Start()
        {
            Debug.Log("Here");
            _coins = 0;

            var coins = GameObject.Find("Coins");
            foreach (Transform child in coins.transform)
            {
                if (child.gameObject.name == "Coin")
                {
                    _maxCoins++;
                }
            }

            Debug.Log("PlayerCoinCollectionScript: Start with coins = " +
                      _coins + " and max coins = " + _maxCoins);
        }

        public void DepositCoin()
        {
            var oldAmount = _coins;
            
            _coins++;
            if (_coins > _maxCoins)
            {
                _coins = _maxCoins;
            }
            
            Debug.Log("PlayerCoinCollectionScript: Deposited coin; " +
                      "old amount = " + oldAmount + ", new amount = " + _coins);
        }

        public bool TakeCoin()
        {
            if (_coins <= 0)
            {
                Debug.Log("PlayerCoinCollectionScript: Cannot take coin because " +
                          "amount is <= 0; amount = " + _coins);
                return false;
            }

            _coins--;
            if (_coins >= 0) return true;
            
            Debug.Log("PlayerCoinCollectionScript: Amount is less than zero, " +
                      "reset to zero");
            _coins = 0;
            return true;
        }

        public int GetAmountOfCoins()
        {
            return _coins;
        }

        public int GetMaxAmountOfCoins()
        {
            return _maxCoins;
        }

        public void ResetCoins()
        {
            Debug.Log("PlayerCoinCollectionScript: Reset coins");
            _coins = 0;
        }
    }
}