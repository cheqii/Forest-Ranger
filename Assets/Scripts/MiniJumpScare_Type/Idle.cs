using UnityEngine;

public class Idle : MonoBehaviour
{
    // Put this script to "MiniJumpScare_Idle" GameObject
    [SerializeField] private float idleDuration = 2f;

    private void Start()
    {
        Destroy(gameObject, idleDuration);
    }
}