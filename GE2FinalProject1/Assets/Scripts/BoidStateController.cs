using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Boid))]
public class BoidStateController : MonoBehaviour
{
    //Control swapping between boid states by analysing information of the boid

    public enum BoidStates
    {
        Wander,
        Flee,
        Pursue,
        Attack
    }
    public BoidStates currentState = BoidStates.Wander;

    public string[] enemyTags;
    public GameObject currentEnemyTarget;
    public float  puruseDistance;
    public float attackDistance;
    public float fleeSpeedMultiplier = 1.5f;
    private float fleeSpeed;
    private float originalMaxSpeed;


    public float shootRate;
    private float m_shootRateTimeStamp;

    public GameObject m_shotPrefab;
    public Transform target;
    RaycastHit hit;
    public Transform muzzle;

    public List<GameObject> enemiesTargeting = new List<GameObject>();

    private void Start()
    {
        currentState = BoidStates.Wander;
        fleeSpeed = GetComponent<Boid>().maxSpeed;
        originalMaxSpeed = fleeSpeed;
        fleeSpeed *= fleeSpeedMultiplier;

        puruseDistance *= (Random.Range(0.9f, 1.4f));
    }

    private void Update()
    {
        AnalyzeStates();
    }
    
    //In here we analyze the current information surrounding this boid and act on it
    public void AnalyzeStates()
    {
        //Get the components on each object [If it gets them, then it saves them as a variable for this frame]
        TryGetComponent(out NoiseWander noiseWander);
        TryGetComponent(out Pursue pursue);
        TryGetComponent(out Flee flee);

        //Use the .Where function to select Boids in the area that fit your specific requirements
        var enemiesInArea = FindObjectsOfType<Boid>().Where(type => enemyTags.Contains(type.gameObject.tag) && Vector3.Distance(transform.position, type.transform.position) < puruseDistance).ToList();
        Debug.Log("Enemies in Area of " + gameObject.name + ": " + enemiesInArea.Count);

        switch (currentState)
        { //Switch statement that runs depending on the state you are in
            case BoidStates.Wander:
                noiseWander.enabled = true;
                pursue.enabled = false;
                flee.enabled = false;

                if (enemiesTargeting.Count > 0)
                {
                    currentState = BoidStates.Flee;
                    GetComponent<Boid>().maxSpeed = fleeSpeed;
                }


                //Pursue if there is an enemy in the area
                if (enemiesInArea.Count > 0)
                {
                    currentEnemyTarget = enemiesInArea[Random.Range(0, enemiesInArea.Count)].gameObject;
                    currentEnemyTarget.GetComponent<BoidStateController>().enemiesTargeting.Add(gameObject);
                    currentState = BoidStates.Pursue;
                }



                break;
                
case BoidStates.Flee:
                noiseWander.enabled = false;
                pursue.enabled = false;
                flee.enabled = true;

                if (enemiesTargeting.Count <= 0)
                {
                    currentState = BoidStates.Wander;
                    GetComponent<Boid>().maxSpeed = originalMaxSpeed;
                }
                else
                {
                    flee.targetGameObject = enemiesTargeting[0];
                }


                break;
            case BoidStates.Pursue:
                noiseWander.enabled = false;
                pursue.enabled = true;
                flee.enabled = false;

                pursue.target = currentEnemyTarget.GetComponent<Boid>();
                GetComponent<Boid>().maxSpeed = originalMaxSpeed;

                if (Vector3.Distance(transform.position, currentEnemyTarget.transform.position) > puruseDistance)
                {
                    currentEnemyTarget.GetComponent<BoidStateController>().enemiesTargeting.Remove(gameObject);
                    GetComponent<Boid>().maxSpeed = originalMaxSpeed;
                    currentState = BoidStates.Wander;
                }


                if (Vector3.Distance(transform.position, currentEnemyTarget.transform.position) < attackDistance)
                {
                    
                    GetComponent<Boid>().maxSpeed = originalMaxSpeed;
                    currentState = BoidStates.Attack;
                }

                if (enemiesTargeting.Count >= 2)
                {
                    currentState = BoidStates.Flee;
                    currentEnemyTarget.GetComponent<BoidStateController>().enemiesTargeting.Remove(gameObject);
                    GetComponent<Boid>().maxSpeed = fleeSpeed;
                }

                break;
            case BoidStates.Attack:
                noiseWander.enabled = false;
                pursue.enabled = true;
                flee.enabled = false;


                if (Time.time > m_shootRateTimeStamp)
                {
                    shootRay();
                    m_shootRateTimeStamp = Time.time + shootRate;
                }


                if (Vector3.Distance(transform.position, currentEnemyTarget.transform.position) > attackDistance)
                {
                    
                    GetComponent<Boid>().maxSpeed = originalMaxSpeed;
                    currentState = BoidStates.Pursue;
                }

                break;
        }
    }


    void shootRay()
    {

        GameObject laser = GameObject.Instantiate(m_shotPrefab, muzzle.position, muzzle.rotation) as GameObject;
        laser.GetComponent<ShotBehavior>().setTarget(currentEnemyTarget.transform.position);
        GameObject.Destroy(laser, 10f);




    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0.5f, 0.5f, 0.75f);
        Gizmos.DrawWireSphere(transform.position, puruseDistance);

        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireSphere(transform.position, attackDistance);

    }
}
