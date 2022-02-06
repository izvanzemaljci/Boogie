[System.Serializable]
public class Beat
{
    public string UnitID;
    public float Time;

    public Unit Unit => UnitController.I.GetUnitById(UnitID);
}
