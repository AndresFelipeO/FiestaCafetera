using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetroBullet : MonoBehaviour
{
    public float velocity;
    public int damage;
    
    private float chronometer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chronometer+=1*Time.deltaTime;
        transform.Translate(Time.deltaTime*velocity*Vector2.right);
        if (chronometer >= 2)
        {
            Destroy(gameObject);
        }
    }
}
