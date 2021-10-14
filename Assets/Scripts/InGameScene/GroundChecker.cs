using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGameScene
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private float offset = 0.07499957f;

        [SerializeField] LayerMask groundMask;
        public float distanceFromGround;

        // Update is called once per frame
        void Update()
        {
            distanceFromGround = CalculateDistanceFromGround();
        }

        private float CalculateDistanceFromGround()
        {
            var distanceFromGround = Physics2D.Raycast (transform.position, Vector3.down, 30, groundMask);
            return distanceFromGround.distance - offset;
        }

        public void SetActive(bool isActive)
        {
            GetComponent<Collider2D>().enabled = isActive;
        }
    }
}
