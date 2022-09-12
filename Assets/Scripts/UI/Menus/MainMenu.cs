using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI coinsText;

    private void Start()
    {
        coinsText.text = "Coins: "+PlayerData.Instance.coins;
    }

    public void OnClick_Play()
    {
        MenuManager.SceneChanged();
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClick_Shop()
    {
        MenuManager.OpenMenu(Menu.Shop, this.gameObject);
    }

    public void OnClick_Settings()
    {
        MenuManager.OpenMenu(Menu.Settings, this.gameObject);
    }


    public void OnClick_Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
