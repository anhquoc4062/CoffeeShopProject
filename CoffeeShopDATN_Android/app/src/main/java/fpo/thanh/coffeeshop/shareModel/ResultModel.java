package fpo.thanh.coffeeshop.shareModel;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class ResultModel {
    @SerializedName("exit_code")
    @Expose
    private Integer exitCode;
    @SerializedName("data")
    @Expose
    private AllDataModel data;
    @SerializedName("message")
    @Expose
    private String message;

    public Integer getExitCode() {
        return exitCode;
    }

    public void setExitCode(Integer exitCode) {
        this.exitCode = exitCode;
    }

    public AllDataModel getData() {
        return data;
    }

    public void setData(AllDataModel data) {
        this.data = data;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }
}
