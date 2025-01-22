using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] Button editImageButton;
    [SerializeField] Button gradientButton;
    [SerializeField] Button paintFrameButton;
    [SerializeField] Button goMainButton;

    void Start()
    {
        editImageButton.onClick.AddListener(GoEditImage);
        gradientButton.onClick.AddListener(GoGradient);
        paintFrameButton.onClick.AddListener(GoPaintFrame);
        goMainButton.onClick.AddListener(GoMain);

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "EditImage"||
            SceneManager.GetActiveScene().name == "UI Gradient" ||
            SceneManager.GetActiveScene().name == "UI Paint")
        {
            editImageButton.gameObject.SetActive(false);
            gradientButton.gameObject.SetActive(false);
            paintFrameButton.gameObject.SetActive(false);

            goMainButton.gameObject.SetActive(true);
        }
        else
        {
            editImageButton.gameObject.SetActive(true);
            gradientButton.gameObject.SetActive(true);
            paintFrameButton.gameObject.SetActive(true);

            goMainButton.gameObject.SetActive(false);
        }
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

    void GoMain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
