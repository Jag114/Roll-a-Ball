using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public enum Dimension
    {
        Dark,
        Light
    }
    public Dimension dimension = Dimension.Dark;
    public int doorID;

    public void Interact(Collider player)
    {
        player.GetComponent<Player>()?.AddToInventory(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        Interact(other);
    }

}
