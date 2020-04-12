using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpaw : MonoBehaviour
{
    [SerializeField]
    private GameObject Rock;

    public float min;
    public float max;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spaw());
    }

    IEnumerator Spaw()
    {
        float x = Random.Range(min, max);
        yield return new WaitForSeconds(x);
        Instantiate(Rock, transform.position, Quaternion.identity);
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
