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

    [SerializeField]
    private GameObject door;

    public void Interact(Collider player)
    {
        player.GetComponent<PlayerController>()?.AddToInventory(this);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider player)
    {
        Interact(player);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerController>().OpenDoor(door, doorID);
    }

}
