using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckForItem : MonoBehaviour
{
    public GameObject go_ItemHolder;
    public Text txt_PickUpText;

    private bool b_HoldingItem=false;
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
        if (!b_HoldingItem)
        {
            if (Physics.Raycast(ray, out hit, 3f))
            {
                if (hit.transform.tag == "Item")
                {
                    txt_PickUpText.enabled = true;
                    hit.transform.SendMessage("HighlightItem");
                    lastObject = hit.transform.gameObject;
                    if (Input.GetMouseButtonDown(0))
                    {
                        lastObject.GetComponent<Rigidbody>().isKinematic = true;
                        lastObject.transform.position = go_ItemHolder.transform.position;
                        lastObject.transform.rotation = go_ItemHolder.transform.rotation;
                        lastObject.transform.parent = go_ItemHolder.transform;
                        b_HoldingItem = true;
                        lastObject.SendMessage("DehighlightItem");
                        txt_PickUpText.enabled = false;
                    }
                }
                else if (lastObject != null)
                {
                    txt_PickUpText.enabled = false;
                    lastObject.SendMessage("DehighlightItem");
                }
                else
                {
                    txt_PickUpText.enabled = false;
                }
            }
            else if (lastObject != null)
            {
                txt_PickUpText.enabled = false;
                lastObject.SendMessage("DehighlightItem");
            }
            else
            {
                txt_PickUpText.enabled = false;
            }
        }
        else
        {
            if (lastObject != null)
            {
                txt_PickUpText.enabled = false;
                if (Input.GetMouseButtonDown(0))
                {
                    lastObject.GetComponent<Rigidbody>().isKinematic = false;
                    lastObject.transform.parent = null;
                    b_HoldingItem = false;
                }
            }
        }
    }
}
