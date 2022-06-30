using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance { get; private set; }

    [Header("Tutorial")]
    [SerializeField] private GameObject sText = default;
    [SerializeField] private GameObject dText = default;
    [SerializeField] private GameObject aText = default;
    [SerializeField] private GameObject rightText = default;
    [SerializeField] private GameObject leftText = default;
    [SerializeField] private GameObject duckText = default;
    [SerializeField] private GameObject spaceText = default;
    [SerializeField] private GameObject jumpText = default;
    [SerializeField] private GameObject eText = default;
    [SerializeField] private GameObject openText = default;
    [Header("HUD")]
    [SerializeField] private TextMeshProUGUI starsScore = default;
    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        starsScore.text = score.ToString();
    }

    public void MoveTutorialOn()
    {
        sText.SetActive(true);
        dText.SetActive(true);
        aText.SetActive(true);
        rightText.SetActive(true);
        leftText.SetActive(true);
        duckText.SetActive(true);
    }

    public void MoveTutorialOff()
    {
        sText.SetActive(false);
        dText.SetActive(false);
        aText.SetActive(false);
        rightText.SetActive(false);
        leftText.SetActive(false);
        duckText.SetActive(false);
    }

    public void JumpTutorialOn()
    {
        spaceText.SetActive(true);
        jumpText.SetActive(true);
    }

    public void JumpTutorialOff()
    {
        spaceText.SetActive(false);
        jumpText.SetActive(false);
    }

    public void OpenChest()
    {
        eText.SetActive(true);
        openText.SetActive(true);
    }

    public void OpenChestOff()
    {
        eText.SetActive(false);
        openText.SetActive(false);
    }

    public void Star()
    {
        score++;
    }
}
