using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Obstacles
{
    /// <summary><para>Obstacle Path Script should be added to an abstract game object called "Obstacle Path".
    /// The children of this object should be Node objects named "Node1", "Node2", and so on where the number
    /// indicates the order of the nodes. The nodes are positions of the movement path.</para></summary>
    public class ObstaclePathScript : MonoBehaviour
    {
        private int _currentNode;
        private List<Transform> _nodes;

        public void Init()
        {
            _currentNode = 0;
            _nodes = new List<Transform>();

            foreach (Transform child in transform)
            {
                if (child.gameObject.name.Contains("Node"))
                {
                    _nodes.Add(child);
                }
            }

            _nodes.Sort((t1, t2) =>
                string.Compare(t1.gameObject.name, t2.gameObject.name, StringComparison.Ordinal));

            var sb = new StringBuilder();
            sb
                .Append("ObstaclePathScript: Node positions for ")
                .Append(gameObject.name)
                .Append(": ");
            for (var i = 0; i < _nodes.Count; i++)
            {
                sb.Append(_nodes[i].name);
                if (i != _nodes.Count - 1)
                {
                    sb.Append(", ");
                }
            }
            Debug.Log(sb);
        }

        public void SetToNextNode()
        {
            _currentNode = GetIndexOfNextNode();
        }

        public Transform GetStartNode()
        {
            return _nodes[_currentNode];
        }

        public Transform GetNextNode()
        {
            return _nodes[GetIndexOfNextNode()];
        }

        private int GetIndexOfNextNode()
        {
            var temp = _currentNode + 1;
            if (temp >= _nodes.Count)
            {
                temp = 0;
            }

            return temp;
        }
    }
}