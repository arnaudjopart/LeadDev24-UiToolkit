using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor((typeof(Champion)))]
public class ChampionInspector : Editor
{
    [SerializeField] private VisualTreeAsset m_visualTreeAsset;
    private VisualElement m_portraitVisualElement;
    private EnumField m_classType;

    public override VisualElement CreateInspectorGUI()
    {
        var championScript = target as Champion;
        
        var myInspector = new VisualElement();
        m_visualTreeAsset.CloneTree(myInspector);
        
        var defaultInspector = myInspector.Q<Foldout>("DefaultInspector_FoldOut");
        InspectorElement.FillDefaultInspector(defaultInspector,serializedObject,this);

        m_portraitVisualElement = myInspector.Q<VisualElement>("Portrait_VisualElement");
        var portraitObjectField = myInspector.Q<ObjectField>("Portrait_ObjectField");

        m_classType = myInspector.Q<EnumField>("TypeOfClass_Enum");
        var hasClassToggle = myInspector.Q<Toggle>("HasClass_Toggle");

        hasClassToggle.RegisterValueChangedCallback(OnHasClassToggleValueChange);
        portraitObjectField.RegisterValueChangedCallback(OnUpdatePortrait);
        
        if (championScript != null)
        {
            m_classType.style.display = championScript.m_hasAClass ? DisplayStyle.Flex : DisplayStyle.None;
            if (championScript.m_portraitSprite != null)
                m_portraitVisualElement.style.backgroundImage = new StyleBackground(championScript.m_portraitSprite);
        }
        
        return myInspector;
    }

    private void OnHasClassToggleValueChange(ChangeEvent<bool> evt)
    {
        var result = evt.newValue;
        m_classType.style.display = result ? DisplayStyle.Flex : DisplayStyle.None;
    }

    private void OnUpdatePortrait(ChangeEvent<Object> evt)
    {
        var sprite = evt.newValue as Sprite;
        m_portraitVisualElement.style.backgroundImage = new StyleBackground(sprite);
    }
}
