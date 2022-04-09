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
        for (int i = 0; i < 3; i++)
        {
            GameObject person = Instantiate(personPrefab);
            person.GetComponent<Person>().Init(2, 5, 0);
            people[2].Add(person);
        }
    }

    private void Update()
    {
        
    }
}
