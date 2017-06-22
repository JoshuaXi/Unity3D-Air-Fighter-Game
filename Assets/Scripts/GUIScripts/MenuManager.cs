using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MenuManager : MonoBehaviour {
    public MenuList menus;

    public enum MenuList{
    mainmenu,options,ingame,gameover,shop
    }

    List<string>currentMenus;

     string[] menuItemsArray;
     List<string> menuItemsList;

    public GameObject[] menuObjects;

    public static MenuManager instance;
    public MenuList StartMenu;
	// Use this for initialization
	void Awake () {
        instance = this;
        MapMenuIndexes();
        CloseAll();
        SetDefault(StartMenu.ToString());
	}

    public void CloseAll() {
        foreach (GameObject menuItems in menuObjects) {
            menuItems.SetActive(false);
        }
        currentMenus.Clear();
    }

    void MapMenuIndexes() {

        menuItemsArray = System.Enum.GetNames(typeof(MenuList));
        menuItemsList = new List<string>(menuItemsArray.Length - 1);
        for (int i = 0;i<=menuItemsArray.Length-1;i++) {
            menuItemsList.Add(menuItemsArray[i]);
        }
        currentMenus = new List<string>();
    }

    void SetDefault(string defaultMenu) {

        Open(defaultMenu);
    }


    public void Open(string menu) {

        int index = menuItemsList.IndexOf(menu);
        GameObject menuObject = menuObjects[index];

        if (menuObject.activeInHierarchy == false) {
            menuObject.SetActive(true);
        }

        if (currentMenus.Contains(menu) == false) { 
            currentMenus.Add(menu);
        }

    }

    public void CloseByName(string menu) {

        int index = menuItemsList.IndexOf(menu);
        CloseAt(index);
    }



    public void CloseAt(int index)
    {
        GameObject menuObject = menuObjects[index];
        if (menuObject.activeInHierarchy == true)
        {
            currentMenus.RemoveAt(index);

            menuObjects[index].SetActive(false);
        }

    }

    public void CloseFirst() {
        int index = 0;
        CloseAt(index);
        
    }
    public void CloseLast()
    {
        int index = currentMenus.Count-1;
        CloseAt(index);

    }




}
