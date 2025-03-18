using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] Button editImageButton;
    [SerializeField] Button gradientButton;
    [SerializeField] Button paintFrameButton;
    [SerializeField] Button localDataTestButton;
    [SerializeField] Button sequenceButton;
    [SerializeField] Button goMainButton;

    void Start()
    {
        editImageButton.onClick.AddListener(GoEditImage);
        gradientButton.onClick.AddListener(GoGradient);
        paintFrameButton.onClick.AddListener(GoPaintFrame);
        localDataTestButton.onClick.AddListener(GoLocalData);
        sequenceButton.onClick.AddListener(GoSequence);

        goMainButton.onClick.AddListener(GoMain);
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        bool isMain = SceneManager.GetActiveScene().name != "MainScene";

        editImageButton.gameObject.SetActive(!isMain);
        gradientButton.gameObject.SetActive(!isMain);
        paintFrameButton.gameObject.SetActive(!isMain);
        localDataTestButton.gameObject.SetActive(!isMain);
        sequenceButton.gameObject.SetActive(!isMain);

        goMainButton.gameObject.SetActive(isMain);
    }

    void GoEditImage()
    {
        SceneManager.LoadScene("EditImage");
    }

    void GoGradient()
    {
        SceneManager.LoadScene("UI Gradient");
    }

    void GoPaintFrame()
    {
        SceneManager.LoadScene("UI Paint");
    }

    void GoLocalData()
    {
        SceneManager.LoadScene("LocalData");
    }

    void GoSequence()
    {
        SceneManager.LoadScene("Sequence");
    }

    void GoMain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
