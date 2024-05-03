using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Menüler
    public GameObject menu;
    public GameObject mainMenu;
    public GameObject game;
    public GameObject gameMenu;
    public GameObject pauseMenu;
    public GameObject onCompletedMenu;
    private IDictionary<string, IMenuItem> menuItems;

    private void Awake()
    {
        menuItems = new Dictionary<string, IMenuItem>
        {
            // Anahtar-deðer çiftlerini oluþtur ve ilgili komutlarý baðlama
            { "startGame", new StartGameCommand(mainMenu,game, gameMenu) },
            { "pauseMenu", new PauseGameCommand(game,pauseMenu) },
            { "retrunHome", new ReturnHome(game,mainMenu) },
            { "nextLevel", new NextLevel(gameMenu ,onCompletedMenu, game) },
            { "continue", new Continue(pauseMenu,game ) },
            { "restart", new Restart( ) },

            // Diðer menü öðeleri
        };
    }

    // Menü öðesine týklandýðýnda çaðrýlan fonksiyon
    public void OnMenuItemClicked(string menuItemKey)
    {
        if (menuItems.ContainsKey(menuItemKey))
        {
            menuItems[menuItemKey].Execute();
        }
    }



    
}
