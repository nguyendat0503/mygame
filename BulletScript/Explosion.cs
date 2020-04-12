using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float Scale;
    public float MinScale;
    public float MaxScale;
    void Awake()
    {
        Scale = Random.Range(MinScale, MaxScale);
        transform.localScale = new Vector3(Scale, Scale, 0);
        Destroy(gameObject, 1.3f);
    }   
}
