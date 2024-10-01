using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestScene : MonoBehaviour
{
    ContactService contactService;

    public GameObject myText;

    // Start is called before the first frame update
    void Start()
    {
        contactService = new ContactService();
        myText = GameObject.Find("Output");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ToConsole(IEnumerable<Contact> contacts)
    {
        foreach (var contact in contacts)
        {
            ToConsole(contact.ToString());
        }
    }

    private void ToConsole(string msg)
    {
        Debug.Log(msg);
    }

    public void onContactTableButtonClick()
    {
        Debug.Log("onContactTableButtonClick----------");
        contactService.CreateContactTable();
        Output();
    }

    public void onAddContactButtonClick()
    {
        Debug.Log("onAddContactButtonClick----------");
        Contact contact = new Contact
        {
            Name = "lol",
            Surname = "lolov",
            Age = 1,
            Mobile = "3435",
            Email = "ferg",
            City = "Moscow"
        };

        int pk = contactService.AddContact(contact);

        Debug.Log("Primary Key = " + pk);
        Output();
    }

    public void onAddContactsButtonClick()
    {
        Debug.Log("onAddContactsButtonClick----------");
        Contact[] contacts = new[] {
            new Contact
            {
                Name = "loejlijil",
                Surname = "loltyjgyjgjyov",
                Age = 1467,
                Mobile = "34gyjgyj35",
                Email = "fegyjgyjrg",
                City = "Moscogyjgyjgyw"
            },
            new Contact
            {
                Name = "tt",
                Surname = "ttt",
                Age = 56,
                Mobile = "tttttt",
                Email = "ttttttttttttt",
                City = "ttttt"
            }
        };
        int val = contactService.AddContacts(contacts);

        Debug.Log("Return Value = " + val);
        Output();
    }

    public void onGetContactsButtonClick()
    {
        var contacts = contactService.GetContacts();
        ToConsole(contacts);
    }

    public void onGetContactsByNameButtonClick()
    {
        var contacts = contactService.GetContacts("tt");
        ToConsole(contacts);
    }

    public void onGetContactByNameButtonClick()
    {
        var contact = contactService.GetContact("tt");
        ToConsole(contact.ToString());
    }

    public void onDeleteContactButtonClick()
    {
        Debug.Log("onDeleteContactButtonClick----------");
        Contact contact = new Contact
        {
            Id = 7
        };

        int val = contactService.DeleteContact(contact);

        Debug.Log("Return Value= " + val);
        Output();
    }

    public void onUpdateContactButtonClick()
    {
        Debug.Log("onUpdateContactButtonClick----------");
        Contact contact = new Contact
        {
            Id = 5,
            Name = "jjj",
            Surname = "tjjjtt",
            Age = 56,
            Mobile = "tttjjjjttt",
            Email = "jjjj",
            City = "jjj"
        };

        int val = contactService.UpdateContact(contact);

        Debug.Log("Return Value= " + val);
        Output();
    }

    public void onUpdateAllContactsButtonClick()
    {
        Debug.Log("onUpdateAllContactsButtonClick----------");
        Contact[] contacts = new[] {
            new Contact
            {
                Id = 5,
                Name = "1111",
                Surname = "1111",
                Age = 1111,
                Mobile = "111",
                Email = "111",
                City = "1111"
            },
            new Contact
            {
                Id = 6,
                Name = "2222",
                Surname = "2222",
                Age = 2222,
                Mobile = "2222",
                Email = "2222",
                City = "2222"
            }
        };

        int val = contactService.UpdateContacts(contacts);

        Debug.Log("Return Value= " + val);
        Output();
    }

    private void Output()
    {
        var contacts = contactService.GetContacts();
        string res = "";
        foreach (var contact in contacts)
        {
            res = res + contact.ToString() + "\n";
        }
        myText.GetComponent<TextMeshPro>().text = res;
    }
}
