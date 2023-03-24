using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelctionController : MonoBehaviour
{
    [SerializeField] Transform cameraTrans;
    [SerializeField] LayerMask layerMask;
    private GameObject lastObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(cameraTrans.position, cameraTrans.forward, out hit, Mathf.Infinity, layerMask))
        {
            //hittato
        }
        else
        {
            //non hittato
        }
    }
}
