using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uimaneger : MonoBehaviour
{
    public Text UI_mask;
    public Text UI_money;

    public GameObject ending;
    public Text endT;

    public static bool died = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UI_mask.text = ""+Ca_dead.mask;
        UI_money.text = "" + maneger.money;
        if(died == true)
        {
            ending.SetActive(true);
            endT.text = "지킨 사람 : " + maneger.spreadcount + "명";
        }
    }

    public void gohome()
    {
        SceneManager.LoadScene("main");
    }
}
