using UnityEngine;

public class UIFollowTarget : MonoBehaviour
{
    [Header("Target Setup")]
    [Tooltip("Drag your main Canvas object here in the Inspector")]
    public Transform targetCanvas;

    [Header("Positional & Rotational Offsets")]
    [Tooltip("X (Left/Right), Y (Up/Down), Z (Forward/Back) relative to the Canvas")]
    public Vector3 localPositionOffset = new Vector3(0f, -10f, -0.05f); 
    
    [Tooltip("Adjust if the keyboard needs to be tilted relative to the Canvas")]
    public Vector3 localRotationOffset = Vector3.zero;

    void LateUpdate()
    {
        if (targetCanvas != null)
        {
            // Calculates the world position based on the Canvas's local space
            // This ensures the offset respects which way the Canvas is facing
            transform.position = targetCanvas.TransformPoint(localPositionOffset);

            // Matches the Canvas rotation, plus any extra tilt you want to add
            transform.rotation = targetCanvas.rotation * Quaternion.Euler(localRotationOffset);
        }
    }
}