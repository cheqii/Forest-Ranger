using UnityEngine;

public class Walkthrough : MonoBehaviour
{
    // Put this script to "MiniJumpScare_Walkthrough" GameObject
    [SerializeField] private float walkDuration = 1f;
    [SerializeField] private float speed = 20f;
    [SerializeField] private AxisToMove axisToMove = AxisToMove.X;

    [HideInInspector]
    public enum AxisToMove
    {
        X,
        Z
    }

    private void Start()
    {
        Destroy(gameObject, walkDuration);
    }

    private void Update()
    {
        if (axisToMove == AxisToMove.X)
        {
            MoveObject(speed, 0f, 0f);
        }
        else if (axisToMove == AxisToMove.Z)
        {
            MoveObject(0f, 0f, speed);
        }
    }

    private void MoveObject(float x, float y, float z)
    {
        transform.Translate(new Vector3(x, y, z) * Time.deltaTime);
    }
}