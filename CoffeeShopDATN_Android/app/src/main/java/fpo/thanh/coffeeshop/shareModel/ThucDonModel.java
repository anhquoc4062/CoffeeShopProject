package fpo.thanh.coffeeshop.shareModel;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class ThucDonModel {
    @SerializedName("tenLoai")
    @Expose
    private String tenLoai;
    @SerializedName("getGiaKhuyenMai")
    @Expose
    private Double getGiaKhuyenMai;
    @SerializedName("maThucDon")
    @Expose
    private Integer maThucDon;
    @SerializedName("tenThucDon")
    @Expose
    private String tenThucDon;
    @SerializedName("hinhAnh")
    @Expose
    private String hinhAnh;
    @SerializedName("maLoai")
    @Expose
    private Integer maLoai;
    @SerializedName("gia")
    @Expose
    private Double gia;
    @SerializedName("khuyenMai")
    @Expose
    private Integer khuyenMai;
    @SerializedName("moTa")
    @Expose
    private String moTa;
    @SerializedName("giaKhuyenMai")
    @Expose
    private Double giaKhuyenMai;

    public String getTenLoai() {
        return tenLoai;
    }

    public void setTenLoai(String tenLoai) {
        this.tenLoai = tenLoai;
    }

    public Double getGetGiaKhuyenMai() {
        return getGiaKhuyenMai;
    }

    public void setGetGiaKhuyenMai(Double getGiaKhuyenMai) {
        this.getGiaKhuyenMai = getGiaKhuyenMai;
    }

    public Integer getMaThucDon() {
        return maThucDon;
    }

    public void setMaThucDon(Integer maThucDon) {
        this.maThucDon = maThucDon;
    }

    public String getTenThucDon() {
        return tenThucDon;
    }

    public void setTenThucDon(String tenThucDon) {
        this.tenThucDon = tenThucDon;
    }

    public String getHinhAnh() {
        return hinhAnh;
    }

    public void setHinhAnh(String hinhAnh) {
        this.hinhAnh = hinhAnh;
    }

    public Integer getMaLoai() {
        return maLoai;
    }

    public void setMaLoai(Integer maLoai) {
        this.maLoai = maLoai;
    }

    public Double getGia() {
        return gia;
    }

    public void setGia(Double gia) {
        this.gia = gia;
    }

    public Integer getKhuyenMai() {
        return khuyenMai;
    }

    public void setKhuyenMai(Integer khuyenMai) {
        this.khuyenMai = khuyenMai;
    }

    public String getMoTa() {
        return moTa;
    }

    public void setMoTa(String moTa) {
        this.moTa = moTa;
    }

    public Double getGiaKhuyenMai() {
        return giaKhuyenMai;
    }

    public void setGiaKhuyenMai(Double giaKhuyenMai) {
        this.giaKhuyenMai = giaKhuyenMai;
    }
}
