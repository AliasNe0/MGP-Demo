using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Advanced touch input MonoBehaviour that spawns balls at touch positions.
public class AdvancedTouchInput : MonoBehaviour
{
    // Reference to touch count Text component in the scene.
    [SerializeField] private TextMeshProUGUI touchCountText;
    [SerializeField] private TextMeshProUGUI objectCountText;

    // Reference to prefabs in the project assets.
    [SerializeField] private GameObject prefab1;
    [SerializeField] private GameObject prefab2;
    [SerializeField] private GameObject prefab3;
    [SerializeField] private GameObject prefab4;

    [Range(5f, 10f)]
    [SerializeField] float instantiateDistance = 5f;

    int objectIndex = 0;

    // Update method is called every frame, if the MonoBehaviour is enabled.
    private void Update()
    {
        // Display the current touch count in the Text component.
        touchCountText.text = "Touch count: " + Input.touchCount;

        objectCountText.text = "Object count: " + objectIndex;

        // Make sure there are currently touches on the screen (at least one).
        if (Input.touchCount > 0)
        {
            // Obtain all the Touches currently available.
            for (int i = 0; i < Input.touchCount; i++)
            {
                // Get the Touch at index.
                Touch touch = Input.GetTouch(i);

                // Convert the screen position to world position.
                // A Z-coordinate ("10f") is passed to the method to account for offset from the Camera position.
                var worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, instantiateDistance));

                // Log the touch phase events.
                if (touch.phase == TouchPhase.Began)
                {
                    Debug.Log("TouchPhase.Began: " + i);

                    // Spawn a new object instance from the prefab each time the screen is touched.
                    switch (i)
                    {
                        case 0:
                            Instantiate(prefab1, worldPosition, Quaternion.identity);
                            objectIndex++;
                            break;
                        case 1:
                            Instantiate(prefab2, worldPosition, Quaternion.identity);
                            objectIndex++;
                            break;
                        case 2:
                            Instantiate(prefab3, worldPosition, Quaternion.identity);
                            objectIndex++;
                            break;
                        case 3:
                            Instantiate(prefab4, worldPosition, Quaternion.identity);
                            objectIndex++;
                            break;
                    }
                }
            }
        }
    }
}