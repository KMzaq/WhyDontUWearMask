using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maneger : MonoBehaviour
{
    public GameObject grcra;
    public GameObject prefap_cra;
    bool death = false;

    float curtime;
    public static int spreadcount = 0;
    public static int money = 0;

    private void Update()
    {
        if(death == true)
        {
            curtime += Time.deltaTime;
            if (curtime >= 5)
                this.gameObject.SetActive(false);
        }
        print(money);
        print(Ca_dead.mask);
    }

    public void inspection() //Vector3 pos
    {
        //GameObject child = Instantiate(prefap_cra, pos, Quaternion.identity) as GameObject;
        //child.transform.parent = grcra.transform;
        //GameObject.Find("Chracter").GetComponent<SpriteOutline>().reeeset();
        GameObject.Find("Chracter").GetComponent<Ca_dead>().reeset();
    }

    public void spread()
    {
        spreadcount++;
        money += 250;
    }

    public void youdied()
    {
        death = true;
        uimaneger.died = true;
    }
}
