using System.Collections.Generic;

namespace WPFExample1
{
    public class MyModel
    {
        public MyModel()
        {
            InitPersonList();
        }

        public List<Person> PersonList { get; set; }

        private void InitPersonList()
        {
            PersonList = new List<Person>();
            PersonList.Add(new Person(){FirstName = "code f1", LastName = "code l1", Tel = "code t1"});
            PersonList.Add(new Person(){FirstName = "code f2", LastName = "code l2", Tel = "code t2"});
            PersonList.Add(new Person(){FirstName = "code f3", LastName = "code l3", Tel = "code t3"});
        }
    }
}