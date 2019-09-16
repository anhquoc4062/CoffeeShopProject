package fpo.thanh.coffeeshop.domain.Room.RoomModel;

import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.PrimaryKey;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.util.List;

import fpo.thanh.coffeeshop.shareModel.DsMonModel;

@Entity
public class HoaDon {
    @PrimaryKey(autoGenerate = false)
    public Integer maHoaDon;
    @ColumnInfo(name = "thoiGianLap")
    public String thoiGianLap;
    @ColumnInfo(name = "maNhanVien")
    public Integer maNhanVien;
    @ColumnInfo(name = "maBan")
    public Integer maBan;
    @ColumnInfo(name = "tongTien")
    public Integer tongTien;
    @ColumnInfo(name = "maHoaDonLocal")
    public Integer maHoaDonLocal;
    @ColumnInfo(name = "trangThai")
    public String trangThai;

}
