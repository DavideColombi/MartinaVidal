using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform destination;
    [SerializeField] OVRPlayerController playerController; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            StartCoroutine(TeleportPlayer(other.transform));
        }
           
    }
    IEnumerator TeleportPlayer(Transform other)
    {
        yield return new WaitForSeconds(0.001f);
        playerController.enabled = false;
        yield return new WaitForSeconds(0.001f);
        other.transform.position = new Vector3(destination.position.x, destination.position.y-0.25f, destination.position.z-0.3f);
        yield return new WaitForSeconds(0.001f);
        playerController.enabled = true;
    }
}
