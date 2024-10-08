using System;
using TMPro;
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

    public static GameManager Instance;

    public int foundObjAmount;
    public int maxObj;

    public TextMeshPro amountObjText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        babyLock = FindObjectOfType<BabyLock>();

        UpdateAmountItemText();
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

    #region count items

    public void FoundItemIncrease()
    {
        foundObjAmount++;
        UpdateAmountItemText();
    }

    private void UpdateAmountItemText()
    {
        amountObjText.text = $"{foundObjAmount} / {maxObj} Object Found.";
    }

    #endregion
}
