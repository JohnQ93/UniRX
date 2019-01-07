using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQGroupByExample : MonoBehaviour {

    public class Student
    {
        public string Name;
        public int Age;
    }

    void Start () {
        var students = new List<Student>
        {
            new Student{Name = "zhangsan",Age = 18},
            new Student{Name = "lisi",Age = 19},
            new Student{Name = "lalalal",Age = 28},
            new Student{Name = "hahahahah",Age = 18},
            new Student{Name = "superman",Age = 18},
            new Student{Name = "perfect",Age = 19},
            new Student{Name = "wonderful",Age = 24},
            new Student{Name = "excellent",Age = 24},
            new Student{Name = "lenguage",Age = 28}
        };

        students.GroupBy(student => student.Age)
                .ToList()
                .ForEach(studentGroup =>
                {
                    studentGroup.ToList()
                                .ForEach(student =>
                                {
                                    Debug.LogFormat("GroupBy:{0}, name:{1},age:{2}", studentGroup.Key, student.Name, student.Age);
                                });
                });

        //(from student in students
        //group student by student.Age into studentGroup
        //select studentGroup).ToList()
                            //.ForEach(studentGroup =>
                            //{
                            //    studentGroup.ToList()
                            //                .ForEach(student =>
                            //                {
                            //                    Debug.LogFormat("GroupBy:{0}, name:{1},age:{2}", studentGroup.Key, student.Name, student.Age);
                            //                });
                            //});


    }
}
