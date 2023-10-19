using System;
using UnityEngine;

namespace Coins
{
    public class PlayerTouchCoinScript : MonoBehaviour
    {
        private PlayerCoinCollectionScript _coinCollection;

        private void Start()
        {
            // coin collection is stored in Game Logic object, fetch reference to it here
            _coinCollection = GameObject.Find("Game Logic")
                .GetComponent<PlayerCoinCollectionScript>();

            // coin collection is NOT optional
            if (!_coinCollection)
            {
                throw new Exception("PlayerTouchCoinScript: Player key collection " +
                                    "cannot be null");
            }

            Debug.Log("PlayerTouchCoinScript: Initialized coin collection");
        }

        private void OnTriggerEnter(Collider other)
        {
            // when the player collides with a coin and the coin is not yet collected, then
            // the coin should be "deposited" and its OnCollected method should be called
            
            var coin = other.gameObject.GetComponent<CoinScript>();
            // if not a coin, then ignore
            if (!coin)
            {
                Debug.Log("PlayerTouchCoinScript: Not a coin that player touched");
                return;
            }

            // if the coin is already collected, then do nothing; this state should not
            // occur since the coin's collider should be switched off when the coin is
            // collected; therefore, this is an error / illegal state
            if (coin.IsCollected())
            {
                Debug.Log("PlayerTouchCoinScript: Touched coin is already collected");
                return;
            }
            
            var oldAmount = _coinCollection.GetAmountOfCoins();
            
            // deposit the coin and call the coin's OnCollected method
            _coinCollection.DepositCoin();
            coin.OnCollected();

            Debug.Log("PlayerTouchCoinScript: Coin deposited; " +
                      "old amount = " + oldAmount + ", new amount = " +
                      _coinCollection.GetAmountOfCoins());
        }
    }
}