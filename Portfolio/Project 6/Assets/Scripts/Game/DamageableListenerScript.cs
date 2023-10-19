using System;
using UnityEngine;

namespace Game
{
    public class DamageableListenerScript : MonoBehaviour
    {
        private PlayerHealthScript _health;

        private void Start()
        {
            Debug.Log("DamageableListenerScript: Start");
            _health = GameObject.Find("Game Logic").GetComponent<PlayerHealthScript>();
            if (!_health)
            {
                throw new Exception("DamageableListenerScript: Could not find health script");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.name.Contains("Obstacle"))
            {
                Debug.Log("DamageableListenerScript: Hit a collider but it's not an obstacle");
                return;
            }
            
            if (_health.IsInvincible())
            {
                Debug.Log("DamageableListenerScript: Player hit by obstacle but is invincible");
                return;
            }

            if (_health.Damage(1))
            {
                Debug.Log("DamageableListenerScript: Player took damage from obstacle");
            }
        }

        /*
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (!hit.collider.gameObject.name.Contains("Obstacle")) return;
            
            if (_health.IsInvincible())
            {
                Debug.Log("DamageableListenerScript: Player hit by obstacle but is invincible");
                return;
            }

            if (_health.Damage(1))
            {
                Debug.Log("DamageableListenerScript: Player took damage from obstacle");
            }
        }
        */        
        
    }
}