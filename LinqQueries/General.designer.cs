﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3623
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LinqQueries
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="General")]
	public partial class GeneralDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertNumber(Number instance);
    partial void UpdateNumber(Number instance);
    partial void DeleteNumber(Number instance);
    #endregion
		
		public GeneralDataContext() : 
				base(global::LinqQueries.Properties.Settings.Default.GeneralConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public GeneralDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GeneralDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GeneralDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GeneralDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Number> Numbers
		{
			get
			{
				return this.GetTable<Number>();
			}
		}
	}
	
	[Table(Name="dbo.Number")]
	public partial class Number : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _RowID;
		
		private System.Nullable<int> _RandomNumber;
		
		private string _HexNumber;
		
		private string _WordNumber;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnRowIDChanging(int value);
    partial void OnRowIDChanged();
    partial void OnRandomNumberChanging(System.Nullable<int> value);
    partial void OnRandomNumberChanged();
    partial void OnHexNumberChanging(string value);
    partial void OnHexNumberChanged();
    partial void OnWordNumberChanging(string value);
    partial void OnWordNumberChanged();
    #endregion
		
		public Number()
		{
			OnCreated();
		}
		
		[Column(Storage="_RowID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int RowID
		{
			get
			{
				return this._RowID;
			}
			set
			{
				if ((this._RowID != value))
				{
					this.OnRowIDChanging(value);
					this.SendPropertyChanging();
					this._RowID = value;
					this.SendPropertyChanged("RowID");
					this.OnRowIDChanged();
				}
			}
		}
		
		[Column(Storage="_RandomNumber", DbType="Int")]
		public System.Nullable<int> RandomNumber
		{
			get
			{
				return this._RandomNumber;
			}
			set
			{
				if ((this._RandomNumber != value))
				{
					this.OnRandomNumberChanging(value);
					this.SendPropertyChanging();
					this._RandomNumber = value;
					this.SendPropertyChanged("RandomNumber");
					this.OnRandomNumberChanged();
				}
			}
		}
		
		[Column(Storage="_HexNumber", DbType="NVarChar(50)")]
		public string HexNumber
		{
			get
			{
				return this._HexNumber;
			}
			set
			{
				if ((this._HexNumber != value))
				{
					this.OnHexNumberChanging(value);
					this.SendPropertyChanging();
					this._HexNumber = value;
					this.SendPropertyChanged("HexNumber");
					this.OnHexNumberChanged();
				}
			}
		}
		
		[Column(Storage="_WordNumber", DbType="NVarChar(100)")]
		public string WordNumber
		{
			get
			{
				return this._WordNumber;
			}
			set
			{
				if ((this._WordNumber != value))
				{
					this.OnWordNumberChanging(value);
					this.SendPropertyChanging();
					this._WordNumber = value;
					this.SendPropertyChanged("WordNumber");
					this.OnWordNumberChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
