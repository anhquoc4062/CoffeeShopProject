package fpo.thanh.coffeeshop.domain.Room.RoomDAO;

import androidx.room.Dao;
import androidx.room.Insert;
import androidx.room.Query;

import fpo.thanh.coffeeshop.domain.Room.RoomModel.Tang;

import static androidx.room.OnConflictStrategy.REPLACE;

@Dao
public interface TangDAO {
    @Insert(onConflict = REPLACE)
    public void insertTang(Tang tang);
    @Query("SELECT COUNT(*) FROM tang")
    public int getSizeTang();
    @Query("DELETE FROM Tang")
    public void deleteAllTang();
}
