using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    public static bool stopMove = false;

    public float moveSpeed;
    Vector2 move; 
    public Rigidbody2D rigid;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        move = new Vector2();
        moveSpeed = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }
    private void FixedUpdate()
    {
        if (!stopMove)
            MovePlayer();
    }

    public void MovePlayer()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        move.Normalize();
        rigid.velocity = move * moveSpeed;
    }

    public void StopPlayer()
    {
        move.x = 0;
        move.y = 0;
        move.Normalize();
        rigid.velocity = Vector2.zero;
    }

    private void UpdateState()
    {
        if (Mathf.Approximately(move.x, 0) && Mathf.Approximately(move.y, 0))
        {
            anim.SetBool("isMove", false);
        }
        else
        {
            //if (!audioSource.isPlaying)
            //{
            //    SoundManager.instance.PlaySound("snowstep");
            //}
            anim.SetBool("isMove", true);
        }
        anim.SetFloat("inputx", move.x);
        anim.SetFloat("inputy", move.y);
    }
}
