using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private string turretTag = "Turret Bullet";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag==turretTag)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
