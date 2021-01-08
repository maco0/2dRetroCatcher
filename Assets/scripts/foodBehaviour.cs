using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodBehaviour : MonoBehaviour
{
    public int foodpoint;
        public float speed;
    public Rigidbody2D velo;
    public GameObject ded;
    PlayerMovement plaer;
    public GameObject foodsond;
     void Start()
    {
        plaer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerMovement>().sprintreminder < collision.gameObject.GetComponent<PlayerMovement>().sprintmaxdur)
            {
               collision.gameObject.GetComponent<PlayerMovement>().plussprint(5f);
            }
            collision.gameObject.GetComponent<PlayerMovement>().pointDag(foodpoint);
            Destroy(gameObject,0.01f);
            Instantiate(ded, transform.position, transform.rotation);

            
        }
        else if(collision.gameObject.tag == "Ground")
        {
            
            Destroy(gameObject,0.5f);
            plaer.gotHit(10);
           
            StartCoroutine(particles());

        }
    }
    
    void Update()
    {
        velo.velocity = Vector2.down * speed;
    }

    IEnumerator particles()
    { 
        yield return new WaitForSeconds( 0.45f);
     ded=(GameObject) Instantiate(ded, transform.position, transform.rotation);
        foodsond = (GameObject)Instantiate(foodsond, transform.position, transform.rotation);
        Destroy(foodsond, 0.6f);
    }
}
