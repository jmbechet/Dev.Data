﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Apps72.Dev.Data
{
    /// <summary>
    /// Base Interface to manage all DataBaseCommands
    /// </summary>
    public partial interface IDatabaseCommand : IDisposable
    {

        /// <summary>
        /// Gets or sets the sql query
        /// </summary>
        StringBuilder CommandText { get; set; }

        /// <summary>
        /// Gets or sets the command type
        /// </summary>
        System.Data.CommandType CommandType { get; set; }

        /// <summary>
        /// Gets or sets the current transaction
        /// </summary>
        System.Data.Common.DbTransaction Transaction { get; set; }

        /// <summary>
        /// Gets sql parameters of the query
        /// </summary>
        System.Data.Common.DbParameterCollection Parameters { get; }

        /// <summary>
        /// Enable or disable the raise of exceptions when queries are executed.
        /// Default is True (Enabled).
        /// </summary>
        bool ThrowException { get; set; }

        /// <summary>
        /// Set this property to log the SQL generated by this class to the given delegate. 
        /// For example, to log to the console, set this property to Console.Write.
        /// </summary>
        Action<string> Log { get; set; }

        /// <summary>
        /// Set this property to execute an action immediately BEFORE the database request.
        /// </summary>
        Action<DatabaseCommandBase> ActionBeforeExecution { get; set; }

        /// <summary>
        /// Set this property to execute an action immediately AFTER the database request,
        /// and before the type convertions.
        /// </summary>
        Action<DatabaseCommandBase, IEnumerable<Schema.DataTable>> ActionAfterExecution { get; set; }

        /// <summary>
        /// Delete the CommandText and the all sql parameters
        /// </summary>
        void Clear();

        /// <summary>
        /// Prepare a query
        /// </summary>
        void Prepare();

        /// <summary>
        /// Begin a transaction into the database
        /// </summary>
        /// <returns>Transaction</returns>
        System.Data.Common.DbTransaction TransactionBegin();

        /// <summary>
        /// Commit the current transaction to the database
        /// </summary>
        void TransactionCommit();

        /// <summary>
        /// Rollback the current transaction 
        /// </summary>
        void TransactionRollback();

        /// <summary>
        /// Adds a value to the end of the <see cref="Parameters"/> property.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value to be added. Null value will be replaced by System.DBNull.Value.</param>
        /// <returns></returns>
        DatabaseCommandBase AddParameter(string name, object value);

        /// <summary>
        /// Adds a value to the end of the <see cref="Parameters"/> property.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value to be added. Null value will be replaced by System.DBNull.Value.</param>
        /// <param name="type">Type of parameter.</param>
        /// <returns></returns>
        DatabaseCommandBase AddParameter(string name, object value, System.Data.DbType? type);

        /// <summary>
        /// Add all properties / values to the end of the <see cref="Parameters"/> property.
        /// If a property is already exist in Parameters collection, the parameter is removed and new added with new value.
        /// </summary>
        /// <param name="values">Object or anonymous object to convert all properties to parameters</param>
        DatabaseCommandBase AddParameter<T>(T values);

        /// <summary>
        /// Gets the full CommandText, integrating parameters values.
        /// </summary>
        /// <returns>Formatted query</returns>
        string GetCommandTextFormatted();

        /// <summary>
        /// Execute the query and return a list or array of new instances of typed results filled with data table results.
        /// </summary>
        /// <typeparam name="T">Object type for first table</typeparam>
        /// <typeparam name="U">Object type for second table</typeparam>
        /// <typeparam name="V">Object type for third table</typeparam>
        /// <typeparam name="W">Object type for fourth table</typeparam>
        /// <typeparam name="X">Object type for fifth table</typeparam>
        /// <returns>List of array of typed results</returns>
        Tuple<IEnumerable<T>, IEnumerable<U>, IEnumerable<V>, IEnumerable<W>, IEnumerable<X>> ExecuteDataSet<T, U, V, W, X>(T typeOfItem1, U typeOfItem2, V typeOfItem3, W typeOfItem4, X typeOfItem5);

        /// <summary>
        /// Execute the query and return a list or array of new instances of typed results filled with data table results.
        /// </summary>
        /// <typeparam name="T">Object type for first table</typeparam>
        /// <typeparam name="U">Object type for second table</typeparam>
        /// <typeparam name="V">Object type for third table</typeparam>
        /// <typeparam name="W">Object type for fourth table</typeparam>
        /// <returns>List of array of typed results</returns>
        Tuple<IEnumerable<T>, IEnumerable<U>, IEnumerable<V>, IEnumerable<W>> ExecuteDataSet<T, U, V, W>(T typeOfItem1, U typeOfItem2, V typeOfItem3, W typeOfItem4);

        /// <summary>
        /// Execute the query and return a list or array of new instances of typed results filled with data table results.
        /// </summary>
        /// <typeparam name="T">Object type for first table</typeparam>
        /// <typeparam name="U">Object type for second table</typeparam>
        /// <typeparam name="V">Object type for third table</typeparam>
        /// <returns>List of array of typed results</returns>
        Tuple<IEnumerable<T>, IEnumerable<U>, IEnumerable<V>> ExecuteDataSet<T, U, V>(T typeOfItem1, U typeOfItem2, V typeOfItem3);


        /// <summary>
        /// Execute the query and return a list or array of new instances of typed results filled with data table results.
        /// </summary>
        /// <typeparam name="T">Object type for first table</typeparam>
        /// <typeparam name="U">Object type for second table</typeparam>
        /// <returns>List of array of typed results</returns>
        Tuple<IEnumerable<T>, IEnumerable<U>> ExecuteDataSet<T, U>(T typeOfItem1, U typeOfItem2);

        /// <summary>
        /// Execute the query and return a list or array of new instances of typed results filled with data table results.
        /// </summary>
        /// <typeparam name="T">Object type for first table</typeparam>
        /// <typeparam name="U">Object type for second table</typeparam>
        /// <typeparam name="V">Object type for third table</typeparam>
        /// <typeparam name="W">Object type for fourth table</typeparam>
        /// <typeparam name="X">Object type for fifth table</typeparam>
        /// <returns>List of array of typed results</returns>
        Tuple<IEnumerable<T>, IEnumerable<U>, IEnumerable<V>, IEnumerable<W>, IEnumerable<X>> ExecuteDataSet<T, U, V, W, X>();

        /// <summary>
        /// Execute the query and return a list or array of new instances of typed results filled with data table results.
        /// </summary>
        /// <typeparam name="T">Object type for first table</typeparam>
        /// <typeparam name="U">Object type for second table</typeparam>
        /// <typeparam name="V">Object type for third table</typeparam>
        /// <typeparam name="W">Object type for fourth table</typeparam>
        /// <returns>List of array of typed results</returns>
        Tuple<IEnumerable<T>, IEnumerable<U>, IEnumerable<V>, IEnumerable<W>> ExecuteDataSet<T, U, V, W>();

        /// <summary>
        /// Execute the query and return a list or array of new instances of typed results filled with data table results.
        /// </summary>
        /// <typeparam name="T">Object type for first table</typeparam>
        /// <typeparam name="U">Object type for second table</typeparam>
        /// <typeparam name="V">Object type for third table</typeparam>
        /// <returns>List of array of typed results</returns>
        Tuple<IEnumerable<T>, IEnumerable<U>, IEnumerable<V>> ExecuteDataSet<T, U, V>();


        /// <summary>
        /// Execute the query and return a list or array of new instances of typed results filled with data table results.
        /// </summary>
        /// <typeparam name="T">Object type for first table</typeparam>
        /// <typeparam name="U">Object type for second table</typeparam>
        /// <returns>List of array of typed results</returns>
        Tuple<IEnumerable<T>, IEnumerable<U>> ExecuteDataSet<T, U>();

        /// <summary>
        /// Execute the query and return an array of new instances of typed results filled with data table result.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <returns>Array of typed results</returns>
        /// <example>
        /// <code>
        ///   Employee[] emp = cmd.ExecuteTable&lt;Employee&gt;();
        ///   var x = cmd.ExecuteTable&lt;Employee&gt;();
        /// </code>
        /// <remarks>
        ///   Result object property (ex. Employee.Name) may be tagged with the ColumnAttribute 
        ///   to set which column name (ex. [Column("Name")] must be associated to this property.
        /// </remarks>
        /// </example>
        IEnumerable<T> ExecuteTable<T>();

        /// <summary>
        /// Execute the query and return an array of new instances of typed results filled with data table result.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="itemOftype"></param>
        /// <returns>Array of typed results</returns>
        /// <example>
        /// <code>
        ///   Employee emp = new Employee();
        ///   var x = cmd.ExecuteTable(new { emp.Age, emp.Name });
        ///   var y = cmd.ExecuteTable(new { Age = 0, Name = "" });
        /// </code>
        /// <remarks>
        ///   Result object property (ex. Employee.Name) may be tagged with the ColumnAttribute 
        ///   to set which column name (ex. [Column("Name")] must be associated to this property.
        /// </remarks>
        /// </example>
        IEnumerable<T> ExecuteTable<T>(T itemOftype);

        /// <summary>
        /// Execute the query and return an array of new instances of typed results filled with data table result.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="converter">Conversion function to customize the transformation of a DataRow to an object of <typeparamref name="T"/> </param>
        /// <returns>Array of typed results</returns>    
        IEnumerable<T> ExecuteTable<T>(Func<Schema.DataRow, T> converter);

        /// <summary>
        /// Execute the query and return the count of modified rows
        /// </summary>
        /// <returns>Count of modified rows</returns>
        int ExecuteNonQuery();

        /// <summary>
        /// Execute the query and return the first column of the first row of results
        /// </summary>
        /// <returns>Object - Result</returns>
        object ExecuteScalar();

        /// <summary>
        /// Execute the query and return the first column of the first row of results
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <returns>Result</returns>
        T ExecuteScalar<T>();

        /// <summary>
        /// Execute the query and return a new instance of T with the first row of results
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <returns>First row of results</returns>
        /// <example>
        /// <code>
        ///   Employee emp = cmd.ExecuteRow&lt;Employee&gt;();
        /// </code>
        /// <remarks>
        ///   Result object property (ex. Employee.Name) may be tagged with the ColumnAttribute 
        ///   to set which column name (ex. [Column("Name")] must be associated to this property.
        /// </remarks>
        /// </example>
        T ExecuteRow<T>();

        /// <summary>
        /// Execute the query and fill the specified T object with the first row of results
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="itemOftype"></param>
        /// <returns>First row of results</returns>
        /// <example>
        /// <code>
        ///   Employee emp = new Employee();
        ///   var x = cmd.ExecuteRow(new { emp.Age, emp.Name });
        ///   var y = cmd.ExecuteRow(new { Age = 0, Name = "" });
        ///   var z = cmd.ExecuteRow(emp);
        /// </code>
        /// <remarks>
        ///   Result object property (ex. Employee.Name) may be tagged with the ColumnAttribute 
        ///   to set which column name (ex. [Column("Name")] must be associated to this property.
        /// </remarks>
        /// </example>
        T ExecuteRow<T>(T itemOftype);

        /// <summary>
        /// Execute the query and fill the specified T object with the first row of results
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="converter">Conversion function to customize the transformation of a DataRow to an object of <typeparamref name="T"/> </param>
        /// <returns>First row of results</returns>
        T ExecuteRow<T>(Func<Schema.DataRow, T> converter);

        /// <summary>
        /// Gets the last raised exception 
        /// </summary>
        System.Data.Common.DbException Exception { get; }

        /// <summary>
        /// Gets a Fluent Query tool to execute SQL request.
        /// </summary>
        FluentQuery Query();

        /// <summary>
        /// Gets a Fluent Query tool to execute SQL request.
        /// </summary>
        /// <param name="sqlQuery">SQL query to execute.</param>
        FluentQuery Query(string sqlQuery);

        /// <summary>
        /// Gets a Fluent Query tool to execute SQL request.
        /// </summary>
        /// <param name="sqlQuery">SQL query to execute.</param>
        /// <param name="parameters">Object contains all SQL parameters (as object properties)</param>
        FluentQuery Query<T>(string sqlQuery, T parameters);
    }

    /// <summary>
    /// Base Interface to manage all DataBaseCommands.
    /// IDatabaseCommandBase and IDatabaseCommand are exactly same interfaces.
    /// </summary>
    [Obsolete("Renamed. Use IDatabaseCommand instead.")]
    public partial interface IDatabaseCommandBase : IDatabaseCommand
    {

    }
    }
