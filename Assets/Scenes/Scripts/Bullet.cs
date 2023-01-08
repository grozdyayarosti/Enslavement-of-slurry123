using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20f;
    private Vector3 dir;
    public Vector3 Dir { set { dir = value; } }
    private GameObject parent;
    public GameObject Parent { set { parent = value; } }

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        Destroy(gameObject, 0.09f);
    }
    private void Update()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0f;
    }
    //private void OnTriggerEnter2D(Collider2D collider) // Пуля исчезает при касании (для дальнего боя)
    //{
    //    Entity entity = collider.GetComponent<Entity>();
    //    if (entity && entity.gameObject!=parent)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
