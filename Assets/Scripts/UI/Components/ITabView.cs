using System.Collections;
using System.Collections.Generic;
using UI.Components;
using UnityEngine;

public interface ITabView
{
    TabViewButton TabViewButton { get; }
    GameObject TabViewContent { get; set; }
    bool IsSelected { get; set; }
    void Show();
    void Hide();

}
