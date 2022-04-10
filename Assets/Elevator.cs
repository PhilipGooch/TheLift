using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject personPrefab;

    private List<GameObject>[] people;

    private List<GameObject> elevatorPeople = new List<GameObject>();

    public int currentFloor = 0;
    public int desiredFloor = 5;

    public float timer = 0.0f;

    public enum STATE
    {
        MOVING,
        BOARDING,
        EXITING
    }

    public STATE state = STATE.MOVING;


    private void Start()
    {
        people = new List<GameObject>[7];
        for (int i = 0; i < 7; i++)
        {
            people[i] = new List<GameObject>();
        }
        for (int i = 0; i < 3; i++)
        {
            people[2].Add(Instantiate(personPrefab));
            people[2][i].GetComponent<Person>().Init(2, 5, i);
        }


        //OpenDoor();
    }

    private void Update()
    {
        switch(state)
        {
            case STATE.MOVING:
            {
                int direction = desiredFloor > currentFloor ? 1 : -1;
                // if still moving
                if (!Move(direction))
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    timer = 0.0f;
                    currentFloor = currentFloor + direction;
                    if(currentFloor == desiredFloor)
                    {
                        state = STATE.BOARDING;
                        desiredFloor = 5;
                    }
                }
                break;
            }
            case STATE.BOARDING:
            {
                // if people are still getting on 
                if (!OpenDoor())
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    timer = 0.0f;
                    state = STATE.MOVING;
                }
                break;
            }
            case STATE.EXITING:

                break;
        }


    }

    private bool Move(int direction)
    {
        float x = transform.position.x;
        float y = Mathf.Lerp(currentFloor, currentFloor + direction, timer);
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);

        return timer >= 1.0f;
    }

    private bool OpenDoor()
    {
        
        // find index of first person going to desired floor
        int index = 0;
        for( ; index < people[currentFloor].Count; index++)
        {
            if (people[currentFloor][index].GetComponent<Person>().desiredFloor == desiredFloor) break;
        }
        if (index == people[currentFloor].Count)
        {
            timer = 0;
            return true;
        }


        // move this guy onto elevator
        people[currentFloor][index].GetComponent<Person>().Resolve(-1, timer);

        // move the guys after this dude one step forward in the queue
        for (int i = index; i < people[currentFloor].Count; i++)
            people[currentFloor][i].GetComponent<Person>().Resolve(i - 1, timer);

        if(timer >= 1.0f)
        {
            elevatorPeople.Add(people[currentFloor][index]);
            people[currentFloor].RemoveAt(index);
            timer = 0;
        }

        
        return timer >= 1.0f;
    }
}
