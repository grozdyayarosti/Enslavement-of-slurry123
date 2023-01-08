using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy_mushroom : Monster
{    
    private SpriteRenderer sprite2;
    DateTime dateTime;

    protected override void Awake()
    {
        E_Lives = 2; 
        sprite2 = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void OnTriggerEnter2D(Collider2D collider) // Урон по герою и грибу
    {
        Entity entity = collider.gameObject.GetComponent<Entity>();
        if (entity && entity is Hero)
        {
            if (Mathf.Abs(entity.transform.position.x - transform.position.x) < 1.1f)
            {
                E_Lives--;
                Debug.Log("Enemy: " + lives + " hp");
                if (lives < 1)
                    Die();
                //Hero.Instance.AddLives();
            }
            //else entity.GetDamage(); - уже срабатывает автоматически
        }
        Bullet bullet = collider.GetComponent<Bullet>();
        if (bullet)
        {
            E_Lives--;                        
            Debug.Log("Enemy: " + lives + " hp");
            if (E_Lives < 1)
                Die();

            sprite2.color = Color.red;
            //dateTime = DateTime.Now;
            //if ( DateTime.Now == dateTime.AddMinutes(1/60f) ) sprite2.color = Color.white;
        }
    }
}
