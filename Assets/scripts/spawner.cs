using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public AudioSource spawn;
    public GameObject[] sachmeli;
    public GameObject fexebi;
    public float Xbounds, Ybounds;
    public Transform moe;
    public GameObject startparticle;
    //difficuly
    public float seconds=3f;
    float  timepass=0.0f;
    float difficultyacc=1f;
    float difficultyfex = 0.6f;

    void Start()
    {
        
        StartCoroutine(SpawnRandom());

    }
    

    void Update()
    {
        timepass += Time.deltaTime;
        if (timepass > 10)
        {
            difficultyacc += 0.1f;
            timepass = 0;
            if (difficultyacc >= seconds)
            {
                difficultyacc = seconds;
            }
        }
    }

    IEnumerator SpawnRandom()
    {
        float rangeX = Random.Range(-Xbounds, Xbounds);



        var particle = (GameObject)Instantiate(startparticle,new Vector2(rangeX,Ybounds),Quaternion.identity);

       Destroy(particle, (seconds / difficultyacc) - 0.1f);
         yield return new WaitForSeconds(seconds/difficultyacc);
        int randomFruit = Random.Range(0, sachmeli.Length);
        spawn.Play();
            Instantiate(sachmeli[randomFruit], new Vector2(rangeX, Ybounds), Quaternion.identity);
        if (Random.value < difficultyfex)
        {
            Instantiate(fexebi, new Vector2(moe.position.x - 0.3f, Ybounds), Quaternion.identity);
        }
        StartCoroutine(SpawnRandom());
    }

   

}
