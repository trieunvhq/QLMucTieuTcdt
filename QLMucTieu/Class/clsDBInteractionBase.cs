using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace QLMucTieu
{
	public enum LLBLError
	{
		AllOk
		// Add more here (check the comma's!)
	}


	public interface ICommonDBAccess
	{
		bool		Insert();
		bool		Update();
		bool		Delete();
		DataTable	SelectOne();
		DataTable	SelectAll();
	}


	public abstract class clsDBInteractionBase : IDisposable, ICommonDBAccess
	{
		#region Class Member Declarations
			protected	SqlConnection			m_scoMainConnection;
			private		bool					m_bIsDisposed;
		#endregion


		public clsDBInteractionBase()
		{
			// Initialize the class' members.
			InitClass();
		}


		private void InitClass()
		{
			// create all the objects and initialize other members.
			m_scoMainConnection = new SqlConnection();
			AppSettingsReader m_asrConfigReader = new AppSettingsReader();

			// Set connection string of the sqlconnection object
			m_scoMainConnection.ConnectionString = 
						m_asrConfigReader.GetValue("Main.ConnectionString", typeof(string)).ToString();
			m_bIsDisposed = false;
		}


		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}


		protected virtual void Dispose(bool bIsDisposing)
		{
			// Check to see if Dispose has already been called.
			if(!m_bIsDisposed)
			{
				if(bIsDisposing)
				{
					// Dispose managed resources.
					m_scoMainConnection.Dispose();
					m_scoMainConnection = null;
				}
			}
			m_bIsDisposed = true;
		}


		public virtual bool Insert()
		{
			// No implementation, throw exception
			throw new NotImplementedException();
		}


		public virtual bool Delete()
		{
			// No implementation, throw exception
			throw new NotImplementedException();
		}


		public virtual bool Update()
		{
			// No implementation, throw exception
			throw new NotImplementedException();
		}


		public virtual DataTable SelectOne()
		{
			// No implementation, throw exception
			throw new NotImplementedException();
		}


		public virtual DataTable SelectAll()
		{
			// No implementation, throw exception
			throw new NotImplementedException();
		}


		#region Class Property Declarations
		#endregion
	}
}
