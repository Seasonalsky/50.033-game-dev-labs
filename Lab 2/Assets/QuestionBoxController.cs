using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBoxController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public SpringJoint2D springJoint;
    public GameObject consummablePrefab; // the spawned mushroom prefab
    public SpriteRenderer spriteRenderer;
    public Sprite usedQuestionBox; // the sprite that indicates empty box instead of a question mark
    private bool hit = false;
    public GameObject mushroom;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        springJoint = GetComponent<SpringJoint2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // usedQuestionBox = GetComponent<Sprite>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Debug.Log("OnCollisionEnter2D");
        if (col.gameObject.CompareTag("Player") && !hit)
        {
            hit = true;
            // ensure that we move this object sufficiently 
            rigidBody.AddForce(new Vector2(0, rigidBody.mass * 20), ForceMode2D.Impulse);
            // spawn mushroom
            mushroom = Instantiate(consummablePrefab, new Vector3(this.transform.position.x, this.transform.position.y + 1.0f, this.transform.position.z), Quaternion.identity);
            // begin check to disable object's spring and rigidbody
            StartCoroutine(DisableHittable());
        }
        if (col.gameObject.CompareTag("Pipe") && !hit)
        {

        }
    }

    void OnDestroy()
    {
        Destroy(mushroom);
    }

    bool ObjectMovedAndStopped()
    {
        return Mathf.Abs(rigidBody.velocity.magnitude) < 0.01;
    }

    IEnumerator DisableHittable()
    {
        if (!ObjectMovedAndStopped())
        {
            yield return new WaitUntil(() => ObjectMovedAndStopped());
        }
        //continues here when the ObjectMovedAndStopped() returns true
        spriteRenderer.sprite = usedQuestionBox; // change sprite to be "used-box" sprite
        rigidBody.bodyType = RigidbodyType2D.Static; // make the box unaffected by Physics

        //reset box position
        this.transform.localPosition = Vector3.zero;
        springJoint.enabled = false; // disable spring
    }


}
