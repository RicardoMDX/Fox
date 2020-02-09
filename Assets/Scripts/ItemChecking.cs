using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChecking : MonoBehaviour
{
    public List<GameObject> GO_CorrectItems;

    private CapsuleCollider cl_CheckArea;
    private Light l_Light;
    // Start is called before the first frame update
    void Start()
    {
        cl_CheckArea = GetComponent<CapsuleCollider>();
        l_Light = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(GO_CorrectItems.Contains(other.transform.parent.gameObject))
        {
            GameObject.Destroy(other.transform.parent.gameObject);
            l_Light.color = Color.green;
            l_Light.enabled = true;
            StartCoroutine(Wait());
        }
        else
        {
            l_Light.color = Color.red;
            l_Light.enabled = true;
            StartCoroutine(Wait());

        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        l_Light.enabled = false;
    }
}
