public class rune
{
    private int _taken; // a counter for how many of this type of powerup is taken
    private int _increase; // a value that the powerup increases something by
    private string _name;

    public rune(string name, int taken, int increase)
    {
        this._taken = taken;
        this._name = name;
        this._increase = increase;
    }

    public int GetTaken()
    {
        return this._taken;
    }

    public void SetTaken(int newTaken)
    {
        this._taken = newTaken;
    }

    public int GetIncrease()
    {
        return this._increase;
    }
}
