using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sphere : MonoBehaviour
{
    public float speed = 0.8f;
    public float maxSpeed = 1.2f;
    public float distanceFromCamera = 10;
    public Transform cameraTransform;
    public Transform plantTransform;
    public Text texto;
    public Animator animplant;
    public Rigidbody rbparent;
    public AudioSource tierrasound;
    public AudioSource awasound;
    private Animator anim;
    private Rigidbody rb;
    private MeshRenderer renderer;
    private string curr_anim;
    private float ballheight;
    private float sizestart = 0.5f;
    private float sizesum = 0.0f;
    private int points = 0;
    private int awas = 0;
    private int tierras = 0;
    // Start is called before the first frame update
    void Start()
    {
        curr_anim = "ball1";
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<MeshRenderer>();
        ballheight = renderer.bounds.size.y;
        sizestart = renderer.bounds.size.y;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movementHorizontal, 0.0f, movementVertical);

        rb.AddForce(movement * speed);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        Vector3 objectpos = new Vector3(transform.position.x,transform.position.y+5.0f, transform.position.z-5.0f);
        cameraTransform.position = objectpos;

        objectpos = new Vector3(transform.position.x,transform.position.y+(ballheight/2), transform.position.z);
        plantTransform.position = objectpos;

        texto.text = "Score: " + points;
    }
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "tierrafertil") // GameObject is a type, gameObject is the property
        {
            tierrasound.loop = false;
            tierrasound.Play();
            tierras++;
            if ( tierras > 0 && tierras < 3 ) {
                anim.SetTrigger("ball1");
            } else if( tierras >= 3 && tierras < 6 ){
                anim.SetTrigger("ball2");
            } else if( tierras >= 6 && tierras < 9 ){
                anim.SetTrigger("ball3");
            } else if( tierras >= 9 && tierras < 12 ){
                anim.SetTrigger("ball4");
            }
            points += 10;
            if (sizesum<0.4f) {
                sizesum+=0.2f;
                resizeBall();
            }
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "awa") // GameObject is a type, gameObject is the property
        {
            awasound.loop = false;
            awasound.Play();
            awas++;
            if ( awas > 0 && awas < 2 ) {
                animplant.SetTrigger("plant1");
            } else if( awas >= 2 && awas < 4 ){
                animplant.SetTrigger("plant2");
            } else if( awas >= 4 && awas < 6 ){
                animplant.SetTrigger("plant3");
            } else if( awas >= 6 ){
                animplant.SetTrigger("plant4");
            }
            Destroy(col.gameObject);
        }
    }

    private void resizeBall() {
        Vector3 newsize = new Vector3(sizestart + sizesum,sizestart + sizesum, sizestart + sizesum);
        transform.localScale = newsize;
        ballheight = renderer.bounds.size.y;
    }
}
