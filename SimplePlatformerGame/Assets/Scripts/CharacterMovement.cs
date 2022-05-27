using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float jumpForce = 2.0f;
    public float speed = 1.0f;
    
    private bool grounded = true;
    private bool jump;

    private Rigidbody2D _rigidbody2D;
    private Animator anim; 
    private SpriteRenderer _spriteRenderer;
    private float moveDirection;

    public ParticleSystem PlayerWalkingParticleSystem;
    public ParticleSystem.MainModule PlayerWalkingParticleSystemMainModule;

    public GameObject PlayerHurtParticle;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate() 
    {

        _rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y);

        if (jump)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            PlayerWalkingParticleSystem.Stop();
            jump = false;
        }
        
        
    }
    private void Update() 
    {
        
        if ((Input.GetAxis("Horizontal") != 0))
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                moveDirection = -1.0f;
                float yRotation = 180.0f;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
                anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                moveDirection = 1.0f;
                float yRotation = 0.0f;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
                anim.SetFloat("speed", speed);
            }

        }
        else if (grounded)
        {
            moveDirection = 0.0f;
            anim.SetFloat("speed", 0.0f);
        }
        if (grounded && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)))
            {
                jump = true;
                anim.SetTrigger("jump");
                grounded = false;
                anim.SetBool("grounded", false);
            }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            PlayerWalkingParticleSystem.Play();
            anim.SetBool("grounded", true);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject spawnedObject = Instantiate(PlayerHurtParticle, transform.position, Quaternion.identity, null);
        }
    }
}
