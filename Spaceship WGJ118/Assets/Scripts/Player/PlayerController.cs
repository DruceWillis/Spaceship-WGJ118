using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] GameObject trail;
    [SerializeField] float acceleratedSpeed = 10f;

    bool finishedDash = true;
    float baseSpeed;
    public int health = 100;
    Rigidbody2D rb;
    // Start is called before the first frame update

    private void Awake() {
        //Application.targetFrameRate = 60;
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        baseSpeed = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        Aim();
        
        //Dash();
    }

    private void Update() {
        
        if (Input.GetKeyDown(KeyCode.Space) && finishedDash)
        {
            StartCoroutine(Dash());
        }
        if (finishedDash)
            Accelerate();
    }

    private void Aim()
    {
        // float addAngle = 270;
        // Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + addAngle;
        // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    


        // Vector3 mouseScreenPosition = Camera.main.WorldToScreenPoint(Input.mousePosition);

        // Vector3 lookAt = mouseScreenPosition;

        // float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

        // float AngleDeg = (180 / Mathf.PI) * AngleRad;

        // this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);


        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;

    }

    private void Movement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 newPosition = new Vector3(horizontalMovement, verticalMovement, 0);
        newPosition = newPosition.normalized * speed * Time.smoothDeltaTime;
        rb.MovePosition(transform.position + newPosition);
    }

    IEnumerator Dash()
    {
        finishedDash = false;
        speed += 20f;
        if (!trail.activeSelf)
            trail.SetActive(true);
        yield return new WaitForSeconds(.3f);
        speed -= 20f;
        yield return new WaitForSeconds(.2f);
        if (trail.activeSelf)
            trail.SetActive(false);
       finishedDash = true;
    }

    private void Accelerate()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = acceleratedSpeed;
            if (!trail.activeSelf)
                trail.SetActive(true);
        }
        else
        {
            speed = baseSpeed;
            if (trail.activeSelf)
                trail.SetActive(false);
        }
    }


}
