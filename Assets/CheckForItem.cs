using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForItem : MonoBehaviour
{
    private Camera camera;
    private GameObject lastObject=null;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 3f))
        {
            if(hit.transform.tag=="Item")
            {
                hit.transform.SendMessage("HighlightItem");
                lastObject = hit.transform.gameObject;
            }
        }
        else if(lastObject!=null)
        {
            lastObject.SendMessage("DehighlightItem");
        }
    }
}
