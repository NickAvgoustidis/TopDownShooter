using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDescribable
{
    Sprite GetIcon { get; }
    string GetName { get; }
    string GetDescription { get; }
}
