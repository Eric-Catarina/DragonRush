using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject element;
    [SerializeField] private float timeToGenerate;
    [SerializeField] private float timeToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        GenerateElement();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateElement()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        yield return new WaitForSeconds(timeToGenerate);
        GenerateElement();
        GameObject newElement = Instantiate(element, transform.position, Quaternion.identity);
        Destroy(newElement, timeToDestroy);
    }
}
