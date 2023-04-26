using AHS.Core;
using AHS.Core.Framework;
using AHS.Core.Utility;
using System;
using System.Collections.Generic;
using System.Data;

namespace AHAL.StudentCourse.BO
{
    #region Service Object
    [Serializable]
    internal sealed class CourseService : BaseService
    {
        #region Constructor
        internal CourseService()
        {
        }
        #endregion

        #region Methods
        internal void Save(Course item)
        {
            this.DatabaseManager.DatabaseProvider.BeginTransaction(true);
            try
            {
                this.SourceObject = item;
                if (item.IsNew)
                {
                    item.ID = this.GenerateSequence();
                    //item.course_name
                    //item.Position = this.GenerateSequence("Position");
                    //item.EntryUserID = AHS.Security.Global.CurrentUser.ID;
                    //item.EntryDate = DateTime.Now;
                    this.AddData();
                }
                else
                {
                    //item.UpdateUserID = AHS.Security.Global.CurrentUser.ID;
                    //item.UpdateDate = DateTime.Now;
                    this.ClearSearchColumns();
                    this.UpdateData();
                }
                this.DatabaseManager.DatabaseProvider.CommitTransaction();
            }
            catch (Exception exp)
            {
                this.DatabaseManager.DatabaseProvider.RollbackTransaction();
                ExceptionLog.Write(exp);
                throw new Exception(exp.Message, exp.InnerException);
            }
        }

        internal void Delete(int id)
        {
            this.DatabaseManager.DatabaseProvider.BeginTransaction(true);
            try
            {
                Course item = new Course();
                item.ID = id;
                this.SourceObject = item;
                this.ClearSearchColumns(); //why? saimon bhai
                this.RemoveData();

                this.DatabaseManager.DatabaseProvider.CommitTransaction();
            }
            catch (Exception exp)
            {
                this.DatabaseManager.DatabaseProvider.RollbackTransaction();
                ExceptionLog.Write(exp);
                throw new Exception(exp.Message, exp.InnerException);
            }
        }
        internal bool IsExists(List<ParamValue> searchItems)
        {
            bool isExists = false;

            this.DatabaseManager.DatabaseProvider.BeginTransaction(false);
            try
            {
                Course item = new Course();
                this.SourceObject = item;
                isExists = this.IsRecordExists(searchItems);
                this.DatabaseManager.DatabaseProvider.CommitTransaction();
            }
            catch (Exception exp)
            {
                this.DatabaseManager.DatabaseProvider.RollbackTransaction();
                ExceptionLog.Write(exp);
                throw new Exception(exp.Message, exp.InnerException);
            }

            return isExists;
        }

        internal Course GetData(List<ParamValue> searchItems)
        {
            Course item = new Course();
            this.DatabaseManager.DatabaseProvider.BeginTransaction(false);
            try
            {
                this.SourceObject = item;
                item = (Course)base.GetDataByParamValue(searchItems);
                this.DatabaseManager.DatabaseProvider.CommitTransaction();
            }
            catch (Exception exp)
            {
                this.DatabaseManager.DatabaseProvider.RollbackTransaction();
                ExceptionLog.Write(exp);
                throw new Exception(exp.Message, exp.InnerException);
            }
            return item;
        }
        internal CourseCollection GetAllData(List<ParamValue> searchItems, List<ParamValue> orderByItems)
        {
            CourseCollection collection = new CourseCollection();
            this.DatabaseManager.DatabaseProvider.BeginTransaction(false);
            try
            {
                Course item = new Course();
                this.SourceObject = item;

                string sql = this.ObjectMap.SelectStatement;
                sql += AHS.Core.Global.MakeSearchSQL(searchItems);
                sql += AHS.Core.Global.MakeOrderBySQL(orderByItems);

                IDataReader reader = this.DatabaseManager.DatabaseProvider.ExecuteRead(sql);
                while (reader.Read())
                {
                    Course singleItem = (Course)this.ObjectMap.LoadObject(reader);
                    collection.Add(singleItem);
                }
                reader.Close();
                reader.Dispose();
                reader = null;

                this.DatabaseManager.DatabaseProvider.CommitTransaction();
            }
            catch (Exception exp)
            {
                this.DatabaseManager.DatabaseProvider.RollbackTransaction();
                ExceptionLog.Write(exp);
                throw new Exception(exp.Message, exp.InnerException);
            }
            return collection;
        }
        internal DataSet LoadAllData(List<ParamValue> searchItems, List<ParamValue> orderByItems)
        {
            DataSet dataSet = new DataSet();
            this.DatabaseManager.DatabaseProvider.BeginTransaction(false);
            try
            {
                string sql = "SELECT * FROM course";
                sql += AHS.Core.Global.MakeSearchSQL(searchItems);
                sql += AHS.Core.Global.MakeOrderBySQL(orderByItems);
                this.DatabaseManager.DatabaseProvider.FillDataSet(sql, dataSet, "course");

                this.DatabaseManager.DatabaseProvider.CommitTransaction();
            }
            catch (Exception exp)
            {
                this.DatabaseManager.DatabaseProvider.RollbackTransaction();
                ExceptionLog.Write(exp);
                throw new Exception(exp.Message, exp.InnerException);
            }
            return dataSet;
        }
        #endregion
    }
    #endregion
}
