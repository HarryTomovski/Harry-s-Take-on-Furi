
using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    [SerializeField]
    private float range = 100.0f;
    [SerializeField]
    private float fireRate = 10.0f;
    [SerializeField]
    private float bulletSpeed = 1.0f;
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private  Camera mainCam;

    private CharacterMovement movement;
    
    private float nextTimeToFire = 0.0f;

    [SerializeField]
    private GameObject gun;

    [SerializeField]
    private GameObject player;
    

    // Start is called before the first frame update

    void Start()
    {
        
        movement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time>=nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            RotateShootDirection();
            Shoot();
        }
    }
   public void Shoot()
    {
        RaycastHit hitInfo;
        Vector3 targetpoint;
                        
        if (Physics.Raycast(gun.transform.position, gun.transform.forward, out hitInfo, range))
        {
            
            Debug.Log(hitInfo.transform.name);
            Debug.Log(gun.transform.forward);
            

            targetpoint = hitInfo.point;

           

            Vector3 direction = targetpoint - gun.transform.position;

            GameObject projectile = Instantiate(projectilePrefab, transform.position,transform.rotation);

            projectile.transform.forward = direction.normalized;

            projectile.GetComponent<Rigidbody>().AddForce(direction.normalized * bulletSpeed, ForceMode.Impulse);
            
            
            
            Destroy(projectile, 2.0f);
        }
    }
    private void RotateShootDirection()
    {
        Plane referencePlane = new Plane(Vector3.up, player.transform.position);

        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0;

        if (referencePlane.Raycast(ray, out hitDist))
        {
            var targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - player.transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;

            RotatePlayer(targetRotation);
        }

    }
    private void RotatePlayer(Quaternion rotation)
    {
        player.transform.rotation = rotation;
    }
    
}
