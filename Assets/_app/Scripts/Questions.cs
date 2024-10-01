using SQLite4Unity3d;

public class Questions
{

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int IdLvl { get; set; }
    public string Question { get; set; }
    public string Answer1 { get; set; }
    public string Answer2 { get; set; }
    public string Answer3 { get; set; }
    public string Answer4 { get; set; }
    public string RightAnswer { get; set; }

    public override string ToString()
    {
        return string.Format("[Questions: Id={0}, IdLvl={1},  Question={2}, Answer1={3}, Answer2={4},  Answer3={5}, Answer4={6}, rightAnser={7}]", Id, IdLvl, Question, Answer1, Answer2, Answer3, Answer4, RightAnswer);
    }
}
