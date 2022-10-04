using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;




public class ProgrammManeger : MonoBehaviour
{
    [SerializeField] private GameObject Marker;

    private ARRaycastManager ARRaycastManagerScript;
    private Vector2 TouchPosition;

    public GameObject ObjectToSpawn;

    public bool ChooseObject = false;

    public GameObject ScrollViev;

    [SerializeField] private Camera ARCamera;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject SelectedObject;

    public bool Rotation;
    private Quaternion YRotation;

    public bool Delite;
    // Start is called before the first frame update
    void Start()
    {
        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();

        Marker.SetActive(false);
        ScrollViev.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (ChooseObject)
        {
            ShowMarker();
        }

        MoveObject();

    }

    void ShowMarker()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        //show marker
        if (hits.Count > 0)
        {
            Marker.transform.position = hits[0].pose.position;
            Marker.SetActive(true);
        }
        //set object
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Instantiate(ObjectToSpawn, hits[0].pose.position, ObjectToSpawn.transform.rotation);
            ChooseObject = false;
            Marker.SetActive(false);
        }
    }


    void MoveObject()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            TouchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = ARCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;

                if (Physics.Raycast(ray, out hitObject))
                {
                    if (hitObject.collider.CompareTag("UnSelected"))
                    {
                        hitObject.collider.gameObject.tag = "Selected";
                    }
                }
            }
                SelectedObject = GameObject.FindWithTag("Selected");
            if (touch.phase == TouchPhase.Moved && Input.touchCount == 1)
            {
                if (Rotation)
                {
                    YRotation = Quaternion.Euler(0f, -touch.deltaPosition.x*0.1f,0f);
                    SelectedObject.transform.rotation = YRotation * SelectedObject.transform.rotation;
                }
                else
                {
                    ARRaycastManagerScript.Raycast(TouchPosition, hits, TrackableType.Planes);
                    
                    SelectedObject.transform.position = hits[0].pose.position;
                }
            }

            if (Delite)
            {
                Destroy(SelectedObject);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (SelectedObject.CompareTag("Selected"))
                {
                    SelectedObject.tag = "UnSelected";
                }
            }

        }
    }
}
