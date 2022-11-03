using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLMucTieu
{
    public partial class frmChiTiet_HaiQuan : Form
    {
        private bool Insert_HaiQuan()
        {
            clsTabHaiQuan cls = new clsTabHaiQuan();
            cls.daDateCurent = Convert.ToDateTime(dateNgayThang.EditValue.ToString());
            cls.daDateChange = DateTime.Now;
            cls.sQuocGia = comboQuocGia.Text;
            cls.sVungBien = comboVungBien.Text;
            cls.sDanhHieu = txtDanhHieu.Text;
            cls.sSoHieu = txtSoHieu.Text;
            cls.sFullName = txtFullname.Text;
            cls.sKieuLoai = comboKieuLoai.Text;
            cls.iSoLuong = Convert.ToInt32(txtSoLuong.Text.Trim());

            if (txtToaDo.Text.Contains("/"))
            {
                if (!txtToaDo.Text.Contains('⁰'))
                {
                    string[] str_tmpToaDo = txtToaDo.Text.Trim().Split('/');
                    string str_tmpViDo = str_tmpToaDo[0].Substring(0,2) + "⁰" + str_tmpToaDo[0].Substring(3);
                    string str_tmpKinhDo = str_tmpToaDo[1].Substring(0, 3) + "⁰" + str_tmpToaDo[1].Substring(4);

                    cls.fKinhDo = CheckString._toDouble_ToaDo(str_tmpViDo.Trim());
                    cls.fViDo = CheckString._toDouble_ToaDo(str_tmpKinhDo.Trim());

                    txtToaDo.Text = str_tmpViDo + "/" + str_tmpKinhDo;
                }
                else
                {
                    cls.fKinhDo = CheckString._toDouble_ToaDo(txtToaDo.Text.Trim().Split('/')[0]);
                    cls.fViDo = CheckString._toDouble_ToaDo(txtToaDo.Text.Trim().Split('/')[1]);
                }
            }
            else
            {
                cls.fKinhDo = 0;
                cls.fViDo = 0;
            }

            cls.sToaDo = txtToaDo.Text;
            cls.iDistance = Convert.ToInt32(txtKhoangCach.Text);
            cls.sKhuVucDuKien = txtKhuVucDuKien.Text;
            cls.sKhuVucHoatDong = txtKhuVucHoatDong.Text;
            cls.sMoTa = txtMoTa.Text;

            if (cls.Insert()) return true;
            else return false;
        }


        // 
        private bool Update_HaiQuan()
        {
            clsTabHaiQuan cls = new clsTabHaiQuan();

            cls.iId = frmMain.ID_HQ;
            cls.daDateCurent = Convert.ToDateTime(dateNgayThang.EditValue.ToString());
            cls.daDateChange = DateTime.Now;
            cls.sQuocGia = comboQuocGia.Text;
            cls.sVungBien = comboVungBien.Text;
            cls.sDanhHieu = txtDanhHieu.Text;
            cls.sSoHieu = txtSoHieu.Text;
            cls.sFullName = txtFullname.Text;
            cls.sKieuLoai = comboKieuLoai.Text;
            cls.iSoLuong = Convert.ToInt32(txtSoLuong.Text.Trim());

            if (txtToaDo.Text.Contains("/"))
            {
                if (!txtToaDo.Text.Contains('⁰'))
                {
                    string[] str_tmpToaDo = txtToaDo.Text.Trim().Split('/');
                    string str_tmpViDo = str_tmpToaDo[0].Substring(0, 2) + "⁰" + str_tmpToaDo[0].Substring(3);
                    string str_tmpKinhDo = str_tmpToaDo[1].Substring(0, 3) + "⁰" + str_tmpToaDo[1].Substring(4);

                    cls.fKinhDo = CheckString._toDouble_ToaDo(str_tmpViDo.Trim());
                    cls.fViDo = CheckString._toDouble_ToaDo(str_tmpKinhDo.Trim());

                    txtToaDo.Text = str_tmpViDo + "/" + str_tmpKinhDo;
                }
                else
                {
                    cls.fKinhDo = CheckString._toDouble_ToaDo(txtToaDo.Text.Trim().Split('/')[0]);
                    cls.fViDo = CheckString._toDouble_ToaDo(txtToaDo.Text.Trim().Split('/')[1]);
                }
            }
            else
            {
                cls.fKinhDo = 0;
                cls.fViDo = 0;
            }
            
            cls.sToaDo = txtToaDo.Text;
            cls.iDistance = Convert.ToInt32(txtKhoangCach.Text);
            cls.sKhuVucDuKien = txtKhuVucDuKien.Text;
            cls.sKhuVucHoatDong = txtKhuVucHoatDong.Text;
            cls.sMoTa = txtMoTa.Text;

            if (cls.Update()) return true;
            else return false;
        }


        private void Load_frmEdit()
        {
            dateNgayThang.EditValue = frmMain.DateCurent_HQ;
            txtMoTa.Text = frmMain.MoTa_HQ;
            comboKieuLoai.Text = frmMain.KieuLoai_HQ;
            txtFullname.Text = frmMain.FullName_HQ;
            txtDanhHieu.Text = frmMain.DanhHieu_HQ;
            txtSoHieu.Text = frmMain.SoHieu_HQ;
            txtSoLuong.Text = frmMain.SoLuong_HQ.ToString();
            comboQuocGia.Text = frmMain.QuocGia_HQ;
            comboVungBien.Text = frmMain.VungBien_HQ;
            txtToaDo.Text = frmMain.ToaDo_HQ;
            txtKhoangCach.Text = frmMain.Distance_HQ.ToString();
            txtKhuVucDuKien.Text = frmMain.KhuVucDuKien_HQ;
            txtKhuVucHoatDong.Text = frmMain.KhuVucHoatDong_HQ;
            txtMoTa.Text = frmMain.MoTa_HQ;
        }

        private bool CheckDataInput()
        {
            if (string.IsNullOrWhiteSpace(dateNgayThang.Text))
            {
                MessageBox.Show("Kiểm tra lại ngày tháng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateNgayThang.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(comboQuocGia.Text))
            {
                MessageBox.Show("Kiểm tra lại quốc gia!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboQuocGia.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(comboVungBien.Text))
            {
                MessageBox.Show("Kiểm tra lại vùng biển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboVungBien.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Kiểm tra lại số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtKhoangCach.Text))
            {
                MessageBox.Show("Kiểm tra lại khoảng cách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtKhoangCach.Focus();
                return false;
            }
            else if (!CheckString.CheckIsNumber(txtSoLuong.Text))
            {
                MessageBox.Show("Kiểm tra lại số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return false;
            }
            else if (!CheckString.CheckIsNumber(txtKhoangCach.Text))
            {
                MessageBox.Show("Kiểm tra lại khoảng cách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtKhoangCach.Focus();
                return false;
            }
            else return true;
        }



        frmMain _ucBBKTDM;
        public frmChiTiet_HaiQuan(frmMain ucBBKTDM)
        {
            _ucBBKTDM = ucBBKTDM;
            InitializeComponent();
        }

        private void frmChiTiet_HaiQuan_Load(object sender, EventArgs e)
        {
            comboQuocGia.Properties.Items.Add("Trung Quốc");
            comboQuocGia.Properties.Items.Add("Mỹ");
            comboQuocGia.Text = "Trung Quốc";

            comboVungBien.Properties.Items.Add("Vịnh Bắc Bộ");
            comboVungBien.Properties.Items.Add("Vùng biển miền Trung");
            comboVungBien.Properties.Items.Add("Vùng biển Trường Sa - DK1 và phía Nam");
            comboVungBien.Text = "Vịnh Bắc Bộ";

            comboKieuLoai.Properties.Items.Add("Tàu quân sự");
            comboKieuLoai.Properties.Items.Add("Tàu chấp pháp");
            comboKieuLoai.Properties.Items.Add("Tàu nghiên cứu khảo sát");
            comboKieuLoai.Text = "Tàu quân sự";

            dateNgayThang.EditValue = DateTime.Now.AddDays(-1);

            if (frmMain.mbCopy_HQ)
            {
                Load_frmEdit();
            }

            dateNgayThang.Focus();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btSave_Click(object sender, EventArgs e)
        {
            if (frmMain.mbAdd_HQ == true
                && frmMain.mb_Sua_HQ == false)
            {
                if (checkNhieuMT.Checked)
                {
                    if (!string.IsNullOrEmpty(txtMoTa.Text))
                    {
                        string mota = txtMoTa.Text;
                        mota = mota.Trim();
                        mota = mota.Trim('-');
                        mota = mota.Trim();

                        while (mota.IndexOf("\t") >= 0)
                        {
                            mota = mota.Replace("\t", " ");
                        }
                        while (mota.IndexOf("  ") >= 0)
                        {
                            mota = mota.Replace("  ", " ");
                        }

                        //
                        int count = 0;
                        string[] str = mota.Split('\n');
                        for (int i = 0; i < str.Length; i++)
                        {
                            if (Insert__HQ_NhieuMT(str[i])) count += 1;
                        }
                        _ucBBKTDM.btRefresh_Click(null, null);
                        MessageBox.Show("Lưu " + count + " mục tiêu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Lưu dữ liệu thất bại. Kiểm tra lại trường mô tả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (CheckDataInput())
                    {
                        if (Insert_HaiQuan())
                        {
                            _ucBBKTDM.btRefresh_Click(null, null);
                            MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Lưu dữ thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else if (frmMain.mbAdd_HQ == false
                && frmMain.mb_Sua_HQ == true)
            {
                if (Update_HaiQuan())
                {
                    this.Close();
                    _ucBBKTDM.LoadData_HQ(frmMain._SoTrang_HQ, false);
                    MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lưu dữ thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void dateNgayThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btSave_Click(null, null);
            }
        }

        private void txtSoHieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btSave_Click(null, null);
            }
        }


        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtMoTa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)13)
            {
                if (!string.IsNullOrEmpty(txtMoTa.Text))
                {
                    string mota = txtMoTa.Text;
                    mota = mota.Trim();
                    mota = mota.Trim('-');
                    mota = mota.Trim();
                    mota = mota.Trim('+');
                    mota = mota.Trim();

                    while (mota.IndexOf("\t") >= 0)
                    {
                        mota = mota.Replace("\t", " ");
                    }
                    while (mota.IndexOf("  ") >= 0)
                    {
                        mota = mota.Replace("  ", " ");
                    }

                    while (mota.IndexOf(" ở ") >= 0)
                    {
                        mota = mota.Replace(" ở ", " tại ");
                        //string result__ = Regex.Replace(mota, " ở ", " tại ", RegexOptions.IgnoreCase);
                    }

                    // Số lượng:
                    if (CheckString.CheckIsNumber(mota.Split()[0]))
                    {
                        txtSoLuong.Text = mota.Split()[0].Trim();
                    }
                    else txtSoLuong.Text = "1";

                    
                    //
                    if (mota.Contains("tại"))
                    {
                        string[] tmp = mota.Split(new string[] { "tại" }, StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i < tmp.Length; i++)
                        {
                            if (tmp[i].Contains("(") && tmp[i].ToLower().Contains("hl"))
                            {
                                string toado = (tmp[i].Trim()).Split()[0].Trim();
                                toado = toado.Trim('.').Trim(',').Trim(':').Trim(';');

                                if (toado.Contains("/") && !toado.Contains('⁰'))
                                {
                                    string[] str_tmpToaDo = toado.Trim().Split('/');
                                    string str_tmpViDo = str_tmpToaDo[0].Substring(0, 2) + "⁰" + str_tmpToaDo[0].Substring(3);
                                    string str_tmpKinhDo = str_tmpToaDo[1].Substring(0, 3) + "⁰" + str_tmpToaDo[1].Substring(4);

                                    txtToaDo.Text = str_tmpViDo + "/" + str_tmpKinhDo;
                                }
                                else
                                {
                                    txtToaDo.Text = toado;
                                }


                                string tmp1 = tmp[i].Split('(')[1];
                                string khuVucHD = "";
                                string khoangCach = "";

                                for (int j = 0; j < tmp1.Length; j++)
                                {
                                    if (CheckString.CheckIsNumber(tmp1[j].ToString()))
                                    {
                                        khoangCach += tmp1[j].ToString();
                                    }
                                }

                                for (int j = 0; j < tmp1.Length; j++)
                                {
                                    if (!CheckString.CheckIsNumber(tmp1[j].ToString()))
                                    {
                                        khuVucHD += tmp1[j].ToString();
                                    }
                                    else break;
                                }

                                txtKhuVucHoatDong.Text = khuVucHD.Trim();
                                txtKhoangCach.Text = khoangCach.Trim();
                            }
                        }
                    }

                    //
                    if (mota.ToLower().Contains("dự kiến"))
                    {
                        if (mota.Contains("Dự kiến"))
                        {
                            string[] dk = mota.Split(new string[] { "Dự" }, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < dk.Length; i++)
                            {
                                if (dk[i].Contains("kiến"))
                                {
                                    string khuVucDK = "";
                                    for (int j = 0; j < dk[i].Length; j++)
                                    {
                                        if (dk[i][j].ToString() == ":"
                                            || dk[i][j].ToString() == "."
                                            || dk[i][j].ToString() == ","
                                            || dk[i][j].ToString() == ";")
                                            break;
                                        else khuVucDK += dk[i][j].ToString();
                                    }
                                    txtKhuVucDuKien.Text = "Dự " + khuVucDK;
                                }
                            }
                        }
                        else if (mota.Contains("dự kiến"))
                        {
                            string[] dk = mota.Split(new string[] { "dự" }, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < dk.Length; i++)
                            {
                                if (dk[i].Contains("kiến"))
                                {
                                    string khuVucDK = "";
                                    for (int j = 0; j < dk[i].Length; j++)
                                    {
                                        if (dk[i][j].ToString() == ":"
                                            || dk[i][j].ToString() == "."
                                            || dk[i][j].ToString() == ","
                                            || dk[i][j].ToString() == ";")
                                            break;
                                        else khuVucDK += dk[i][j].ToString();
                                    }
                                    txtKhuVucDuKien.Text = "Dự " + khuVucDK;
                                }
                            }
                        }

                    }

                    //
                    if (mota.ToLower().Contains("lúc"))
                    {
                        string[] tg = mota.ToLower().Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                        string th_gian = tg[1].Trim().Split()[0].Trim();
                        int gio = 0;
                        int phut = 0;

                        if (th_gian.Contains("."))
                        {
                            gio = Convert.ToInt32(th_gian.Split('.')[0].Trim());
                            phut = Convert.ToInt32(th_gian.Split('.')[1].Trim());
                        }
                        else if (th_gian.Contains(":"))
                        {
                            gio = Convert.ToInt32(th_gian.Split(':')[0].Trim());
                            phut = Convert.ToInt32(th_gian.Split(':')[1].Trim());
                        }

                        DateTime daynow = Convert.ToDateTime(dateNgayThang.EditValue);
                        dateNgayThang.EditValue = new DateTime(daynow.Year
                            , daynow.Month
                            , daynow.Day
                            , gio
                            , phut
                            , 0);
                    }

                    //
                    if (mota.ToLower().Contains("có mã"))
                    {
                        if (mota.Contains("có mã"))
                        {
                            string[] cm = mota.Split(new string[] { "có mã" }, StringSplitOptions.RemoveEmptyEntries);
                            string tenMT = "";
                            for (int j = 0; j < cm[1].Length; j++)
                            {
                                if (cm[1][j].ToString() == ":"
                                    || cm[1][j].ToString() == "."
                                    || cm[1][j].ToString() == ";")
                                    break;
                                else
                                {
                                    tenMT += cm[1][j].ToString();

                                    if (tenMT.Contains("Dự kiến"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                }
                            }
                            txtFullname.Text = "mã " + tenMT.Trim();
                        }
                        else if (mota.Contains("Có mã"))
                        {
                            string[] cm = mota.Split(new string[] { "Có mã" }, StringSplitOptions.RemoveEmptyEntries);
                            string tenMT = "";
                            for (int j = 0; j < cm[1].Length; j++)
                            {
                                if (cm[1][j].ToString() == ":"
                                    || cm[1][j].ToString() == "."
                                    || cm[1][j].ToString() == ";")
                                    break;
                                else
                                {
                                    tenMT += cm[1][j].ToString();

                                    if (tenMT.Contains("Dự kiến"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                }
                            }
                            txtFullname.Text = "mã " + tenMT.Trim();
                        }
                    }
                    else if (mota.ToLower().Contains("mã"))
                    {
                        if (mota.Contains("mã"))
                        {
                            string[] cm = mota.Split(new string[] { "mã" }, StringSplitOptions.RemoveEmptyEntries);
                            string tenMT = "";
                            for (int j = 0; j < cm[1].Length; j++)
                            {
                                if (cm[1][j].ToString() == ":"
                                    || cm[1][j].ToString() == "."
                                    || cm[1][j].ToString() == ";"
                                    || cm[1][j].ToString() == ")")
                                    break;
                                else
                                {
                                    tenMT += cm[1][j].ToString();

                                    if (tenMT.Contains("Dự kiến"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                }
                            }
                            txtFullname.Text = "mã " + tenMT.Trim();
                        }
                        else if (mota.Contains("Mã"))
                        {
                            string[] cm = mota.Split(new string[] { "Mã" }, StringSplitOptions.RemoveEmptyEntries);
                            string tenMT = "";
                            for (int j = 0; j < cm[1].Length; j++)
                            {
                                if (cm[1][j].ToString() == ":"
                                    || cm[1][j].ToString() == "."
                                    || cm[1][j].ToString() == ";"
                                    || cm[1][j].ToString() == ")")
                                    break;
                                else
                                {
                                    tenMT += cm[1][j].ToString();

                                    if (tenMT.Contains("Dự kiến"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                }
                            }
                            txtFullname.Text = "mã " + tenMT.Trim();
                        }
                    }

                    if (mota.Contains("Tàu HD"))
                    {
                        string[] cm = mota.Split(new string[] { "Tàu HD" }, StringSplitOptions.RemoveEmptyEntries);
                        string tenMT = "";
                        
                        if (cm.Length > 1)
                        {
                            for (int j = 0; j < cm[1].Length; j++)
                            {
                                if (cm[1][j].ToString() == ":"
                                    || cm[1][j].ToString() == "."
                                    || cm[1][j].ToString() == ";"
                                    || cm[1][j].ToString() == ")")
                                    break;
                                else
                                {
                                    tenMT += cm[1][j].ToString();

                                    if (tenMT.Contains("Dự kiến"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < cm[0].Length; j++)
                            {
                                if (cm[0][j].ToString() == ":"
                                    || cm[0][j].ToString() == "."
                                    || cm[0][j].ToString() == ";"
                                    || cm[0][j].ToString() == ")")
                                    break;
                                else
                                {
                                    tenMT += cm[0][j].ToString();

                                    if (tenMT.Contains("Dự kiến"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                }
                            }
                        }

                        txtFullname.Text = "HD" + tenMT.Trim();
                    }
                    else if (mota.Contains("Tàu Hải dương"))
                    {
                        string[] cm = mota.Split(new string[] { "Tàu Hải dương" }, StringSplitOptions.RemoveEmptyEntries);
                        string tenMT = "";

                        if (cm.Length > 1)
                        {
                            for (int j = 0; j < cm[1].Length; j++)
                            {
                                if (cm[1][j].ToString() == ":"
                                    || cm[1][j].ToString() == "."
                                    || cm[1][j].ToString() == ";"
                                    || cm[1][j].ToString() == ")")
                                    break;
                                else
                                {
                                    tenMT += cm[1][j].ToString();

                                    if (tenMT.Contains("Dự kiến"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < cm[0].Length; j++)
                            {
                                if (cm[0][j].ToString() == ":"
                                    || cm[0][j].ToString() == "."
                                    || cm[0][j].ToString() == ";"
                                    || cm[0][j].ToString() == ")")
                                    break;
                                else
                                {
                                    tenMT += cm[0][j].ToString();

                                    if (tenMT.Contains("Dự kiến"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                }
                            }
                        }
                        
                        txtFullname.Text = "HD" + tenMT.Trim();
                    }
                    else if (mota.Contains("Tàu Hải Dương"))
                    {
                        string[] cm = mota.Split(new string[] { "Tàu Hải Dương" }, StringSplitOptions.RemoveEmptyEntries);
                        string tenMT = "";
                        for (int j = 0; j < cm[1].Length; j++)
                        {
                            if (cm[1][j].ToString() == ":"
                                || cm[1][j].ToString() == "."
                                || cm[1][j].ToString() == ";"
                                || cm[1][j].ToString() == ")")
                                break;
                            else
                            {
                                tenMT += cm[1][j].ToString();

                                if (tenMT.Contains("Dự kiến"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("Lúc"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                            }
                        }
                        txtFullname.Text = "HD" + tenMT.Trim();
                    }

                    //
                    //
                    if (mota.ToLower().Contains("số hiệu"))
                    {
                        if (mota.Contains("số hiệu"))
                        {
                            string[] cm = mota.Split(new string[] { "số hiệu" }, StringSplitOptions.RemoveEmptyEntries);
                            string sohieu = "";
                            for (int j = 0; j < cm[1].Length; j++)
                            {
                                if (cm[1][j].ToString() == ":"
                                    || cm[1][j].ToString() == "."
                                    || cm[1][j].ToString() == ","
                                    || cm[1][j].ToString() == ";")
                                    break;
                                else
                                {
                                    sohieu += cm[1][j].ToString();

                                    if (sohieu.Contains("Dự kiến"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                }
                            }
                            txtSoHieu.Text = sohieu.Trim().ToUpper();
                        }
                        else if (mota.Contains("Số hiệu"))
                        {
                            string[] cm = mota.Split(new string[] { "Số hiệu" }, StringSplitOptions.RemoveEmptyEntries);
                            string sohieu = "";
                            for (int j = 0; j < cm[1].Length; j++)
                            {
                                if (cm[1][j].ToString() == ":"
                                    || cm[1][j].ToString() == "."
                                    || cm[1][j].ToString() == ","
                                    || cm[1][j].ToString() == ";")
                                    break;
                                else
                                {
                                    sohieu += cm[1][j].ToString();

                                    if (sohieu.Contains("Dự kiến"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                }
                            }
                            txtSoHieu.Text = sohieu.Trim().ToUpper();
                        }
                    }
                    else if (mota.ToLower().Contains("sh:"))
                    {
                        if (mota.Contains("SH:"))
                        {
                            string[] cm = mota.Split(new string[] { "SH:" }, StringSplitOptions.RemoveEmptyEntries);
                            string sohieu = "";
                            for (int j = 0; j < cm[1].Length; j++)
                            {
                                if (cm[1][j].ToString() == ":"
                                    || cm[1][j].ToString() == "."
                                    || cm[1][j].ToString() == ","
                                    || cm[1][j].ToString() == ";"
                                    || cm[1][j].ToString() == ")")
                                    break;
                                else
                                {
                                    sohieu += cm[1][j].ToString();

                                    if (sohieu.Contains("Dự kiến"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                }
                            }
                            txtSoHieu.Text = sohieu.Trim().ToUpper();
                        }
                        else if (mota.Contains("sh:"))
                        {
                            string[] cm = mota.Split(new string[] { "sh:" }, StringSplitOptions.RemoveEmptyEntries);
                            string sohieu = "";
                            for (int j = 0; j < cm[1].Length; j++)
                            {
                                if (cm[1][j].ToString() == ":"
                                    || cm[1][j].ToString() == "."
                                    || cm[1][j].ToString() == ","
                                    || cm[1][j].ToString() == ";"
                                    || cm[1][j].ToString() == ")")
                                    break;
                                else
                                {
                                    sohieu += cm[1][j].ToString();

                                    if (sohieu.Contains("Dự kiến"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                }
                            }
                            txtSoHieu.Text = sohieu.Trim().ToUpper();
                        }
                    }

                    //
                    if (mota.ToLower().Contains("danh hiệu thông tin"))
                    {
                        string[] dhtt = mota.ToLower().Split(new string[] { "danh hiệu thông tin" }, StringSplitOptions.RemoveEmptyEntries);
                        string danhHieu_ = "";
                        for (int j = 0; j < dhtt[1].Length; j++)
                        {
                            if (dhtt[1][j].ToString() == ":"
                                || dhtt[1][j].ToString() == "."
                                || dhtt[1][j].ToString() == ";")
                                break;
                            else
                            {
                                danhHieu_ += dhtt[1][j].ToString();

                                if (danhHieu_.Contains("dự kiến"))
                                {
                                    string[] tmp_ten = danhHieu_.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    danhHieu_ = tmp_ten[0].Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim();
                                    break;
                                }
                                else if (danhHieu_.Contains("lúc"))
                                {
                                    string[] tmp_ten = danhHieu_.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    danhHieu_ = tmp_ten[0].Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim();
                                    break;
                                }
                                else if (danhHieu_.Contains("hoạt động"))
                                {
                                    string[] tmp_ten = danhHieu_.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                    danhHieu_ = tmp_ten[0].Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim();
                                    break;
                                }

                            }
                        }
                        txtDanhHieu.Text = danhHieu_.Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim().ToUpper();
                    }
                    else if (mota.ToLower().Contains("danh hiệu"))
                    {
                        string[] dhtt = mota.ToLower().Split(new string[] { "danh hiệu" }, StringSplitOptions.RemoveEmptyEntries);
                        string danhHieu_ = "";
                        for (int j = 0; j < dhtt[1].Length; j++)
                        {
                            if (dhtt[1][j].ToString() == ":"
                                || dhtt[1][j].ToString() == "."
                                || dhtt[1][j].ToString() == ";")
                                break;
                            else
                            {
                                danhHieu_ += dhtt[1][j].ToString();

                                if (danhHieu_.Contains("dự kiến"))
                                {
                                    string[] tmp_ten = danhHieu_.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    danhHieu_ = tmp_ten[0].Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim();
                                    break;
                                }
                                else if (danhHieu_.Contains("lúc"))
                                {
                                    string[] tmp_ten = danhHieu_.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    danhHieu_ = tmp_ten[0].Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim();
                                    break;
                                }
                                else if (danhHieu_.Contains("hoạt động"))
                                {
                                    string[] tmp_ten = danhHieu_.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                    danhHieu_ = tmp_ten[0].Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim();
                                    break;
                                }

                            }
                        }
                        txtDanhHieu.Text = danhHieu_.Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim().ToUpper();
                    }
                    else if (mota.ToLower().Contains("acos"))
                    {
                        string[] dhtt = mota.ToLower().Split(new string[] { "acos" }, StringSplitOptions.RemoveEmptyEntries);
                        string danhHieu_ = "";
                        for (int j = 0; j < dhtt[1].Length; j++)
                        {
                            if (dhtt[1][j].ToString() == ":"
                                || dhtt[1][j].ToString() == "."
                                || dhtt[1][j].ToString() == ";")
                                break;
                            else
                            {
                                danhHieu_ += dhtt[1][j].ToString();

                                if (danhHieu_.Contains("dự kiến"))
                                {
                                    string[] tmp_ten = danhHieu_.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    danhHieu_ = tmp_ten[0].Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim();
                                    break;
                                }
                                else if (danhHieu_.Contains("lúc"))
                                {
                                    string[] tmp_ten = danhHieu_.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    danhHieu_ = tmp_ten[0].Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim();
                                    break;
                                }
                                else if (danhHieu_.Contains("hoạt động"))
                                {
                                    string[] tmp_ten = danhHieu_.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                    danhHieu_ = tmp_ten[0].Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim();
                                    break;
                                }

                            }
                        }
                        txtDanhHieu.Text = "ACOS " + danhHieu_.Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim().ToUpper();
                    }
                    dateNgayThang.Focus();
                }
            }
        }


        //Nhập nhiều mục tiêu:
        private bool Insert__HQ_NhieuMT(string mota)
        {
            string QuocGia_ = comboQuocGia.Text.Trim();
            string VungBien_ = comboVungBien.Text.Trim(); 
            string DanhHieu_ = "";
            string SoHieu_ = "";
            string FullName_ = "";
            string KieuLoai_ = comboKieuLoai.Text.Trim();
            int SoLuong_  = 0;
            double KinhDo_ = 0;
            double ViDo_ = 0;
            string ToaDo_ = "";
            int Distance_ = 0;
            string KhuVucDuKien_ = "";
            string KhuVucHoatDong_ = "";
            DateTime DateCurent_ = DateTime.Now;
            DateTime DateChange_ = DateTime.Now;
            clsTabHaiQuan cls = new clsTabHaiQuan();

            if (!string.IsNullOrEmpty(mota))
            {
                mota = mota.Trim();
                mota = mota.Trim('-');
                mota = mota.Trim();
                mota = mota.Trim('+');
                mota = mota.Trim();

                while (mota.IndexOf("\t") >= 0)
                {
                    mota = mota.Replace("\t", " ");
                }
                while (mota.IndexOf("  ") >= 0)
                {
                    mota = mota.Replace("  ", " ");
                }

                 while (mota.IndexOf(" ở ") >= 0)
                {
                    mota = mota.Replace(" ở ", " tại ");
                }


                // Số lượng:
                if (CheckString.CheckIsNumber(mota.Split()[0]))
                {
                    try
                    {
                        SoLuong_ = Convert.ToInt32(mota.Split()[0].Trim());
                    }
                    catch
                    {
                        SoLuong_ = 1;
                    }
                }
                else SoLuong_ = 1;

                //
                if (mota.Contains("tại"))
                {
                    string[] tmp = mota.Split(new string[] { "tại" }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (tmp[i].Contains("(") && tmp[i].ToLower().Contains("hl"))
                        {
                            string toado = (tmp[i].Trim()).Split()[0].Trim();
                            ToaDo_ = toado.Trim('.').Trim(',').Trim(':').Trim(';');

                            if (ToaDo_.Contains("/"))
                            {
                                if (!ToaDo_.Contains('⁰'))
                                {
                                    string[] str_tmpToaDo = ToaDo_.Trim().Split('/');
                                    string str_tmpViDo = str_tmpToaDo[0].Substring(0, 2) + "⁰" + str_tmpToaDo[0].Substring(3);
                                    string str_tmpKinhDo = str_tmpToaDo[1].Substring(0, 3) + "⁰" + str_tmpToaDo[1].Substring(4);

                                    KinhDo_ = CheckString._toDouble_ToaDo(str_tmpViDo.Trim());
                                    ViDo_ = CheckString._toDouble_ToaDo(str_tmpKinhDo.Trim());

                                    ToaDo_ = str_tmpViDo + "/" + str_tmpKinhDo;
                                }
                                else
                                {
                                    KinhDo_ = CheckString._toDouble_ToaDo(ToaDo_.Trim().Split('/')[0]);
                                    ViDo_ = CheckString._toDouble_ToaDo(ToaDo_.Trim().Split('/')[1]);
                                }
                            }
                            else
                            {
                                KinhDo_ = 0;
                                ViDo_ = 0;
                            }

                            //if (ToaDo_.Contains("/"))
                            //{
                            //    KinhDo_ = CheckString._toDouble_ToaDo(ToaDo_.Split('/')[0]);
                            //    ViDo_ = CheckString._toDouble_ToaDo(ToaDo_.Split('/')[1]);
                            //}
                            //else
                            //{
                            //    KinhDo_ = 0;
                            //    ViDo_ = 0;
                            //}

                            string tmp1 = tmp[i].Split('(')[1];
                            string khuVucHD = "";
                            string khoangCach = "";

                            for (int j = 0; j < tmp1.Length; j++)
                            {
                                if (CheckString.CheckIsNumber(tmp1[j].ToString()))
                                {
                                    khoangCach += tmp1[j].ToString();
                                }
                            }

                            for (int j = 0; j < tmp1.Length; j++)
                            {
                                if (!CheckString.CheckIsNumber(tmp1[j].ToString()))
                                {
                                    khuVucHD += tmp1[j].ToString();
                                }
                                else break;
                            }

                            KhuVucHoatDong_ = khuVucHD.Trim();
                            try
                            {
                                if (CheckString.CheckIsNumber(khoangCach.Trim()))
                                {
                                    Distance_ = Convert.ToInt32(khoangCach.Trim());
                                }
                                else Distance_ = 0;
                            }
                            catch
                            {
                                Distance_ = 0;
                            }
                        }
                    }
                }

                //
                if (mota.ToLower().Contains("dự kiến"))
                {
                    if (mota.Contains("Dự kiến"))
                    {
                        string[] dk = mota.Split(new string[] { "Dự" }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < dk.Length; i++)
                        {
                            if (dk[i].Contains("kiến"))
                            {
                                string khuVucDK = "";
                                for (int j = 0; j < dk[i].Length; j++)
                                {
                                    if (dk[i][j].ToString() == ":"
                                        || dk[i][j].ToString() == "."
                                        || dk[i][j].ToString() == ","
                                        || dk[i][j].ToString() == ";")
                                        break;
                                    else khuVucDK += dk[i][j].ToString();
                                }
                                KhuVucDuKien_ = "Dự " + khuVucDK;
                            }
                        }
                    }
                    else if (mota.Contains("dự kiến"))
                    {
                        string[] dk = mota.Split(new string[] { "dự" }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < dk.Length; i++)
                        {
                            if (dk[i].Contains("kiến"))
                            {
                                string khuVucDK = "";
                                for (int j = 0; j < dk[i].Length; j++)
                                {
                                    if (dk[i][j].ToString() == ":"
                                        || dk[i][j].ToString() == "."
                                        || dk[i][j].ToString() == ","
                                        || dk[i][j].ToString() == ";")
                                        break;
                                    else khuVucDK += dk[i][j].ToString();
                                }
                                KhuVucDuKien_ = "Dự " + khuVucDK;
                            }
                        }
                    }

                }

                //
                if (mota.ToLower().Contains("lúc"))
                {
                    string[] tg = mota.ToLower().Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                    string th_gian = tg[1].Trim().Split()[0].Trim();
                    int gio = 0;
                    int phut = 0;

                    if (th_gian.Contains("."))
                    {
                        gio = Convert.ToInt32(th_gian.Split('.')[0].Trim());
                        phut = Convert.ToInt32(th_gian.Split('.')[1].Trim());
                    }
                    else if (th_gian.Contains(":"))
                    {
                        gio = Convert.ToInt32(th_gian.Split(':')[0].Trim());
                        phut = Convert.ToInt32(th_gian.Split(':')[1].Trim());
                    }

                    DateTime daynow = Convert.ToDateTime(dateNgayThang.EditValue);
                    DateCurent_ = new DateTime(daynow.Year
                        , daynow.Month
                        , daynow.Day
                        , gio
                        , phut
                        , 0);
                }

                //
                if (mota.ToLower().Contains("có mã"))
                {
                    if (mota.Contains("có mã"))
                    {
                        string[] cm = mota.Split(new string[] { "có mã" }, StringSplitOptions.RemoveEmptyEntries);
                        string tenMT = "";
                        for (int j = 0; j < cm[1].Length; j++)
                        {
                            if (cm[1][j].ToString() == ":"
                                || cm[1][j].ToString() == "."
                                || cm[1][j].ToString() == ";")
                                break;
                            else
                            {
                                tenMT += cm[1][j].ToString();

                                if (tenMT.Contains("Dự kiến"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("Lúc"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                            }
                        }
                        FullName_ = "mã " + tenMT.Trim();
                    }
                    else if (mota.Contains("Có mã"))
                    {
                        string[] cm = mota.Split(new string[] { "Có mã" }, StringSplitOptions.RemoveEmptyEntries);
                        string tenMT = "";
                        for (int j = 0; j < cm[1].Length; j++)
                        {
                            if (cm[1][j].ToString() == ":"
                                || cm[1][j].ToString() == "."
                                || cm[1][j].ToString() == ";")
                                break;
                            else
                            {
                                tenMT += cm[1][j].ToString();

                                if (tenMT.Contains("Dự kiến"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("Lúc"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                            }
                        }
                        FullName_ = "mã " + tenMT.Trim();
                    }
                }
                else if (mota.ToLower().Contains("mã"))
                {
                    if (mota.Contains("mã"))
                    {
                        string[] cm = mota.Split(new string[] { "mã" }, StringSplitOptions.RemoveEmptyEntries);
                        string tenMT = "";
                        for (int j = 0; j < cm[1].Length; j++)
                        {
                            if (cm[1][j].ToString() == ":"
                                || cm[1][j].ToString() == "."
                                || cm[1][j].ToString() == ";"
                                || cm[1][j].ToString() == ")")
                                break;
                            else
                            {
                                tenMT += cm[1][j].ToString();

                                if (tenMT.Contains("Dự kiến"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("Lúc"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                            }
                        }
                        FullName_ = "mã " + tenMT.Trim();
                    }
                    else if (mota.Contains("Mã"))
                    {
                        string[] cm = mota.Split(new string[] { "Mã" }, StringSplitOptions.RemoveEmptyEntries);
                        string tenMT = "";
                        for (int j = 0; j < cm[1].Length; j++)
                        {
                            if (cm[1][j].ToString() == ":"
                                || cm[1][j].ToString() == "."
                                || cm[1][j].ToString() == ";"
                                || cm[1][j].ToString() == ")")
                                break;
                            else
                            {
                                tenMT += cm[1][j].ToString();

                                if (tenMT.Contains("Dự kiến"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("Lúc"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                            }
                        }
                        FullName_ = "mã " + tenMT.Trim();
                    }
                }


                if (mota.Contains("Tàu HD"))
                {
                    string[] cm = mota.Split(new string[] { "Tàu HD" }, StringSplitOptions.RemoveEmptyEntries);
                    string tenMT = "";
                    
                    if (cm.Length > 1)
                    {
                        for (int j = 0; j < cm[1].Length; j++)
                        {
                            if (cm[1][j].ToString() == ":"
                                || cm[1][j].ToString() == "."
                                || cm[1][j].ToString() == ";"
                                || cm[1][j].ToString() == ")")
                                break;
                            else
                            {
                                tenMT += cm[1][j].ToString();

                                if (tenMT.Contains("Dự kiến"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("Lúc"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < cm[0].Length; j++)
                        {
                            if (cm[0][j].ToString() == ":"
                                || cm[0][j].ToString() == "."
                                || cm[0][j].ToString() == ";"
                                || cm[0][j].ToString() == ")")
                                break;
                            else
                            {
                                tenMT += cm[0][j].ToString();

                                if (tenMT.Contains("Dự kiến"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("Lúc"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                            }
                        }
                    }

                    FullName_ = "HD" + tenMT.Trim();
                }
                else if (mota.Contains("Tàu Hải dương"))
                {
                    string[] cm = mota.Split(new string[] { "Tàu Hải dương" }, StringSplitOptions.RemoveEmptyEntries);
                    string tenMT = "";
                    
                    if (cm.Length > 1)
                    {
                        for (int j = 0; j < cm[1].Length; j++)
                        {
                            if (cm[1][j].ToString() == ":"
                                || cm[1][j].ToString() == "."
                                || cm[1][j].ToString() == ";"
                                || cm[1][j].ToString() == ")")
                                break;
                            else
                            {
                                tenMT += cm[1][j].ToString();

                                if (tenMT.Contains("Dự kiến"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("Lúc"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < cm[0].Length; j++)
                        {
                            if (cm[0][j].ToString() == ":"
                                || cm[0][j].ToString() == "."
                                || cm[0][j].ToString() == ";"
                                || cm[0][j].ToString() == ")")
                                break;
                            else
                            {
                                tenMT += cm[0][j].ToString();

                                if (tenMT.Contains("Dự kiến"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("Lúc"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                            }
                        }
                    }

                    FullName_ = "HD" + tenMT.Trim();
                }

                //
                //
                if (mota.ToLower().Contains("số hiệu"))
                {
                    if (mota.Contains("số hiệu"))
                    {
                        string[] cm = mota.Split(new string[] { "số hiệu" }, StringSplitOptions.RemoveEmptyEntries);
                        string sohieu = "";
                        for (int j = 0; j < cm[1].Length; j++)
                        {
                            if (cm[1][j].ToString() == ":"
                                || cm[1][j].ToString() == "."
                                || cm[1][j].ToString() == ","
                                || cm[1][j].ToString() == ";")
                                break;
                            else
                            {
                                sohieu += cm[1][j].ToString();

                                if (sohieu.Contains("Dự kiến"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("Lúc"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                            }
                        }
                        SoHieu_ = sohieu.Trim().ToUpper();
                    }
                    else if (mota.Contains("Số hiệu"))
                    {
                        string[] cm = mota.Split(new string[] { "Số hiệu" }, StringSplitOptions.RemoveEmptyEntries);
                        string sohieu = "";
                        for (int j = 0; j < cm[1].Length; j++)
                        {
                            if (cm[1][j].ToString() == ":"
                                || cm[1][j].ToString() == "."
                                || cm[1][j].ToString() == ","
                                || cm[1][j].ToString() == ";")
                                break;
                            else
                            {
                                sohieu += cm[1][j].ToString();

                                if (sohieu.Contains("Dự kiến"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("Lúc"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                            }
                        }
                        SoHieu_ = sohieu.Trim().ToUpper();
                    }
                }
                else if (mota.ToLower().Contains("sh:"))
                {
                    if (mota.Contains("SH:"))
                    {
                        string[] cm = mota.Split(new string[] { "SH:" }, StringSplitOptions.RemoveEmptyEntries);
                        string sohieu = "";
                        for (int j = 0; j < cm[1].Length; j++)
                        {
                            if (cm[1][j].ToString() == ":"
                                || cm[1][j].ToString() == "."
                                || cm[1][j].ToString() == ","
                                || cm[1][j].ToString() == ";"
                                || cm[1][j].ToString() == ")")
                                break;
                            else
                            {
                                sohieu += cm[1][j].ToString();

                                if (sohieu.Contains("Dự kiến"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("Lúc"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                            }
                        }
                        SoHieu_ = sohieu.Trim().ToUpper();
                    }
                    else if (mota.Contains("sh:"))
                    {
                        string[] cm = mota.Split(new string[] { "sh:" }, StringSplitOptions.RemoveEmptyEntries);
                        string sohieu = "";
                        for (int j = 0; j < cm[1].Length; j++)
                        {
                            if (cm[1][j].ToString() == ":"
                                || cm[1][j].ToString() == "."
                                || cm[1][j].ToString() == ","
                                || cm[1][j].ToString() == ";"
                                || cm[1][j].ToString() == ")")
                                break;
                            else
                            {
                                sohieu += cm[1][j].ToString();

                                if (sohieu.Contains("Dự kiến"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "Dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("Lúc"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                            }
                        }
                        SoHieu_ = sohieu.Trim().ToUpper();
                    }
                }

                //
                //
                if (mota.ToLower().Contains("danh hiệu thông tin"))
                {
                    string[] dhtt = mota.ToLower().Split(new string[] { "danh hiệu thông tin" }, StringSplitOptions.RemoveEmptyEntries);
                    string danhHieu_ = "";
                    for (int j = 0; j < dhtt[1].Length; j++)
                    {
                        if (dhtt[1][j].ToString() == ":"
                            || dhtt[1][j].ToString() == "."
                            || dhtt[1][j].ToString() == ";")
                            break;
                        else
                        {
                            danhHieu_ += dhtt[1][j].ToString();

                            if (danhHieu_.Contains("dự kiến"))
                            {
                                string[] tmp_ten = danhHieu_.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                danhHieu_ = tmp_ten[0].Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim();
                                break;
                            }
                            else if (danhHieu_.Contains("lúc"))
                            {
                                string[] tmp_ten = danhHieu_.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                danhHieu_ = tmp_ten[0].Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim();
                                break;
                            }
                            else if (danhHieu_.Contains("hoạt động"))
                            {
                                string[] tmp_ten = danhHieu_.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                danhHieu_ = tmp_ten[0].Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim();
                                break;
                            }

                        }
                    }
                    DanhHieu_ = danhHieu_.Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim().ToUpper();
                }
                else if (mota.ToLower().Contains("danh hiệu"))
                {
                    string[] dhtt = mota.ToLower().Split(new string[] { "danh hiệu" }, StringSplitOptions.RemoveEmptyEntries);
                    string danhHieu_ = "";
                    for (int j = 0; j < dhtt[1].Length; j++)
                    {
                        if (dhtt[1][j].ToString() == ":"
                            || dhtt[1][j].ToString() == "."
                            || dhtt[1][j].ToString() == ";")
                            break;
                        else
                        {
                            danhHieu_ += dhtt[1][j].ToString();

                            if (danhHieu_.Contains("dự kiến"))
                            {
                                string[] tmp_ten = danhHieu_.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                danhHieu_ = tmp_ten[0].Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim();
                                break;
                            }
                            else if (danhHieu_.Contains("lúc"))
                            {
                                string[] tmp_ten = danhHieu_.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                danhHieu_ = tmp_ten[0].Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim();
                                break;
                            }
                            else if (danhHieu_.Contains("hoạt động"))
                            {
                                string[] tmp_ten = danhHieu_.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                danhHieu_ = tmp_ten[0].Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim();
                                break;
                            }

                        }
                    }
                    DanhHieu_ = danhHieu_.Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim().ToUpper();
                }
                else if (mota.ToLower().Contains("acos"))
                {
                    string[] dhtt = mota.ToLower().Split(new string[] { "acos" }, StringSplitOptions.RemoveEmptyEntries);
                    string danhHieu_ = "";
                    for (int j = 0; j < dhtt[1].Length; j++)
                    {
                        if (dhtt[1][j].ToString() == ":"
                            || dhtt[1][j].ToString() == "."
                            || dhtt[1][j].ToString() == ";")
                            break;
                        else
                        {
                            danhHieu_ += dhtt[1][j].ToString();

                            if (danhHieu_.Contains("dự kiến"))
                            {
                                string[] tmp_ten = danhHieu_.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                danhHieu_ = tmp_ten[0].Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim();
                                break;
                            }
                            else if (danhHieu_.Contains("lúc"))
                            {
                                string[] tmp_ten = danhHieu_.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                danhHieu_ = tmp_ten[0].Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim();
                                break;
                            }
                            else if (danhHieu_.Contains("hoạt động"))
                            {
                                string[] tmp_ten = danhHieu_.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                danhHieu_ = tmp_ten[0].Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim();
                                break;
                            }

                        }
                    }
                    DanhHieu_ = "ACOS " + danhHieu_.Trim().Trim(',').Trim().Trim(':').Trim().Trim('.').Trim().Trim(')').Trim().Trim('(').Trim().ToUpper();
                }

                //
                cls.sQuocGia = QuocGia_;
                cls.daDateCurent = DateCurent_;
                cls.daDateChange = DateTime.Now;
                cls.sVungBien = VungBien_;
                cls.sDanhHieu = DanhHieu_;
                cls.sSoHieu = SoHieu_;
                cls.sFullName = FullName_;
                cls.sKieuLoai = KieuLoai_;
                cls.iSoLuong = SoLuong_;
                cls.fKinhDo = KinhDo_;
                cls.fViDo = ViDo_;
                cls.sToaDo = ToaDo_;
                cls.iDistance = Distance_;
                cls.sKhuVucDuKien = KhuVucDuKien_;
                cls.sKhuVucHoatDong = KhuVucHoatDong_;
                cls.sMoTa = mota;

                if (cls.Insert()) return true;
                else return false;
            }
            else return false;
        }
        private void comboKieuLoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btSave_Click(null, null);
            }
        }

        private void txtFullname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btSave_Click(null, null);
            }
        }

        private void txtDanhHieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btSave_Click(null, null);
            }
        }

        private void txtSoLuong_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btSave_Click(null, null);
            }
        }

        private void comboQuocGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btSave_Click(null, null);
            }
        }

        private void comboVungBien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btSave_Click(null, null);
            }
        }

        private void txtKhuVucDuKien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btSave_Click(null, null);
            }
        }

        private void txtKhuVucHoatDong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btSave_Click(null, null);
            }
        }

        private void txtToaDo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btSave_Click(null, null);
            }
        }

        private void txtKhoangCach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btSave_Click(null, null);
            }
        }
    }
}
