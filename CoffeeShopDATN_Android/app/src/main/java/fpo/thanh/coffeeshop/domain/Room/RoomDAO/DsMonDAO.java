package fpo.thanh.coffeeshop.domain.Room.RoomDAO;

import androidx.room.Dao;
import androidx.room.Insert;
import androidx.room.Query;

import fpo.thanh.coffeeshop.domain.Room.RoomModel.DsMon;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.HoaDon;

import static androidx.room.OnConflictStrategy.REPLACE;

@Dao
public interface DsMonDAO {
    @Insert(onConflict = REPLACE)
    public void insertTang(DsMon dsmon);
    @Query("SELECT COUNT(*) FROM DsMon")
    public int getSizeDsMon();
    @Query("DELETE FROM DsMon")
    public void deleteAllDsMon();
}
