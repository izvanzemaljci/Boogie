[System.Serializable]
public class Beat
{
    public string unitID;
    public float time;

    public Unit Unit => UnitController.I.GetUnitById(unitID);
}
