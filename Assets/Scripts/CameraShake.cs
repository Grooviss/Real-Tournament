using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeduration = 0.2f;
    public float shakemagnitude = 0.3f;
    private Vector3 originalposition;
    private float shaketime = 0f;
    public Health health;
    // Start is called before the first frame update
    void Start()
    {
        health.ondamage.AddListener(Shake);
        originalposition = transform.position;
    }


    
    void Update()
    {
        if(shaketime < shakeduration)
        {
            Vector3 Newpos = originalposition + Random.insideUnitSphere * shakemagnitude;
            transform.localPosition = Newpos;
            shaketime += Time.deltaTime;
        }
        else
        {
            transform.localPosition = originalposition;
            shaketime = 0f;
        }
        
    }
    public void Shake()
    {
        shaketime = 0f;
    }
}
