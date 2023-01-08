using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Entity
{
    protected int lives = 3;
    public int E_Lives
    {
        get { return lives; }
        set { lives = value; }        
    }

    protected virtual void Awake() { }
    protected virtual void Start() { }
    protected virtual void Update() { }
    //private SpriteRenderer sprite;


    //public Color color
    //{
    //    set { sprite.color = value; }
    //}

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {      
        Bullet bullet = collider.GetComponent<Bullet>();
        if (bullet)
        {
            lives--;
            Debug.Log("Enemy: " + lives + " hp");
            if (lives < 1)
                Die();            
            //sprite2.color = Color.red;
            //sprite = GetComponentInChildren<SpriteRenderer>();
            //sprite.color = Color.red;
        }
    }
}
