using System;
using System.Collections.Generic;
using MvvmCross.Logging;

using MobileTemplateCSharp.Core.Database.Interfaces;
using MobileTemplateCSharp.Core.Models.Database;

namespace MobileTemplateCSharp.Core.Database.Implementations {

    public class RepositoryDBClient<TEntity> : IRepositoryDBClient<TEntity> where TEntity : BaseEntity, new() {

        public RepositoryDBClient(
            IConnectionDBClient connectionDBClient,
            IMvxLog mvxLog
        ) {
            this.connectionDBClient = connectionDBClient;
            this.mvxLog = mvxLog;
            connectionDBClient.Database.CreateTable<TEntity>();
        }

        #region Services
        private readonly IConnectionDBClient connectionDBClient;
        private readonly IMvxLog mvxLog;
        #endregion

        public void Add(TEntity obj) {
            lock (connectionDBClient) {
                try {
                    connectionDBClient.Database.Insert(obj);
                } catch (Exception ex) {
                    mvxLog.ErrorException($"Database exception. method: add.", ex);
                }
            }
        }

        public void ClearAll() {
            lock (connectionDBClient) {
                try {
                    connectionDBClient.Database.Table<TEntity>().Delete(e => true);
                } catch (Exception ex) {
                    mvxLog.ErrorException($"Database exception. method: clear all.", ex);
                }
            }
        }

        public TEntity Find(Predicate<TEntity> predicate) {
            lock (connectionDBClient) {
                try {
                    return connectionDBClient.Database.Table<TEntity>().First((entity) => predicate.Invoke(entity));
                } catch (Exception ex) {
                    mvxLog.ErrorException($"Database exception. method: find.", ex);
                }
            }
            return null;
        }

        public TEntity Get(int id) {
            lock (connectionDBClient) {
                try {
                    return connectionDBClient.Database.Table<TEntity>().First((entity) => entity.Id == id);
                } catch (Exception ex) {
                    mvxLog.ErrorException($"Database exception. method: get.", ex);
                }
            }
            return null;
        }

        public IEnumerable<TEntity> GetAll() {
            lock (connectionDBClient) {
                try {
                    return connectionDBClient.Database.Table<TEntity>().ToArray();
                } catch (Exception ex) {
                    mvxLog.ErrorException($"Database exception. method: get all.", ex);
                }
            }
            return null;
        }

        public void Remove(TEntity obj) {
            lock (connectionDBClient) {
                try {
                    connectionDBClient.Database.Table<TEntity>().Delete((entity) => entity.Id == obj.Id);
                } catch (Exception ex) {
                    mvxLog.ErrorException($"Database exception. method: remove.", ex);
                }
            }
        }

        public void Update(TEntity obj) {
            lock (connectionDBClient) {
                try {
                    connectionDBClient.Database.Update(obj);
                } catch (Exception ex) {
                    mvxLog.ErrorException($"Database exception. method: update.", ex);
                }
            }
        }
    }
}
