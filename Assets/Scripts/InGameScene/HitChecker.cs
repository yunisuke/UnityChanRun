using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGameScene
{
    public class HitChecker : MonoBehaviour
    {
        public delegate void HitEventHandler(Collider2D col);
        public event HitEventHandler OnTriggerEnterEvent;

        void OnTriggerEnter2D(Collider2D col)
        {
            OnTriggerEnterEvent(col);
        }

        public void SetActive(bool isActive)
        {
            GetComponent<Collider2D>().enabled = isActive;
        }
    }
}
