using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject element, elementContainer;
    [SerializeField] private float timeToGenerate;
    [SerializeField] private float timeToDestroy;
    [SerializeField]
    private float minimumXPosition, maximumXPosition;
    private float timer = 0;

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToGenerate)
        {
            timer = 0;
            Generate();
        }
    }

    public void Generate()
    {
        float randomXPosition = Random.Range(minimumXPosition, maximumXPosition);
        randomXPosition = randomXPosition + transform.position.x;
        Vector3 position = new Vector3(randomXPosition, transform.position.y, transform.position.z);
        GameObject newElement =  Instantiate(element, position, Quaternion.identity);
        newElement.transform.parent = elementContainer.transform;
        Destroy(newElement, timeToDestroy);
    }


}
