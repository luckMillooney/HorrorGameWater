using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] TMP_Text creditsText;
    [SerializeField] GameObject playText;
    [SerializeField] GameObject settingsText;
    [SerializeField] GameObject quitText;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject settingsButton;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject creditsInfo;
    [SerializeField] Animator cameraAnim;
    private bool _isInCredits;

    private void Update()
    {
        if (_isInCredits && Input.GetKeyDown(KeyCode.Escape))
        {
            creditsEnter();
        }    
    }

    public void creditsEnter()
    {
        if (!_isInCredits)
        {
            cameraAnim.Play("credits_enter");
            _isInCredits = true;
            creditsText.text = "back";
            playButton.SetActive(false);
            settingsButton.SetActive(false);
            quitButton.SetActive(false);
            playText.SetActive(false);
            settingsText.SetActive(false);
            quitText.SetActive(false);
        } else
        {
            cameraAnim.Play("credits_exit");
            _isInCredits = false;
            creditsText.text = "credits";
            creditsInfo.SetActive(false);
        }
    }

    public void creditsReveal()
    {
        if (_isInCredits)
        {
            creditsInfo.SetActive(true);
        } else
        {
            playButton.SetActive(true);
            settingsButton.SetActive(true);
            quitButton.SetActive(true);
            playText.SetActive(true);
            settingsText.SetActive(true);
            quitText.SetActive(true);
        }
    }

    public void doExitGame()
    {
        Application.Quit();
    }

    public void doPlay()
    {
        SceneManager.LoadScene("Underwater-FIRST");
    }
}
