using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public List<Sprite> sprites;

    private int currentFloor;
    private int desiredFloor;
    private int positionInQueue;

    public void Init(int currentFloor, int desiredFloor, int positionInQueue)
    {
        Debug.Log("hi");
        this.currentFloor = currentFloor;
        this.desiredFloor = desiredFloor;
        this.positionInQueue = positionInQueue;
        transform.position = new Vector3(2.5f + positionInQueue, currentFloor + 0.5f, 0);
        GetComponent<SpriteRenderer>().sprite = sprites[desiredFloor];
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
