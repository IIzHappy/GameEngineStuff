using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected abstract void OnTriggerEnter2D(Collider2D collision);
}
