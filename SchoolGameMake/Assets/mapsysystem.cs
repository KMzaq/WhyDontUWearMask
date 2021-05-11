using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapsysystem : MonoBehaviour
{
    [SerializeField]
    private GameObject map;
    [SerializeField]
    private int mapsize;
    [SerializeField]
    private GameObject moumzip;
    void Start()
    {
        mapsize = 60;
        createmap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //0좌표의 1개 밑으로 갈수록 1개씩 추가
    private void createmap()
    {
        int a = 0;
        int b = (int)(mapsize * 0.5f);
        Vector2 tilesize = new Vector2(10.06f, 3.57f);
        Vector2 pos = new Vector2(5.03f, tilesize.y * mapsize * 0.5f);


        for (int y = 0; y < mapsize; y++)
        {
            a++;
            if (a <= mapsize * 0.5f)
            {

                pos.x -= tilesize.x * 0.5f;
                for (int x = 0; x < a; x++)
                {

                    GameObject newTile = Instantiate(map);
                    newTile.transform.parent = moumzip.transform;
                    newTile.transform.position = new Vector3(pos.x + tilesize.x * x, pos.y + tilesize.y * -y, 0);
                }
                
            }

            if(a > mapsize * 0.5f)
            {
                print(pos.x);
                
                pos.x += tilesize.x * 0.5f;
                for (int x = 0; x < b-1; x++)
                {
                    print(pos.x);
                    GameObject newTile = Instantiate(map);
                    newTile.transform.parent = moumzip.transform;
                    newTile.transform.position = new Vector3(pos.x + tilesize.x * x, pos.y + tilesize.y * -y, 0);
                }
                
                b--;
            }
        }


        

    }

}
