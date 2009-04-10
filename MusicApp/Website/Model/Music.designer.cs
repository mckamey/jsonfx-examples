﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3074
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicApp.Model
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
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="Music")]
	public partial class MusicDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertArtist(Artist instance);
    partial void UpdateArtist(Artist instance);
    partial void DeleteArtist(Artist instance);
    partial void InsertGenre(Genre instance);
    partial void UpdateGenre(Genre instance);
    partial void DeleteGenre(Genre instance);
    partial void InsertMember(Member instance);
    partial void UpdateMember(Member instance);
    partial void DeleteMember(Member instance);
    #endregion
		
		public MusicDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["MusicConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MusicDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MusicDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MusicDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MusicDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Artist> Artists
		{
			get
			{
				return this.GetTable<Artist>();
			}
		}
		
		public System.Data.Linq.Table<ArtistGenre> ArtistGenres
		{
			get
			{
				return this.GetTable<ArtistGenre>();
			}
		}
		
		public System.Data.Linq.Table<Genre> Genres
		{
			get
			{
				return this.GetTable<Genre>();
			}
		}
		
		public System.Data.Linq.Table<Member> Members
		{
			get
			{
				return this.GetTable<Member>();
			}
		}
	}
	
	[Table(Name="dbo.Artist")]
	public partial class Artist : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ArtistID;
		
		private string _ArtistName;
		
		private string _SortName;
		
		private string _WikipediaKey;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnArtistIDChanging(long value);
    partial void OnArtistIDChanged();
    partial void OnArtistNameChanging(string value);
    partial void OnArtistNameChanged();
    partial void OnSortNameChanging(string value);
    partial void OnSortNameChanged();
    partial void OnWikipediaKeyChanging(string value);
    partial void OnWikipediaKeyChanged();
    #endregion
		
		public Artist()
		{
			OnCreated();
		}
		
		[Column(Storage="_ArtistID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ArtistID
		{
			get
			{
				return this._ArtistID;
			}
			set
			{
				if ((this._ArtistID != value))
				{
					this.OnArtistIDChanging(value);
					this.SendPropertyChanging();
					this._ArtistID = value;
					this.SendPropertyChanged("ArtistID");
					this.OnArtistIDChanged();
				}
			}
		}
		
		[Column(Storage="_ArtistName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string ArtistName
		{
			get
			{
				return this._ArtistName;
			}
			set
			{
				if ((this._ArtistName != value))
				{
					this.OnArtistNameChanging(value);
					this.SendPropertyChanging();
					this._ArtistName = value;
					this.SendPropertyChanged("ArtistName");
					this.OnArtistNameChanged();
				}
			}
		}
		
		[Column(Storage="_SortName", DbType="NVarChar(50)")]
		public string SortName
		{
			get
			{
				return this._SortName;
			}
			set
			{
				if ((this._SortName != value))
				{
					this.OnSortNameChanging(value);
					this.SendPropertyChanging();
					this._SortName = value;
					this.SendPropertyChanged("SortName");
					this.OnSortNameChanged();
				}
			}
		}
		
		[Column(Storage="_WikipediaKey", DbType="NVarChar(50)")]
		public string WikipediaKey
		{
			get
			{
				return this._WikipediaKey;
			}
			set
			{
				if ((this._WikipediaKey != value))
				{
					this.OnWikipediaKeyChanging(value);
					this.SendPropertyChanging();
					this._WikipediaKey = value;
					this.SendPropertyChanged("WikipediaKey");
					this.OnWikipediaKeyChanged();
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
	
	[Table(Name="dbo.ArtistGenre")]
	public partial class ArtistGenre
	{
		
		private long _ArtistID;
		
		private long _GenreID;
		
		public ArtistGenre()
		{
		}
		
		[Column(Storage="_ArtistID", DbType="BigInt NOT NULL")]
		public long ArtistID
		{
			get
			{
				return this._ArtistID;
			}
			set
			{
				if ((this._ArtistID != value))
				{
					this._ArtistID = value;
				}
			}
		}
		
		[Column(Storage="_GenreID", DbType="BigInt NOT NULL")]
		public long GenreID
		{
			get
			{
				return this._GenreID;
			}
			set
			{
				if ((this._GenreID != value))
				{
					this._GenreID = value;
				}
			}
		}
	}
	
	[Table(Name="dbo.Genre")]
	public partial class Genre : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _GenreID;
		
		private string _GenreName;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnGenreIDChanging(long value);
    partial void OnGenreIDChanged();
    partial void OnGenreNameChanging(string value);
    partial void OnGenreNameChanged();
    #endregion
		
		public Genre()
		{
			OnCreated();
		}
		
		[Column(Storage="_GenreID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long GenreID
		{
			get
			{
				return this._GenreID;
			}
			set
			{
				if ((this._GenreID != value))
				{
					this.OnGenreIDChanging(value);
					this.SendPropertyChanging();
					this._GenreID = value;
					this.SendPropertyChanged("GenreID");
					this.OnGenreIDChanged();
				}
			}
		}
		
		[Column(Storage="_GenreName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string GenreName
		{
			get
			{
				return this._GenreName;
			}
			set
			{
				if ((this._GenreName != value))
				{
					this.OnGenreNameChanging(value);
					this.SendPropertyChanging();
					this._GenreName = value;
					this.SendPropertyChanged("GenreName");
					this.OnGenreNameChanged();
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
	
	[Table(Name="dbo.Member")]
	public partial class Member : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _MemberID;
		
		private long _ArtistID;
		
		private string _FirstName;
		
		private string _LastName;
		
		private short _StartYear;
		
		private System.Nullable<short> _EndYear;
		
		private string _Instruments;
		
		private string _WikipediaKey;
		
		private EntityRef<Artist> _Artist;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMemberIDChanging(long value);
    partial void OnMemberIDChanged();
    partial void OnArtistIDChanging(long value);
    partial void OnArtistIDChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnStartYearChanging(short value);
    partial void OnStartYearChanged();
    partial void OnEndYearChanging(System.Nullable<short> value);
    partial void OnEndYearChanged();
    partial void OnInstrumentsChanging(string value);
    partial void OnInstrumentsChanged();
    partial void OnWikipediaKeyChanging(string value);
    partial void OnWikipediaKeyChanged();
    #endregion
		
		public Member()
		{
			this._Artist = default(EntityRef<Artist>);
			OnCreated();
		}
		
		[Column(Storage="_MemberID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long MemberID
		{
			get
			{
				return this._MemberID;
			}
			set
			{
				if ((this._MemberID != value))
				{
					this.OnMemberIDChanging(value);
					this.SendPropertyChanging();
					this._MemberID = value;
					this.SendPropertyChanged("MemberID");
					this.OnMemberIDChanged();
				}
			}
		}
		
		[Column(Storage="_ArtistID", DbType="BigInt NOT NULL")]
		public long ArtistID
		{
			get
			{
				return this._ArtistID;
			}
			set
			{
				if ((this._ArtistID != value))
				{
					if (this._Artist.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnArtistIDChanging(value);
					this.SendPropertyChanging();
					this._ArtistID = value;
					this.SendPropertyChanged("ArtistID");
					this.OnArtistIDChanged();
				}
			}
		}
		
		[Column(Storage="_FirstName", DbType="NVarChar(50)")]
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
		
		[Column(Storage="_LastName", DbType="NVarChar(50)")]
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
		
		[Column(Storage="_StartYear", DbType="SmallInt NOT NULL")]
		public short StartYear
		{
			get
			{
				return this._StartYear;
			}
			set
			{
				if ((this._StartYear != value))
				{
					this.OnStartYearChanging(value);
					this.SendPropertyChanging();
					this._StartYear = value;
					this.SendPropertyChanged("StartYear");
					this.OnStartYearChanged();
				}
			}
		}
		
		[Column(Storage="_EndYear", DbType="SmallInt")]
		public System.Nullable<short> EndYear
		{
			get
			{
				return this._EndYear;
			}
			set
			{
				if ((this._EndYear != value))
				{
					this.OnEndYearChanging(value);
					this.SendPropertyChanging();
					this._EndYear = value;
					this.SendPropertyChanged("EndYear");
					this.OnEndYearChanged();
				}
			}
		}
		
		[Column(Storage="_Instruments", DbType="NVarChar(150)")]
		public string Instruments
		{
			get
			{
				return this._Instruments;
			}
			set
			{
				if ((this._Instruments != value))
				{
					this.OnInstrumentsChanging(value);
					this.SendPropertyChanging();
					this._Instruments = value;
					this.SendPropertyChanged("Instruments");
					this.OnInstrumentsChanged();
				}
			}
		}
		
		[Column(Storage="_WikipediaKey", DbType="NVarChar(50)")]
		public string WikipediaKey
		{
			get
			{
				return this._WikipediaKey;
			}
			set
			{
				if ((this._WikipediaKey != value))
				{
					this.OnWikipediaKeyChanging(value);
					this.SendPropertyChanging();
					this._WikipediaKey = value;
					this.SendPropertyChanged("WikipediaKey");
					this.OnWikipediaKeyChanged();
				}
			}
		}
		
		[Association(Name="Artist_Member", Storage="_Artist", ThisKey="ArtistID", OtherKey="ArtistID", IsForeignKey=true)]
		internal Artist Artist
		{
			get
			{
				return this._Artist.Entity;
			}
			set
			{
				if ((this._Artist.Entity != value))
				{
					this.SendPropertyChanging();
					this._Artist.Entity = value;
					this.SendPropertyChanged("Artist");
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
