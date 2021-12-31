using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGameScene
{
    public class StageElement : MonoBehaviour
    {
        [SerializeField] private RectTransform enemyContainer;

        private RectTransform rectTransform;

        public Vector3 LocalPosition 
        {
            get {return rectTransform.localPosition;}
            set {rectTransform.localPosition = value;}
        }

        public RectTransform EnemyContainer
        {
            get {return enemyContainer;}
        }
        
        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            // rb = GetComponent<Rigidbody2D>();
        }

        public void ClearEnemys()
        {
            foreach (Transform tr in enemyContainer.transform)
            {
                Destroy(tr.gameObject);
            }
        }
    }
}
