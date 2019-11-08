using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;

    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 0, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 newPosition = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
            transform.position = newPosition;
        }
        
    }
}
