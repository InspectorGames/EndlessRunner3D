using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public void OnClick_MainMenu()
    {
        MenuManager.OpenMenu(Menu.MainMenu, this.gameObject);
    }
}
