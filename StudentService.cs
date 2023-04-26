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
    internal sealed class StudentService : BaseService
    {
        #region Constructor
        internal StudentService() 
        {
        }
        #endregion

        #region Methods
        internal void Save(Student item)
        {
            this.DatabaseManager.DatabaseProvider.BeginTransaction(true);
            try
            {
                this.SourceObject = item;
                if (item.IsNew)
                {
                    item.ID = this.GenerateSequence();
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
                Student item = new Student();
                item.ID = id;
                this.SourceObject = item;
                this.ClearSearchColumns(); //why?
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
                Student item = new Student();
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

        internal Student GetData(List<ParamValue> searchItems)
        {
            Student item = new Student();
            this.DatabaseManager.DatabaseProvider.BeginTransaction(false);
            try
            {
                this.SourceObject = item;
                item = (Student)base.GetDataByParamValue(searchItems);
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
        internal StudentCollection GetAllData(List<ParamValue> searchItems, List<ParamValue> orderByItems)
        {
            StudentCollection collection = new StudentCollection();
            this.DatabaseManager.DatabaseProvider.BeginTransaction(false);
            try
            {
                Student item = new Student();
                this.SourceObject = item;

                string sql = this.ObjectMap.SelectStatement;
                sql += AHS.Core.Global.MakeSearchSQL(searchItems);
                sql += AHS.Core.Global.MakeOrderBySQL(orderByItems);

                IDataReader reader = this.DatabaseManager.DatabaseProvider.ExecuteRead(sql);
                while (reader.Read())
                {
                    Student singleItem = (Student)this.ObjectMap.LoadObject(reader);
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
                string sql = "SELECT * FROM student";
                sql += AHS.Core.Global.MakeSearchSQL(searchItems);
                sql += AHS.Core.Global.MakeOrderBySQL(orderByItems);
                this.DatabaseManager.DatabaseProvider.FillDataSet(sql, dataSet, "student");

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
