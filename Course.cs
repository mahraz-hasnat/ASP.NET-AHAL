using AHS.Core;
using AHS.Core.DataAccess;
using AHS.Core.Framework;
using System;
using System.Collections.Generic;
using System.Data;


namespace AHAL.StudentCourse.BO
{
    #region Business Object
    [Serializable, DataTable("course")] //table name

    public class Course : BaseObject
    {
        #region Variables 
        private string _course_name;   /*column name*/
        private string _course_instructor; /*column name*/
        private int _credit; /*column name*/
        #endregion

        #region Constructor
        public Course()   
        {
            this.Initialize(); //initializing all the items from course
            _course_name = string.Empty; 
            _course_instructor = string.Empty;
            _credit = 0;
        }
        #endregion

        #region Properties
        [DataColumn("course_name", typeof(string))] // properties for each column in the course table
        public string course_name
        {
            get { return _course_name; }
            set { _course_name = value; }
        }
        [DataColumn("course_instructor", typeof(string))] // properties for each column in the course table
        public string course_instructor
        {
            get { return _course_instructor; }
            set { _course_instructor = value; }
        }
        [DataColumn("credit", typeof(int))] // properties for each column in the course table
        public int credit
        {
            get { return _credit; }
            set { _credit = value; }
        }
        #endregion

        #region Methods
        public void Save()
        {
            CourseService serviceObject = new CourseService();
            serviceObject.Save(this);
        }
        public void Delete()
        {
            CourseService serviceObject = new CourseService();
            serviceObject.Delete(this.ID);//Which ID it selects?
        }

        public Course GetData()
        {
            List<ParamValue> searchItems = new List<ParamValue>();
            ParamValue paramValue = new ParamValue("ID", this.ID, ComparisonOperator.Equal, JoinOperator.None);
            searchItems.Add(paramValue);
            CourseService serviceObject = new CourseService();
            return serviceObject.GetData(searchItems);
        }
        public Course GetData(List<ParamValue> searchItems)
        {
            CourseService serviceObject = new CourseService();
            return serviceObject.GetData(searchItems);
        }
        #endregion
    }
    #endregion

    #region Collection Object
    [Serializable]
    public class CourseCollection : BaseCollection
    {
        #region Constructor
        public CourseCollection()
        {
            base.ClearItem();
        }
        #endregion

        #region Collection Related Methods
        public void Add(Course item)
        {
            base.AddItem(item);
        }
        public void Remove(Course item)
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
        public Course GetObjectByIndex(int index) //What?, why?
        {
            return (Course)base.GetByIndex(index);
        }
        public Course GetObject(int id) //What?, why?
        {
            return (Course)base.GetItem(id);
        }
        public Course GetObject(Course item) //What?, why?
        {
            return (Course)base.GetItem(item);
        }
        #endregion

        #region Other Methods
        public CourseCollection GetAllData(List<ParamValue> searchItems, List<ParamValue> orderByItems)
        {
            CourseService serviceObject = new CourseService();
            return serviceObject.GetAllData(searchItems, orderByItems);
        }
        public DataSet LoadAllData(List<ParamValue> searchItems, List<ParamValue> orderByItems)
        {
            CourseService serviceObject = new CourseService();
            return serviceObject.LoadAllData(searchItems, orderByItems);
        }
        #endregion
    }
    #endregion
}
