using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        :base(firstName,lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if(!IsNumberValid(value))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value;
        }
    }

    private bool IsNumberValid(string number)
    {
        string numberPattern = @"^([0-9a-zA-Z]{5,10})$";

        var regex = new Regex(numberPattern);

        var match = regex.Match(number);

        if (match.Success)
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat($@"
First Name: {this.FirstName}
Last Name: {this.LastName}
Faculty number: {this.FacultyNumber}");
        return sb.ToString(); 
    }
}
