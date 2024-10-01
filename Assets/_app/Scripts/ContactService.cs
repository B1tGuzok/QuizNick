using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactService
{
    DB dB;

    public ContactService()
    {
        dB = new DB();
    }

    public void CreateContactTable()
    {
        dB.GetConnection().DropTable<Contact>();
        dB.GetConnection().CreateTable<Contact>();
    }

    public int AddContact(Contact contact)
    {
        return dB.GetConnection().Insert(contact);
    }

    public int AddContacts(Contact[] contacts)
    {
        return dB.GetConnection().InsertAll(contacts);
    }

    public IEnumerable<Contact> GetContacts()
    {
        return dB.GetConnection().Table<Contact>();
    }

    public IEnumerable<Contact> GetContacts(string name)
    {
        return dB.GetConnection().Table<Contact>().Where(x => x.Name == name);
    }

    public Contact GetContact(string name)
    {
        return dB.GetConnection().Table<Contact>().Where(x => x.Name == name).FirstOrDefault();
    }

    public int DeleteContact(Contact contact)
    {
        return dB.GetConnection().Delete(contact);
    }

    public int UpdateContact(Contact contact)
    {
        return dB.GetConnection().Update(contact);
    }

    public int UpdateContacts(Contact[] contacts)
    {
        return dB.GetConnection().UpdateAll(contacts);
    }
}
