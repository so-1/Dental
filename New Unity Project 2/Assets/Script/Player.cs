using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //変数定義
    public float flap = 10f;
    public float scroll = 1f;
    float direction = 0f;
    Rigidbody2D rb2d;

    private Animator Anim;
   

    bool jump = false;

    // Use this for initialization
    void Start()
    {
        //コンポーネント読み込み
        rb2d = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 temp = gameObject.transform.localScale;

        //キーボード操作
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1f;
            if (temp.x <= 0)
            {
                temp.x *= -1;
                gameObject.transform.localScale = temp;
            }
            Anim.SetBool("RunKey", true);
           
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1f;
            if (temp.x > 0)
            {
                temp.x *= -1;
                gameObject.transform.localScale = temp;
            }
            gameObject.transform.localScale = temp;
            Anim.SetBool("RunKey", true);
        }
        else
        {
            direction = 0f;
            Anim.SetBool("RunKey", false);
        }


        //キャラのy軸のdirection方向にscrollの力をかける
        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);

        //ジャンプ判定
        if (Input.GetKeyDown("space") && !jump)
        {
            rb2d.AddForce(Vector2.up * flap);
            jump = true;
            Anim.SetBool("JumpKey",true);
        }
        else {
            Anim.SetBool("JumpKey", false);
        }
        


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
        if (other.gameObject.CompareTag("Block"))
        {
            jump = false;
        }
    }
}

