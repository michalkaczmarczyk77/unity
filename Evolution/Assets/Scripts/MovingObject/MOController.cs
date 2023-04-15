using UnityEngine;
using System;
using System.IO;

public class MovingObjectCtrl : MonoBehaviour
{
    public bool toClone = false;
    public float speed = 2;
    public float forceAmount = 0;
//    public GameObject objectPrefab;

    private Sprite mySprite;
    private bool cloned = false;
    private Rigidbody2D body;

    private void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {/*
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, 2 * Time.deltaTime);
     */
        /*        
                float x = Input.GetAxis("Horizontal");
                float y = Input.GetAxis("Vertical");

                Vector2 movement = new Vector2(x, y);
                transform.Translate(movement * speed * Time.deltaTime);
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 oposite = new Vector2(-1, -1);
        forceAmount = calculateForce(collision.relativeVelocity, body.mass);
        body.AddForce(Vector2.up * forceAmount, ForceMode2D.Impulse);
        //body.AddForce(body.transform.position.normalized * oposite * forceAmount, ForceMode2D.Impulse);

        if (!cloned && toClone)
        {
            cloned = true;
            System.Random rnd = new System.Random();

            //Instantiate(newPrefab, new Vector2(0.2f * rnd.Next(1, 10), 0.2f * rnd.Next(1, 10)), Quaternion.identity);
            //Instantiate(objectPrefab, new Vector2(0.2f * rnd.Next(1, 10), 0.2f * rnd.Next(1, 10)), Quaternion.identity);
            Instantiate(body, new Vector2(0.2f * rnd.Next(1, 10), 0.2f * rnd.Next(1, 10)), Quaternion.identity);
        }

    }

    void OnMouseDown()
    {
        Debug.Log("Mouse button pressed");
    }

    private float calculateForce(Vector2 velocity, float mass)
    {
        float force = velocity.magnitude*0.75f;

        if (force < 0.3f)
        {
            force = 0;
        }

        return force;
    }

}
