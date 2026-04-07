using UnityEngine;

public abstract class BasePanel : MonoBehaviour
{
    public void RegisterPanel()
    {
        UIManager.Instance.RegisterPanel(this);
    }
    public virtual void OpenPanel()
    {
        gameObject.SetActive(true);
    }
    public virtual void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
