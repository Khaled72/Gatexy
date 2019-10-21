using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RayCasterLoader : MonoBehaviour
{

    public float maxTimeToTeriggre;
    public Image imageFiller;
    RaycastHit hit;
    float Timer=0;
    GameObject oldTarget;
    void Start()
    {
        Timer = 0;
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Interactable")
            {
                if (hit.collider.gameObject == oldTarget)
                {
                    if (Timer >= maxTimeToTeriggre)
                    {
                        Timer = 0;
                        hit.collider.GetComponent<InteractableEvents>().events.Invoke();
                        Debug.Log("Doing Someting");
                        imageFiller.fillAmount = Timer / maxTimeToTeriggre;
                    }
                    else
                    {
                        Timer += Time.deltaTime;
                        //Fill Amount of Image
                        imageFiller.fillAmount = Timer / maxTimeToTeriggre;
                    }
                }
                else
                {
                    Timer = 0;
                    oldTarget = hit.collider.gameObject;
                    Timer += Time.deltaTime;
                    imageFiller.fillAmount = Timer / maxTimeToTeriggre;
                }
            }
            else
            {
                Timer = 0;
                oldTarget = null;
                imageFiller.fillAmount = Timer / maxTimeToTeriggre;
            }
        }
        else
        {
            Timer = 0;
            oldTarget = null;
            imageFiller.fillAmount = Timer / maxTimeToTeriggre;
        }
    }
}
