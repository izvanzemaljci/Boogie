[System.Serializable]
public class Hit
{
    public bool result;
    public string unitID;
    public int timeStamp;

    public Hit(bool result, string unitID, int timeStamp)
    {
        this.result = result;
        this.unitID = unitID;
        this.timeStamp = timeStamp;
    }

}
