using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;

namespace Territories.DAL
{
    public class QueryExecutor
    {
        #region ExecuteFirstOrDefault methods


        public static T ExecuteFirstOrDefault<T>(ObjectQuery<T> objectQuery, MergeOption merge)
        {
            try
            {
                objectQuery.MergeOption = merge;
                return objectQuery.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T ExecuteFirstOrDefault<T>(ObjectQuery<T> objectQuery)
        {
            return ExecuteFirstOrDefault<T>(objectQuery, MergeOption.AppendOnly);
        }

        public static T ExecuteFirstOrDefault<T>(IQueryable<T> L2Query, MergeOption merge)
        {
            ObjectQuery<T> objectQuery = (ObjectQuery<T>)L2Query;
            return ExecuteFirstOrDefault<T>(objectQuery, merge);
        }

        public static T ExecuteFirstOrDefault<T>(IQueryable<T> L2Query)
        {
            ObjectQuery<T> objectQuery = (ObjectQuery<T>)L2Query;
            return ExecuteFirstOrDefault<T>(objectQuery, MergeOption.AppendOnly);
        }
        #endregion

        #region ExecuteList methos

        public static List<T> ExecuteList<T>(ObjectQuery<T> objectQuery, MergeOption merge)
        {
            try
            {
                objectQuery.MergeOption = merge;
                return objectQuery.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<T> ExecuteList<T>(ObjectQuery<T> objectQuery)
        {
            return ExecuteList<T>(objectQuery, MergeOption.AppendOnly);
        }

        public static List<T> ExecuteList<T>(IQueryable<T> L2Query, MergeOption merge)
        {
            ObjectQuery<T> objectQuery = (ObjectQuery<T>)L2Query;
            return ExecuteList<T>(objectQuery, merge);
        }

        public static List<T> ExecuteList<T>(IQueryable<T> L2Query)
        {
            ObjectQuery<T> objectQuery = (ObjectQuery<T>)L2Query;
            return ExecuteList<T>(objectQuery, MergeOption.AppendOnly);
        }
        #endregion
    }
}
