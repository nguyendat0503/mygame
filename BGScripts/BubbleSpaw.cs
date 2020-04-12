using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpaw : MonoBehaviour
{
    [SerializeField]
    private GameObject Bubble;
    public float Delay;
    public float minX;
    public float maxX;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spaw());
    }
    IEnumerator Spaw()
    {
        yield return new WaitForSeconds(Delay);
        Vector3 temp = Bubble.transform.position;
        temp.x = Random.Range(minX, maxX);
        Instantiate(Bubble, temp, Quaternion.identity);
        StartCoroutine(Spaw());
    }
}
