using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Entity entity = collider.gameObject.GetComponent<Entity>();
        if (entity && entity is Hero)
        {
            Debug.Log(entity);
            entity.GetDamage();
        }
    }
}
