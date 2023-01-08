using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Entity
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private int lives;
    public GameObject respawn;
    public int Lives
    {
        get { return lives; }
        set
        {
            if (value <= 5) lives = value;
            livesBar.Refresh();
        }
    }
    private LivesBar livesBar;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public bool isGrounded = false;
    //private Animator animator;
    private Bullet bullet;

    public static Hero Instance { get; set; }

    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>();
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet");
    }

    private void Run()
    {
        //if (isGrounded) { State = States.HeroRunAnimation; }

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = 
            Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0f;
    }

    private void Update()
    {
        //if (isGrounded) { State = States.HeroAnimation0; }
        //if (!isGrounded) { State = States.HeroJumpAnimation; }
        if (Input.GetButtonDown("Fire1"))  Shoot(); 
        if (Input.GetButton("Horizontal")) Run(); 
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }
    private void Shoot()
    {
        Vector3 position = transform.position;  position.y += 1.0f;
        Bullet newBullet = 
            Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
        //newBullet.Parent = gameObject; // Для исчезания пули
        newBullet.Dir =
            newBullet.transform.right * (sprite.flipX ? -1.0f : 1.0f);
    }

    private void OnCollisionEnter2D()
    {
        isGrounded = true;
    }
    public override void GetDamage()
    {
        Lives--;
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.up * 20.0f, ForceMode2D.Impulse);
        Debug.Log("Hero: " + lives + " hp");
        if (Lives <= 0)
        {
            transform.position = respawn.transform.position;
            Lives = 5;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider) // При касании существа - герой теряет жизни
    {
        Entity entity = collider.gameObject.GetComponent<Entity>();
        if (entity)
        {
            Debug.Log(entity);
            GetDamage();
        }
    }
    public void AddLives()
    {
        Lives++;
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
