using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGameScene
{
    public abstract class BaseItem : MonoBehaviour
    {
        [SerializeField] private SEType hitSe;
        private HitChecker hitChk;

        [SerializeField] private bool isEffectPulling = true;
        private bool isPulling = false;

        void Awake()
        {
            hitChk = GetComponentInChildren<HitChecker>();
            hitChk.OnTriggerEnterEvent += OnTriggerEnterEvent;

            Initialize();
        }

        void Update()
        {
            if (isPulling)
            {
                Vector3 vec = (InGameManager.Instance.GetPlayer().transform.position - transform.position).normalized;
                var pos = vec * 0.4f;
                transform.position += pos;
            }
        }

        private void OnTriggerEnterEvent(Collider2D col)
        {
            if (col.tag == "Player")
            {
                SoundManager.Instance.PlaySE(hitSe);
                ItemEffect(col);
            }

            if (col.tag == "PullItem" && isEffectPulling)
            {
                isPulling = true;
            }
        }

        protected abstract void ItemEffect(Collider2D col);
        protected virtual void Initialize() {}
    }
}
