using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRay : MonoBehaviour
{

    LineRenderer deathRay;
    Transform laserHit;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        deathRay = GetComponent<LineRenderer>();
        deathRay.enabled = false;
        deathRay.useWorldSpace = true;
        //player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Vector2 direction = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        // transform.up = direction;
        // Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        // transform.up = direction;



        RaycastHit2D hit = Physics2D.Raycast(transform.position * 1, player.up);
        Debug.DrawLine(transform.position, hit.point);

        // laserHit.position = hit.point;
        // transform.position = player.position + transform.up * 1.2f;
        deathRay.SetPosition(0, transform.position);
        
        if (hit)
            deathRay.SetPosition(1, hit.point);
        else
            deathRay.SetPosition(1, laserHit.position);
        if (Input.GetKey(KeyCode.Alpha1))
        {
            deathRay.enabled = true;
        }
        else
        {
            deathRay.enabled = false;
        }

    }
}
