package fpo.thanh.coffeeshop.contanst;

public class API {
    public static final String serverName = "http://192.168.137.1:45455";

    static final String funcAccount =serverName+ "/account";
    //===============================
    public static final String signInAPI =funcAccount + "/oauth2";
    public static final String getAccountInfo =funcAccount + "/getById";
}
