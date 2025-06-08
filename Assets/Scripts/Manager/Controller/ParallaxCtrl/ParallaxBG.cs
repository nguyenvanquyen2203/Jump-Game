using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    private Transform cameraTransform;
    public Sprite bg;

    public float parallaxSpeed = 0.5f;
    public int sortingOrderValue;

    private Vector3 lastCameraPosition;

    [SerializeField] private float mapHeight;
    private float spriteWidth;
    private float spriteHeight;
    private float scaleValue;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }
    void Start()
    {
        // If cameraTransform is not set, try to find the MainCamera
        cameraTransform = Camera.main.transform;
        mapHeight = CameraCtrl.Instance.GameHeight();
        lastCameraPosition = cameraTransform.position;
        transform.position = new Vector3(lastCameraPosition.x, CameraCtrl.Instance.CenterY(), lastCameraPosition.z);
    
        spriteHeight = bg.bounds.size.y;
        scaleValue = mapHeight / spriteHeight;
        CreateBG(Vector3.zero);
        spriteWidth = bg.bounds.size.x * scaleValue;
        CreateBG(new Vector3(-spriteWidth, 0f, 0f));
        CreateBG(new Vector3(spriteWidth, 0f, 0f));
    }

    // Use LateUpdate to ensure the camera has finished moving for the current frame
    void Update()
    {
        // Calculate how much the camera has moved since the last frame
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        // Apply parallax effect to this layer
        // Multiply by parallaxSpeed to make farther layers move less
        transform.position += new Vector3(deltaMovement.x * parallaxSpeed, 0, 0);

        // Update the last camera position for the next frame
        lastCameraPosition = cameraTransform.position;

        // Handle seamless tiling (optional, if your camera moves horizontally past the sprite bounds)
        if (spriteWidth > 0) // Ensure we have a valid spriteWidth
        {
            // If the camera has moved far enough to the right
            if (cameraTransform.position.x > transform.position.x + spriteWidth / 2)
            {
                // Move the background layer to the right by its width
                transform.position = new Vector3(transform.position.x + spriteWidth, transform.position.y, transform.position.z);
            }
            // If the camera has moved far enough to the left
            else if (cameraTransform.position.x < transform.position.x - spriteWidth / 2)
            {
                // Move the background layer to the left by its width
                transform.position = new Vector3(transform.position.x - spriteWidth, transform.position.y, transform.position.z);
            }
        }
    }
    private void CreateBG(Vector3 localPos)
    {
        GameObject tempBG = new GameObject();
        SpriteRenderer sR = tempBG.AddComponent<SpriteRenderer>();
        sR.sprite = bg;
        sR.sortingOrder = sortingOrderValue;
        tempBG.transform.SetParent(transform);
        tempBG.transform.localPosition = localPos;
        tempBG.transform.localScale = new Vector3(scaleValue, scaleValue, 1f);
    }
}