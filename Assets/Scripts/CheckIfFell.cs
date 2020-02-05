using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfFell : MonoBehaviour
{
    public GameObject go_Spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y<=-5)
        {
            Reset();
        }
    }

    void Reset()
    {
        this.transform.SetPositionAndRotation(go_Spawn.transform.position, go_Spawn.transform.rotation);
    }
}
