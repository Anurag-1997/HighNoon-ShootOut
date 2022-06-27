using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_01 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Border" || collision.gameObject.tag == "Player" )
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<PlayerCombat>().Health -= 1;
            if(collision.gameObject.GetComponent<PlayerCombat>().Health <=1)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
