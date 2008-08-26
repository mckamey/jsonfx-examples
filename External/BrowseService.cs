using System;
using System.ComponentModel;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Web;

using MediaLib.Web;
using JsonFx.Json;
using JsonFx.JsonRpc;

namespace MediaLib
{
	[JsonService(Namespace="Browse", Name="Proxy")]
	public class BrowseService
	{
		#region Constants

		private static readonly string PhysicalRoot;

		#endregion Constants

		#region Init

		/// <summary>
		/// CCtor
		/// </summary>
		static BrowseService()
		{
			BrowseService.PhysicalRoot = ConfigurationManager.AppSettings["PhysicalRoot"];
		}

		#endregion Init

		#region Service Methods

		[JsonMethod("browse")]
		public BrowseNode Browse(string path)
		{
			bool isRoot = "/".Equals(path);

			path = BrowseService.GetPhysicalPath(path);

			DirectoryInfo target = new DirectoryInfo(path);
			if (!target.Exists)
			{
				FileInfo file = new FileInfo(path);
				if (!file.Exists)
				{
					throw new FileNotFoundException("Folder does not exist.");
				}
				return BrowseNode.Create(file, true);
			}

			BrowseNode node = BrowseNode.Create(target, false);
			if (isRoot)
			{
				node.Name = String.Empty;
			}

			bool hasMedia = false;
			FileSystemInfo[] children = target.GetFileSystemInfos();
			foreach (FileSystemInfo child in children)
			{
				BrowseNode childNode = BrowseNode.Create(child, false);

				MimeType mime = MimeTypes.GetByExtension(child.Extension);
				if (mime != null)
				{
					if (!hasMedia)
					{
						if (mime.Category == MimeCategory.Audio)
						{
							BrowseNode playlist = new BrowseNode();
							playlist.Name = "Playlist";
							playlist.Path = Path.Combine(node.Path, "Playlist.m3u");
							playlist.IsDownload = true;
							node.Children.Insert(0, playlist);

							hasMedia = true;
						}
						else if (mime.Category == MimeCategory.Video)
						{
							BrowseNode playlist = new BrowseNode();
							playlist.Name = "Playlist";
							playlist.Path = Path.Combine(node.Path, "Playlist.wpl");
							playlist.IsDownload = true;
							node.Children.Insert(0, playlist);

							hasMedia = true;
						}
					}
				}

				node.Children.Add(childNode);
			}

			if (hasMedia && children.Length > 1)
			{
				// only worth creating an archive if more than one media file
				BrowseNode archive = new BrowseNode();
				archive.Name = "Download";
				archive.Path = Path.Combine(node.Path, "Download.zip");
				archive.IsDownload = true;
				node.Children.Insert(0, archive);
			}

			return node;
		}

		#endregion Service Methods

		#region Utility Methods

		public static string GetVirtualPath(string path)
		{
			return path.Substring(BrowseService.PhysicalRoot.Length-1).Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
		}

		public static string GetPhysicalPath(string path)
		{
			if (path == null)
			{
				path = String.Empty;
			}

			path = path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
			path = HttpUtility.UrlDecode(path);
			if (path.IndexOf("..\\") >= 0)
			{
				throw new NotSupportedException("Invalid path.");
			}

			int i = 0;
			for (; i<path.Length; i++)
			{
				if (path[i] != '.' && path[i] != '\\')
				{
					break;
				}
			}
			path = path.Substring(i);
			path = Path.Combine(BrowseService.PhysicalRoot, path);
			return path;
		}

		#endregion Utility Methods
	}

	public class BrowseNode
	{
		#region Fields

		private string name;
		private string path;
		private long bytes = 0L;
		private bool isDownload = false;
		private bool isSpecial = false;
		private MimeCategory category = MimeCategory.Unknown;
		private string fileType;
		private string mimeType;
		private Nullable<DateTime> dateCreated;
		private Nullable<DateTime> dateModified;

		#endregion Fields

		#region Properties

		[DefaultValue(null)]
		[JsonName("name")]
		public string Name
		{
			get
			{
				if (this.name == null)
				{
					return String.Empty;
				}
				return this.name;
			}
			set { this.name = value; }
		}

