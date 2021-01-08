using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterloader : MonoBehaviour
{
    public GameObject[] characterspref;
    public Transform spawnpoint;
     void Start()
    {
        int selected = PlayerPrefs.GetInt("selected");
        GameObject prefab = characterspref[selected];
        GameObject instantiating = Instantiate(prefab, spawnpoint.position, Quaternion.identity);
       

    }
}
