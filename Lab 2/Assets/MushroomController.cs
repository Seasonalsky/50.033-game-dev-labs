using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    private Vector2 CurrentVelocity;
    private SpriteRenderer mushroomSprite;
    public float speed;

    // public bool stop;
    // public BoxCollider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        mushroomSprite = GetComponent<SpriteRenderer>();
        rigidBody.AddForce(Vector2.up * 25, ForceMode2D.Impulse);
        int randNum = Random.Range(0, 2);
        if (randNum != 0)
        {
            rigidBody.AddForce(Vector2.right * 3, ForceMode2D.Impulse);
        }
        else
        {
            rigidBody.AddForce(Vector2.left * 3, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            rigidBody.velocity = CurrentVelocity;
        }

        if (col.gameObject.CompareTag("Player"))
        {
            // when hit player, stop moving
            rigidBody.velocity = Vector2.zero;

        }
        if (col.gameObject.CompareTag("Pipe"))
        {
            // when hit object, change direction
            rigidBody.velocity = new Vector2(CurrentVelocity.x * -1, CurrentVelocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goomba"))
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        CurrentVelocity = rigidBody.velocity;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
