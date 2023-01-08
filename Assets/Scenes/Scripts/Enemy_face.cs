using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;  

public class Enemy_face : Monster
{
    private float speed = 1.5f;
    private Vector3 dir;
    private SpriteRenderer sprite;    
    //private int lives = 3;

    protected override void Awake()
    {        
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    protected override void Start()
    {
        dir = transform.right;
    }    
    protected override void Update()
    {
        Move();
    }
    //private void OnTriggerEnter2D(Collider2D collider) // Урон по фэйсу и по герою
    //{
    //    Entity entity = collider.gameObject.GetComponent<Entity>();
    //    if (entity && entity is Hero)
    //    {
    //        if (Mathf.Abs(entity.transform.position.x - transform.position.x) < 1.0f)
    //        {
    //            lives--;
    //            Debug.Log("Face: " + lives + " hp");
    //            if (lives < 1)
    //                Die();
    //            Hero.Instance.AddLives();
    //        }
    //        //else entity.GetDamage(); - уже срабатывает автоматически
    //    }        
    //}
    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5f + transform.right * dir.x, 0.01f);
        if (colliders.Length > 0 && colliders.All(x=>!x.GetComponent<Hero>()) && colliders.All(x => !x.GetComponent<Bullet>())) dir *= -1.0f;
        transform.position =
            Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0f;        
    }    
}
