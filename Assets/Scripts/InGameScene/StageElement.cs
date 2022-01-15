using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGameScene
{
    public class StageElement : MonoBehaviour
    {
        [SerializeField] private RectTransform enemyContainer;

        private RectTransform rectTransform;
        
        [SerializeField] private bool isInitialize = false;
        public bool IsInitialize {
            get {return isInitialize;}
            set {isInitialize = value;}
        }

        public Vector3 LocalPosition 
        {
            get {return rectTransform.localPosition;}
            set {rectTransform.localPosition = value;}
        }

        public Vector2 AnchoredPosition
        {
            get {return rectTransform.anchoredPosition;}
            set{rectTransform.anchoredPosition = value;}
        }

        public RectTransform EnemyContainer
        {
            get {return enemyContainer;}
        }
        
        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void DestoryEnemys()
        {
            foreach (Transform tr in enemyContainer.transform)
            {
                Destroy(tr.gameObject);
            }
        }
    }
}
