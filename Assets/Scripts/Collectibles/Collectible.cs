using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour, IInteractable
{
    public abstract void Interact();
    
}
