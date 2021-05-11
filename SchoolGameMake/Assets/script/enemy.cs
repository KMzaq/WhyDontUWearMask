using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    float directionx, directiony;
    float speed = 5;
    float runspeed = 1f;
    float curtime, curtime2, curtime3 = 0;
    [SerializeField] float movetime;
    [SerializeField] float nomovetime;
    float lifetime = 20;
    Rigidbody2D rig;
    bool run = false;
    bool timer = false;
    GameObject cra;
    void Start()
    {
        randomdirection();
        rig = gameObject.GetComponent<Rigidbody2D>();
        cra = GameObject.Find("Group_Character");
    }
    void Update()
    {
        curtime3 += Time.deltaTime;
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

        if (curtime3 > lifetime) Destroy(gameObject);
    }
    private void chase()
    {
        curtime = 0;
        curtime2 = 0;
        runspeed = 1.06f;
        Vector3 pos = new Vector3(runspeed * (cra.transform.position.x - transform.position.x), runspeed * (cra.transform.position.y - transform.position.y), 0);
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
            chase();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "zombie")
        {
            GameObject.Find("GameManeger").GetComponent<maneger>().youdied();
            Destroy(other.transform.parent.gameObject);
        }
    }
}
