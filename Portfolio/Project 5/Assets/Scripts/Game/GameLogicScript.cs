using System;
using System.Collections.Generic;
using Coins;
using UnityEngine;

namespace Game
{
    public class GameLogicScript : MonoBehaviour
    {
        private PlayerCoinCollectionScript _coinCollection;
        private List<CoinScript> _coinScripts;
        private PlayerHealthScript _healthScript;
        private Camera _mainCamera;
        private CharacterController _characterController;

        private void Start()
        {
            _mainCamera = Camera.main;
            if (!_mainCamera)
            {
                throw new Exception("GameLogicScript: Failed to fetch main camera");
            }
            
            // fetch reference to main camera
            _characterController = GameObject.Find("XR Origin (XR Rig)").GetComponent<CharacterController>();
            if (!_characterController)
            {
                throw new Exception("GameLogicScript: Failed to fetch XR Origin (XR Rig)");
            }

            // fetch reference to player health script from this (Game Logic) object
            _healthScript = GetComponent<PlayerHealthScript>();
            if (!_healthScript)
            {
                throw new Exception("GameLogicScript: Failed to fetch health script");
            }

            // fetch reference to coin collection script from this (Game Logic) object
            _coinCollection = GetComponent<PlayerCoinCollectionScript>();
            if (!_coinCollection)
            {
                throw new Exception("GameLogicScript: Failed to fetch coin collection script");
            }

            // list of coin scripts is fetched from children of Coins object
            _coinScripts = new List<CoinScript>();
            var coins = GameObject.Find("Coins");
            foreach (Transform child in coins.transform)
            {
                var coinScript = child.gameObject.GetComponent<CoinScript>();
                _coinScripts.Add(coinScript);
            }

            Debug.Log("GameLogicScript: Coin scripts set up; " +
                      "list size = " + _coinScripts.Count);

            // set up by resetting the coin collection and each coin script
            ResetGame();
        }

        private void Update()
        {
            if (_healthScript.IsDead())
            {
                // TODO: Reset game when player dies
            }
        }

        public void ResetGame()
        {
            // reset player position
            _characterController.transform.position = new Vector3(0f, 0f, 0f);

            // reset to max health
            _healthScript.ResetToMaxHealth();

            // reset the coin collection
            _coinCollection.ResetCoins();

            // reset the coin scripts
            foreach (var coinScript in _coinScripts)
            {
                coinScript.ResetScript();
            }

            Debug.Log("GameLogicScript: Reset game");
        }
    }
}