using UnityEngine;

namespace Coins
{
    public class CoinScript : MonoBehaviour
    {
        private bool _collected;

        public void ResetScript()
        {
            Debug.Log("CoinScript: Reset coin script");
            
            // collected should be false, and renderer and collider enabled
            // when the game starts or is reset / restarted
            // TODO: enable texture rendering
            _collected = false;
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<Collider>().enabled = true;
        }

        public void OnCollected()
        {
            Debug.Log("CoinScript: Coin collected");
            
            // when a coin is collected, it should be flagged as such
            // and the renderer and collider switched off
            // TODO: disable texture rendering 
            _collected = true;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }

        public bool IsCollected()
        {
            return _collected;
        }
    }
}