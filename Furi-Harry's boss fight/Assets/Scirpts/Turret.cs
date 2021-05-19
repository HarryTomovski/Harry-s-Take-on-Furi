using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //Turret variables
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float range = 30.0f;
    private float aimRotationSpeed = 10.0f;
    private string playerTargetTag = "Player";
    [SerializeField]
    private Transform TurretPointToRotate;
    


    //Shooting variables
    [SerializeField]
    private float fireRate = 1f;
    [SerializeField]
    private float bulletSpeed = 1f;
    [SerializeField]
    private GameObject projectilePrefab;
    private float nextTimeToFire = 0f;

    [SerializeField]
    private Transform TurretPointToFire;
    void Start()
    {
        //Invoke Target update twice per second
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target==null)
        {
            return;
        }

        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3  rotation = Quaternion.Lerp(TurretPointToRotate.rotation,lookRotation,Time.deltaTime*aimRotationSpeed).eulerAngles;
        TurretPointToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);

       if (nextTimeToFire<=0f)
       {
            nextTimeToFire =  1f / fireRate;
            Shoot();

        }

        nextTimeToFire -= Time.deltaTime;
        
    }
    void UpdateTarget()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTargetTag);

        float distanceToPlayer = Vector3.Distance(transform.position, player .transform.position);

        if (distanceToPlayer <= range)
        {
            target = player.transform;
        }
        else
        {
            target = null;
        }
            

       
    }
    //Check range of turret
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Shoot()
    {
        if (target != null)
        {

            Vector3 direction = target.position - TurretPointToFire.position;

            GameObject projectile = Instantiate(projectilePrefab, TurretPointToFire.position, TurretPointToFire.rotation);

            projectile.transform.forward = direction.normalized;

            projectile.GetComponent<Rigidbody>().AddForce(direction.normalized * bulletSpeed, ForceMode.Impulse);

            Destroy(projectile, 2.0f);
        }
        else
        {
            return;
        }
        Debug.Log("Shoot");
    }
}
