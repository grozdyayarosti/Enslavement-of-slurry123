using UnityEngine;

public class DieSpace : MonoBehaviour
{
    public GameObject respawn;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Hero hero = collider.gameObject.GetComponent<Hero>();
        if (hero)
        {
            hero.Lives--;
            hero.transform.position = respawn.transform.position;
            if (hero.Lives <= 0)
            {                
                hero.Lives = 5;
            }
        }
    }    
}
