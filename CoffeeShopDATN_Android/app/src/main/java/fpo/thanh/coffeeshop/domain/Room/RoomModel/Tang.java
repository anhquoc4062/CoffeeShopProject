package fpo.thanh.coffeeshop.domain.Room.RoomModel;

import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.PrimaryKey;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

@Entity
public class Tang {
    @PrimaryKey(autoGenerate = false)
    public Integer maTang;
    @ColumnInfo(name = "tenTang")
    public String tenTang;

}
