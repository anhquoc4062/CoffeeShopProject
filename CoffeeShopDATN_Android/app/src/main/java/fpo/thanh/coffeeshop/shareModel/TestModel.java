package fpo.thanh.coffeeshop.shareModel;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class TestModel {

    @SerializedName("exitcode")
    @Expose
    private Integer exitcode;
    @SerializedName("data")
    @Expose
    private DataTestModel data;
    @SerializedName("message")
    @Expose
    private Object message;

    public Integer getExitcode() {
        return exitcode;
    }

    public void setExitcode(Integer exitcode) {
        this.exitcode = exitcode;
    }

    public DataTestModel getData() {
        return data;
    }

    public void setData(DataTestModel data) {
        this.data = data;
    }

    public Object getMessage() {
        return message;
    }

    public void setMessage(Object message) {
        this.message = message;
    }
}
