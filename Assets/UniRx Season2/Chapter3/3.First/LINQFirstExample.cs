using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UniRx;

public class LINQFirstExample : MonoBehaviour {

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

        var newStudent = students.First(student => student.Age < 15);
        Debug.Log(newStudent.Name);
    }
}
