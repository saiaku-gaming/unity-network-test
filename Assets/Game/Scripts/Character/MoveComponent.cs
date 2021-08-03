using System;
using UnityEngine;

namespace Game.Scripts.Character
{
    public class MoveComponent : MonoBehaviour
    {
        
        private void Start()
        {
            Debug.Log("SPAWNED MOVER");
        }
        
        public void Move(Vector2 direction)
        {
            gameObject.transform.position += new Vector3(Math.Sign(direction.x), 0, Math.Sign(direction.y));
        }
    }
}