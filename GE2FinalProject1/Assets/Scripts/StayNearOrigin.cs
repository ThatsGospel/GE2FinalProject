using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class StayNearOrigin : MonoBehaviour
{
    public Vector3 origin;
    public List<Boid> boids = new List<Boid>();

    public float maxDistance = 100;

    private void Start()
    {
        origin = transform.position;
    }

    private void Update()
    {
        boids = FindObjectsOfType<Boid>().ToList();

        foreach (var boid in boids)
        {
            if (Vector3.Distance(origin, boid.transform.position) > maxDistance)
            {
                boid.transform.LookAt(origin);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0.75f, 0.5f, 0.5f);
        Gizmos.DrawWireSphere(origin, maxDistance);
    }
}
