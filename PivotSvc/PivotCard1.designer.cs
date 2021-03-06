﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PivotCardService
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DB_20674_pivot1")]
	public partial class PivotCard1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPivot(Pivot instance);
    partial void UpdatePivot(Pivot instance);
    partial void DeletePivot(Pivot instance);
    partial void InsertUsers(Users instance);
    partial void UpdateUsers(Users instance);
    partial void DeleteUsers(Users instance);
    #endregion
		
		public PivotCard1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DB_20674_pivot1ConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PivotCard1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PivotCard1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PivotCard1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PivotCard1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Pivot> Pivots
		{
			get
			{
				return this.GetTable<Pivot>();
			}
		}
		
		public System.Data.Linq.Table<Users> Users
		{
			get
			{
				return this.GetTable<Users>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetPivotRedir")]
		public ISingleResult<Pivot> GetPivotRedir([global::System.Data.Linq.Mapping.ParameterAttribute(Name="PivotName", DbType="NVarChar(100)")] string pivotName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PivotCode", DbType="NVarChar(50)")] string pivotCode, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IsDefault", DbType="Bit")] System.Nullable<bool> isDefault)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pivotName, pivotCode, isDefault);
			return ((ISingleResult<Pivot>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetCheckUser")]
		public ISingleResult<GetCheckUserResult> GetCheckUser([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserName", DbType="NVarChar(100)")] string userName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userName);
			return ((ISingleResult<GetCheckUserResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetCheckPivot")]
		public ISingleResult<GetCheckPivotResult> GetCheckPivot([global::System.Data.Linq.Mapping.ParameterAttribute(Name="PivotName", DbType="NVarChar(50)")] string pivotName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pivotName);
			return ((ISingleResult<GetCheckPivotResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetPivotName")]
		public ISingleResult<GetPivotNameResult> GetPivotName([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserName", DbType="NVarChar(50)")] string userName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userName);
			return ((ISingleResult<GetPivotNameResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SetLoginUser")]
		public ISingleResult<SetLoginUserResult> SetLoginUser([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserName", DbType="NVarChar(50)")] string userName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Password", DbType="NVarChar(50)")] string password, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PivotName", DbType="NVarChar(50)")] string pivotName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FirstName", DbType="NVarChar(50)")] string firstName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userName, password, pivotName, firstName);
			return ((ISingleResult<SetLoginUserResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SetUpdateUser")]
		public int SetUpdateUser([global::System.Data.Linq.Mapping.ParameterAttribute(Name="PivotName", DbType="NVarChar(256)")] string pivotName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserName", DbType="NVarChar(256)")] string userName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FirstName", DbType="NVarChar(256)")] string firstName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pivotName, userName, firstName);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SetSavePivot")]
		public ISingleResult<SetSavePivotResult> SetSavePivot([global::System.Data.Linq.Mapping.ParameterAttribute(Name="PivotName", DbType="NVarChar(100)")] string pivotName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PivotCode", DbType="NVarChar(50)")] string pivotCode, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PivotId", DbType="Int")] System.Nullable<int> pivotId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PivotContent", DbType="NVarChar(500)")] string pivotContent, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PivotType", DbType="Int")] System.Nullable<int> pivotType, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PivotDefault", DbType="Bit")] System.Nullable<bool> pivotDefault)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pivotName, pivotCode, pivotId, pivotContent, pivotType, pivotDefault);
			return ((ISingleResult<SetSavePivotResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetPivots")]
		public ISingleResult<Pivot> GetPivots([global::System.Data.Linq.Mapping.ParameterAttribute(Name="PivotName", DbType="NVarChar(100)")] string pivotName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pivotName);
			return ((ISingleResult<Pivot>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetPivot")]
		public ISingleResult<Pivot> GetPivot([global::System.Data.Linq.Mapping.ParameterAttribute(Name="PivotName", DbType="NVarChar(100)")] string pivotName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PivotID", DbType="Int")] System.Nullable<int> pivotID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pivotName, pivotID);
			return ((ISingleResult<Pivot>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SetDeletePivot")]
		public ISingleResult<Pivot> SetDeletePivot([global::System.Data.Linq.Mapping.ParameterAttribute(Name="PivotName", DbType="NVarChar(100)")] string pivotName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PivotID", DbType="Int")] System.Nullable<int> pivotID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pivotName, pivotID);
			return ((ISingleResult<Pivot>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblPivots")]
	public partial class Pivot : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private System.Guid _UserID;
		
		private string _PivotCode;
		
		private string _PivotURL;
		
		private int _Type;
		
		private bool _IsDefault;
		
		private bool _IsDeleted;
		
		private EntityRef<Users> _Users;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnUserIDChanging(System.Guid value);
    partial void OnUserIDChanged();
    partial void OnPivotCodeChanging(string value);
    partial void OnPivotCodeChanged();
    partial void OnPivotContentChanging(string value);
    partial void OnPivotContentChanged();
    partial void OnTypeChanging(int value);
    partial void OnTypeChanged();
    partial void OnIsDefaultChanging(bool value);
    partial void OnIsDefaultChanged();
    partial void OnIsDeletedChanging(bool value);
    partial void OnIsDeletedChanged();
    #endregion
		
		public Pivot()
		{
			this._Users = default(EntityRef<Users>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID")]
		public System.Guid UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					if (this._Users.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PivotCode", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string PivotCode
		{
			get
			{
				return this._PivotCode;
			}
			set
			{
				if ((this._PivotCode != value))
				{
					this.OnPivotCodeChanging(value);
					this.SendPropertyChanging();
					this._PivotCode = value;
					this.SendPropertyChanged("PivotCode");
					this.OnPivotCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PivotURL", DbType="NVarChar(MAX)")]
		public string PivotContent
		{
			get
			{
				return this._PivotURL;
			}
			set
			{
				if ((this._PivotURL != value))
				{
					this.OnPivotContentChanging(value);
					this.SendPropertyChanging();
					this._PivotURL = value;
					this.SendPropertyChanged("PivotContent");
					this.OnPivotContentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="Int NOT NULL")]
		public int Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsDefault", DbType="Bit NOT NULL")]
		public bool IsDefault
		{
			get
			{
				return this._IsDefault;
			}
			set
			{
				if ((this._IsDefault != value))
				{
					this.OnIsDefaultChanging(value);
					this.SendPropertyChanging();
					this._IsDefault = value;
					this.SendPropertyChanged("IsDefault");
					this.OnIsDefaultChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsDeleted", DbType="Bit NOT NULL")]
		public bool IsDeleted
		{
			get
			{
				return this._IsDeleted;
			}
			set
			{
				if ((this._IsDeleted != value))
				{
					this.OnIsDeletedChanging(value);
					this.SendPropertyChanging();
					this._IsDeleted = value;
					this.SendPropertyChanged("IsDeleted");
					this.OnIsDeletedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_Pivot", Storage="_Users", ThisKey="UserID", OtherKey="UserId", IsForeignKey=true)]
		public Users Users
		{
			get
			{
				return this._Users.Entity;
			}
			set
			{
				Users previousValue = this._Users.Entity;
				if (((previousValue != value) 
							|| (this._Users.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Users.Entity = null;
						previousValue.Pivots.Remove(this);
					}
					this._Users.Entity = value;
					if ((value != null))
					{
						value.Pivots.Add(this);
						this._UserID = value.UserId;
					}
					else
					{
						this._UserID = default(System.Guid);
					}
					this.SendPropertyChanged("Users");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.aspnet_Users")]
	public partial class Users : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _ApplicationId;
		
		private System.Guid _UserId;
		
		private string _UserName;
		
		private string _LoweredUserName;
		
		private string _MobileAlias;
		
		private bool _IsAnonymous;
		
		private System.DateTime _LastActivityDate;
		
		private string _PivotName;
		
		private string _FirstName;
		
		private string _LastName;
		
		private System.Nullable<bool> _IsActive;
		
		private System.Nullable<System.DateTime> _LastLoginTime;
		
		private EntitySet<Pivot> _Pivots;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnApplicationIdChanging(System.Guid value);
    partial void OnApplicationIdChanged();
    partial void OnUserIdChanging(System.Guid value);
    partial void OnUserIdChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnLoweredUserNameChanging(string value);
    partial void OnLoweredUserNameChanged();
    partial void OnMobileAliasChanging(string value);
    partial void OnMobileAliasChanged();
    partial void OnIsAnonymousChanging(bool value);
    partial void OnIsAnonymousChanged();
    partial void OnLastActivityDateChanging(System.DateTime value);
    partial void OnLastActivityDateChanged();
    partial void OnPivotNameChanging(string value);
    partial void OnPivotNameChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnIsActiveChanging(System.Nullable<bool> value);
    partial void OnIsActiveChanged();
    partial void OnLastLoginTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnLastLoginTimeChanged();
    #endregion
		
		public Users()
		{
			this._Pivots = new EntitySet<Pivot>(new Action<Pivot>(this.attach_Pivots), new Action<Pivot>(this.detach_Pivots));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApplicationId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ApplicationId
		{
			get
			{
				return this._ApplicationId;
			}
			set
			{
				if ((this._ApplicationId != value))
				{
					this.OnApplicationIdChanging(value);
					this.SendPropertyChanging();
					this._ApplicationId = value;
					this.SendPropertyChanged("ApplicationId");
					this.OnApplicationIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LoweredUserName", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
		public string LoweredUserName
		{
			get
			{
				return this._LoweredUserName;
			}
			set
			{
				if ((this._LoweredUserName != value))
				{
					this.OnLoweredUserNameChanging(value);
					this.SendPropertyChanging();
					this._LoweredUserName = value;
					this.SendPropertyChanged("LoweredUserName");
					this.OnLoweredUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MobileAlias", DbType="NVarChar(16)")]
		public string MobileAlias
		{
			get
			{
				return this._MobileAlias;
			}
			set
			{
				if ((this._MobileAlias != value))
				{
					this.OnMobileAliasChanging(value);
					this.SendPropertyChanging();
					this._MobileAlias = value;
					this.SendPropertyChanged("MobileAlias");
					this.OnMobileAliasChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsAnonymous", DbType="Bit NOT NULL")]
		public bool IsAnonymous
		{
			get
			{
				return this._IsAnonymous;
			}
			set
			{
				if ((this._IsAnonymous != value))
				{
					this.OnIsAnonymousChanging(value);
					this.SendPropertyChanging();
					this._IsAnonymous = value;
					this.SendPropertyChanged("IsAnonymous");
					this.OnIsAnonymousChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastActivityDate", DbType="DateTime NOT NULL")]
		public System.DateTime LastActivityDate
		{
			get
			{
				return this._LastActivityDate;
			}
			set
			{
				if ((this._LastActivityDate != value))
				{
					this.OnLastActivityDateChanging(value);
					this.SendPropertyChanging();
					this._LastActivityDate = value;
					this.SendPropertyChanged("LastActivityDate");
					this.OnLastActivityDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PivotName", DbType="NVarChar(256)")]
		public string PivotName
		{
			get
			{
				return this._PivotName;
			}
			set
			{
				if ((this._PivotName != value))
				{
					this.OnPivotNameChanging(value);
					this.SendPropertyChanging();
					this._PivotName = value;
					this.SendPropertyChanged("PivotName");
					this.OnPivotNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(256)")]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(256)")]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsActive", DbType="Bit")]
		public System.Nullable<bool> IsActive
		{
			get
			{
				return this._IsActive;
			}
			set
			{
				if ((this._IsActive != value))
				{
					this.OnIsActiveChanging(value);
					this.SendPropertyChanging();
					this._IsActive = value;
					this.SendPropertyChanged("IsActive");
					this.OnIsActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastLoginTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> LastLoginTime
		{
			get
			{
				return this._LastLoginTime;
			}
			set
			{
				if ((this._LastLoginTime != value))
				{
					this.OnLastLoginTimeChanging(value);
					this.SendPropertyChanging();
					this._LastLoginTime = value;
					this.SendPropertyChanged("LastLoginTime");
					this.OnLastLoginTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_Pivot", Storage="_Pivots", ThisKey="UserId", OtherKey="UserID")]
		public EntitySet<Pivot> Pivots
		{
			get
			{
				return this._Pivots;
			}
			set
			{
				this._Pivots.Assign(value);
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
		
		private void attach_Pivots(Pivot entity)
		{
			this.SendPropertyChanging();
			entity.Users = this;
		}
		
		private void detach_Pivots(Pivot entity)
		{
			this.SendPropertyChanging();
			entity.Users = null;
		}
	}
	
	public partial class GetCheckUserResult
	{
		
		private string _UserName;
		
		public GetCheckUserResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this._UserName = value;
				}
			}
		}
	}
	
	public partial class GetCheckPivotResult
	{
		
		private string _PivotName;
		
		public GetCheckPivotResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PivotName", DbType="NVarChar(50)")]
		public string PivotName
		{
			get
			{
				return this._PivotName;
			}
			set
			{
				if ((this._PivotName != value))
				{
					this._PivotName = value;
				}
			}
		}
	}
	
	public partial class GetPivotNameResult
	{
		
		private string _PivotName;
		
		public GetPivotNameResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PivotName", DbType="NVarChar(50)")]
		public string PivotName
		{
			get
			{
				return this._PivotName;
			}
			set
			{
				if ((this._PivotName != value))
				{
					this._PivotName = value;
				}
			}
		}
	}
	
	public partial class SetLoginUserResult
	{
		
		private string _UserName;
		
		public SetLoginUserResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this._UserName = value;
				}
			}
		}
	}
	
	public partial class SetSavePivotResult
	{
		
		private string _PivotCode;
		
		private int _ID;
		
		private string _PivotContent;
		
		private int _Type;
		
		private bool _IsDefault;
		
		private string _PivotName;
		
		public SetSavePivotResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PivotCode", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string PivotCode
		{
			get
			{
				return this._PivotCode;
			}
			set
			{
				if ((this._PivotCode != value))
				{
					this._PivotCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL")]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PivotContent", DbType="NVarChar(MAX)")]
		public string PivotContent
		{
			get
			{
				return this._PivotContent;
			}
			set
			{
				if ((this._PivotContent != value))
				{
					this._PivotContent = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="Int NOT NULL")]
		public int Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this._Type = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsDefault", DbType="Bit NOT NULL")]
		public bool IsDefault
		{
			get
			{
				return this._IsDefault;
			}
			set
			{
				if ((this._IsDefault != value))
				{
					this._IsDefault = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PivotName", DbType="NVarChar(256)")]
		public string PivotName
		{
			get
			{
				return this._PivotName;
			}
			set
			{
				if ((this._PivotName != value))
				{
					this._PivotName = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
