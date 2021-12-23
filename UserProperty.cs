using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class UserProperty: System.ComponentModel.INotifyPropertyChanged//System.ComponentModel.INotifyPropertyChanged : 바인딩 = 데이터 실시간 적용
    {
        //바인딩 시작
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void Notify(string propertyName)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        //바인딩 끝
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name == value) { return; }
                name = value;
                Notify("Name");//바인딩 대상
            }
        }
        private int age;



        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (age == value) { return; }
                age = value;
                Notify("Age");//바인딩 대상
            }
        }
        public UserProperty() { }
        public UserProperty(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
