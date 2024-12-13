using UnityEngine;

public class OldItem : MonoBehaviour
{
    public enum Dimension
    {
        Dark,
        Light
    }
    public Dimension dimension = Dimension.Dark;
    public int doorID;

    public OldItem(int doorID)
    {
        this.doorID = doorID;
    }

    public void ReverseDimension()
    {
        if(dimension == Dimension.Dark)
        {
            dimension = Dimension.Light;
        }
        else
        {
            dimension = Dimension.Dark;
        }
    }

    public bool OpenDoor(OldItem door)
    {
        if(door.doorID == doorID)
        {
            return true;
        }
        return false;
    }
}
