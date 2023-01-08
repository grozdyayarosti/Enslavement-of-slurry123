using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) // ѕри касании существа - герой тер€ет жизни
    {
        Hero hero = collider.gameObject.GetComponent<Hero>();
        if (hero && hero.Lives<5)
        {
            hero.Lives++;            
            Destroy(gameObject);
        }
    }
}
