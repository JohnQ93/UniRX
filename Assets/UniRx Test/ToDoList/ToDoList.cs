using UniRx;
using System.Collections.Generic;
using System;

namespace UniRxLesson
{
    /// <summary>
    /// 待办事项
    /// </summary>
    [Serializable]
    public class ToDoItem
    {
        /// <summary>
        /// The identifier
        /// </summary>
        public int Id;

        /// <summary>
        /// 内容
        /// </summary>
        public StringReactiveProperty Content;

        /// <summary>
        /// 是否完成
        /// </summary>
        public BoolReactiveProperty Completed;

    }

    [Serializable]
    public class ToDoList
    {

        public List<ToDoItem> ToDoItems = new List<ToDoItem>()
        {
            new ToDoItem
            {
                Id = 0,
                Content = new StringReactiveProperty("我想要mac pro..."),
                Completed = new BoolReactiveProperty(false)
            },
            new ToDoItem
            {
                Id = 1,
                Content = new StringReactiveProperty("Happy Birthday To Me"),
                Completed = new BoolReactiveProperty(false)
            }
        };
    }
}

