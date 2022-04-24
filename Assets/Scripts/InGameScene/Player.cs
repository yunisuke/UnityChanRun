using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGameScene
{
    public class Player : MonoBehaviour
    {
        private const int MaxAirJumpNum = 1;

        private int airJumpNum;

        [SerializeField] private Transform shotTr;
        [SerializeField] private Animator anm;
        [SerializeField] private GroundChecker grChk;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private HitChecker hitChk;

        // 設置判定許容値。プレイヤーと地面までの距離は完全に0にならない。大きすぎると明らかに地面に接地していないのに接地判定されるので注意
        [SerializeField] private float onGroundOffset = 0.01f;

        void Start()
        {
            anm.SetTrigger("RunTrigger");
            hitChk.OnTriggerEnterEvent += (x) => {};
        }

        void Update()
        {
            anm.SetFloat ("GroundDistance", grChk.distanceFromGround);
            anm.SetFloat ("VelocityY", rb.velocity.y);
            
            if (IsOnGround()) ResetJumpNum();
        }

        private void ResetJumpNum()
        {
                airJumpNum = 0;
        }

        public void DefeatEnemy()
        {
            rb.velocity = new Vector2(0, 13);
            SoundManager.Instance.PlayVoice(VoiceType.Attack);
            airJumpNum = 0;
        }

        public void GameOver()
        {
            // ゲームオーバー演出
            rb.velocity = new Vector2(-4, 10);
            hitChk.SetActive(false);
            grChk.SetActive(false);
            SoundManager.Instance.PlayVoice(VoiceType.Damage);
            anm.SetTrigger("DamageTrigger");
        }

        public void Jump()
        {
            if(airJumpNum < MaxAirJumpNum)
            {
                if (IsOnGround() == false)
                {
                    airJumpNum++;
                    anm.SetTrigger("OneMoreJumpTrigger");
                    SoundManager.Instance.PlayVoice(VoiceType.JumpOneMore);
                    rb.velocity = new Vector2(0, 11);
                }
                else
                {
                    SoundManager.Instance.PlayVoice(VoiceType.Jump);
                    rb.velocity = new Vector2(0, 13);
                }
                
                SoundManager.Instance.PlaySE(SEType.Jump);
            }
        }

        public void Up()
        {
            ResetJumpNum();
            SoundManager.Instance.PlayVoice(VoiceType.HighJump);
            rb.velocity = new Vector2(0, 18);
        }

        public bool IsOnGround()
        {
            if (grChk.distanceFromGround <= onGroundOffset && rb.velocity.y <= 0) 
            {
                return true;
            }

            return false;
        }

        public void AppearGetItemEffect(GameObject effectPrefab)
        {
            StartCoroutine(GetItemEffect(effectPrefab));
        }

        private IEnumerator GetItemEffect(GameObject effectPrefab)
        {
            var obj = Instantiate(effectPrefab);
            obj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
