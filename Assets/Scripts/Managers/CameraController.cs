using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f; //How fast it works when you drag
    [SerializeField] private float zoomSpeed = 0.1f; //How much it changes when you zoom
    [SerializeField] private float minZoom = 2f; //The minimum zoom level, how far you can zoom out
    [SerializeField] private float maxZoom = 20f; //The maximum zoom level, how far you can zoom in

    private Camera cam;// No idea explain this

    private void Awake() //Actually don't understand
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        Move(); //Checks if anything on your keyboard is pressed and if it is it moves
        Zoom(); //Checks if your mouse wheel is being scrolled and if it is it zooms in or out
    }

    private void Move()
    {
        Vector2 movement = Vector2.zero; //Position

        if (Keyboard.current.wKey.isPressed)
            movement.y += 1;

        if (Keyboard.current.sKey.isPressed)
            movement.y -= 1;

        if (Keyboard.current.aKey.isPressed)
            movement.x -= 1;

        if (Keyboard.current.dKey.isPressed)
            movement.x += 1;

        movement = movement.normalized; //Makes it so that it's diagonal speed is 1 and not sqrt(2)

        transform.position += (Vector3)(movement * moveSpeed * Time.deltaTime);
    }

    private void Zoom()
    {
        float scroll = Mouse.current.scroll.ReadValue().y; //Checks what the mouse wheel is doing

        if (scroll != 0) //Checks if the mouse wheel is moved at all
        {
            cam.orthographicSize -= scroll * zoomSpeed * Time.deltaTime; //Changes the zoom level based on how much the mouse wheel is moved
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom); //Makes it so that the zoom level can't go below the minimum or above the maximum
        }
    }
}