using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public List<BasePanel> registeredPanels;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void RegisterPanel(BasePanel panel)
    {
        if (!registeredPanels.Contains(panel))
        {
            registeredPanels.Add(panel);
        }
    }
    public void OpenPanel(string panelName)
    {
        BasePanel panel = registeredPanels.Find(p => p.name == panelName);
        if (panel != null)
        {
            panel.OpenPanel();
        }
        else
        {
            Debug.LogWarning($"Panel with name {panelName} not found.");
        }
    }
    public void ClosePanel(string panelName)
    {
        BasePanel panel = registeredPanels.Find(p => p.name == panelName);
        if (panel != null)
        {
            panel.ClosePanel();
        }
        else
        {
            Debug.LogWarning($"Panel with name {panelName} not found.");
        }
    }
    public void CloseAllPanels()
    {
        foreach (BasePanel panel in registeredPanels)
        {
            panel.ClosePanel();
        }
    }
}
