using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 4f;
    public float smoothTime = .5f;

    private float yaw;
    private float pitch;
    private Vector3 currentSpeed;
    private Vector3 refVelocity;

    private void Awake()
    {
        yaw = transform.eulerAngles.y;
        pitch = transform.eulerAngles.x;
        currentSpeed = Vector3.zero;
        refVelocity = Vector3.zero;
    }

    private void Update()
    {
        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        movementSpeed = Mathf.Clamp(movementSpeed + scroll * 2, 0.1f, 15);

        Vector3 x = Input.GetAxisRaw("Vertical") * transform.forward;
        Vector3 z = Input.GetAxisRaw("Horizontal") * transform.right;
        Vector3 y = Input.GetAxisRaw("Elevation") * transform.up;
        Vector3 targetSpeed = (x + y + z) * movementSpeed;
        currentSpeed = Vector3.SmoothDamp(currentSpeed, targetSpeed, ref refVelocity, smoothTime);

        if (Input.GetButton("Fire2"))
        {
            yaw += mouseSensitivity * Input.GetAxis("Mouse X");
            pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0);
        }
        transform.position += currentSpeed * Time.deltaTime;
    }
}
