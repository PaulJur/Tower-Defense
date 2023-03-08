
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Camera : MonoBehaviour
{
    public float panSpeed = 20f;
    public float border = 10f;
    public Vector2 Limits;

    public float scrollSpeed;

    private float minY = 225f;
    private float maxY=450f;

    
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y>=Screen.height-border){
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= border)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - border)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= border)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y-=scroll*scrollSpeed*100f*Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -Limits.x, Limits.x);
        pos.y = Mathf.Clamp(pos.y, minY,maxY);
        pos.z = Mathf.Clamp(pos.z, -Limits.y, Limits.y);
        transform.position = pos;


    }
}
