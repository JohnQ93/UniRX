using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class LINQWhereExample : MonoBehaviour {

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

        students.Where(student => student.Age > 15)
                .ToList()
                .ForEach(student =>
                {
                    Debug.Log(student.Name);
                });

        (from student in students where student.Age > 15 select student)
                .ToList()
                .ForEach(student =>
                {
                    Debug.Log(student.Name);
                });                                                     
    }
}
