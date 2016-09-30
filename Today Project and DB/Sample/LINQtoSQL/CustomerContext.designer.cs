﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LINQtoSQL
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Sample")]
	public partial class CustomerDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCountry(Country instance);
    partial void UpdateCountry(Country instance);
    partial void DeleteCountry(Country instance);
    partial void InsertCustomer(Customer instance);
    partial void UpdateCustomer(Customer instance);
    partial void DeleteCustomer(Customer instance);
    partial void InsertProvince(Province instance);
    partial void UpdateProvince(Province instance);
    partial void DeleteProvince(Province instance);
    #endregion
		
		public CustomerDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public CustomerDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CustomerDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CustomerDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CustomerDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Country> Countries
		{
			get
			{
				return this.GetTable<Country>();
			}
		}
		
		public System.Data.Linq.Table<Customer> Customers
		{
			get
			{
				return this.GetTable<Customer>();
			}
		}
		
		public System.Data.Linq.Table<Province> Provinces
		{
			get
			{
				return this.GetTable<Province>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Country")]
	public partial class Country : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CountryID;
		
		private string _Country1;
		
		private EntitySet<Customer> _Customers;
		
		private EntitySet<Province> _Provinces;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCountryIDChanging(int value);
    partial void OnCountryIDChanged();
    partial void OnCountry1Changing(string value);
    partial void OnCountry1Changed();
    #endregion
		
		public Country()
		{
			this._Customers = new EntitySet<Customer>(new Action<Customer>(this.attach_Customers), new Action<Customer>(this.detach_Customers));
			this._Provinces = new EntitySet<Province>(new Action<Province>(this.attach_Provinces), new Action<Province>(this.detach_Provinces));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CountryID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CountryID
		{
			get
			{
				return this._CountryID;
			}
			set
			{
				if ((this._CountryID != value))
				{
					this.OnCountryIDChanging(value);
					this.SendPropertyChanging();
					this._CountryID = value;
					this.SendPropertyChanged("CountryID");
					this.OnCountryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Country", Storage="_Country1", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Country1
		{
			get
			{
				return this._Country1;
			}
			set
			{
				if ((this._Country1 != value))
				{
					this.OnCountry1Changing(value);
					this.SendPropertyChanging();
					this._Country1 = value;
					this.SendPropertyChanged("Country1");
					this.OnCountry1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Country_Customer", Storage="_Customers", ThisKey="CountryID", OtherKey="CountryID")]
		public EntitySet<Customer> Customers
		{
			get
			{
				return this._Customers;
			}
			set
			{
				this._Customers.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Country_Province", Storage="_Provinces", ThisKey="CountryID", OtherKey="CountryID")]
		public EntitySet<Province> Provinces
		{
			get
			{
				return this._Provinces;
			}
			set
			{
				this._Provinces.Assign(value);
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
		
		private void attach_Customers(Customer entity)
		{
			this.SendPropertyChanging();
			entity.Country = this;
		}
		
		private void detach_Customers(Customer entity)
		{
			this.SendPropertyChanging();
			entity.Country = null;
		}
		
		private void attach_Provinces(Province entity)
		{
			this.SendPropertyChanging();
			entity.Country = this;
		}
		
		private void detach_Provinces(Province entity)
		{
			this.SendPropertyChanging();
			entity.Country = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Customer")]
	public partial class Customer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _CustomerID;
		
		private string _FirstName;
		
		private string _LastName;
		
		private System.DateTime _BirthDate;
		
		private string _Phone;
		
		private string _Email;
		
		private string _Address;
		
		private int _ProvinceID;
		
		private int _CountryID;
		
		private System.DateTime _CreatedDate;
		
		private long _CreatedByID;
		
		private System.DateTime _ModifiedDate;
		
		private long _ModifiedByID;
		
		private bool _IsActive;
		
		private bool _IsDeleted;
		
		private EntityRef<Country> _Country;
		
		private EntityRef<Province> _Province;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCustomerIDChanging(long value);
    partial void OnCustomerIDChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnBirthDateChanging(System.DateTime value);
    partial void OnBirthDateChanged();
    partial void OnPhoneChanging(string value);
    partial void OnPhoneChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnProvinceIDChanging(int value);
    partial void OnProvinceIDChanged();
    partial void OnCountryIDChanging(int value);
    partial void OnCountryIDChanged();
    partial void OnCreatedDateChanging(System.DateTime value);
    partial void OnCreatedDateChanged();
    partial void OnCreatedByIDChanging(long value);
    partial void OnCreatedByIDChanged();
    partial void OnModifiedDateChanging(System.DateTime value);
    partial void OnModifiedDateChanged();
    partial void OnModifiedByIDChanging(long value);
    partial void OnModifiedByIDChanged();
    partial void OnIsActiveChanging(bool value);
    partial void OnIsActiveChanged();
    partial void OnIsDeletedChanging(bool value);
    partial void OnIsDeletedChanged();
    #endregion
		
		public Customer()
		{
			this._Country = default(EntityRef<Country>);
			this._Province = default(EntityRef<Province>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long CustomerID
		{
			get
			{
				return this._CustomerID;
			}
			set
			{
				if ((this._CustomerID != value))
				{
					this.OnCustomerIDChanging(value);
					this.SendPropertyChanging();
					this._CustomerID = value;
					this.SendPropertyChanged("CustomerID");
					this.OnCustomerIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BirthDate", DbType="DateTime NOT NULL")]
		public System.DateTime BirthDate
		{
			get
			{
				return this._BirthDate;
			}
			set
			{
				if ((this._BirthDate != value))
				{
					this.OnBirthDateChanging(value);
					this.SendPropertyChanging();
					this._BirthDate = value;
					this.SendPropertyChanged("BirthDate");
					this.OnBirthDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(320) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProvinceID", DbType="Int NOT NULL")]
		public int ProvinceID
		{
			get
			{
				return this._ProvinceID;
			}
			set
			{
				if ((this._ProvinceID != value))
				{
					if (this._Province.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProvinceIDChanging(value);
					this.SendPropertyChanging();
					this._ProvinceID = value;
					this.SendPropertyChanged("ProvinceID");
					this.OnProvinceIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CountryID", DbType="Int NOT NULL")]
		public int CountryID
		{
			get
			{
				return this._CountryID;
			}
			set
			{
				if ((this._CountryID != value))
				{
					if (this._Country.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCountryIDChanging(value);
					this.SendPropertyChanging();
					this._CountryID = value;
					this.SendPropertyChanged("CountryID");
					this.OnCountryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreatedDate
		{
			get
			{
				return this._CreatedDate;
			}
			set
			{
				if ((this._CreatedDate != value))
				{
					this.OnCreatedDateChanging(value);
					this.SendPropertyChanging();
					this._CreatedDate = value;
					this.SendPropertyChanged("CreatedDate");
					this.OnCreatedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedByID", DbType="BigInt NOT NULL")]
		public long CreatedByID
		{
			get
			{
				return this._CreatedByID;
			}
			set
			{
				if ((this._CreatedByID != value))
				{
					this.OnCreatedByIDChanging(value);
					this.SendPropertyChanging();
					this._CreatedByID = value;
					this.SendPropertyChanged("CreatedByID");
					this.OnCreatedByIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL")]
		public System.DateTime ModifiedDate
		{
			get
			{
				return this._ModifiedDate;
			}
			set
			{
				if ((this._ModifiedDate != value))
				{
					this.OnModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._ModifiedDate = value;
					this.SendPropertyChanged("ModifiedDate");
					this.OnModifiedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedByID", DbType="BigInt NOT NULL")]
		public long ModifiedByID
		{
			get
			{
				return this._ModifiedByID;
			}
			set
			{
				if ((this._ModifiedByID != value))
				{
					this.OnModifiedByIDChanging(value);
					this.SendPropertyChanging();
					this._ModifiedByID = value;
					this.SendPropertyChanged("ModifiedByID");
					this.OnModifiedByIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsActive", DbType="Bit NOT NULL")]
		public bool IsActive
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
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Country_Customer", Storage="_Country", ThisKey="CountryID", OtherKey="CountryID", IsForeignKey=true)]
		public Country Country
		{
			get
			{
				return this._Country.Entity;
			}
			set
			{
				Country previousValue = this._Country.Entity;
				if (((previousValue != value) 
							|| (this._Country.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Country.Entity = null;
						previousValue.Customers.Remove(this);
					}
					this._Country.Entity = value;
					if ((value != null))
					{
						value.Customers.Add(this);
						this._CountryID = value.CountryID;
					}
					else
					{
						this._CountryID = default(int);
					}
					this.SendPropertyChanged("Country");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Province_Customer", Storage="_Province", ThisKey="ProvinceID", OtherKey="ProvinceID", IsForeignKey=true)]
		public Province Province
		{
			get
			{
				return this._Province.Entity;
			}
			set
			{
				Province previousValue = this._Province.Entity;
				if (((previousValue != value) 
							|| (this._Province.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Province.Entity = null;
						previousValue.Customers.Remove(this);
					}
					this._Province.Entity = value;
					if ((value != null))
					{
						value.Customers.Add(this);
						this._ProvinceID = value.ProvinceID;
					}
					else
					{
						this._ProvinceID = default(int);
					}
					this.SendPropertyChanged("Province");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Province")]
	public partial class Province : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ProvinceID;
		
		private int _CountryID;
		
		private string _Province1;
		
		private EntitySet<Customer> _Customers;
		
		private EntityRef<Country> _Country;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProvinceIDChanging(int value);
    partial void OnProvinceIDChanged();
    partial void OnCountryIDChanging(int value);
    partial void OnCountryIDChanged();
    partial void OnProvince1Changing(string value);
    partial void OnProvince1Changed();
    #endregion
		
		public Province()
		{
			this._Customers = new EntitySet<Customer>(new Action<Customer>(this.attach_Customers), new Action<Customer>(this.detach_Customers));
			this._Country = default(EntityRef<Country>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProvinceID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ProvinceID
		{
			get
			{
				return this._ProvinceID;
			}
			set
			{
				if ((this._ProvinceID != value))
				{
					this.OnProvinceIDChanging(value);
					this.SendPropertyChanging();
					this._ProvinceID = value;
					this.SendPropertyChanged("ProvinceID");
					this.OnProvinceIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CountryID", DbType="Int NOT NULL")]
		public int CountryID
		{
			get
			{
				return this._CountryID;
			}
			set
			{
				if ((this._CountryID != value))
				{
					if (this._Country.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCountryIDChanging(value);
					this.SendPropertyChanging();
					this._CountryID = value;
					this.SendPropertyChanged("CountryID");
					this.OnCountryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Province", Storage="_Province1", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Province1
		{
			get
			{
				return this._Province1;
			}
			set
			{
				if ((this._Province1 != value))
				{
					this.OnProvince1Changing(value);
					this.SendPropertyChanging();
					this._Province1 = value;
					this.SendPropertyChanged("Province1");
					this.OnProvince1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Province_Customer", Storage="_Customers", ThisKey="ProvinceID", OtherKey="ProvinceID")]
		public EntitySet<Customer> Customers
		{
			get
			{
				return this._Customers;
			}
			set
			{
				this._Customers.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Country_Province", Storage="_Country", ThisKey="CountryID", OtherKey="CountryID", IsForeignKey=true)]
		public Country Country
		{
			get
			{
				return this._Country.Entity;
			}
			set
			{
				Country previousValue = this._Country.Entity;
				if (((previousValue != value) 
							|| (this._Country.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Country.Entity = null;
						previousValue.Provinces.Remove(this);
					}
					this._Country.Entity = value;
					if ((value != null))
					{
						value.Provinces.Add(this);
						this._CountryID = value.CountryID;
					}
					else
					{
						this._CountryID = default(int);
					}
					this.SendPropertyChanged("Country");
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
		
		private void attach_Customers(Customer entity)
		{
			this.SendPropertyChanging();
			entity.Province = this;
		}
		
		private void detach_Customers(Customer entity)
		{
			this.SendPropertyChanging();
			entity.Province = null;
		}
	}
}
#pragma warning restore 1591