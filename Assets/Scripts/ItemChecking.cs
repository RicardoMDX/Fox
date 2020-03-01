using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChecking : MonoBehaviour
{
    public List<GameObject> GO_CorrectItems;
    public AudioClip auc_Correct, auc_Incorrect;
    public AudioSource aus_Door;

    private CapsuleCollider cl_CheckArea;
    private Light l_Light;
    private AudioSource aus_Cauldron;

    private int i_ItemCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        cl_CheckArea = GetComponent<CapsuleCollider>();
        l_Light = GetComponentInChildren<Light>();
        aus_Cauldron = GetComponent<AudioSource>();
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
            aus_Cauldron.PlayOneShot(auc_Correct);
            i_ItemCount++;
            if(i_ItemCount>=3)
            {
                aus_Door.Play();
            }
        }
        else
        {
            l_Light.color = Color.red;
            l_Light.enabled = true;
            StartCoroutine(Wait());
            aus_Cauldron.PlayOneShot(auc_Incorrect);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        l_Light.enabled = false;
    }
}
