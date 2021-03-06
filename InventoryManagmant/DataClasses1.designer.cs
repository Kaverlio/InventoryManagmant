#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryManagmant
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Inventorydb")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertCategoryTbl(CategoryTbl instance);
    partial void UpdateCategoryTbl(CategoryTbl instance);
    partial void DeleteCategoryTbl(CategoryTbl instance);
    partial void InsertUserTbl(UserTbl instance);
    partial void UpdateUserTbl(UserTbl instance);
    partial void DeleteUserTbl(UserTbl instance);
    partial void InsertCustomerTbl(CustomerTbl instance);
    partial void UpdateCustomerTbl(CustomerTbl instance);
    partial void DeleteCustomerTbl(CustomerTbl instance);
    partial void InsertProductTbl(ProductTbl instance);
    partial void UpdateProductTbl(ProductTbl instance);
    partial void DeleteProductTbl(ProductTbl instance);
    partial void InsertOrdersTbl(OrdersTbl instance);
    partial void UpdateOrdersTbl(OrdersTbl instance);
    partial void DeleteOrdersTbl(OrdersTbl instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::InventoryManagmant.Properties.Settings.Default.InventorydbConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<CategoryTbl> CategoryTbl
		{
			get
			{
				return this.GetTable<CategoryTbl>();
			}
		}
		
		public System.Data.Linq.Table<UserTbl> UserTbl
		{
			get
			{
				return this.GetTable<UserTbl>();
			}
		}
		
		public System.Data.Linq.Table<CustomerTbl> CustomerTbl
		{
			get
			{
				return this.GetTable<CustomerTbl>();
			}
		}
		
		public System.Data.Linq.Table<ProductTbl> ProductTbl
		{
			get
			{
				return this.GetTable<ProductTbl>();
			}
		}
		
		public System.Data.Linq.Table<OrdersTbl> OrdersTbl
		{
			get
			{
				return this.GetTable<OrdersTbl>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CategoryTbl")]
	public partial class CategoryTbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CatId;
		
		private string _CatName;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCatIdChanging(int value);
    partial void OnCatIdChanged();
    partial void OnCatNameChanging(string value);
    partial void OnCatNameChanged();
    #endregion
		
		public CategoryTbl()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CatId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int CatId
		{
			get
			{
				return this._CatId;
			}
			set
			{
				if ((this._CatId != value))
				{
					this.OnCatIdChanging(value);
					this.SendPropertyChanging();
					this._CatId = value;
					this.SendPropertyChanged("CatId");
					this.OnCatIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CatName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CatName
		{
			get
			{
				return this._CatName;
			}
			set
			{
				if ((this._CatName != value))
				{
					this.OnCatNameChanging(value);
					this.SendPropertyChanging();
					this._CatName = value;
					this.SendPropertyChanged("CatName");
					this.OnCatNameChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserTbl")]
	public partial class UserTbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Uname;
		
		private string _Ufullname;
		
		private string _Upassword;
		
		private string _UPhone;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUnameChanging(string value);
    partial void OnUnameChanged();
    partial void OnUfullnameChanging(string value);
    partial void OnUfullnameChanged();
    partial void OnUpasswordChanging(string value);
    partial void OnUpasswordChanged();
    partial void OnUPhoneChanging(string value);
    partial void OnUPhoneChanged();
    #endregion
		
		public UserTbl()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Uname", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Uname
		{
			get
			{
				return this._Uname;
			}
			set
			{
				if ((this._Uname != value))
				{
					this.OnUnameChanging(value);
					this.SendPropertyChanging();
					this._Uname = value;
					this.SendPropertyChanged("Uname");
					this.OnUnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ufullname", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Ufullname
		{
			get
			{
				return this._Ufullname;
			}
			set
			{
				if ((this._Ufullname != value))
				{
					this.OnUfullnameChanging(value);
					this.SendPropertyChanging();
					this._Ufullname = value;
					this.SendPropertyChanged("Ufullname");
					this.OnUfullnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Upassword", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Upassword
		{
			get
			{
				return this._Upassword;
			}
			set
			{
				if ((this._Upassword != value))
				{
					this.OnUpasswordChanging(value);
					this.SendPropertyChanging();
					this._Upassword = value;
					this.SendPropertyChanged("Upassword");
					this.OnUpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UPhone", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string UPhone
		{
			get
			{
				return this._UPhone;
			}
			set
			{
				if ((this._UPhone != value))
				{
					this.OnUPhoneChanging(value);
					this.SendPropertyChanging();
					this._UPhone = value;
					this.SendPropertyChanged("UPhone");
					this.OnUPhoneChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CustomerTbl")]
	public partial class CustomerTbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CustId;
		
		private string _CustName;
		
		private string _CustPhone;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCustIdChanging(int value);
    partial void OnCustIdChanged();
    partial void OnCustNameChanging(string value);
    partial void OnCustNameChanged();
    partial void OnCustPhoneChanging(string value);
    partial void OnCustPhoneChanged();
    #endregion
		
		public CustomerTbl()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int CustId
		{
			get
			{
				return this._CustId;
			}
			set
			{
				if ((this._CustId != value))
				{
					this.OnCustIdChanging(value);
					this.SendPropertyChanging();
					this._CustId = value;
					this.SendPropertyChanged("CustId");
					this.OnCustIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CustName
		{
			get
			{
				return this._CustName;
			}
			set
			{
				if ((this._CustName != value))
				{
					this.OnCustNameChanging(value);
					this.SendPropertyChanging();
					this._CustName = value;
					this.SendPropertyChanged("CustName");
					this.OnCustNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustPhone", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CustPhone
		{
			get
			{
				return this._CustPhone;
			}
			set
			{
				if ((this._CustPhone != value))
				{
					this.OnCustPhoneChanging(value);
					this.SendPropertyChanging();
					this._CustPhone = value;
					this.SendPropertyChanged("CustPhone");
					this.OnCustPhoneChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ProductTbl")]
	public partial class ProductTbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ProdId;
		
		private string _ProdName;
		
		private int _ProdQty;
		
		private int _ProdPrice;
		
		private string _ProdDesc;
		
		private string _Prodcat;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProdIdChanging(int value);
    partial void OnProdIdChanged();
    partial void OnProdNameChanging(string value);
    partial void OnProdNameChanged();
    partial void OnProdQtyChanging(int value);
    partial void OnProdQtyChanged();
    partial void OnProdPriceChanging(int value);
    partial void OnProdPriceChanged();
    partial void OnProdDescChanging(string value);
    partial void OnProdDescChanged();
    partial void OnProdcatChanging(string value);
    partial void OnProdcatChanged();
    #endregion
		
		public ProductTbl()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProdId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ProdId
		{
			get
			{
				return this._ProdId;
			}
			set
			{
				if ((this._ProdId != value))
				{
					this.OnProdIdChanging(value);
					this.SendPropertyChanging();
					this._ProdId = value;
					this.SendPropertyChanged("ProdId");
					this.OnProdIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProdName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ProdName
		{
			get
			{
				return this._ProdName;
			}
			set
			{
				if ((this._ProdName != value))
				{
					this.OnProdNameChanging(value);
					this.SendPropertyChanging();
					this._ProdName = value;
					this.SendPropertyChanged("ProdName");
					this.OnProdNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProdQty", DbType="Int NOT NULL")]
		public int ProdQty
		{
			get
			{
				return this._ProdQty;
			}
			set
			{
				if ((this._ProdQty != value))
				{
					this.OnProdQtyChanging(value);
					this.SendPropertyChanging();
					this._ProdQty = value;
					this.SendPropertyChanged("ProdQty");
					this.OnProdQtyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProdPrice", DbType="Int NOT NULL")]
		public int ProdPrice
		{
			get
			{
				return this._ProdPrice;
			}
			set
			{
				if ((this._ProdPrice != value))
				{
					this.OnProdPriceChanging(value);
					this.SendPropertyChanging();
					this._ProdPrice = value;
					this.SendPropertyChanged("ProdPrice");
					this.OnProdPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProdDesc", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ProdDesc
		{
			get
			{
				return this._ProdDesc;
			}
			set
			{
				if ((this._ProdDesc != value))
				{
					this.OnProdDescChanging(value);
					this.SendPropertyChanging();
					this._ProdDesc = value;
					this.SendPropertyChanged("ProdDesc");
					this.OnProdDescChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Prodcat", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Prodcat
		{
			get
			{
				return this._Prodcat;
			}
			set
			{
				if ((this._Prodcat != value))
				{
					this.OnProdcatChanging(value);
					this.SendPropertyChanging();
					this._Prodcat = value;
					this.SendPropertyChanged("Prodcat");
					this.OnProdcatChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.OrdersTbl")]
	public partial class OrdersTbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _OrderId;
		
		private int _CustId;
		
		private string _DataSell;
		
		private System.DateTime _OrderDate;
		
		private int _TotalAmt;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnOrderIdChanging(int value);
    partial void OnOrderIdChanged();
    partial void OnCustIdChanging(int value);
    partial void OnCustIdChanged();
    partial void OnDataSellChanging(string value);
    partial void OnDataSellChanged();
    partial void OnOrderDateChanging(System.DateTime value);
    partial void OnOrderDateChanged();
    partial void OnTotalAmtChanging(int value);
    partial void OnTotalAmtChanged();
    #endregion
		
		public OrdersTbl()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int OrderId
		{
			get
			{
				return this._OrderId;
			}
			set
			{
				if ((this._OrderId != value))
				{
					this.OnOrderIdChanging(value);
					this.SendPropertyChanging();
					this._OrderId = value;
					this.SendPropertyChanged("OrderId");
					this.OnOrderIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustId", DbType="Int NOT NULL")]
		public int CustId
		{
			get
			{
				return this._CustId;
			}
			set
			{
				if ((this._CustId != value))
				{
					this.OnCustIdChanging(value);
					this.SendPropertyChanging();
					this._CustId = value;
					this.SendPropertyChanged("CustId");
					this.OnCustIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DataSell", DbType="VarChar(150) NOT NULL", CanBeNull=false)]
		public string DataSell
		{
			get
			{
				return this._DataSell;
			}
			set
			{
				if ((this._DataSell != value))
				{
					this.OnDataSellChanging(value);
					this.SendPropertyChanging();
					this._DataSell = value;
					this.SendPropertyChanged("DataSell");
					this.OnDataSellChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderDate", DbType="DateTime NOT NULL")]
		public System.DateTime OrderDate
		{
			get
			{
				return this._OrderDate;
			}
			set
			{
				if ((this._OrderDate != value))
				{
					this.OnOrderDateChanging(value);
					this.SendPropertyChanging();
					this._OrderDate = value;
					this.SendPropertyChanged("OrderDate");
					this.OnOrderDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotalAmt", DbType="Int NOT NULL")]
		public int TotalAmt
		{
			get
			{
				return this._TotalAmt;
			}
			set
			{
				if ((this._TotalAmt != value))
				{
					this.OnTotalAmtChanging(value);
					this.SendPropertyChanging();
					this._TotalAmt = value;
					this.SendPropertyChanged("TotalAmt");
					this.OnTotalAmtChanged();
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
