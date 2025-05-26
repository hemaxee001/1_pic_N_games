using Unity.VisualScripting;
using UnityEngine;

public class input_handle_script : MonoBehaviour
{

    public Transform target;
    public float speed;

    private void Update()
    {


        //--------------------------getkey--------------
        //------GetKey is a continuous state check for each frame the key is held down.--------
        //print(Time.deltaTime);
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    target.position += Vector3.left * speed * Time.deltaTime;
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    target.position += Vector3.right * speed * Time.deltaTime;
        //}
        //else if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    target.position += Vector3.up * speed * Time.deltaTime;
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    target.position += Vector3.down * speed * Time.deltaTime;
        //}
        //-------------------------keydown----------------------

        //----GetKeyDown is a one-time event for each key press.----------------
        //print(Time.deltaTime);
        //if (Input.GetKeydown(KeyCode.LeftArrow))
        //{
        //    target.position += Vector3.left * speed * Time.deltaTime;
        //}
        //else if (Input.GetKeydown(KeyCode.RightArrow))
        //{
        //    target.position += Vector3.right * speed * Time.deltaTime;
        //}
        //else if (Input.GetKeydown(KeyCode.UpArrow))
        //{
        //    target.position += Vector3.up * speed * Time.deltaTime;
        //}
        //else if (Input.GetKeydown(KeyCode.DownArrow))
        //{
        //    target.position += Vector3.down * speed * Time.deltaTime;
        //}
        //------------------------getkeyup----------------------
        //if (Input.GetKeyUp(KeyCode.LeftArrow))
        //{
        //    target.position += Vector3.left * speed * Time.deltaTime;
        //}
        //else if (Input.GetKeyUp(KeyCode.RightArrow))
        //{
        //    target.position += Vector3.right * speed * Time.deltaTime;
        //}
        //else if (Input.GetKeyUp(KeyCode.UpArrow))
        //{
        //    target.position += Vector3.up * speed * Time.deltaTime;
        //}
        //else if (Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    target.position += Vector3.down * speed * Time.deltaTime;
        //}


        //-------------------------getmousebutton----------------------
        //------GetMouseButton is a continuous state check for each frame the mouse button is held down.--------
        //if (Input.GetMouseButton(0)) // 0 for left click, 1 for right click, 2 for middle click
        //{
        //    Vector3 mousePosition = Input.mousePosition;
        //    mousePosition.z = Camera.main.nearClipPlane; // Set the distance from the camera
        //    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //    target.position = worldPosition;
        //}

        //-------------------------getmousebuttondown----------------------
        //----GetMouseButtonDown is a one-time event for each mouse button press.----------------
        if (Input.GetMouseButtonDown(0)) // 0 for left click, 1 for right click, 2 for middle click
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane; // Set the distance from the camera
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            target.position = worldPosition;
            print("Mouse Down at: " + worldPosition);
        }


        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
           print("down");
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            print("up");
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            print("hold");
        }
        */

        //if (Input.GetMouseButtonDown(0))
        //{
        //    print("Mouse Down");
        //}
        //else if (Input.GetMouseButtonUp(0))
        //{
        //    print("Mouse Up");
        //}
        //else if (Input.GetMouseButton(0))
        //{
        //    print("Mouse Hold");
        //}


    }
    /*
    private void Awake()
    {
        print("Awake");
    }
    private void OnEnable()
    {
        print("OnEnable");
    }
    private void Start()
    {
        print("Start");
    }
    private void Update()
    {
        print("Update");
    }
    private void FixedUpdate()
    {
        print("FixedUpdate");
    }
    private void LateUpdate()
    {
        print("LateUpdate");
    }

    private void OnDisable()
    {
        print("OnDisable");
    }
    private void OnDestroy()
    {
        print("OnDestroy");
    }

    */
}
