using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PepitoMovment : MonoBehaviour
{
    public GameObject bullet;
    public float JumpForce;
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private float LastShoot;

    private bool Grounded;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) 
            transform.localScale = new Vector3(-0.5f, 0.5f, 1.0f);
        else if (Horizontal > 0.0f) 
            transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);

        Animator.SetBool("Running", Horizontal != 0.0f);
        Animator.SetBool("Jumping", !Grounded);

        // Verificar si está en el suelo
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
            Animator.SetBool("Jumping", false);
        }
        else
        {
            Grounded = false;
            Animator.SetBool("Jumping", true);
        }

        // Saltar
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        // Disparar
        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25)
        {

            Shoot();
            LastShoot = Time.time;
        }

        // Detener la animación de disparo cuando se deja de presionar Space
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Animator.SetBool("Shooting", false);
        }
    
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    private void Shoot()
    {
        // Activar la animación de disparo
        Animator.SetBool("Shooting", true);   
             
        Vector3 direction;

        // Verificar la dirección basada en la escala
        if (transform.localScale.x == 0.5f)
            direction = Vector2.right;
        else
            direction = Vector2.left;

        // Instanciar la bala
        GameObject bulletInstance = Instantiate(bullet, transform.position + direction * 0.6f, Quaternion.identity);
        bulletInstance.GetComponent<BulletScript>().SetDirection(direction);

    }

}
