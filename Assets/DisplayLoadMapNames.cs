using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLoadMapNames : MonoBehaviour
{
    MenusController menusController;

    [SerializeField]
    private GameObject buttonPrefab;
    [SerializeField]
    private GameObject viewPortContent;
    [SerializeField]
    private List<GameObject> loadMapButtons;

    public void SetMenusController(MenusController menusController) 
    {
        this.menusController = menusController;
    }

    public void CreateButton(string[] buttonNames) 
    {
        for (int i = 0; i < buttonNames.Length; i++)
        {
            loadMapButtons.Add(Instantiate(buttonPrefab, viewPortContent.transform));
            loadMapButtons[i].GetComponent<LoadButton>().SetupLoadButton(i,menusController, buttonNames[i]);

        }
    }

    public void ResetButtonList() 
    {
        while (loadMapButtons.Count > 0)
        {
            GameObject button = loadMapButtons[0];
            loadMapButtons.RemoveAt(0);
            Destroy(button);
        }
    }
}
