﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;

namespace Territories.DAL
{
    public class CommandExecutor
    {
        #region ExecuteFirstOrDefault methods
        public T ExecuteFirstOrDefault<T>(ObjectQuery<T> objectQuery)
        {
            return ExecuteFirstOrDefault<T>(objectQuery, MergeOption.AppendOnly);
        }

        public T ExecuteFirstOrDefault<T>(ObjectQuery<T> objectQuery,MergeOption merge)
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

        public T ExecuteFirstOrDefault<T>(IQueryable<T> L2Query)
        {
            try
            {
                return L2Query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public List<T> ExecuteList<T>(ObjectQuery<T> objectQuery)
        {

            return ExecuteList<T>(objectQuery, MergeOption.AppendOnly);
        }

        public List<T> ExecuteList<T>(ObjectQuery<T> objectQuery, MergeOption merge)
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

        public List<T> ExecuteList<T>(IQueryable<T> L2Query,MergeOption merge)
        {
            ObjectQuery<T> objectQuery = Convert.ChangeType(L2Query, typeof(ObjectQuery<T>));
            return ExecuteList<T>(objectQuery, merge);

        }

        public void SaveChanges(ObjectContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
