using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForTheFutureButtons : MonoBehaviour
{
    [SerializeField] private Controller controller;
    [SerializeField] private MenusController menusController;
    [SerializeField] private string text;

    public virtual void ButtonMethod()
    {
        menusController.OpenFutureMenu(text);
    }
}
