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

    /// <summary>
    /// Defines menusController reference variable
    /// </summary>
    /// <param name="menusController"></param>
    public void SetMenusController(MenusController menusController) 
    {
        this.menusController = menusController;
    }

    /// <summary>
    /// Instatiates a new Load Button and adds it to a List
    /// </summary>
    /// <param name="buttonNames"></param>
    public void CreateButton(string[] buttonNames) 
    {
        for (int i = 0; i < buttonNames.Length; i++)
        {
            loadMapButtons.Add(Instantiate(buttonPrefab, viewPortContent.transform));
            loadMapButtons[i].GetComponent<LoadButton>().SetupLoadButton(i,menusController, buttonNames[i]);

        }
    }

    /// <summary>
    /// Removes Load Buttons from List
    /// </summary>
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
