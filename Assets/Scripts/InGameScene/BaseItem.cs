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

        void Awake()
        {
            hitChk = GetComponentInChildren<HitChecker>();
            hitChk.OnTriggerEnterEvent += OnTriggerEnterEvent;

            Initialize();
        }

        private void OnTriggerEnterEvent(Collider2D col)
        {
            if (col.tag != "Player") return;
            SoundManager.Instance.PlaySE(hitSe);
            ItemEffect(col);
        }

        protected abstract void ItemEffect(Collider2D col);
        protected virtual void Initialize() {}
    }
}
