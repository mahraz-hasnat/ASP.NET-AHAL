using AHS.Core;
using AHS.Core.DataAccess;
using AHS.Core.Framework;
using System;
using System.Collections.Generic;
using System.Data;


namespace AHAL.StudentCourse.BO
{
    #region Business Object
    [Serializable, DataTable("student")] //table name

    public class Student : BaseClass
    {
        #region Variables 
        private string _name;   /*column name*/
        private int _age; /*column name*/
        private string _about; /*column name*/
        private int _course_id; /*column name*/
        private Course _course;
        #endregion

        #region Constructor
        public Student()
        {
            this.Initialize(); //initializing all the items from student
            _name = string.Empty;
            _age = 0;
            _about = string.Empty;
            _course_id = 0;
            _course = null;
        }
        #endregion

        #region Properties
        [DataColumn("name", typeof(string))] // properties for each column in the student table
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
                
        [DataColumn("age", typeof(decimal))] // properties for each column in the Student table
        public int age
        {
            get { return _age; }
            set { _age = value; }
        }
        
        [DataColumn("about", typeof(string))] // properties for each column in the student table
        public string about
        {
            get { return _about; }
            set { _about = value; }
        }

        [DataColumn ("course_id", typeof(int))] //Relation between two tables ... Foreign Key
        public int course_id
        {
            get { return _course_id; }
            set { _course_id = value; }
            
            
        }

        [DataColumnIgnore] //Relation between two tables ... Foreign Key
        public Course course
        {
            get
            {
                if (_course == null)
                {
                    List<ParamValue> searchItems = new List<ParamValue>();
                    ParamValue paramValue = new ParamValue("ID", course_id, ComparisonOperator.Equal, JoinOperator.None);
                    searchItems.Add(paramValue);
                    _course = _course.GetData();
                }
                return _course;
            }

        }


        #endregion

        #region Methods
        public void Save()
        {
            StudentService serviceObject = new StudentService();
            serviceObject.Save(this);
        }
        public void Delete()
        {
            StudentService serviceObject = new StudentService();
            serviceObject.Delete(this.ID);
        }

        public Student GetData()
        {
            List<ParamValue> searchItems = new List<ParamValue>();
            ParamValue paramValue = new ParamValue("ID", this.ID, ComparisonOperator.Equal, JoinOperator.None);
            searchItems.Add(paramValue);
            StudentService serviceObject = new StudentService();
            return serviceObject.GetData(searchItems);
        }
        public Student GetData(List<ParamValue> searchItems)
        {
            StudentService serviceObject = new StudentService();
            return serviceObject.GetData(searchItems);
        }
        #endregion
    }
    #endregion

    #region Collection Object
    [Serializable]
    public class StudentCollection : BaseCollection
    {
        #region Constructor
        public StudentCollection()
        {
            base.ClearItem();
        }
        #endregion

        #region Collection Related Methods
        public void Add(Student item)
        {
            base.AddItem(item);
        }
        public void Remove(Student item)
        {
            base.RemoveItem(item);
        }
        public void Remove(int index)
        {
            base.RemoveItem(index);
        }
        public void ClearAll()
        {
            base.ClearItem();
        }
        public Student GetObjectByIndex(int index) //What?, why?
        {
            return (Student)base.GetByIndex(index);
        }
        public Student GetObject(int id) //What?, why?
        {
            return (Student)base.GetItem(id);
        }
        public Student GetObject(Student item) //What?, why?
        {
            return (Student)base.GetItem(item);
        }
        #endregion

        #region Other Methods
        public StudentCollection GetAllData(List<ParamValue> searchItems, List<ParamValue> orderByItems)
        {
            StudentService serviceObject = new StudentService();
            return serviceObject.GetAllData(searchItems, orderByItems);
        }
        public DataSet LoadAllData(List<ParamValue> searchItems, List<ParamValue> orderByItems)
        {
            StudentService serviceObject = new StudentService();
            return serviceObject.LoadAllData(searchItems, orderByItems);
        }
        #endregion
    }
    #endregion
}
