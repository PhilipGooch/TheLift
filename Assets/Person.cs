using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public List<Sprite> sprites;

    private int currentFloor;
    public int desiredFloor;
    private int positionInQueue;

    public void Init(int currentFloor, int desiredFloor, int positionInQueue)
    {
        this.currentFloor = currentFloor;
        this.desiredFloor = desiredFloor;
        this.positionInQueue = positionInQueue;
        transform.position = new Vector3(2.5f + positionInQueue, currentFloor + 0.5f, 0);
        GetComponent<SpriteRenderer>().sprite = sprites[desiredFloor];
    }

    public void Resolve(int targetPositionInQueue, float timer)
    {
        float x;
        // if getting on lift
        if (targetPositionInQueue == -1)
            x = Mathf.Lerp(2.5f + positionInQueue, 0, timer);
        else
            x = Mathf.Lerp(2.5f + positionInQueue, 2.5f + targetPositionInQueue, timer);
        float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
        if (timer >= 1.0f)
        {
            positionInQueue--;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
