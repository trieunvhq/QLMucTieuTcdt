using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace QLMucTieu
{
    public partial class clsTr_BB_KtraDinhMuc_HHSX : clsDBInteractionBase
    {
		#region Class Member Declarations
			private SqlDateTime		m_daNgayThang;
			private SqlDouble		m_fPhePham, m_fSoLuongKtra, m_fSoLuong, m_fQuyRaKien, m_fDoCao, m_fSauMuoi_BaoKien, m_fTrongLuong, m_fMotBao_kg, m_fMotBao_SoKien;
			private SqlInt32		m_iCa, m_iId_BB;
			private SqlString		m_sGhiChu, m_sSoHieu, m_sLoaiHang, m_sDonVi_Second, m_sDonVi_first, m_sLoaiGiay;
		#endregion


		public clsTr_BB_KtraDinhMuc_HHSX()
		{
			// Nothing for now.
		}


		public override bool Insert()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_Tr_BB_KtraDinhMuc_HHSX_Insert]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayThang", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayThang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoHieu", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoHieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iCa", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iCa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sLoaiHang", SqlDbType.NChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sLoaiHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sLoaiGiay", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sLoaiGiay));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongKtra", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongKtra));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDonVi_first", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDonVi_first));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTrongLuong", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTrongLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuong", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDonVi_Second", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDonVi_Second));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fQuyRaKien", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fQuyRaKien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fPhePham", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fPhePham));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDoCao", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDoCao));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fMotBao_kg", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fMotBao_kg));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fMotBao_SoKien", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fMotBao_SoKien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSauMuoi_BaoKien", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSauMuoi_BaoKien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iId_BB", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, m_iId_BB));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				m_iId_BB = (SqlInt32)scmCmdToExecute.Parameters["@iId_BB"].Value;
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTr_BB_KtraDinhMuc_HHSX::Insert::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				m_scoMainConnection.Close();
				scmCmdToExecute.Dispose();
			}
		}


		public override bool Update()
		{
			SqlCommand	scmCmdToExecute = new SqlCommand();
			scmCmdToExecute.CommandText = "dbo.[pr_Tr_BB_KtraDinhMuc_HHSX_Update]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iId_BB", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iId_BB));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@daNgayThang", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_daNgayThang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sSoHieu", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sSoHieu));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iCa", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iCa));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sLoaiHang", SqlDbType.NChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sLoaiHang));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sLoaiGiay", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sLoaiGiay));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuongKtra", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuongKtra));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDonVi_first", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDonVi_first));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fTrongLuong", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fTrongLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSoLuong", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSoLuong));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sDonVi_Second", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sDonVi_Second));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fQuyRaKien", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fQuyRaKien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fPhePham", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fPhePham));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fDoCao", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fDoCao));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fMotBao_kg", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fMotBao_kg));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fMotBao_SoKien", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fMotBao_SoKien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@fSauMuoi_BaoKien", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, m_fSauMuoi_BaoKien));
				scmCmdToExecute.Parameters.Add(new SqlParameter("@sGhiChu", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, m_sGhiChu));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTr_BB_KtraDinhMuc_HHSX::Update::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_Tr_BB_KtraDinhMuc_HHSX_Delete]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iId_BB", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iId_BB));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				scmCmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTr_BB_KtraDinhMuc_HHSX::Delete::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_Tr_BB_KtraDinhMuc_HHSX_SelectOne]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("Tr_BB_KtraDinhMuc_HHSX");
			SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

			// Use base class' connection object
			scmCmdToExecute.Connection = m_scoMainConnection;

			try
			{
				scmCmdToExecute.Parameters.Add(new SqlParameter("@iId_BB", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, m_iId_BB));

				// Open connection.
				m_scoMainConnection.Open();

				// Execute query.
				sdaAdapter.Fill(dtToReturn);
				if(dtToReturn.Rows.Count > 0)
				{
					m_iId_BB = (Int32)dtToReturn.Rows[0]["Id_BB"];
					m_daNgayThang = dtToReturn.Rows[0]["NgayThang"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)dtToReturn.Rows[0]["NgayThang"];
					m_sSoHieu = dtToReturn.Rows[0]["SoHieu"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["SoHieu"];
					m_iCa = dtToReturn.Rows[0]["Ca"] == System.DBNull.Value ? SqlInt32.Null : (Int32)dtToReturn.Rows[0]["Ca"];
					m_sLoaiHang = dtToReturn.Rows[0]["LoaiHang"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["LoaiHang"];
					m_sLoaiGiay = dtToReturn.Rows[0]["LoaiGiay"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["LoaiGiay"];
					m_fSoLuongKtra = dtToReturn.Rows[0]["SoLuongKtra"] == System.DBNull.Value ? SqlDouble.Null : (double)dtToReturn.Rows[0]["SoLuongKtra"];
					m_sDonVi_first = dtToReturn.Rows[0]["DonVi_first"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["DonVi_first"];
					m_fTrongLuong = dtToReturn.Rows[0]["TrongLuong"] == System.DBNull.Value ? SqlDouble.Null : (double)dtToReturn.Rows[0]["TrongLuong"];
					m_fSoLuong = dtToReturn.Rows[0]["SoLuong"] == System.DBNull.Value ? SqlDouble.Null : (double)dtToReturn.Rows[0]["SoLuong"];
					m_sDonVi_Second = dtToReturn.Rows[0]["DonVi_Second"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["DonVi_Second"];
					m_fQuyRaKien = dtToReturn.Rows[0]["QuyRaKien"] == System.DBNull.Value ? SqlDouble.Null : (double)dtToReturn.Rows[0]["QuyRaKien"];
					m_fPhePham = dtToReturn.Rows[0]["PhePham"] == System.DBNull.Value ? SqlDouble.Null : (double)dtToReturn.Rows[0]["PhePham"];
					m_fDoCao = dtToReturn.Rows[0]["DoCao"] == System.DBNull.Value ? SqlDouble.Null : (double)dtToReturn.Rows[0]["DoCao"];
					m_fMotBao_kg = dtToReturn.Rows[0]["MotBao_kg"] == System.DBNull.Value ? SqlDouble.Null : (double)dtToReturn.Rows[0]["MotBao_kg"];
					m_fMotBao_SoKien = dtToReturn.Rows[0]["MotBao_SoKien"] == System.DBNull.Value ? SqlDouble.Null : (double)dtToReturn.Rows[0]["MotBao_SoKien"];
					m_fSauMuoi_BaoKien = dtToReturn.Rows[0]["SauMuoi_BaoKien"] == System.DBNull.Value ? SqlDouble.Null : (double)dtToReturn.Rows[0]["SauMuoi_BaoKien"];
					m_sGhiChu = dtToReturn.Rows[0]["GhiChu"] == System.DBNull.Value ? SqlString.Null : (string)dtToReturn.Rows[0]["GhiChu"];
				}
				return dtToReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("clsTr_BB_KtraDinhMuc_HHSX::SelectOne::Error occured.", ex);
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
			scmCmdToExecute.CommandText = "dbo.[pr_Tr_BB_KtraDinhMuc_HHSX_SelectAll]";
			scmCmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable dtToReturn = new DataTable("Tr_BB_KtraDinhMuc_HHSX");
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
				throw new Exception("clsTr_BB_KtraDinhMuc_HHSX::SelectAll::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				m_scoMainConnection.Close();
				scmCmdToExecute.Dispose();
				sdaAdapter.Dispose();
			}
		}

        public DataTable SelectPage_BB_Ktra_DMHHSX(int sotrang, DateTime ngay_batdau, DateTime ngay_ketthuc, string id_BienBan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_SelecPage_BB_Ktra_HHSX]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("Tr_SelecPage_BB_Ktra_HHSX");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                scmCmdToExecute.Parameters.Add(new SqlParameter("@SoTrang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, sotrang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@id_BienBan", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, id_BienBan));

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Tr_SelecPage_BB_Ktra_HHSX", ex);
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
        public DataTable SelectAll_BB_Ktra_DMHHSX_date(DateTime ngay_batdau, DateTime ngay_ketthuc, string id_BienBan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[Tr_SelectAll_BB_Ktra_HHSX_Date]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("Tr_SelectAll_BB_Ktra_HHSX_Date");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@id_BienBan", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, id_BienBan));

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Tr_SelectAll_BB_Ktra_HHSX_Date", ex);
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
        public DataTable T_TongSoBB(DateTime ngay_batdau, DateTime ngay_ketthuc, string ma_phieu)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[pr_TrTongSo_BB_Ktra_DMHHSX]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("pr_TrTongSo_BB_Ktra_DMHHSX");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@id_BienBan", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ma_phieu));
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("pr_TrTongSo_BB_Ktra_DMHHSX", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }


        #region Class Property Declarations
        public SqlInt32 iId_BB
		{
			get
			{
				return m_iId_BB;
			}
			set
			{
				SqlInt32 iId_BBTmp = (SqlInt32)value;
				if(iId_BBTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iId_BB", "iId_BB can't be NULL");
				}
				m_iId_BB = value;
			}
		}


		public SqlDateTime daNgayThang
		{
			get
			{
				return m_daNgayThang;
			}
			set
			{
				SqlDateTime daNgayThangTmp = (SqlDateTime)value;
				if(daNgayThangTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("daNgayThang", "daNgayThang can't be NULL");
				}
				m_daNgayThang = value;
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


		public SqlInt32 iCa
		{
			get
			{
				return m_iCa;
			}
			set
			{
				SqlInt32 iCaTmp = (SqlInt32)value;
				if(iCaTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("iCa", "iCa can't be NULL");
				}
				m_iCa = value;
			}
		}


		public SqlString sLoaiHang
		{
			get
			{
				return m_sLoaiHang;
			}
			set
			{
				SqlString sLoaiHangTmp = (SqlString)value;
				if(sLoaiHangTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sLoaiHang", "sLoaiHang can't be NULL");
				}
				m_sLoaiHang = value;
			}
		}


		public SqlString sLoaiGiay
		{
			get
			{
				return m_sLoaiGiay;
			}
			set
			{
				SqlString sLoaiGiayTmp = (SqlString)value;
				if(sLoaiGiayTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sLoaiGiay", "sLoaiGiay can't be NULL");
				}
				m_sLoaiGiay = value;
			}
		}


		public SqlDouble fSoLuongKtra
		{
			get
			{
				return m_fSoLuongKtra;
			}
			set
			{
				SqlDouble fSoLuongKtraTmp = (SqlDouble)value;
				if(fSoLuongKtraTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoLuongKtra", "fSoLuongKtra can't be NULL");
				}
				m_fSoLuongKtra = value;
			}
		}


		public SqlString sDonVi_first
		{
			get
			{
				return m_sDonVi_first;
			}
			set
			{
				SqlString sDonVi_firstTmp = (SqlString)value;
				if(sDonVi_firstTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sDonVi_first", "sDonVi_first can't be NULL");
				}
				m_sDonVi_first = value;
			}
		}


		public SqlDouble fTrongLuong
		{
			get
			{
				return m_fTrongLuong;
			}
			set
			{
				SqlDouble fTrongLuongTmp = (SqlDouble)value;
				if(fTrongLuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fTrongLuong", "fTrongLuong can't be NULL");
				}
				m_fTrongLuong = value;
			}
		}


		public SqlDouble fSoLuong
		{
			get
			{
				return m_fSoLuong;
			}
			set
			{
				SqlDouble fSoLuongTmp = (SqlDouble)value;
				if(fSoLuongTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSoLuong", "fSoLuong can't be NULL");
				}
				m_fSoLuong = value;
			}
		}


		public SqlString sDonVi_Second
		{
			get
			{
				return m_sDonVi_Second;
			}
			set
			{
				SqlString sDonVi_SecondTmp = (SqlString)value;
				if(sDonVi_SecondTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sDonVi_Second", "sDonVi_Second can't be NULL");
				}
				m_sDonVi_Second = value;
			}
		}


		public SqlDouble fQuyRaKien
		{
			get
			{
				return m_fQuyRaKien;
			}
			set
			{
				SqlDouble fQuyRaKienTmp = (SqlDouble)value;
				if(fQuyRaKienTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fQuyRaKien", "fQuyRaKien can't be NULL");
				}
				m_fQuyRaKien = value;
			}
		}


		public SqlDouble fPhePham
		{
			get
			{
				return m_fPhePham;
			}
			set
			{
				SqlDouble fPhePhamTmp = (SqlDouble)value;
				if(fPhePhamTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fPhePham", "fPhePham can't be NULL");
				}
				m_fPhePham = value;
			}
		}


		public SqlDouble fDoCao
		{
			get
			{
				return m_fDoCao;
			}
			set
			{
				SqlDouble fDoCaoTmp = (SqlDouble)value;
				if(fDoCaoTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fDoCao", "fDoCao can't be NULL");
				}
				m_fDoCao = value;
			}
		}


		public SqlDouble fMotBao_kg
		{
			get
			{
				return m_fMotBao_kg;
			}
			set
			{
				SqlDouble fMotBao_kgTmp = (SqlDouble)value;
				if(fMotBao_kgTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fMotBao_kg", "fMotBao_kg can't be NULL");
				}
				m_fMotBao_kg = value;
			}
		}


		public SqlDouble fMotBao_SoKien
		{
			get
			{
				return m_fMotBao_SoKien;
			}
			set
			{
				SqlDouble fMotBao_SoKienTmp = (SqlDouble)value;
				if(fMotBao_SoKienTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fMotBao_SoKien", "fMotBao_SoKien can't be NULL");
				}
				m_fMotBao_SoKien = value;
			}
		}


		public SqlDouble fSauMuoi_BaoKien
		{
			get
			{
				return m_fSauMuoi_BaoKien;
			}
			set
			{
				SqlDouble fSauMuoi_BaoKienTmp = (SqlDouble)value;
				if(fSauMuoi_BaoKienTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("fSauMuoi_BaoKien", "fSauMuoi_BaoKien can't be NULL");
				}
				m_fSauMuoi_BaoKien = value;
			}
		}


		public SqlString sGhiChu
		{
			get
			{
				return m_sGhiChu;
			}
			set
			{
				SqlString sGhiChuTmp = (SqlString)value;
				if(sGhiChuTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("sGhiChu", "sGhiChu can't be NULL");
				}
				m_sGhiChu = value;
			}
		}
		#endregion
	}
}
