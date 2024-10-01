using SQLite4Unity3d;

public class Contact
{

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string City { get; set; }

    public override string ToString()
    {
        return string.Format("[Contact: Id={0}, Name={1},  Surname={2}, Age={3}, Mobile={4},  Email={5}, City={6}]", Id, Name, Surname, Age, Mobile, Email, City);
    }
}
