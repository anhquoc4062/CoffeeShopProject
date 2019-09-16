package fpo.thanh.coffeeshop.storage.savePreference;

import android.content.Context;
import android.preference.PreferenceManager;


/**
 * Created by mrkaz on 7/19/2017.
 */

public class CacheClient {
    public static void setCache(Context ctx, String key, String data)
    {
        PreferenceManager.getDefaultSharedPreferences(ctx).edit().putString(key,data).commit();
    }
    public static String getCache(Context ctx, String key)
    {
        return PreferenceManager.getDefaultSharedPreferences(ctx).getString(key,"null");
    }
}
