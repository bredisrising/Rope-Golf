using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{

    [SerializeField] AudioClip die;
    [SerializeField] AudioClip portal;
    [SerializeField] AudioSource audioSrc;

    private DistanceJoint2D joint;
    [SerializeField] GameObject pointer;


    [SerializeField] GameObject camHolder;

    [SerializeField] float speed;
    [SerializeField] float maxSpeed;

    private bool currentlyDown = false;

    [SerializeField] Manager manager;

    private Rigidbody2D rb;

    private Vector3 pointerPos;

    [SerializeField] CameraCon cameraShake;

    public LineRenderer line;
    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();

        rb = GetComponent<Rigidbody2D>();






    }

    


    void Update()
    {



        if (!manager.gameOver)
        {

            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
            }



            if (Input.GetMouseButton(0))
            {
                if (!currentlyDown)
                {
                    pointerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    rb.AddForce((rb.velocity.normalized * speed));

                }


                currentlyDown = true;



            }
            else
            {

                currentlyDown = false;

                joint.enabled = false;
                line.enabled = false;
            }


            if (currentlyDown)
            {


                line.enabled = true;
                line.SetPosition(0, new Vector3(transform.position.x, transform.position.y, 0));
                line.SetPosition(1, new Vector3(pointerPos.x, pointerPos.y, 0));
                joint.enabled = true;
                pointer.transform.position = pointerPos;

                joint.connectedBody = pointer.GetComponent<Rigidbody2D>();
            }

        }
    }




    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!manager.gameOver)
        {

            audioSrc.PlayOneShot(die);
            line.enabled = false;
            rb.velocity = new Vector2(0, 0);
            rb.isKinematic = true;
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<TrailRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

            StartCoroutine(cameraShake.Shake(.4f, .13f));
            StartCoroutine(cameraShake.Zoom(.05f, .16f));

            manager.gameOver = true;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Portal") {
            audioSrc.PlayOneShot(portal);



            if (manager.numOflvls - manager.currentLvlIndex == 1)
            {

                manager.EndScene();
            }
            else
            {
                manager.TeleportNextLevel();
            }

        }else if (collision.gameObject.tag == "Star")
        {

            audioSrc.PlayOneShot(portal);
            manager.AddStars(1);

            collision.gameObject.SetActive(false);
        }
    } 

    
}
