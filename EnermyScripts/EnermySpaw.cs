using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermySpaw : MonoBehaviour
{
    [SerializeField]
    private GameObject Enermy;

    public float min;
    public float max;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spaw());
    }
    IEnumerator Spaw()
    {
        float x = Random.Range(min, max);
        yield return new WaitForSeconds(x);
        Vector3 temp = transform.position;
        temp.y = Random.Range(minY, maxY);
        Instantiate(Enermy, temp, Quaternion.identity);
        StartCoroutine(Spaw());
    }
        // Update is called once per frame
    void Update()
    {
        if (PenguinControl.instance != null)
        {
            if (PenguinControl.instance.flag == 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
