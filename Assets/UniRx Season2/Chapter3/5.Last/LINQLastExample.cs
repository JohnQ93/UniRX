using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQLastExample : MonoBehaviour {

    class Student
    {
        public string Name;
        public int Age;
    }

    void Start()
    {
        var students = new List<Student>()
        {
            new Student{ Name = "仇一", Age = 18},
            new Student{ Name = "仇二", Age = 18},
            new Student{ Name = "仇三", Age = 10},
        };

        var newStudent = students.Last(student => student.Age > 10);
        Debug.Log(newStudent.Name);
    }
}
