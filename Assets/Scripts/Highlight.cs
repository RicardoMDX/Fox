using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    private Color startcolor;

    // Start is called before the first frame update
    void Start()
    {
        startcolor = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HighlightItem()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void DehighlightItem()
    {
        GetComponent<Renderer>().material.color = startcolor;
    }
}
