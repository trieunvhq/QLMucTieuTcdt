
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace QLMucTieu
{
    /// <summary>
    /// Purpose: Data Access class for the table 'Phieu_tbPhieu'.
    /// </summary>
    public partial class clsThin : clsDBInteractionBase
    {
        public DataTable T_TongPhieuSX(DateTime ngay_batdau, DateTime ngay_ketthuc, string ma_phieu)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_TongPhieuSX]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("T_TongPhieuSX");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ma_phieu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ma_phieu));
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_TongPhieuSX", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_PhieuSX_SF(int sotrang, DateTime ngay_batdau, DateTime ngay_ketthuc, string ma_phieu)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_PhieuSX_SF]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("T_PhieuSX_SF");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                scmCmdToExecute.Parameters.Add(new SqlParameter("@SoTrang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, sotrang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_batdau", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_batdau));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ngay_ketthuc", SqlDbType.SmallDateTime, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ngay_ketthuc));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ma_phieu", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ma_phieu));

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_PhieuSX_SF", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_NhanSu_tbBoPhan_SA()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_NhanSu_tbBoPhan_SA]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("T_TongPhieuSX");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_NhanSu_tbBoPhan_SA", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_LoaiHangSX_SF(int loai)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_LoaiHangSX_SF]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("T_LoaiHangSX_SF");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                scmCmdToExecute.Parameters.Add(new SqlParameter("@loai", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, loai));

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_LoaiHangSX_SF", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_DinhMuc_DinhMuc_Luong_TheoSanLuong_SO(int ID_VTHH, int thang, int nam)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_DinhMuc_DinhMuc_Luong_TheoSanLuong_SO]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("T_LoaiHangSX_SF");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_VTHH));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_DinhMuc_DinhMuc_Luong_TheoSanLuong_SO", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public DataTable T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_SO(int nam
            , int thang, int ID_BoPhan, int ID_VTHH, string ten_nhanvien)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_SO]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_BoPhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_VTHH));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ten_nhanvien", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ten_nhanvien));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_Phieu_ChiTietPhieu_New_SF(int nam
            , int thang, bool in_, bool cat_, bool dot_)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_Phieu_ChiTietPhieu_New_SF]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("T_Phieu_ChiTietPhieu_New_SF");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@in", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, in_));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@cat", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, cat_));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@dot", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, dot_));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_Phieu_ChiTietPhieu_New_SF::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_ChamCom_SF(int nam
            , int thang, int ID_BoPhan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_ChamCom_SF]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_BoPhan));


                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_BTTL_TGD_SF(int nam, int thang, int id_bophan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_BTTL_TGD_SF]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@id_bophan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_bophan));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_BTTL_TMC_SF(int nam, int thang, string ten_nhanvien)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_BTTL_TMC_SF]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ten_nhanvien", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ten_nhanvien));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_BTTL_TGD_Mau()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_BTTL_TGD_Mau]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
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
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_BTTL_TGD_Mau::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public void T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(int iID_CongNhan, int iThang, int iNam
            , int iID_VTHH, int iID_DinhMuc_Luong_SanLuong, float fNgay1, float fNgay2, float fNgay3, float fNgay4
            , float fNgay5, float fNgay6, float fNgay7, float fNgay8, float fNgay9
            , float fNgay10, float fNgay11, float fNgay12, float fNgay13
            , float fNgay14, float fNgay15, float fNgay16, float fNgay17, float fNgay18, float fNgay19
            , float fNgay20, float fNgay21, float fNgay22, float fNgay23, float fNgay24, float fNgay25
            , float fNgay26, float fNgay27, float fNgay28, float fNgay29, float fNgay30, float fNgay31
            , float fSanLuong, bool bGuiDuLieu, bool bIsTangCa, int id_bophan, int ID_DinhMucLuong_CongNhat,
             int ID_LoaiCong)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {

                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CongNhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_CongNhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iThang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iThang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iNam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iNam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_VTHH", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_VTHH));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_DinhMuc_Luong_SanLuong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_DinhMuc_Luong_SanLuong));

                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay1", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay1));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay2", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay2));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay3", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay3));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay4", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay4));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay5", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay5));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay6", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay6));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay7", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay7));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay8", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay8));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay9", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay9));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay10", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay10));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay11", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay11));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay12", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay12));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay13", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay13));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay14", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay14));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay15", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay15));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay16", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay16));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay17", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay17));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay18", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay18));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay19", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay19));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay20", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay20));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay21", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay21));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay22", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay22));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay23", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay23));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay24", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay24));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay25", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay25));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay26", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay26));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay27", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay27));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay28", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay28));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay29", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay29));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay30", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay30));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay31", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay31));


                scmCmdToExecute.Parameters.Add(new SqlParameter("@fSanLuong", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fSanLuong));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bGuiDuLieu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, bGuiDuLieu));

                scmCmdToExecute.Parameters.Add(new SqlParameter("@bIsTangCa", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, bIsTangCa));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_BoPhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_bophan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_DinhMucLuong_CongNhat", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_DinhMucLuong_CongNhat));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@ID_LoaiCong", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ID_LoaiCong));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I:Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
            }
        }

        public void T_BTTL_TGD_I(int iID_ChamCom, int iID_CongNhan, int iThang, int iNam
            , float fNgay1, float fNgay2, float fNgay3, float fNgay4
            , float fNgay5, float fNgay6, float fNgay7, float fNgay8, float fNgay9
            , float fNgay10, float fNgay11, float fNgay12, float fNgay13
            , float fNgay14, float fNgay15, float fNgay16, float fNgay17, float fNgay18, float fNgay19
            , float fNgay20, float fNgay21, float fNgay22, float fNgay23, float fNgay24, float fNgay25
            , float fNgay26, float fNgay27, float fNgay28, float fNgay29, float fNgay30, float fNgay31
            , bool bGuiDuLieu)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_BTTL_TGD_I]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_ChamCom", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_ChamCom));

                scmCmdToExecute.Parameters.Add(new SqlParameter("@iID_CongNhan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iID_CongNhan));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iThang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iThang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@iNam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, iNam));

                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay1", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay1));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay2", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay2));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay3", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay3));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay4", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay4));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay5", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay5));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay6", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay6));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay7", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay7));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay8", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay8));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay9", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay9));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay10", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay10));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay11", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay11));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay12", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay12));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay13", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay13));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay14", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay14));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay15", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay15));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay16", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay16));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay17", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay17));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay18", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay18));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay19", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay19));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay20", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay20));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay21", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay21));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay22", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay22));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay23", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay23));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay24", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay24));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay25", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay25));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay26", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay26));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay27", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay27));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay28", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay28));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay29", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay29));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay30", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay30));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@fNgay31", SqlDbType.Float, 8, ParameterDirection.Input, false, 38, 0, "", DataRowVersion.Proposed, fNgay31));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@bGuiDuLieu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, bGuiDuLieu));


                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                scmCmdToExecute.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_BTTL_TGD_I:Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
            }
        }
        public DataTable T_NhanSu_SF(string lst_id_BoPhan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_NhanSu_SF]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@lst_id_BoPhan", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, lst_id_BoPhan));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public DataTable T_LoaiCong_SA()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_LoaiCong_SA]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("T_LoaiCong_SA");
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
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_LoaiCong_SA::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public DataTable T_DML_CN_SA()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_DML_CN_SA]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
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
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("[T_DML_CN_SA]::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public DataTable T_NhanSu_tbBoPhan_SO(string tenbophan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_NhanSu_tbBoPhan_SO]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("T_NhanSu_tbBoPhan_SO");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                scmCmdToExecute.Parameters.Add(new SqlParameter("@sTenBoPhan", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, tenbophan));

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_NhanSu_tbBoPhan_SO", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataTable T_DM_SO(int nam, int thang, int id_bophan)
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_DM_SO]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable dtToReturn = new DataTable("cpn_bp");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object

            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, nam));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, thang));
                scmCmdToExecute.Parameters.Add(new SqlParameter("@id_bophan", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id_bophan));

                // Open connection.
                m_scoMainConnection.Open();

                // Execute query.
                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("clsCpn_bp::SelectAll::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataSet T_LockUp_DaiLy_ChiTietChoNhapKho_Moi()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_LockUp_DaiLy_ChiTietChoNhapKho_Moi]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet dtToReturn = new DataSet("T_LockUp_DaiLy_ChiTietChoNhapKho_Moi");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_TongPhieuSX", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public DataSet T_LockUp_NPLChiTietNhapKho_DaiLy_ThemMoi()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_LockUp_NPLChiTietNhapKho_DaiLy_ThemMoi]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet dtToReturn = new DataSet("T_LockUp_NPLChiTietNhapKho_DaiLy_ThemMoi");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_TongPhieuSX", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }

        public DataSet T_LockUp_SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_LockUp_SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet dtToReturn = new DataSet("T_LockUp_SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_TongPhieuSX", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
        public DataSet T_LockUp_frmChiTietMuaHang3333333333()
        {
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = "dbo.[T_LockUp_frmChiTietMuaHang3333333333]";
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet dtToReturn = new DataSet("T_LockUp_frmChiTietMuaHang3333333333");
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);

            // Use base class' connection object
            scmCmdToExecute.Connection = m_scoMainConnection;

            try
            {
                m_scoMainConnection.Open();

                sdaAdapter.Fill(dtToReturn);
                return dtToReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("T_TongPhieuSX", ex);
            }
            finally
            {
                //Close connection.
                m_scoMainConnection.Close();
                scmCmdToExecute.Dispose();
                sdaAdapter.Dispose();
            }
        }
    }
}
