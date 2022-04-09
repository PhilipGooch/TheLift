using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject personPrefab;

    private List<GameObject>[] people;

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
    }

    private void Update()
    {

    }
}
