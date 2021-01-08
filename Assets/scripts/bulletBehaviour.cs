using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    public int damage;
    public float speed;
    public Rigidbody2D bulletrig;
    PlayerMovement plaer;
    GameObject rame;
   
   

    // Update is called once per frame
    void Update()
    {
        bulletrig.velocity = Vector2.up * speed;
        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.GetComponent<fexebi>().foothurt(damage);

            plaer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

            plaer.plussprint(20f);
            
            Destroy(gameObject,0.1f);
        }
    }
   
}
