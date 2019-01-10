using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class LINQToArrayExample : MonoBehaviour {
    
    public class Student
    {
        public string Name;
        public int Age;
    }

	void Start () {
        var students = new Student[]
        {
            new Student{Name = "张三",Age = 18},
            new Student{Name = "李四",Age = 28},
            new Student{Name = "王五",Age = 11},
        };

        var studentArray = students.ToArray();
        Array.ForEach(studentArray, student => Debug.Log(student.Name));
	}
}
