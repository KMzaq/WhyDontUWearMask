using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ca_dead : MonoBehaviour
{
    int a = 0;

    public static int mask;
    
    // Update is called once per frame
    private void Start()
    {
        mask = 10;
        
    }
    void Update()
    {
        
        if(a > 30)
        {
            GameObject.Find("GameManeger").GetComponent<maneger>().youdied();
            Destroy(gameObject);
        }
    }

    public void reeset()
    {
        a--;
    }
    public void respawn()
    {
        a++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "shop")
        {
            if(maneger.money >= 200)
            {
                mask += (int)(maneger.money / 200);
                maneger.money = maneger.money % 200;
            }
        }
    }
}
