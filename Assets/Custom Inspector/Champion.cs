using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Champion : MonoBehaviour
{
    public enum Type
    {
        Knight,
        Priest,
        Thief,
        Hunter
    }
    
    [SerializeField] private string m_name;
    public Sprite m_portraitSprite;
    public bool m_hasAClass;
    [SerializeField] private Type m_type;
    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }
    
    public void Attack()
    {
        m_animator.SetTrigger("AttackTrigger");
    }
}
