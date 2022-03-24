using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Animator ani;
    bool isGround;
    //血量
    public static int Hp = 1;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame

    public void Jump()
    {
        if(isGround == true)
        {
            rbody.AddForce(Vector2.up * 380);
            AudioManager.Instance.Play("跳");
        }
        
    }
    //产生碰撞
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //如果是地面
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            ani.SetBool("isJump", false);
        }
        {
            if (collision.collider.tag == "Die" && Hp >0)
            {
                Hp = 0;
                //死亡声音
                AudioManager.Instance.Play("Boss死了");
                ani.SetBool("isDie", true);
            }
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        //如果是地面
        if (collision.collider.tag == "Ground")
        {
            isGround = false;
            ani.SetBool("isJump", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            Hp = 0;
            AudioManager.Instance.Play("Boss死了");
            ani.SetBool("isDie", true);
        }
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}
