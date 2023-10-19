using System;
using UnityEngine;
using UnityEngine.InputSystem;

// Test script that resets the game when the key R is pressed
namespace Game
{
    public class TestGameLogicScript : MonoBehaviour
    {
        private GameLogicScript _setupScript;

        private void Start()
        {
            // fetch reference to GameSetupScript
            _setupScript = GetComponent<GameLogicScript>();

            if (!_setupScript)
            {
                throw new Exception("TestGameSetupScript: Setup script cannot be null");
            }
        }

        private void Update()
        {
            // if the R key is pressed, then reset the game
            if (!Keyboard.current.rKey.wasPressedThisFrame) return; 
        
            Debug.Log("TestGameResetScript: Reset the game!");
            _setupScript.ResetGame();
        }
    }
}