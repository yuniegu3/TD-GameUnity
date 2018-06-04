using UnityEngine;

public class CameraController : MonoBehaviour {

    private bool doMovement = true;
    public float panSpeed = 30f;
    public float panBorderTickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 100f;
	
	// Update is called once per frame
	void Update ()

    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
            doMovement = !doMovement;
        
        if (!doMovement)
            return;
        //postMVP have a limit set to how far you can move

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderTickness)   
            //mousePosition is something in vector3 that checks where mouse poision is
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); // transform.Translate is easiest way to move. Vector3.forward is like writting new Vector3 (0f,0f, panSpeed)
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderTickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World); // transform.Translate is easiest way to move. Vector3.forward is like writting new Vector3 (0f,0f, panSpeed)
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderTickness)
        //mousePosition is something in vector3 that checks where mouse poision is
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World); // transform.Translate is easiest way to move. Vector3.forward is like writting new Vector3 (0f,0f, panSpeed)
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderTickness)
        //mousePosition is something in vector3 that checks where mouse poision is
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World); // transform.Translate is easiest way to move. Vector3.forward is like writting new Vector3 (0f,0f, panSpeed)
        }

        // scrolling 

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;


	}
}
