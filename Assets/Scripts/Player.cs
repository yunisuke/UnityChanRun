using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private int airJumpNum;
    private int count;

    [SerializeField] LayerMask groundMask;
    [SerializeField] GroundChecker groundChecker;
    [SerializeField] private Transform shotTr;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator> ();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsClickJumpButton() && airJumpNum < 1)
        {
            if (IsOnGround() == false)
            {
                airJumpNum++;
            }
            rb.velocity = new Vector2(0, 20);
            SoundManager.Instance.PlaySE(SEType.Jump);
        }

        // 接地したら再ジャンプ可能にする
        if (IsOnGround())
        {
            count = 0;
            airJumpNum = 0;
        }
		
		// update animator parameters
		animator.SetFloat ("GroundDistance", groundChecker.distanceFromGround);
        animator.SetFloat("FallSpeed", rb.velocity.y);

        if (IsClickRightButton())
        {
            transform.position = new Vector2(transform.position.x + 0.1f, transform.position.y);
        }

        if (IsClickLeftButton())
        {
            transform.position = new Vector2(transform.position.x - 0.07f, transform.position.y);
        }

        if (IsClickAttackButton())
        {
            animator.SetTrigger("Attack");
        }

        isJump = false;
        isAttack = false;
    }

    private bool IsOnGround()
    {
        if (groundChecker.distanceFromGround <= 0.001f && rb.velocity.y <= 0) 
        {
            return true;
        }

        return false;
    }

    public bool IsClickAttackButton()
    {
        // ボタン操作
        if (isAttack) return true;

        // キーボード操作
        if (Input.GetKeyDown(KeyCode.Z)) return true;

        return false;
    }

    public bool IsClickJumpButton()
    {
        // ボタン操作
        if (isJump) return true;

        // キーボード操作
        if (Input.GetKeyDown(KeyCode.Space)) return true;

        return false;
    }

    public bool IsClickRightButton()
    {
        // ボタン操作
        if (isRight) return true;

        // キーボード操作
        if (Input.GetKey(KeyCode.RightArrow)) return true;

        return false;
    }

    public bool IsClickLeftButton()
    {
        // ボタン操作
        if (isLeft) return true;

        // キーボード操作
        if (Input.GetKey(KeyCode.LeftArrow)) return true;

        return false;
    }

    bool isRight;
    bool isLeft;
    bool isJump;
    bool isAttack;
    public void OnPointerDownRightkButton()
    {
        isRight = true;
    }

    public void OnPointerUpRightButton()
    {
        isRight = false;
    }

    public void OnPointerDownLeftButton()
    {
        isLeft = true;
    }

    public void OnPointerUpLeftButton()
    {
        isLeft = false;
    }

    public void OnClickJumpButton()
    {
        isJump = true;
    }

    public void OnClickAttackButton()
    {
        isAttack = true;
    }

    [SerializeField] private GameObject bulletPrefab;
    public void Attack()
    {
        SoundManager.Instance.PlaySE(SEType.Shot);
        Instantiate(bulletPrefab, shotTr.position, Quaternion.identity);
    }
}
