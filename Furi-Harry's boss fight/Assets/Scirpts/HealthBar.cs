using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;
    private float newHealth;
    private bool takenDamage=false;
    private string PlayerTag = "Player";
    private string DJTag = "DJ";
    public Target target;
    private bool hasWon = false;
    private bool hasLost = false;
    
    private void Awake()
    {
        
        StartCoroutine(removeHealth());
    }
    private void Update()
    {
        //Player has lost
        if (healthSlider.value==0 && target.getObjectTag().Equals(PlayerTag))
        {
            hasLost = true;
            StartCoroutine(waitBeforeNextScene());
            
        }
        //Player has won
        else if (healthSlider.value == 0 && target.getObjectTag().Equals(DJTag))
        {
            hasWon = true;
            StartCoroutine(waitBeforeNextScene());
            
        }
       
    }
    public void setMaxHealth(float maxH)
    {
        healthSlider.maxValue = maxH;
        healthSlider.value = maxH;
        healthSlider.minValue = 0;
    }

    public void setHealth(float health)
    {
        newHealth = health;
        takenDamage = true;
    }
    IEnumerator removeHealth()
    {
        var wait=  new WaitForSeconds(0.01f);
        while (true)
        {
            if (takenDamage)
            {

                while (healthSlider.value!=newHealth)
                {
                    healthSlider.value -= 1;
                    yield return wait;
                }
                takenDamage = false;
                
            }
            else
            {
                yield return null;
            }
            
        }
    }
    IEnumerator waitBeforeNextScene()
    {
        var wait= new WaitForSeconds(2);
        
        if (hasLost==true)
        {
            
            yield return wait;
            SceneManager.LoadScene("YouLost");
            hasLost = false;
        }
        else if (hasWon==true)
        {
            yield return wait;
            SceneManager.LoadScene("YouWon");
            hasWon =false;
        }
        
    }

}
