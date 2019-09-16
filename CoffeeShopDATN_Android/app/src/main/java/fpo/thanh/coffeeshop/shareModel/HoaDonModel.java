package fpo.thanh.coffeeshop.shareModel;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.util.List;

public class HoaDonModel {
    @SerializedName("dsMon")
    @Expose
    private List<DsMonModel> dsMon = null;
    @SerializedName("maHoaDon")
    @Expose
    private Integer maHoaDon;
    @SerializedName("thoiGianLap")
    @Expose
    private String thoiGianLap;
    @SerializedName("maNhanVien")
    @Expose
    private Integer maNhanVien;
    @SerializedName("maBan")
    @Expose
    private Integer maBan;
    @SerializedName("tongTien")
    @Expose
    private Integer tongTien;
    @SerializedName("maHoaDonLocal")
    @Expose
    private Integer maHoaDonLocal;
    @SerializedName("trangThai")
    @Expose
    private String trangThai;

    public List<DsMonModel> getDsMon() {
        return dsMon;
    }

    public void setDsMon(List<DsMonModel> dsMon) {
        this.dsMon = dsMon;
    }

    public Integer getMaHoaDon() {
        return maHoaDon;
    }

    public void setMaHoaDon(Integer maHoaDon) {
        this.maHoaDon = maHoaDon;
    }

    public String getThoiGianLap() {
        return thoiGianLap;
    }

    public void setThoiGianLap(String thoiGianLap) {
        this.thoiGianLap = thoiGianLap;
    }

    public Integer getMaNhanVien() {
        return maNhanVien;
    }

    public void setMaNhanVien(Integer maNhanVien) {
        this.maNhanVien = maNhanVien;
    }

    public Integer getMaBan() {
        return maBan;
    }

    public void setMaBan(Integer maBan) {
        this.maBan = maBan;
    }

    public Integer getTongTien() {
        return tongTien;
    }

    public void setTongTien(Integer tongTien) {
        this.tongTien = tongTien;
    }

    public Integer getMaHoaDonLocal() {
        return maHoaDonLocal;
    }

    public void setMaHoaDonLocal(Integer maHoaDonLocal) {
        this.maHoaDonLocal = maHoaDonLocal;
    }

    public String getTrangThai() {
        return trangThai;
    }

    public void setTrangThai(String trangThai) {
        this.trangThai = trangThai;
    }
}
