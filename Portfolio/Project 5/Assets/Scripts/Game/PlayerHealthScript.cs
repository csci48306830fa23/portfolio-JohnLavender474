using System;
using UnityEngine;

namespace Game
{
    public class PlayerHealthScript : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int currentHealth;
        [SerializeField] private float invincibilityTime;
        private float _currentInvincibilityTime;

        private void Update()
        {
            if (_currentInvincibilityTime > 0f)
            {
                _currentInvincibilityTime -= Time.deltaTime;
            }
        }

        public void SetMaxHealth(int h)
        {
            maxHealth = h;
        }

        public int GetMaxHealth()
        {
            return maxHealth;
        }

        public void SetCurrentHealth(int h)
        {
            if (h < 0)
            {
                h = 0;
            }

            if (h > maxHealth)
            {
                h = maxHealth;
            }

            currentHealth = h;
        }

        public bool Damage(int d)
        {
            if (IsInvincible())
            {
                Debug.Log("PlayerHealthScript: Is invincible so no damage applied");
                return false;
            }

            if (d < 0)
            {
                throw new Exception("Damage cannot be less than zero");
            }

            var priorHealth = currentHealth;
            SetCurrentHealth(currentHealth - d);
            Debug.Log("PlayerHealthScript: prior health = " + priorHealth +
                      ", current health = " + currentHealth);

            _currentInvincibilityTime = invincibilityTime;
            Debug.Log("PlayerHealthScript: Player now invincible for time = "
                      + invincibilityTime);

            return true;
        }

        public bool IsInvincible()
        {
            return _currentInvincibilityTime > 0f;
        }

        public void ResetToMaxHealth()
        {
            Debug.Log("PlayerHealthScript: Reset to max health of " + maxHealth);
            currentHealth = maxHealth;
        }

        public void Kill()
        {
            Debug.Log("PlayerHealthScript: Kill the health");
            currentHealth = 0;
        }

        public bool IsDead()
        {
            return currentHealth == 0;
        }
    }
}