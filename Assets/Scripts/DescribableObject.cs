using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescribableObject : ScriptableObject, IDescribable
{
    [SerializeField] Sprite Icon;
    [SerializeField] string objectName;
    [TextArea(3, 3)]
    [SerializeField] string description;

    public Sprite GetIcon => Icon;

    public string GetName => objectName;

    public string GetDescription => description;
}
