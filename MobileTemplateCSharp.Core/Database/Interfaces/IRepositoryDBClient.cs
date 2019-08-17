using System;
using System.Collections.Generic;

using MobileTemplateCSharp.Core.Models.Database;

namespace MobileTemplateCSharp.Core.Database.Interfaces {
    /// <summary>
    /// Generic class fro working with Database table with objects of BaseEntity. 
    /// </summary>
    /// <typeparam name="TEntity">Inheritor of BaseEntity. Main Object of DB table, which Repository is working with.</typeparam>
    public interface IRepositoryDBClient<TEntity> where TEntity : BaseEntity, new() {
        /// <summary>
        /// Adds an object of type TEntity in table.
        /// </summary>
        /// <param name="obj">Object for adding</param>
        void Add(TEntity obj);

        /// <summary>
        /// Removes an object of type TEntity from table.
        /// </summary>
        /// <param name="obj">Object for removing</param>
        void Remove(TEntity obj);

        /// <summary>
        /// Gets an object of type TEntity with id <c><paramref name="id"/></c> in table.
        /// </summary>
        /// <param name="id">Id of object to get</param>
        /// <returns></returns>
        TEntity Get(int id);

        /// <summary>
        /// Gets the table of type TEntity
        /// </summary>
        /// <returns>The table of TEntity</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Finds an object of type TEntity witch <paramref name="predicate"/> points on.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity Find(Predicate<TEntity> predicate);

        /// <summary>
        /// Clears all elements in table.
        /// </summary>
        void ClearAll();
    }
}
