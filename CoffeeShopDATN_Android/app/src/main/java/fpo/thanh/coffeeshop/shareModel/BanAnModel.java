package fpo.thanh.coffeeshop.shareModel;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class BanAnModel {
    @SerializedName("tenTang")
    @Expose
    private String tenTang;

    @Override
    public String toString() {
        return "{" +
                "\"tenTang\":\"" + tenTang + '\"' +
                ", \"maBan\":" + maBan +
                ", \"tenBan\":\"" + tenBan + '\"' +
                ", \"maTang\":" + maTang +
                '}';
    }

    @SerializedName("maBan")
    @Expose
    private Integer maBan;
    @SerializedName("tenBan")
    @Expose
    private String tenBan;
    @SerializedName("maTang")
    @Expose
    private Integer maTang;

    public String getTenTang() {
        return tenTang;
    }

    public void setTenTang(String tenTang) {
        this.tenTang = tenTang;
    }

    public Integer getMaBan() {
        return maBan;
    }

    public void setMaBan(Integer maBan) {
        this.maBan = maBan;
    }

    public String getTenBan() {
        return tenBan;
    }

    public void setTenBan(String tenBan) {
        this.tenBan = tenBan;
    }

    public Integer getMaTang() {
        return maTang;
    }

    public void setMaTang(Integer maTang) {
        this.maTang = maTang;
    }

}
