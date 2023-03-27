using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaycastUI : MonoBehaviour
{
    Transform cameraTrans;
    [SerializeField] LayerMask layerMask;
    private GameObject lastObject;
    float timerCambioScena = 0;
    [SerializeField] Transform imgSelection;
    [SerializeField] Sprite buranoVecchia;
    Sprite buranoNuova;
    Image burano;
    Vector3 translateFrom = new Vector3();
    Vector3 translateTo = new Vector3();
    float translateTimer = 0;
    bool translate;
    [SerializeField] Slider slider;
    GameObject scrittaBottone;
    // Start is called before the first frame update
    void Start()
    {
        cameraTrans = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(cameraTrans.position, cameraTrans.forward, out hit, 10f, layerMask))
        {
            if(lastObject != null)
            {
                if(lastObject.name != hit.transform.name)
                {
                    if (hit.transform.tag == "Card")
                    {
                        translateFrom = imgSelection.position;
                        translateTo = new Vector3(hit.transform.position.x, imgSelection.position.y, imgSelection.position.z);
                        translate = true;
                        lastObject = hit.transform.gameObject;
                    }
                }
            }
            else
            {
                if(hit.transform.tag == "Card")
                {
                    translateFrom = imgSelection.position;
                    translateTo = new Vector3(hit.transform.position.x, imgSelection.position.y, imgSelection.position.z);
                    translate = true;
                    lastObject = hit.transform.gameObject;
                }
                
            }
            if(hit.transform.name == "BuranoVr")
            {
                if(buranoNuova == null)
                {
                    buranoNuova = hit.transform.GetComponent<Image>().sprite;
                    burano = hit.transform.GetComponent<Image>();
                }
                burano.sprite = buranoVecchia;
            }
            else
            {
                burano.sprite = buranoNuova;
            }
            //hittato
            if (hit.transform.name == "Button")
            {
                if(scrittaBottone == null)
                {
                    scrittaBottone = hit.transform.GetChild(0).gameObject;
                }
                scrittaBottone.SetActive(false);
                slider.gameObject.SetActive(true);
                timerCambioScena += Time.deltaTime;
                slider.value = timerCambioScena;
                if(timerCambioScena >= 4f)
                {
                    SceneManager.LoadScene("Main");
                }
            }
            else
            {
                scrittaBottone.SetActive(true);
                slider.gameObject.SetActive(false);
                timerCambioScena = 0f;
                slider.value = timerCambioScena;
            }


        }

        if (translate)
        {
            translateTimer += Time.deltaTime;
            imgSelection.position = Vector3.Lerp(translateFrom, translateTo, translateTimer/0.3f);
            if (translateTimer >= 0.3f)
            {
                translate = false;
                translateTimer = 0f;
            }
        }
    }
}
