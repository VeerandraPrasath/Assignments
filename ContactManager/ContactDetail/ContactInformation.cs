﻿
public class ContactInformation
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    public ContactInformation(string name, string email, string phone, string address)
    {
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;

    }
    public override string ToString()
    {
        return $"Name :{Name} , Email :{Email} ,Phone :{Phone} ,Address :{Address}";
    }




}
