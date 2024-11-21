using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetroScript : MonoBehaviour
{
    private Animator animator;
    private float chronometer = 0f;
    public Transform controllerShor;
    public GameObject bulletPrefab;
    public float shotWaitTime = 1f; 
    public float waitTimeAnimator=0.5f;
    public float shootTimer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
       Behavior();
    }
    private void Behavior()
    {
        chronometer+=1*Time.deltaTime;
        
        if (chronometer >= 5f)
        {
            shootTimer += Time.deltaTime;
            animator.SetBool("Attack", true);
            if (shootTimer >= shotWaitTime)
            {
                float randomValue = Random.Range(0f, 2.5f);
                Shoot(randomValue);
                shootTimer = 0f;  
            }
        }

        if (chronometer >= 15f)
        {
            animator.SetBool("Attack",false);
            chronometer = 0f;
            shootTimer = 0f;
        }
    }
    private void Shoot(float positionMadraso)
    {
        Vector3 newPosition = controllerShor.position;
        newPosition.y += positionMadraso;
        Instantiate(bulletPrefab, newPosition, controllerShor.rotation);
        
    }
    
}
