using System;
using UnityEngine;

namespace Character
{
    public class MoveComponent : MonoBehaviour
    {
        public void Move(Vector2 direction)
        {
            gameObject.transform.position += new Vector3(Math.Sign(direction.x), 0, Math.Sign(direction.y));
        }
    }
}