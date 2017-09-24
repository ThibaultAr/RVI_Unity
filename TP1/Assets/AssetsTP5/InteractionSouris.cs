using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSouris : MonoBehaviour
{


    RaycastHit rayHit;
    Ray ray;
    bool isDragingObject = false;
    Vector3 screenPoint;
    Vector3 offset;
    Collider collider;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (isDragingObject)
            {
                Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
                collider.transform.position = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
            }
            else if (Physics.Raycast(ray, out rayHit))
            {
                isDragingObject = true;
                collider = rayHit.collider;
                screenPoint = Camera.main.WorldToScreenPoint(collider.transform.position);
                offset = collider.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

                if (GameObject.Find("GUIText")) Destroy(GameObject.Find("GUIText"));
                if (GameObject.Find("GUIText(Clone)")) Destroy(GameObject.Find("GUIText(Clone)"));
                GameObject obj = Instantiate(new GameObject("GUIText"), new Vector3(0.5f, 0.5f, 0.5f), Quaternion.identity) as GameObject;
                obj.AddComponent<GUIText>();
                obj.GetComponent<GUIText>().text = rayHit.collider.transform.position.ToString();
            }
        } else
        {
            isDragingObject = false;
            collider = null;
        }
            Destroy(GameObject.Find("GUIText"), 3);
            Destroy(GameObject.Find("GUIText(Clone)"), 3);
    }
}
