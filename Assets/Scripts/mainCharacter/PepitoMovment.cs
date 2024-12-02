using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PepitoMovment : MonoBehaviour
{
    public GameObject bullet;
    public float jumpForce;
    public float longitudRaycast = 0.1f;

    public LayerMask capaSuelo;
    public float speed;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private float _horizontal;
    private float _lastShoot;

    public bool enSuelo;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        if (_horizontal < 0.0f) 
            transform.localScale = new Vector3(-0.5f, 0.5f, 1.0f);
        else if (_horizontal > 0.0f) 
            transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);

        _animator.SetBool("Running", _horizontal != 0.0f);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaSuelo);
        enSuelo = hit.collider != null;
        if (enSuelo && Input.GetKeyDown(KeyCode.W))
        {
            _rigidbody2D.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
        }
 
        // Disparar
        if (Input.GetKey(KeyCode.Space) && Time.time > _lastShoot + 0.25)
        {

            Shoot();
            _lastShoot = Time.time;
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            _animator.SetBool("Shooting", false);
        }
    
    }


    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_horizontal * speed, _rigidbody2D.velocity.y);
    }

    private void Shoot()
    {
        // Activar la animación de disparo
        _animator.SetBool("Shooting", true);   
             
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
