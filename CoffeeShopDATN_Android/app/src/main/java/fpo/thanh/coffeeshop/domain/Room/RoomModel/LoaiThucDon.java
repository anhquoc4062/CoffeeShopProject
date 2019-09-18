package fpo.thanh.coffeeshop.domain.Room.RoomModel;

import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.PrimaryKey;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

@Entity
public class LoaiThucDon {
    @PrimaryKey(autoGenerate = false)
    public Integer maLoai;
    @ColumnInfo(name = "tenLoai")
    public String tenLoai;
    @ColumnInfo(name = "maLoaiCha")
    public Integer maLoaiCha;
}
