using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class charachterselector : MonoBehaviour
{
    public Animator transishon;
    public GameObject[] characters;
    public int selected = 0;
    public void Nextcharacter()
    {
        characters[selected].SetActive(false);
        selected = (selected + 1) % characters.Length;
        characters[selected].SetActive(true);
    }
    public void previous()
    {
        characters[selected].SetActive(false);
        selected--;
        if (selected < 0)
        {
            selected += characters.Length;
        }
        characters[selected].SetActive(true);
    }

    public void startgame()
    {
        PlayerPrefs.SetInt("selected", selected);
        StartCoroutine(loadScene(1));
        PlayerMovement.hasMaxAmmo = false;
    }


    public void quit()
    {
        Application.Quit();
    }


    IEnumerator loadScene(int levelindex)
    {
        pausingscript.isloaded = false;
        transishon.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        pausingscript.isloaded = true;
        SceneManager.LoadScene(levelindex, LoadSceneMode.Single);

    }
}
