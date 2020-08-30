package com.example.satya.quiz;


import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

public class LoginRequest extends StringRequest {
    private static final String LOGIN_REQUEST_URL = "https://ravenshawonline.000webhostapp.com/Login.php";
    private Map<String, String> params;

    public LoginRequest(int q_no, int q_section, Response.Listener<String> listener) {
        super(Method.POST, LOGIN_REQUEST_URL, listener, null);
        params = new HashMap<>();
        params.put("q_no", "" + q_no);
        params.put("q_section", "" + q_section);
        //  params.put("password", password);
    }

    @Override
    public Map<String, String> getParams() {
        return params;
    }
}
