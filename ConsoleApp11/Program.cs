using System.Xml.Serialization;

var microsoft = new Company("Microsoft");
var google = new Company("Google");

Person[] people = new Person[]
{
    new Person("Tom", 37, microsoft),
    new Person("Bob", 41, google)
};

XmlSerializer formatter = new XmlSerializer(typeof(Person[]));

using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
{
    formatter.Serialize(fs, people);
}

using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
{
    Person[]? newpeople = formatter.Deserialize(fs) as Person[];

    if (newpeople != null)
    {
        foreach (Person person in newpeople)
        {
            Console.WriteLine($"Name: {person.Name}");
            Console.WriteLine($"Age: {person.Age}");
            Console.WriteLine($"Company: {person.Company.Name}");
        }
    }
}

public class Company
{
    public string Name { get; set; } = "Undefined";

    
    public Company() { }

    public Company(string name) => Name = name;
}
public class Person
{
    public string Name { get; set; } = "Undefined";
    public int Age { get; set; } = 1;
    public Company Company { get; set; } = new Company();

    public Person() { }
    public Person(string name, int age, Company company)
    {
        Name = name;
        Age = age;
        Company = company;
    }
}