using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ballMovement : MonoBehaviour
{
    Rigidbody rb;
    public GameObject football;
    public float thrust = 10.0f;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        scoreText.enabled = false; 
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKey(KeyCode.D))
         {
            transform.Translate(Vector3.right * Time.deltaTime);
         }
         if (Input.GetKey(KeyCode.A))
         {
            transform.Translate(Vector3.left * Time.deltaTime);
         }
         if (Input.GetKeyDown(KeyCode.Mouse0))
         {
            rb.AddForce(0, 0, thrust, ForceMode.Impulse);
         }
    }

    void FixedUpdate()
    {
         if(rb.position.z >= 10.5f)
         {
             rb.velocity = Vector3.zero;
             rb.angularVelocity = Vector3.zero;

        // 2. Put it in kinematic mode
             rb.isKinematic = true;

        // 3. Teleport it back to your start position
             rb.position = new Vector3(-0.13f, -0.959f, -2.0f);
         }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("net"))
        {
           Debug.Log("Goal Scored");
           scoreText.enabled = true;
        }

    }

}
