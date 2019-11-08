using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab))
            gameObject.transform.position = new Vector3(-4.5f, 0, -1f);
        else if (Input.GetKeyUp(KeyCode.Tab))
            gameObject.transform.position = new Vector3(0, 0, 0);
    }
    void LateUpdate()
    {
        
        //else
            //gameObject.SetActive(false);
        // Vector3 newPosition = player.position;
        // newPosition.z = transform.position.z;
        // transform.position = newPosition;
    }
}
