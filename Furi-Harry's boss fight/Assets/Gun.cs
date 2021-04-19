
using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private float damage = 10.0f;
    [SerializeField]
    private float range = 100.0f;
    [SerializeField]
    private float fireRate = 10.0f;
    [SerializeField]
    private float bulletSpeed = 1.0f;
    [SerializeField]
    private GameObject projectilePrefab;

    private CharacterMovement movement;
    
    private float nextTimeToFire = 0.0f;
    public GameObject player;
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
            Shoot();
        }
    }

   public void Shoot()
    {
        RaycastHit hitInfo;
        Vector3 targetpoint;
                        
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.name);
            Debug.Log(player.transform.forward);
            Target target= hitInfo.transform.GetComponent<Target>();

            targetpoint = hitInfo.point;

            Vector3 direction = targetpoint - player.transform.position;

            GameObject projectile = Instantiate(projectilePrefab, transform.position,transform.rotation);

            projectile.transform.forward = direction.normalized;

            projectile.GetComponent<Rigidbody>().AddForce(direction.normalized * bulletSpeed, ForceMode.Impulse);   
           

            
          
                        
            if (target!=null)
            {
                target.TakeDamage(damage);
               
            }
        }
    }
}
