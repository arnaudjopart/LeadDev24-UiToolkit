using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

[UxmlElement]
public partial class PlayerDataVisualizer : VisualElement
{
    [UxmlAttribute,CreateProperty]
    public float ScoreProperty;
}
