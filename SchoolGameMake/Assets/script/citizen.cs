using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class citizen : MonoBehaviour
{
    float directionx, directiony;
    public float speed;
    float runspeed = 1f;
    float curtime, curtime2 = 0;
    [SerializeField] float movetime;
    [SerializeField] float nomovetime;
    Rigidbody2D rig;
    bool run = false;
    bool timer = false;
    GameObject cra;
    maneger maneger;
    void Start()
    {
        randomdirection();
        rig = gameObject.GetComponent<Rigidbody2D>();
        cra = GameObject.Find("Group_Character");
    }
    void Update()
    {
            curtime += Time.deltaTime;
        if (curtime > movetime)
        {

            directionx = 0;
            directiony = 0;
            curtime2 += Time.deltaTime;
            if (curtime2 > nomovetime)
            {
                curtime = 0;
                curtime2 = 0;
                runspeed = 1;
                randomdirection();
            }
        }
        else
            //transform.Translate(directionx * speed * 0.001f, directiony * speed * 0.001f, 0);
            rig.velocity = new Vector2(directionx * speed * runspeed * 0.9f, directiony * speed * runspeed * 0.9f);
        
    }
    private void ruuuun()
    {
        curtime = 0;
        curtime2 = 0;
        runspeed = 1.05f;
        Vector3 pos = new Vector3(runspeed * (transform.position.x - cra.transform.position.x), runspeed * (transform.position.y - cra.transform.position.y), 0);
        directionx = pos.normalized.x;
        directiony = pos.normalized.y;
    }
    private void randomdirection()
    {
        directionx = Random.Range(-1.0f, 1.0f);
        directiony = Random.Range(-1.0f, 1.0f);
        while (directionx == 0 && directiony == 0)
        {
            directionx = Random.Range(-1.0f, 1.0f);
            directiony = Random.Range(-1.0f, 1.0f);
        }
    }



    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "recognition")
        {
            ruuuun();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "zombie")
        {
            if (Ca_dead.mask >= 1)
            {
                Ca_dead.mask--;
                GameObject.Find("GameManeger").GetComponent<maneger>().spread();
                GameObject.Find("GameManeger").GetComponent<maneger>().inspection();

                //GameObject.Find("GameManeger").GetComponent<maneger>().inspection(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0));
                Destroy(gameObject);
            }
        }
    }

}
