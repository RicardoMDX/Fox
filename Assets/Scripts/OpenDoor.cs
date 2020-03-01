using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    private AudioSource aus_Door;

    // Start is called before the first frame update
    void Start()
    {
        aus_Door = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Item")
        {
            aus_Door.Play();
            GameObject.Destroy(this.gameObject,5f);
            GameObject.Destroy(other.gameObject);
        }
    }
}
