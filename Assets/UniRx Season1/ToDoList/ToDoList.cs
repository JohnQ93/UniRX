using UniRx;
using System.Collections.Generic;
using System;
using UnityEngine;

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
        private int mTopId = 2;

        public void Add(string text)
        {
            ToDoItems.Add(new ToDoItem()
            {
                Id = mTopId,
                Content = new StringReactiveProperty(text),
                Completed = new BoolReactiveProperty(false)
            });
            mTopId++;
        }

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

        public void Save()
        {
            PlayerPrefs.SetString("model", JsonUtility.ToJson(this));
        }

        internal static ToDoList Load()
        {
            var jsonContent = PlayerPrefs.GetString("model", string.Empty);
            if (string.IsNullOrEmpty(jsonContent))
            {
                return new ToDoList();
            }
            else
            {
                return JsonUtility.FromJson<ToDoList>(jsonContent);
            }
        }
    }
}

