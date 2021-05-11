using System.Collections;
using UnityEngine;

public class back : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            {
            Application.Quit();
        }
    }
}
