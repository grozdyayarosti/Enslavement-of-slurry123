using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grib : MonoBehaviour
{
    [SerializeField] private int lives = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
            lives--;
            Debug.Log("Huita " + lives);
        }

        if (lives < 1)
            Destroy(this.gameObject);
    }
}
