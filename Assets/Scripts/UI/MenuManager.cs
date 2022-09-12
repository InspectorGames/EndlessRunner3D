using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuManager 
{
    public static bool IsInitialized { get; private set; }
    public static GameObject mainMenu, settingsMenu, shopMenu;

    public static void Init()
    {
        GameObject canvas = GameObject.Find("Canvas");  
        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        settingsMenu = canvas.transform.Find("SettingsMenu").gameObject;
        shopMenu = canvas.transform.Find("ShopMenu").gameObject;

        IsInitialized = true;
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        if (!IsInitialized) Init();

        switch (menu)
        {
            case Menu.MainMenu:
                mainMenu.SetActive(true);
                break;
            case Menu.Shop:
                shopMenu.SetActive(true);
                break;
            case Menu.Settings:
                settingsMenu.SetActive(true);
                break;
        }

        callingMenu.SetActive(false);
    }

    public static void SceneChanged()
    {
        IsInitialized = false;
    }
}
