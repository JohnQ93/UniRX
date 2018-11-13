using UniRx;

namespace UniRxLesson
{
    /// <summary>
    /// 待办事项
    /// </summary>
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

    public class ToDoList
    {

        public ReactiveCollection<ToDoItem> ToDoItems = new ReactiveCollection<ToDoItem>()
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

