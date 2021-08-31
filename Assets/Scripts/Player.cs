using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int airJumpNum;
    private int count;

    [SerializeField] private Transform shotTr;
    [SerializeField] private Animator anm;
    [SerializeField] private GroundChecker grChk;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private HitChecker hitChk;

    void Start()
    {
        anm.SetTrigger("RunTrigger");
        hitChk.OnTriggerEnterEvent += OnTriggerEnterEvent;
    }

    private void OnTriggerEnterEvent(Collider2D col)
    {
        var tag = col.transform.parent.gameObject.tag;
        switch(tag)
        {
            case "Enemy":
                EnemyCollisionEvent(col);
                break;
            default:
                break;
        }
    }

    private void EnemyCollisionEvent(Collider2D col)
    {
        if (IsOnGround() == false)
        {
            rb.velocity = new Vector2(0, 20);
            SoundManager.Instance.PlaySE(SEType.Attack);
            var en = col.GetComponentInParent<Enemy>();
            en.ItemEffect();
            return;
        }
        anm.SetTrigger("DamageTrigger");
    }

    void Update()
    {
        if (IsClickJumpButton() && airJumpNum < 1)
        {
            if (IsOnGround() == false)
            {
                airJumpNum++;
                SoundManager.Instance.PlayVoice(VoiceType.JumpOneMore);
                rb.velocity = new Vector2(0, 17);
            }
            else
            {
                SoundManager.Instance.PlayVoice(VoiceType.Jump);
                rb.velocity = new Vector2(0, 20);
            }
            
            SoundManager.Instance.PlaySE(SEType.Jump);
        }

        // 接地したら再ジャンプ可能にする
        if (IsOnGround())
        {
            count = 0;
            airJumpNum = 0;
        }

		anm.SetFloat ("GroundDistance", grChk.distanceFromGround);
        anm.SetFloat ("VelocityY", rb.velocity.y);

        isJump = false;

        // if (IsClickRightButton())
        // {
        //     transform.position = new Vector2(transform.position.x + 0.1f, transform.position.y);
        // }

        // if (IsClickLeftButton())
        // {
        //     transform.position = new Vector2(transform.position.x - 0.07f, transform.position.y);
        // }

        // if (IsClickAttackButton())
        // {
        //     anm.SetTrigger("Attack");
        // }

        // isAttack = false;
    }

    protected bool IsOnGround()
    {
        if (grChk.distanceFromGround <= 0.001f && rb.velocity.y <= 0) 
        {
            return true;
        }

        return false;
    }

    // public bool IsClickAttackButton()
    // {
    //     // ボタン操作
    //     if (isAttack) return true;

    //     // キーボード操作
    //     if (Input.GetKeyDown(KeyCode.Z)) return true;

    //     return false;
    // }

    public bool IsClickJumpButton()
    {
        // ボタン操作
        if (isJump) return true;

        // キーボード操作
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) return true;

        return false;
    }

    // public bool IsClickRightButton()
    // {
    //     // ボタン操作
    //     if (isRight) return true;

    //     // キーボード操作
    //     if (Input.GetKey(KeyCode.RightArrow)) return true;

    //     return false;
    // }

    // public bool IsClickLeftButton()
    // {
    //     // ボタン操作
    //     if (isLeft) return true;

    //     // キーボード操作
    //     if (Input.GetKey(KeyCode.LeftArrow)) return true;

    //     return false;
    // }

    // bool isRight;
    // bool isLeft;
    bool isJump;
    // bool isAttack;
    // public void OnPointerDownRightkButton()
    // {
    //     isRight = true;
    // }

    // public void OnPointerUpRightButton()
    // {
    //     isRight = false;
    // }

    // public void OnPointerDownLeftButton()
    // {
    //     isLeft = true;
    // }

    // public void OnPointerUpLeftButton()
    // {
    //     isLeft = false;
    // }

    public void OnClickJumpButton()
    {
        isJump = true;
    }

    // public void OnClickAttackButton()
    // {
    //     isAttack = true;
    // }

    // [SerializeField] private GameObject bulletPrefab;
    // public void Attack()
    // {
    //     SoundManager.Instance.PlaySE(SEType.Shot);
    //     Instantiate(bulletPrefab, shotTr.position, Quaternion.identity);
    // }
}
