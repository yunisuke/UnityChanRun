using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGameScene
{
    public class Stage : MonoBehaviour
    {
        [SerializeField] private StageElement[] stageElements;
        [SerializeField] private Transform pos;

        [SerializeField] private GameObject coins;
        [SerializeField] private GameObject enemys;
        private float stageOffset;

        [SerializeField] private bool isBackground = false;
        private float speed;

        void Awake()
        {
            var tmp = stageElements[0];
            stageOffset = stageElements.Length * tmp.gameObject.GetComponent<RectTransform>().sizeDelta.x;
        }

        void FixedUpdate()
        {
            MoveStage();
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        private void MoveStage()
        {
            for(int i=0; i<stageElements.Length; i++)
            {
                var el = stageElements[i];
                el.LocalPosition = new Vector2(el.LocalPosition.x - speed, el.LocalPosition.y);
                if (el.LocalPosition.x < -40) {
                    el.LocalPosition = new Vector2(el.LocalPosition.x + stageOffset, el.LocalPosition.y);
                    if (isBackground == false) InstantiateObject(el);
                }
            }
        }

        private void InstantiateObject(StageElement el)
        {
            el.ClearEnemys();

            Instantiate(enemys, el.EnemyContainer);
        }
    }
}
