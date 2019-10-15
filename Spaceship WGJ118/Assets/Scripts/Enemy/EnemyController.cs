using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float stoppingDistance;
    [SerializeField] float retreatDistance;
    public int health = 30;

    Transform player;
    //GameObject body;
    //SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //body = gameObject.transform.Find("Body").gameObject;
        //sprite = body.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            Move();
            LookAtPlayer();
        }
        
    }

    private void LookAtPlayer()
    {
        var offset = 270f;
        Vector2 direction = player.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    private void Move()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance
                && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.fixedDeltaTime);
        }
    }

    // public void Fade()
    // {
    //     foreach (GameObject child in body.transform)
    //     {
    //         SpriteRenderer s = child.GetComponent<SpriteRenderer>();
    //         float r = s.color.r;
    //         float g = s.color.g;
    //         float b = s.color.b;
    //         float a = s.color.a / 1.5f;
    //         s.color = new Color(r, g, b, a);
    //     }
        
    // }
}
