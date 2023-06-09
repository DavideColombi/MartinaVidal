using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    [SerializeField] Transform cameraTrans;
    [SerializeField] LayerMask layerMask;
    private GameObject lastObject;
    float timerSpegnimento = 0;
    [SerializeField] float maxSecondiSpegnimento = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(cameraTrans.position, cameraTrans.forward, out hit, 3f, layerMask))
        {
            //hittato
            for(int i=0; i < hit.transform.childCount; i++)
            {
                GameObject canvas = hit.transform.GetChild(i).gameObject;
                if(canvas.name == "Canvas")
                {
                    if(lastObject != null)
                    {
                        if(lastObject.transform.position != canvas.transform.position)
                        {
                            lastObject.SetActive(false);
                        }
                    }
                    timerSpegnimento = 0;
                    canvas.SetActive(true);
                    lastObject = canvas;
                }
            }
            
            
        }
        else
        {
            timerSpegnimento += Time.deltaTime;
            //non hittato
            if(lastObject != null && timerSpegnimento >= maxSecondiSpegnimento)
            {
                lastObject.SetActive(false);
                lastObject = null;
            }
        }
    }
}
