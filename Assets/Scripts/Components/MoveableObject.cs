using UnityEngine;

[RequireComponent(typeof(Mover))]
public class MoveableObject : MonoBehaviour
    {
    protected Mover mover;


    public virtual void Awake()
    {
        mover = GetComponent<Mover>();
    }

 

    public virtual void Update()
    {
        if (GameManager.GameState == GameState.PAUSED) return;
        HandleMove();
    }

    public virtual void HandleMove() { }

   
}

