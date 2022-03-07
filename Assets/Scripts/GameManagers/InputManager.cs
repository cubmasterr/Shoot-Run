using System;
using UnityEngine.EventSystems;

public class InputManager : Singleton<InputManager>,IPointerClickHandler
{
    public  Action OnClic;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClic?.Invoke();
    }
}