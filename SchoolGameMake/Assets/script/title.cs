using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using JetBrains.Annotations;
using UnityEngine.UI;

public class title : MonoBehaviour
{
    //public GameObject PauseUI;
    //public bool paused = false;


    //void Start()
    //{
    //    PauseUI.SetActive(false);    
    //}

    //void Update()
    //{
    //    if (Input.GetButtonDown("Puase")) 
    //    {
    //        paused = !paused;
    //    }   
    //    if (paused)
    //    {
    //        PauseUI.SetActive(true);
    //        Time.timeScale = 0;
    //    }
    //    if (paused)
    //    {
    //        PauseUI.SetActive(false);
    //        Time.timeScale = 1f;

    //    }
    //}
    //public void Resume()
    //{
    //    paused = false;
    //}
   
    //public void Restaret()
    //{
    //    SceneManager.LoadScene("Rg_playgamer1");

    //}
    public void MainMenu()
    {
        SceneManager.LoadScene("play");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public Image tutoor;
    public void ontutor()
    {
        tutoor.gameObject.SetActive(true);
    }
    public void offtutor()
    {
        tutoor.gameObject.SetActive(false);
    }
}
