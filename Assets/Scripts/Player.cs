using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

public class Player : MonoBehaviour
{
    private const int MaxAirJumpNum = 1;

    private int airJumpNum;

    [SerializeField] private Transform shotTr;
    [SerializeField] private Animator anm;
    [SerializeField] private GroundChecker grChk;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private HitChecker hitChk;

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
        rb.velocity = new Vector2(0, 20);
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
                rb.velocity = new Vector2(0, 15);
            }
            else
            {
                SoundManager.Instance.PlayVoice(VoiceType.Jump);
                rb.velocity = new Vector2(0, 18);
            }
            
            SoundManager.Instance.PlaySE(SEType.Jump);
        }
    }

    public void Up()
    {
        ResetJumpNum();
        SoundManager.Instance.PlayVoice(VoiceType.HighJump);
        rb.velocity = new Vector2(0, 25);
    }

    public bool IsOnGround()
    {
        if (grChk.distanceFromGround <= 0.001f && rb.velocity.y <= 0) 
        {
            return true;
        }

        return false;
    }
}
