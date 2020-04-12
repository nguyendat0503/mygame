using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public float x;
    void Update()
    {
        transform.localScale =new Vector3(0.15f * PenguinControl.instance.HP,1, 0);
        transform.position = new Vector3(-7f+PenguinControl.instance.HP*x, 4.5f, 0);
        if(PenguinControl.instance.HP < 1)
        {
            Destroy(gameObject);
        }
    }
}
