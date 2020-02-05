using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room4Manager : MonoBehaviour
{
    public GameObject go_Path, go_Floor;
    public Material mat_OriginalColour;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Player puts item back
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            Debug.Log("Item entered");
            go_Path.GetComponent<Renderer>().material.color = mat_OriginalColour.color;
            go_Floor.GetComponent<MeshCollider>().enabled = true;
        }
    }

    //Player takes item
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Item")
        {
            Debug.Log("Item left");
            go_Path.GetComponent<Renderer>().material.color = go_Floor.GetComponent<Renderer>().material.color;
            go_Floor.GetComponent<MeshCollider>().enabled = false;
        }
    }
}
