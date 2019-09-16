package fpo.thanh.coffeeshop.domain.Room.RoomModel;

import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.PrimaryKey;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

@Entity
public class DsMon {
    @PrimaryKey(autoGenerate = true)
    public int maDsMon;
    @ColumnInfo(name = "tenThucDon")
    public String tenThucDon;
    @ColumnInfo(name = "giaMon")
    public Double giaMon;
    @ColumnInfo(name="maChiTiet")
    public Integer maChiTiet;
    @ColumnInfo(name = "maHoaDon")
    public Integer maHoaDon;
    @ColumnInfo(name="maThucDon")
    public Integer maThucDon;
    @ColumnInfo(name = "soLuong")
    public Integer soLuong;
    @ColumnInfo(name = "donGia")
    public Double donGia;
    @ColumnInfo(name = "maChiTietLocal")
    public Integer maChiTietLocal;
    @ColumnInfo(name = "trangThai")
    public Integer trangThai;
}
