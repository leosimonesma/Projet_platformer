using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class pushetpull : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;

    [SerializeField] private Transform raypoint;
    [SerializeField] Player_Stats player;
    private float rayDistance;
    public bool isGrabbing = false;
    private GameObject grabbedObject;
    [SerializeField] private Transform protBox;
    private int layerIndex;
    [SerializeField] Transform PlayerTransform;
    private const float interactDistance = 10f;

    private void Start()
    {
        // getting the layer index of the layer Objects
        layerIndex = LayerMask.NameToLayer("Objects");
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(raypoint.position, transform.right, rayDistance);


        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
          //  Debug.Log("je lance le ray");
            //grab object
            if (Input.GetButtonDown("DialogueCustom") && grabbedObject == null && player.getCanPush() == true)
            {
                grabbedObject = hitInfo.collider.gameObject;
                Debug.Log("je grab");
                if (Vector2.Distance(PlayerTransform.position, grabbedObject.transform.position) < interactDistance)
                {
                    grabbedObject.transform.position = grabPoint.position;

                }

                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.SetParent(transform);
                isGrabbing = true;
                protBox.gameObject.SetActive(true);


            }
            //release object
            else if (Input.GetButtonDown("DialogueCustom"))
            {
                grabbedObject = hitInfo.collider.gameObject;
                Debug.Log("je grab pas !");
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
                isGrabbing = false;
                protBox.gameObject.SetActive(false);


            }
        }



        Debug.DrawRay(raypoint.position, transform.right * rayDistance);

    }
}
