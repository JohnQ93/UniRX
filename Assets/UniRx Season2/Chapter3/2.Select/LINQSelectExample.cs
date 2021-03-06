﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class LINQSelectExample : MonoBehaviour {

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
                .Select(student => student.Name)
                .ToList()
                .ForEach(studentName =>
                {
                    Debug.Log(studentName);
                });

        (from student in students where student.Age > 15 select student.Name)
                .ToList()
                .ForEach(studentName =>
                {
                    Debug.Log(studentName);
                });
    }
}
