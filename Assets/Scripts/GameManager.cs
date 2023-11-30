using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Children")]
    [SerializeField] private GameObject realBaby;
    [SerializeField] private Transform babyInstancePoint;
    [SerializeField] private bool alreadyInstance;
    private BabyLock babyLock;
    
    // Start is called before the first frame update
    void Start()
    {
        babyLock = FindObjectOfType<BabyLock>();
    }

    // Update is called once per frame
    void Update()
    {
        InstanceBaby();
    }

    void InstanceBaby()
    {
        if (babyLock == null && !alreadyInstance)
        {
            alreadyInstance = true;
            GameObject baby = Instantiate(realBaby, babyInstancePoint.position, quaternion.identity);
            baby.transform.Rotate(0f, -180f, 0f);
        }
    }


    public void EndGame()
    {
        Invoke("ReloadScene",5);
    }

    public void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
