using System;
using UnityEngine;

namespace Obstacles
{
    public class ObstacleMovementScript : MonoBehaviour
    {
        [SerializeField] private GameObject obstaclePath;
        [SerializeField] private float speed;

        private ObstaclePathScript _path;
        private float _timer;
        private bool _go;
        
        public void Stop()
        {
            _go = false;
        }

        public void Go()
        {
            _go = true;
        }

        public void setSpeed(float s)
        {
            if (s < 0)
            {
                throw new Exception("ObstacleMovementScript: ObstaclePath has no path script");
            }
            speed = s;
        }
        
        private void Start()
        {
            if (speed < 0)
            {
                throw new Exception("ObstacleMovementScript: Speed cannot be less than zero");
            }
            
            _path = obstaclePath.GetComponent<ObstaclePathScript>();
            if (!_path)
            {
                throw new Exception("ObstacleMovementScript: ObstaclePath has no path script");
            }

            _path.Init();
            Utils.Set(transform, _path.GetStartNode());
            Go();
        }
        
        private void Update()
        {
            if (!_go) return;

            _timer += Time.deltaTime * speed;
            var start = _path.GetStartNode().position;
            var next = _path.GetNextNode().position;

            transform.position = Vector3.Lerp(start, next, _timer);

            if (transform.position != next) return;

            _timer = 0;
            _path.SetToNextNode();
        }
        
    }
}