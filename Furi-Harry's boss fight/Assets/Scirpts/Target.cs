
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{

    private float health;
    [SerializeField]
    private float maxHealth = 100;
    [SerializeField]
    private HealthBar healthBar;
    private string bulletTag = "Bullet";

    //Due to collision detection damage is referenced here rather than in the gun script. 
    private float damage = 10.0f;

    Animator animator;
    int isDeadHash;
    private string turretTag = "Turret Bullet";
    public string objectTag;

    //private bool tookDamage = false;
    //private float healthBeforeDamage;



    private void Start()
    {
        setObjectTag(gameObject.tag);
        
        Debug.Log(objectTag);
        animator=GetComponent<Animator>();
        isDeadHash = Animator.StringToHash("isDead");
        health = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }
    public void TakeDamage(float damageAmount)
    {

        
        health -= damageAmount;
        healthBar.setHealth(health);
        Debug.Log("The current health of the Dj is " + health);
        if (health<=0)
        {
           
            Die();

        }
         
      
    }
    
    private void Die()
    {
        
        animator.SetBool(isDeadHash, true);
        StartCoroutine(stopAnimator());

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag==bulletTag && gameObject.tag!="Player")
        {
            TakeDamage(damage);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == turretTag && gameObject.tag=="Player")
        {
            TakeDamage(damage-5);
            Destroy(collision.gameObject);

        }
        
    }
    IEnumerator stopAnimator()
    {
        yield return new WaitForSeconds(2);
        animator.GetComponent<Animator>().enabled = false;
    }
    public string getObjectTag()
    {
        return objectTag;
    }

    public void setObjectTag(string tag)
    {
        objectTag = tag;
    }
    


}
