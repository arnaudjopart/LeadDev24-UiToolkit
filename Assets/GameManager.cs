using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public float m_score;
    [SerializeField] private UIDocument document;
    [SerializeField] private VisualTreeAsset _template;
    private VisualElement _root;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _root = document.rootVisualElement;
        _root.Q<PlayerDataVisualizer>().dataSource = this;
        _root.Q<VisualElement>("TestVisual").AddToClassList("testVisual");
        var container = _template.Instantiate();
        _root.Add(container);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
