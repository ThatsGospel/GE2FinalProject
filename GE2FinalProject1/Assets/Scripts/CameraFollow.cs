using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using Random = UnityEngine.Random;



public class CameraFollow : MonoBehaviour
{
    public static List<Boid> allBoids = new List<Boid>();

    public GameObject boidToFollow;

    public Vector3 followOffset = new Vector3(-13.45f, 9.4f, -11.27f);
    public float followSensetivity = 0.9f;

    private void Start()
    {
        allBoids = FindObjectsOfType<Boid>().ToList();
        boidToFollow = allBoids[0].gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            boidToFollow = allBoids[Random.Range(0, allBoids.Count)].gameObject;
        }
        FollowBoid();
    }

    public void FollowBoid()
    {
        transform.LookAt(boidToFollow.transform);
        transform.position = Vector3.Lerp(transform.position, boidToFollow.transform.position - followOffset, followSensetivity * Time.deltaTime);
    }
}