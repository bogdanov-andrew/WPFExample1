using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WPFExample1
{
    public class MyModel : INotifyPropertyChanged 
    {
        private string _exampleText = "test text";

        public MyModel()
        {
            InitPersonList();
            TestCommand = new DelegateCommand(TestAction, CanExecuteFunc);
        }

        private bool CanExecuteFunc()
        {
            //return true;
            return !_textButtonAlreadyPressed;
        }


        private bool _textButtonAlreadyPressed = false;
        private void TestAction()
        {
            ExampleText = DateTime.Now.ToLongTimeString();
            _textButtonAlreadyPressed = true;
        }

        public string ExampleText
        {
            get { return _exampleText; }
            set
            {
                _exampleText = value;
                OnPropertyChanged();
            }
        }

        public List<Person> PersonList { get; set; }

        public ICommand TestCommand { get; set; }

        private void InitPersonList()
        {
            PersonList = new List<Person>();
            PersonList.Add(new Person(){FirstName = "code f1", LastName = "code l1", Tel = "code t1"});
            PersonList.Add(new Person(){FirstName = "code f2", LastName = "code l2", Tel = "code t2"});
            PersonList.Add(new Person(){FirstName = "code f3", LastName = "code l3", Tel = "code t3"});
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}