		[DefaultValue("")]
		[JsonName("path")]
		public string Path
		{
			get
			{
				if (this.path == null)
				{
					return String.Empty;
				}
				return this.path;
			}
			set { this.path = value; }
		}

		[DefaultValue(0L)]
		[JsonName("bytes")]
		public long Bytes
		{
			get { return this.bytes; }
			set { this.bytes = value; }
		}

		[DefaultValue(false)]
		[JsonName("isSpecial")]
		public bool IsSpecial
		{
			get { return this.isSpecial; }
			set { this.isSpecial = value; }
		}

		[DefaultValue(false)]
		[JsonName("isDownload")]
		public bool IsDownload
		{
			get { return this.isDownload; }
			set { this.isDownload = value; }
		}

		[JsonName("category")]
		public MimeCategory Category
		{
			get { return this.category; }
			set { this.category = value; }
		}

		[DefaultValue("")]
		[JsonName("fileType")]
		public string FileType
		{
			get
			{
				if (this.fileType == null)
				{
					return String.Empty;
				}
				return this.fileType;
			}
			set { this.fileType = value; }
		}

		[DefaultValue("")]
		[JsonName("mimeType")]
		public string MimeType
		{
			get
			{
				if (this.mimeType == null)
				{
					return String.Empty;
				}
				return this.mimeType;
			}
			set { this.mimeType = value; }
		}

		[JsonName("dateCreated")]
		[JsonSpecifiedProperty("HasDateCreated")]
		public DateTime DateCreated
		{
			get
			{
				if (!this.dateCreated.HasValue)
				{
					return DateTime.MinValue;
				}
				return this.dateCreated.Value;
			}
			set { this.dateCreated = value; }
		}

		[JsonIgnore]
		public bool HasDateCreated
		{
			get { return this.dateCreated.HasValue; }
		}

		[JsonName("dateModified")]
		[JsonSpecifiedProperty("HasDateModified")]
		public DateTime DateModified
		{
			get
			{
				if (!this.dateModified.HasValue)
				{
					return DateTime.MinValue;
				}
				return this.dateModified.Value;
			}
			set { this.dateModified = value; }
		}

		[JsonIgnore]
		public bool HasDateModified
		{
			get { return this.dateModified.HasValue; }
		}

		[JsonName("children")]
		[JsonSpecifiedProperty("HasChildren")]
		public readonly List<BrowseNode> Children = new List<BrowseNode>();

		[JsonIgnore]
		public bool HasChildren
		{
			get { return this.Children.Count > 0; }
		}

		#endregion Properties

		#region Methods

		public static BrowseNode Create(FileSystemInfo info, bool addDetails)
		{
			BrowseNode node = new BrowseNode();
			node.SetName(info.Name);
			node.Path = BrowseService.GetVirtualPath(info.FullName);
			if ((info.Attributes&FileAttributes.Directory) == FileAttributes.Directory)
			{
				node.Category = MimeCategory.Folder;
				if (!node.Path.EndsWith(System.IO.Path.AltDirectorySeparatorChar.ToString()))
				{
					node.Path += System.IO.Path.AltDirectorySeparatorChar;
				}
			}
			else
			{
				if (info is FileInfo)
				{
					node.bytes = ((FileInfo)info).Length;
				}
				MimeType mime = MimeTypes.GetByExtension(info.Extension);
				if (mime != null)
				{
					node.Category = mime.Category;
					if (addDetails)
					{
						node.FileType = mime.Name;
						node.MimeType = mime.ContentType;
					}
				}
			}
			if (addDetails)
			{
				node.DateCreated = info.CreationTimeUtc;
				node.DateModified = info.LastWriteTimeUtc;
			}
			return node;
		}

		private void SetName(string folderName)
		{
			if ((folderName.StartsWith("[ ") && folderName.EndsWith(" ]")) ||
				(folderName.StartsWith("( ") && folderName.EndsWith(" )")))
			{
				this.Name = folderName.Substring(2, folderName.Length-4);
				this.IsSpecial = true;
			}
			else
			{
				this.Name = folderName;
			}
		}

		#endregion Methods
	}
}