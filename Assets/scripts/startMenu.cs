using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{
    public Animator transishon;
    public Text score;

    private void Start()
    {
        score.text = PlayerMovement.pointebi.ToString();
        Time.timeScale = 1f;
    }
    public void newlevel()
    {
        StartCoroutine(loadScene(1));
        PlayerMovement.pointebi = 0;
        PlayerMovement.hasMaxAmmo = false;
        Time.timeScale = 1f;
    }
    public void mainmenu()
    {
        StartCoroutine(loadScene(0));
        PlayerMovement.pointebi = 0;
        PlayerMovement.hasMaxAmmo = false;
        Time.timeScale = 1f;
    }

 public  void gatishva()
    {
        Application.Quit();
    }

    IEnumerator loadScene(int levelindex)
    {
        transishon.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelindex);

    }
}
