using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour
{
    public GameObject SampleUnit;
    public DynamicJoystick fixJoy;
    public float unitSpeed = 5f;
    Rigidbody2D rgd2d;

    private void Start()
    {
        rgd2d = SampleUnit.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        Vector2 direction = Vector2.up * fixJoy.Vertical + Vector2.right * fixJoy.Horizontal;
        rgd2d.velocity = new Vector2(direction.x * unitSpeed * Time.deltaTime, direction.y * unitSpeed * Time.deltaTime);
    }
}
