using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlink : MonoBehaviour
{
    [SerializeField]
    private Light directionalLight;

    // Start is called before the first frame update
    void Start()
    {
        directionalLight = GetComponent<Light>();    
    }

    // Update is called once per frame
    void Update()
    {
        directionalLight.intensity = Mathf.PingPong(Time.unscaledTime, 5);
    }
}
