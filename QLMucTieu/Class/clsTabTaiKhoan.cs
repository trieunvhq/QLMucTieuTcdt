using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace QLMucTieu
{
	public class clsTabTaiKhoan : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlInt32		m_iId;
			private SqlString		m_sChucVu, m_sSoDienThoai, m_sDiaChi, m_sCapBac, m_sTaiKhoan, m_sMatKhau, m_sHoTen;
		#endregion


		public clsTabTaiKhoan()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_tabTaiKhoan_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@staiKhoan", SqlDbType.NChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sTaiKhoan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@smatKhau", SqlDbType.NChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sMatKhau));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@shoTen", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sHoTen));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@scapBac", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sCapBac));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@schucVu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sChucVu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@ssoDienThoai", SqlDbType.NChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoDienThoai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sdiaChi", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDiaChi));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iId));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iId = (SqlInt32)scmCmdToExecute.Parameters["@iid"].Value;
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTabTaiKhoan::Insert::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				m_scoMainConnection.Close();
				scmCmdToExecute.Dispose();
			}
		}

        //
        //
        public DataTable pr_tabTaiKhoan_Login(string taiKhoan, string pass)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_tabTaiKhoan_Login]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_tabTaiKhoan_Login");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@staiKhoan", SqlDbType.NChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, taiKhoan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@smatKhau", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pass));

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_tabTaiKhoan_Login", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }


        public override bool Update()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_tabTaiKhoan_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iId));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@staiKhoan", SqlDbType.NChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sTaiKhoan));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@smatKhau", SqlDbType.NChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sMatKhau));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@shoTen", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sHoTen));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@scapBac", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sCapBac));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@schucVu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sChucVu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@ssoDienThoai", SqlDbType.NChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoDienThoai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sdiaChi", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDiaChi));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTabTaiKhoan::Update::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				m_scoMainConnection.Close();
				scmCmdToExecute.Dispose();
			}
		}


		public override bool Delete()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_tabTaiKhoan_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iId));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTabTaiKhoan::Delete::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				m_scoMainConnection.Close();
				scmCmdToExecute.Dispose();
			}
		}


		public override DataTable SelectOne()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_tabTaiKhoan_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("tabTaiKhoan");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iId));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				if(dtToReturn.Rows.Count > 0)
				{
					m_iId = (Int32)dtToReturn.Rows[0]["id"];
					m_sTaiKhoan = dtToReturn.Rows[0]["taiKhoan"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["taiKhoan"];
					m_sMatKhau = dtToReturn.Rows[0]["matKhau"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["matKhau"];
					m_sHoTen = dtToReturn.Rows[0]["hoTen"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["hoTen"];
					m_sCapBac = dtToReturn.Rows[0]["capBac"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["capBac"];
					m_sChucVu = dtToReturn.Rows[0]["chucVu"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["chucVu"];
					m_sSoDienThoai = dtToReturn.Rows[0]["soDienThoai"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["soDienThoai"];
					m_sDiaChi = dtToReturn.Rows[0]["diaChi"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["diaChi"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTabTaiKhoan::SelectOne::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				m_scoMainConnection.Close();
				scmCmdToExecute.Dispose();
				sdaAdapter.Dispose();
			}
		}


		public override DataTable SelectAll()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_tabTaiKhoan_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("tabTaiKhoan");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTabTaiKhoan::SelectAll::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				m_scoMainConnection.Close();
				scmCmdToExecute.Dispose();
				sdaAdapter.Dispose();
			}
		}


		#region Class Property Declarations
		public SqlInt32 iId
		{
			get
			{
				return m_iId;
			}
			set
			{
				SqlInt32 iIdTmp = (SqlInt32)value;
				if(iIdTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iId", "iId can't be NULL");
				}
				m_iId = value;
			}
		}


		public SqlString sTaiKhoan
		{
			get
			{
				return m_sTaiKhoan;
			}
			set
			{
				SqlString sTaiKhoanTmp = (SqlString)value;
				if(sTaiKhoanTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sTaiKhoan", "sTaiKhoan can't be NULL");
				}
				m_sTaiKhoan = value;
			}
		}


		public SqlString sMatKhau
		{
			get
			{
				return m_sMatKhau;
			}
			set
			{
				SqlString sMatKhauTmp = (SqlString)value;
				if(sMatKhauTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sMatKhau", "sMatKhau can't be NULL");
				}
				m_sMatKhau = value;
			}
		}


		public SqlString sHoTen
		{
			get
			{
				return m_sHoTen;
			}
			set
			{
				SqlString sHoTenTmp = (SqlString)value;
				if(sHoTenTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sHoTen", "sHoTen can't be NULL");
				}
				m_sHoTen = value;
			}
		}


		public SqlString sCapBac
		{
			get
			{
				return m_sCapBac;
			}
			set
			{
				SqlString sCapBacTmp = (SqlString)value;
				if(sCapBacTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sCapBac", "sCapBac can't be NULL");
				}
				m_sCapBac = value;
			}
		}


		public SqlString sChucVu
		{
			get
			{
				return m_sChucVu;
			}
			set
			{
				SqlString sChucVuTmp = (SqlString)value;
				if(sChucVuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sChucVu", "sChucVu can't be NULL");
				}
				m_sChucVu = value;
			}
		}


		public SqlString sSoDienThoai
		{
			get
			{
				return m_sSoDienThoai;
			}
			set
			{
				SqlString sSoDienThoaiTmp = (SqlString)value;
				if(sSoDienThoaiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sSoDienThoai", "sSoDienThoai can't be NULL");
				}
				m_sSoDienThoai = value;
			}
		}


		public SqlString sDiaChi
		{
			get
			{
				return m_sDiaChi;
			}
			set
			{
				SqlString sDiaChiTmp = (SqlString)value;
				if(sDiaChiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sDiaChi", "sDiaChi can't be NULL");
				}
				m_sDiaChi = value;
			}
		}
		#endregion
	}
}
