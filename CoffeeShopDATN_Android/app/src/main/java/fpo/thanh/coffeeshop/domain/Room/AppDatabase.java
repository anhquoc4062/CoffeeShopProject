package fpo.thanh.coffeeshop.domain.Room;

import android.content.Context;

import androidx.room.Database;
import androidx.room.Room;
import androidx.room.RoomDatabase;

import fpo.thanh.coffeeshop.domain.Room.RoomDAO.BanAnDAO;
import fpo.thanh.coffeeshop.domain.Room.RoomDAO.DsMonDAO;
import fpo.thanh.coffeeshop.domain.Room.RoomDAO.HoaDonDAO;
import fpo.thanh.coffeeshop.domain.Room.RoomDAO.LoaiThucDonDAO;
import fpo.thanh.coffeeshop.domain.Room.RoomDAO.TangDAO;
import fpo.thanh.coffeeshop.domain.Room.RoomDAO.ThucDonDAO;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.BanAn;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.DsMon;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.HoaDon;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.LoaiThucDon;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.Tang;
import fpo.thanh.coffeeshop.domain.Room.RoomModel.ThucDon;

@Database(entities = {Tang.class, HoaDon.class, BanAn.class, DsMon.class, LoaiThucDon.class, ThucDon.class}, version = 2,exportSchema = false)
public abstract class AppDatabase extends RoomDatabase {
    private static AppDatabase INSTANCE=null;
    private static final String DB_NAME="TLECOFFEE";
    public abstract TangDAO tangDAO();
    public abstract HoaDonDAO hoaDonDAO();
    public abstract BanAnDAO banAnDAO();
    public abstract DsMonDAO dsMonDAO();
    public abstract LoaiThucDonDAO loaiThucDonDAO();
    public abstract ThucDonDAO thucDonDAO();
    public static AppDatabase getDatabase(Context context) {
        if (INSTANCE == null) {
           INSTANCE=Room
                   .databaseBuilder(context,AppDatabase.class,DB_NAME).allowMainThreadQueries().build();
        }
        return INSTANCE;
    }
    public static void destroyInstance() {
        INSTANCE = null;
    }
}