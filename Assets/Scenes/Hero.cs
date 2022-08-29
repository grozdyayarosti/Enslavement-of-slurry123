using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 3;
    [SerializeField] private float jumpForce = 0.01f;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public bool isGrounded = false;
    //private Animator animator;

    public static Hero Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Run()
    {
        //if (isGrounded) { State = States.HeroRunAnimation; }

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0f;
    }

    private void Update()
    {
        //if (isGrounded) { State = States.HeroAnimation0; }
        //if (!isGrounded) { State = States.HeroJumpAnimation; }
        if (Input.GetButton("Horizontal")) { Run(); }
        if (isGrounded && Input.GetButtonDown("Jump")) { Jump(); }
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter2D()
    {
        isGrounded = true;
    }

    public void GetDamage()
    {
        lives -= 1;
        Debug.Log(lives);
    }

    //private States State
    //{
    //    get { return (States)animator.GetInteger("state"); }
    //    set { animator.SetInteger("state", (int)value); }
    //}
}

//public enum States
//{
//    HeroAnimation0,
//    HeroRunAnimation,
//    HeroJumpAnimation
//}
