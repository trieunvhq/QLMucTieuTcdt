using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace QLMucTieu
{
	public class clsTabKhongQuan : clsDBInteractionBase
	{
		#region Class Member Declarations
			private SqlDateTime		m_daDateChange, m_daDateCurent;
			private SqlDouble		m_fViDo, m_fKinhDo;
			private SqlInt32		m_iSoLuong, m_iId, m_iDistance;
			private SqlString		m_sKhuVucHoatDong, m_sKhuVucDuKien, m_sVungBien, m_sMoTa, m_sQuocGia, m_sFullName, m_sKieuLoai, m_sSoHieu, m_sDanhHieu, m_sToaDo;
		#endregion


		public clsTabKhongQuan()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_tabKhongQuan_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sQuocGia", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sQuocGia));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sVungBien", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sVungBien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDanhHieu", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDanhHieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoHieu", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoHieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sFullName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sFullName));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sKieuLoai", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sKieuLoai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iSoLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iSoLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fKinhDo", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fKinhDo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fViDo", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fViDo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sToaDo", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sToaDo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iDistance", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iDistance));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sKhuVucDuKien", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sKhuVucDuKien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sKhuVucHoatDong", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sKhuVucHoatDong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daDateCurent", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daDateCurent));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daDateChange", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daDateChange));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sMoTa", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sMoTa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iId));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iId = (SqlInt32)scmCmdToExecute.Parameters["@iId"].Value;
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTabKhongQuan::Insert::Error occured.", ex);
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
        public DataTable pr_TongMucTieuKhongQuan(DateTime ngay_batdau, DateTime ngay_ketthuc, string keySearch)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_TongMucTieuKhongQuan]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_TongMucTieuKhongQuan");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@keySearch", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keySearch));
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_TongMucTieuKhongQuan", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        //
        //
        public DataTable pr_SelecPageKhongQuan_TQVBB(DateTime ngay_batdau, DateTime ngay_ketthuc)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_SelecPageKhongQuan_TQVBB]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_SelecPageKhongQuan_TQVBB");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_SelecPageKhongQuan_TQVBB", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        //
        public DataTable pr_SelecPageKhongQuan_MyVBB(DateTime ngay_batdau, DateTime ngay_ketthuc)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_SelecPageKhongQuan_MyVBB]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_SelecPageKhongQuan_MyVBB");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_SelecPageKhongQuan_MyVBB", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        //
        public DataTable pr_SelecPageKhongQuan(int sotrang, DateTime ngay_batdau, DateTime ngay_ketthuc, string keySearch)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_SelecPageKhongQuan]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_SelecPageKhongQuan");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                scmCmdToExecute.Parameters.Add(new SqlParameter("@SoTrang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, sotrang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@keySearch", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keySearch));

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_SelecPageKhongQuan", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        //
        public override bool Update()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_tabKhongQuan_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iId));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sQuocGia", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sQuocGia));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sVungBien", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sVungBien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDanhHieu", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDanhHieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoHieu", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoHieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sFullName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sFullName));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sKieuLoai", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sKieuLoai));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iSoLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iSoLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fKinhDo", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fKinhDo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fViDo", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fViDo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sToaDo", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sToaDo));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iDistance", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iDistance));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sKhuVucDuKien", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sKhuVucDuKien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sKhuVucHoatDong", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sKhuVucHoatDong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daDateCurent", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daDateCurent));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daDateChange", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daDateChange));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sMoTa", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sMoTa));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTabKhongQuan::Update::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				m_scoMainConnection.Close();
				scmCmdToExecute.Dispose();
			}
		}

        public bool pr_tabKhongQuan_Update_rootMy()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_tabKhongQuan_Update_rootMy]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iId));
               
                scmCmdToExecute.Parameters.Add(new SqlParameter("@sToaDo", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sToaDo));
             

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsTabKhongQuan::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tabKhongQuan_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iId));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTabKhongQuan::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tabKhongQuan_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("tabKhongQuan");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iId));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				if(dtToReturn.Rows.Count > 0)
				{
					m_iId = (Int32)dtToReturn.Rows[0]["Id"];
					m_sQuocGia = dtToReturn.Rows[0]["QuocGia"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["QuocGia"];
					m_sVungBien = dtToReturn.Rows[0]["VungBien"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["VungBien"];
					m_sDanhHieu = dtToReturn.Rows[0]["DanhHieu"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["DanhHieu"];
					m_sSoHieu = dtToReturn.Rows[0]["SoHieu"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["SoHieu"];
					m_sFullName = dtToReturn.Rows[0]["FullName"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["FullName"];
					m_sKieuLoai = dtToReturn.Rows[0]["KieuLoai"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["KieuLoai"];
					m_iSoLuong = dtToReturn.Rows[0]["SoLuong"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["SoLuong"];
					m_fKinhDo = dtToReturn.Rows[0]["KinhDo"] == System.DBNull.Value ? SqlDouble.Null : (double)dtToReturn.Rows[0]["KinhDo"];
					m_fViDo = dtToReturn.Rows[0]["ViDo"] == System.DBNull.Value ? SqlDouble.Null : (double)dtToReturn.Rows[0]["ViDo"];
					m_sToaDo = dtToReturn.Rows[0]["ToaDo"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["ToaDo"];
					m_iDistance = dtToReturn.Rows[0]["Distance"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["Distance"];
					m_sKhuVucDuKien = dtToReturn.Rows[0]["KhuVucDuKien"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["KhuVucDuKien"];
					m_sKhuVucHoatDong = dtToReturn.Rows[0]["KhuVucHoatDong"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["KhuVucHoatDong"];
					m_daDateCurent = dtToReturn.Rows[0]["DateCurent"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)dtToReturn.Rows[0]["DateCurent"];
					m_daDateChange = dtToReturn.Rows[0]["DateChange"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)dtToReturn.Rows[0]["DateChange"];
					m_sMoTa = dtToReturn.Rows[0]["MoTa"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["MoTa"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTabKhongQuan::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_tabKhongQuan_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("tabKhongQuan");
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
				throw new Exception("clsTabKhongQuan::SelectAll::Error occured.", ex);
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


		public SqlString sQuocGia
		{
			get
			{
				return m_sQuocGia;
			}
			set
			{
				SqlString sQuocGiaTmp = (SqlString)value;
				if(sQuocGiaTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sQuocGia", "sQuocGia can't be NULL");
				}
				m_sQuocGia = value;
			}
		}


		public SqlString sVungBien
		{
			get
			{
				return m_sVungBien;
			}
			set
			{
				SqlString sVungBienTmp = (SqlString)value;
				if(sVungBienTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sVungBien", "sVungBien can't be NULL");
				}
				m_sVungBien = value;
			}
		}


		public SqlString sDanhHieu
		{
			get
			{
				return m_sDanhHieu;
			}
			set
			{
				SqlString sDanhHieuTmp = (SqlString)value;
				if(sDanhHieuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sDanhHieu", "sDanhHieu can't be NULL");
				}
				m_sDanhHieu = value;
			}
		}


		public SqlString sSoHieu
		{
			get
			{
				return m_sSoHieu;
			}
			set
			{
				SqlString sSoHieuTmp = (SqlString)value;
				if(sSoHieuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sSoHieu", "sSoHieu can't be NULL");
				}
				m_sSoHieu = value;
			}
		}


		public SqlString sFullName
		{
			get
			{
				return m_sFullName;
			}
			set
			{
				SqlString sFullNameTmp = (SqlString)value;
				if(sFullNameTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sFullName", "sFullName can't be NULL");
				}
				m_sFullName = value;
			}
		}


		public SqlString sKieuLoai
		{
			get
			{
				return m_sKieuLoai;
			}
			set
			{
				SqlString sKieuLoaiTmp = (SqlString)value;
				if(sKieuLoaiTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sKieuLoai", "sKieuLoai can't be NULL");
				}
				m_sKieuLoai = value;
			}
		}


		public SqlInt32 iSoLuong
		{
			get
			{
				return m_iSoLuong;
			}
			set
			{
				SqlInt32 iSoLuongTmp = (SqlInt32)value;
				if(iSoLuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iSoLuong", "iSoLuong can't be NULL");
				}
				m_iSoLuong = value;
			}
		}


		public SqlDouble fKinhDo
		{
			get
			{
				return m_fKinhDo;
			}
			set
			{
				SqlDouble fKinhDoTmp = (SqlDouble)value;
				if(fKinhDoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fKinhDo", "fKinhDo can't be NULL");
				}
				m_fKinhDo = value;
			}
		}


		public SqlDouble fViDo
		{
			get
			{
				return m_fViDo;
			}
			set
			{
				SqlDouble fViDoTmp = (SqlDouble)value;
				if(fViDoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fViDo", "fViDo can't be NULL");
				}
				m_fViDo = value;
			}
		}


		public SqlString sToaDo
		{
			get
			{
				return m_sToaDo;
			}
			set
			{
				SqlString sToaDoTmp = (SqlString)value;
				if(sToaDoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sToaDo", "sToaDo can't be NULL");
				}
				m_sToaDo = value;
			}
		}


		public SqlInt32 iDistance
		{
			get
			{
				return m_iDistance;
			}
			set
			{
				SqlInt32 iDistanceTmp = (SqlInt32)value;
				if(iDistanceTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iDistance", "iDistance can't be NULL");
				}
				m_iDistance = value;
			}
		}


		public SqlString sKhuVucDuKien
		{
			get
			{
				return m_sKhuVucDuKien;
			}
			set
			{
				SqlString sKhuVucDuKienTmp = (SqlString)value;
				if(sKhuVucDuKienTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sKhuVucDuKien", "sKhuVucDuKien can't be NULL");
				}
				m_sKhuVucDuKien = value;
			}
		}


		public SqlString sKhuVucHoatDong
		{
			get
			{
				return m_sKhuVucHoatDong;
			}
			set
			{
				SqlString sKhuVucHoatDongTmp = (SqlString)value;
				if(sKhuVucHoatDongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sKhuVucHoatDong", "sKhuVucHoatDong can't be NULL");
				}
				m_sKhuVucHoatDong = value;
			}
		}


		public SqlDateTime daDateCurent
		{
			get
			{
				return m_daDateCurent;
			}
			set
			{
				SqlDateTime daDateCurentTmp = (SqlDateTime)value;
				if(daDateCurentTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("daDateCurent", "daDateCurent can't be NULL");
				}
				m_daDateCurent = value;
			}
		}


		public SqlDateTime daDateChange
		{
			get
			{
				return m_daDateChange;
			}
			set
			{
				SqlDateTime daDateChangeTmp = (SqlDateTime)value;
				if(daDateChangeTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("daDateChange", "daDateChange can't be NULL");
				}
				m_daDateChange = value;
			}
		}


		public SqlString sMoTa
		{
			get
			{
				return m_sMoTa;
			}
			set
			{
				SqlString sMoTaTmp = (SqlString)value;
				if(sMoTaTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sMoTa", "sMoTa can't be NULL");
				}
				m_sMoTa = value;
			}
		}
		#endregion
	}
}
