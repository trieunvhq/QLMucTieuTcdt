using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLMucTieu
{
    public partial class frmChiTiet_KhongQuan : Form
    {
        private bool Insert_KhongQuan()
        {
            clsTabKhongQuan cls = new clsTabKhongQuan();
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
                cls.fKinhDo = CheckString._toDouble_ToaDo(txtToaDo.Text.Trim().Split('/')[0]);
                cls.fViDo = CheckString._toDouble_ToaDo(txtToaDo.Text.Trim().Split('/')[1]);
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
        private bool Update_KhongQuan()
        {
            clsTabKhongQuan cls = new clsTabKhongQuan();

            cls.iId = frmMain.ID;
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
                cls.fKinhDo = CheckString._toDouble_ToaDo(txtToaDo.Text.Trim().Split('/')[0]);
                cls.fViDo = CheckString._toDouble_ToaDo(txtToaDo.Text.Trim().Split('/')[1]);
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
            dateNgayThang.EditValue = frmMain.DateCurent;
            txtMoTa.Text = frmMain.MoTa;
            comboKieuLoai.Text = frmMain.KieuLoai;
            txtFullname.Text = frmMain.FullName;
            txtDanhHieu.Text = frmMain.DanhHieu;
            txtSoHieu.Text = frmMain.SoHieu;
            txtSoLuong.Text = frmMain.SoLuong.ToString();
            comboQuocGia.Text = frmMain.QuocGia;
            comboVungBien.Text = frmMain.VungBien;
            txtToaDo.Text = frmMain.ToaDo;
            txtKhoangCach.Text = frmMain.Distance.ToString();
            txtKhuVucDuKien.Text = frmMain.KhuVucDuKien;
            txtKhuVucHoatDong.Text = frmMain.KhuVucHoatDong;
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
        public frmChiTiet_KhongQuan(frmMain ucBBKTDM)
        {
            _ucBBKTDM = ucBBKTDM;
            InitializeComponent();
        }

        private void frmChiTiet_KhongQuan_Load(object sender, EventArgs e)
        {
            comboQuocGia.Properties.Items.Add("Trung Quốc");
            comboQuocGia.Properties.Items.Add("Mỹ");
            comboQuocGia.Text = "Trung Quốc";

            comboVungBien.Properties.Items.Add("Vịnh Bắc Bộ");
            comboVungBien.Properties.Items.Add("Vùng biển miền Trung");
            comboVungBien.Properties.Items.Add("Vùng biển Trường Sa - DK1 và phía Nam");
            comboVungBien.Text = "Vịnh Bắc Bộ";

            comboKieuLoai.Properties.Items.Add("Trinh sát");
            comboKieuLoai.Properties.Items.Add("Tiêm kích");
            comboKieuLoai.Properties.Items.Add("Trực thăng");
            comboKieuLoai.Properties.Items.Add("Vận tải");
            comboKieuLoai.Properties.Items.Add("Dân dụng");
            comboKieuLoai.Text = "Trinh sát";

            dateNgayThang.EditValue = DateTime.Now.AddDays(-1);

            if (frmMain.mbCopyKQ)
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
            if (frmMain.mbAddKQ == true
                && frmMain.mb_SuaKQ == false)
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

                        while (mota.IndexOf(" ở ") >= 0)
                        {
                            mota = mota.Replace(" ở ", " tại ");
                            //string result__ = Regex.Replace(mota, " ở ", " tại ", RegexOptions.IgnoreCase);
                        }


                        //
                        int count = 0;
                        string[] str = mota.Split('\n');
                        for (int i = 0; i < str.Length; i++)
                        {
                            if (Insert_KQ_NhieuMT(str[i])) count += 1;
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
                        if (Insert_KhongQuan())
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
            else if (frmMain.mbAddKQ == false
                && frmMain.mb_SuaKQ == true)
            {
                if (Update_KhongQuan())
                {
                    this.Close();
                    _ucBBKTDM.LoadData(frmMain._SoTrang, false);
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


                    mota = mota.Trim();

                    // Số lượng:
                    if (CheckString.CheckIsNumber(mota.Split()[0]))
                    {
                        txtSoLuong.Text = mota.Split()[0].Trim();
                    }
                    else txtSoLuong.Text = "1";

                    //
                    //
                    if (mota.ToLower().Contains("tiêm kích"))
                    {
                        comboKieuLoai.Text = "Tiêm kích";
                    }
                    else if (mota.ToLower().Contains("trinh sát"))
                    {
                        comboKieuLoai.Text = "Trinh sát";
                    }
                    else if (mota.ToLower().Contains("ts tuần thám biển"))
                    {
                        comboKieuLoai.Text = "TS tuần thám biển";
                    }
                    else if (mota.ToLower().Contains("trực thăng"))
                    {
                        comboKieuLoai.Text = "Trực thăng";
                    }
                    else if (mota.ToLower().Contains("vận tải"))
                    {
                        comboKieuLoai.Text = "Vận tải";
                    }
                    else if (mota.ToLower().Contains("dân dụng"))
                    {
                        comboKieuLoai.Text = "Dân dụng";
                    }
                    else if (mota.ToLower().Contains("ts điện tử"))
                    {
                        comboKieuLoai.Text = "TSĐT";
                    }
                    else if (mota.ToLower().Contains("tsđt"))
                    {
                        comboKieuLoai.Text = "TSĐT";
                    }
                    else if (mota.ToLower().Contains("tc điện tử"))
                    {
                        comboKieuLoai.Text = "TCĐT";
                    }
                    else if (mota.ToLower().Contains("tcđt"))
                    {
                        comboKieuLoai.Text = "TCĐT";
                    }
                    else if (mota.ToLower().Contains("qs"))
                    {
                        comboKieuLoai.Text = "Quân sự";
                    }
                    else if (mota.ToLower().Contains("chỉ huy cảnh báo sớm"))
                    {
                        comboKieuLoai.Text = "Chỉ huy cảnh báo sớm";
                    }
                    else if (mota.ToLower().Contains("chưa xác định"))
                    {
                        comboKieuLoai.Text = "chưa xác định";
                    }
                    else
                    {
                        comboKieuLoai.Text = "";
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
                    if (mota.Contains("Lúc") || mota.Contains("lúc"))
                    {
                        string[] tg;

                        if (mota.Contains("Lúc"))
                        {
                            tg = mota.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                        }
                        else if (mota.Contains("lúc"))
                        {
                            tg = mota.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                        }
                        else tg = new string[] { };

                        string mota_sub = "";

                        for (int j = 1; j < tg.Length; j++)
                        {
                            if (tg[j].ToLower().Contains("bạch long") ||
                                tg[j].ToLower().Contains("bach long") ||
                                tg[j].ToLower().Contains("bạch  long") ||
                                tg[j].ToLower().Contains("bạch  lông") ||
                                tg[j].ToLower().Contains("blv") ||
                                tg[j].ToLower().Contains("trần") ||
                                tg[j].ToLower().Contains("tran") ||
                                tg[j].ToLower().Contains("trà bản") ||
                                tg[j].ToLower().Contains("tra ban") ||
                                tg[j].ToLower().Contains("cô tô") ||
                                tg[j].ToLower().Contains("co to"))
                            {
                                mota_sub = tg[j];
                                break;
                            }
                            else mota_sub = tg.Last();
                        }

                        //
                        if (mota_sub != "")
                        {
                            //Lấy giờ, phút:
                            string th_gian = mota_sub.Trim().Split()[0].Trim();
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

                            //Lấy tọa độ, khu vực hoạt động, khoảng cách:
                            if (mota_sub.Trim().Contains("tại"))
                            {
                                string[] tmp = mota_sub.Trim().Split(new string[] { "tại" }, StringSplitOptions.RemoveEmptyEntries);

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

                                        for (int t = 0; t < tmp1.Length; t++)
                                        {
                                            if (CheckString.CheckIsNumber(tmp1[t].ToString()))
                                            {
                                                khoangCach += tmp1[t].ToString();
                                            }
                                        }

                                        for (int t = 0; t < tmp1.Length; t++)
                                        {
                                            if (!CheckString.CheckIsNumber(tmp1[t].ToString()))
                                            {
                                                khuVucHD += tmp1[t].ToString();
                                            }
                                            else break;
                                        }

                                        txtKhuVucHoatDong.Text = khuVucHD.Trim();
                                        txtKhoangCach.Text = khoangCach.Trim();
                                    }
                                }
                            }
                        }
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
                                    else if (tenMT.Contains("dự kiến"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("lúc"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("hoạt động"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("Hoạt động"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
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
                                    else if (tenMT.Contains("dự kiến"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("lúc"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("hoạt động"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("Hoạt động"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
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
                                    else if (tenMT.Contains("dự kiến"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("lúc"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("hoạt động"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("Hoạt động"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
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
                                    else if (tenMT.Contains("dự kiến"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("lúc"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("hoạt động"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (tenMT.Contains("Hoạt động"))
                                    {
                                        string[] tmp_ten = tenMT.Split(new string[] { "Hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                        tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                }
                            }
                            txtFullname.Text = "mã " + tenMT.Trim();
                        }
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
                                    else if (sohieu.Contains("dự kiến"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("lúc"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("hoạt động"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("Hoạt động"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "Hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
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
                                    else if (sohieu.Contains("dự kiến"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("lúc"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("hoạt động"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("Hoạt động"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "Hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
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
                                    else if (sohieu.Contains("dự kiến"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("lúc"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("hoạt động"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("Hoạt động"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "Hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
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
                                    else if (sohieu.Contains("dự kiến"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("Lúc"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("lúc"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("hoạt động"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                    else if (sohieu.Contains("Hoạt động"))
                                    {
                                        string[] tmp_ten = sohieu.Split(new string[] { "Hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                        sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                        break;
                                    }
                                }
                            }
                            txtSoHieu.Text = sohieu.Trim().ToUpper();
                        }
                    }

                    dateNgayThang.Focus();
                }
            }
        }


        //Nhập nhiều mục tiêu:
        private bool Insert_KQ_NhieuMT(string mota)
        {
            string QuocGia_ = comboQuocGia.Text.Trim();
            string VungBien_ = comboVungBien.Text.Trim(); 
            string DanhHieu_ = "";
            string SoHieu_ = "";
            string FullName_ = "";
            string KieuLoai_ = "";
            int SoLuong_  = 0;
            double KinhDo_ = 0;
            double ViDo_ = 0;
            string ToaDo_ = "";
            int Distance_ = 0;
            string KhuVucDuKien_ = "";
            string KhuVucHoatDong_ = "";
            DateTime DateCurent_ = DateTime.Now;
            DateTime DateChange_ = DateTime.Now;
            clsTabKhongQuan cls = new clsTabKhongQuan();

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
                mota = mota.Trim();

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
                if (mota.ToLower().Contains("tiêm kích"))
                {
                    KieuLoai_ = "Tiêm kích";
                }
                else if (mota.ToLower().Contains("trinh sát"))
                {
                    KieuLoai_ = "Trinh sát";
                }
                else if (mota.ToLower().Contains("ts tuần thám biển"))
                {
                    KieuLoai_ = "TS tuần thám biển";
                }
                else if (mota.ToLower().Contains("trực thăng"))
                {
                    KieuLoai_ = "Trực thăng";
                }
                else if (mota.ToLower().Contains("vận tải"))
                {
                    KieuLoai_ = "Vận tải";
                }
                else if (mota.ToLower().Contains("dân dụng"))
                {
                    KieuLoai_ = "Dân dụng";
                }
                else if (mota.ToLower().Contains("ts điện tử"))
                {
                    KieuLoai_ = "TSĐT";
                }
                else if (mota.ToLower().Contains("tsđt"))
                {
                    KieuLoai_ = "TSĐT";
                }
                else if (mota.ToLower().Contains("tc điện tử"))
                {
                    KieuLoai_ = "TCĐT";
                }
                else if (mota.ToLower().Contains("tcđt"))
                {
                    KieuLoai_ = "TCĐT";
                }
                else if (mota.ToLower().Contains("qs"))
                {
                    KieuLoai_ = "Quân sự";
                }
                else if (mota.ToLower().Contains("chỉ huy cảnh báo sớm"))
                {
                    KieuLoai_ = "Chỉ huy cảnh báo sớm";
                }
                else if (mota.ToLower().Contains("chưa xác định"))
                {
                    KieuLoai_ = "chưa xác định";
                }
                else
                {
                    KieuLoai_ = "";
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
                if (mota.Contains("Lúc") || mota.Contains("lúc"))
                {
                    string[] tg;

                    if (mota.Contains("Lúc"))
                    {
                        tg = mota.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    else if (mota.Contains("lúc"))
                    {
                        tg = mota.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    else tg = new string[] { };

                    string mota_sub = "";

                    for (int j = 1; j < tg.Length; j++)
                    {
                        if (tg[j].ToLower().Contains("bạch long") ||
                            tg[j].ToLower().Contains("bach long") ||
                            tg[j].ToLower().Contains("bạch  long") ||
                            tg[j].ToLower().Contains("bạch  lông") ||
                            tg[j].ToLower().Contains("blv") ||
                            tg[j].ToLower().Contains("trần") ||
                            tg[j].ToLower().Contains("tran") ||
                            tg[j].ToLower().Contains("trà bản") ||
                            tg[j].ToLower().Contains("tra ban") ||
                            tg[j].ToLower().Contains("cô tô") ||
                            tg[j].ToLower().Contains("co to"))
                        {
                            mota_sub = tg[j];
                            break;
                        }
                        else mota_sub = tg.Last();
                    }

                    //
                    if (mota_sub != "")
                    {
                        //Lấy giờ, phút:
                        string th_gian = mota_sub.Trim().Split()[0].Trim();
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

                        //Lấy tọa độ, khu vực hoạt động, khoảng cách:
                        if (mota_sub.Contains("tại"))
                        {
                            string[] tmp = mota_sub.Split(new string[] { "tại" }, StringSplitOptions.RemoveEmptyEntries);

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
                    }
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
                                else if (tenMT.Contains("dự kiến"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("Lúc"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("lúc"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("hoạt động"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("Hoạt động"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
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
                                else if (tenMT.Contains("dự kiến"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("Lúc"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("lúc"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("hoạt động"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("Hoạt động"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
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
                                else if (tenMT.Contains("dự kiến"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("Lúc"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("lúc"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("hoạt động"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("Hoạt động"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
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
                                else if (tenMT.Contains("dự kiến"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("Lúc"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("lúc"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("hoạt động"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (tenMT.Contains("Hoạt động"))
                                {
                                    string[] tmp_ten = tenMT.Split(new string[] { "Hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                    tenMT = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                            }
                        }
                        FullName_ = "mã " + tenMT.Trim();
                    }
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
                                else if (sohieu.Contains("dự kiến"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("Lúc"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("lúc"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("hoạt động"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("Hoạt động"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "Hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
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
                                else if (sohieu.Contains("dự kiến"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("Lúc"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("lúc"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("hoạt động"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("Hoạt động"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "Hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
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
                                else if (sohieu.Contains("dự kiến"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("Lúc"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("lúc"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("hoạt động"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("Hoạt động"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "Hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
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
                                else if (sohieu.Contains("dự kiến"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "dự kiến" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("Lúc"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "Lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("lúc"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "lúc" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("hoạt động"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                                else if (sohieu.Contains("Hoạt động"))
                                {
                                    string[] tmp_ten = sohieu.Split(new string[] { "Hoạt động" }, StringSplitOptions.RemoveEmptyEntries);
                                    sohieu = tmp_ten[0].Trim().Trim(',').Trim();
                                    break;
                                }
                            }
                        }
                        SoHieu_ = sohieu.Trim().ToUpper();
                    }
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
