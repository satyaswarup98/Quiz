package com.example.satya.quiz;

import android.app.ActionBar;
import android.app.ProgressDialog;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.support.annotation.Nullable;
import android.support.annotation.RequiresApi;
import android.support.design.widget.AppBarLayout;
import android.support.design.widget.CollapsingToolbarLayout;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.Toolbar;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.View;
import android.view.ViewTreeObserver;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.ScrollView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;
import com.bumptech.glide.Glide;
import com.google.android.gms.auth.api.signin.GoogleSignIn;
import com.google.android.gms.auth.api.signin.GoogleSignInAccount;
import com.google.android.gms.auth.api.signin.GoogleSignInClient;
import com.google.android.gms.auth.api.signin.GoogleSignInOptions;
import com.google.android.gms.common.SignInButton;
import com.google.android.gms.common.api.ApiException;
import com.google.android.gms.tasks.Task;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

import de.hdodenhof.circleimageview.CircleImageView;

public class MainActivity extends AppCompatActivity implements View.OnClickListener {

    private static final String TAG = "MainActivity";
    private static final int RC_SIGN_IN = 9001;
    int question_no = 1;                             //count and display question no
    String answers[][] = new String[31][31];        //stores actual answer corresponds to user answer choice
    int chosenId[] = new int[31];                   //tracks the user answer inputs
    int selectedId = 0;                             //specify the button id selected by the user
    int section = 1;
    int bookmarkCheck[] = new int[31];
    int radio_button_1_status = 0;
    int radio_button_2_status = 0;
    int radio_button_3_status = 0;
    int radio_button_4_status = 0;
    ProgressDialog dialog;
    Button next;
    Button prev;
    CountDownTimer cTimer = null;
    Spinner spinner;

    //----------------------------------------------------
    CheckBox bookmark;
    int dialogStatus = 0;
    SharedPreferences profile_data;
    String personEmail;
    String personName;
    String personPhoto;
    GoogleSignInClient mGoogleSignInClient;
    EditText user;

    private SignInButton SignIn;
    private TextView Email;
    private TextView Name;
    private CircleImageView ProfPic;


    CardAdapter adapter;
    List<User> users;


    //        ------ CODES FOR TIMER DISPLAY -------

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        profile_data = getSharedPreferences("data", MODE_PRIVATE);

        Email = (TextView) findViewById(R.id.login_email);
        Name = (TextView) findViewById(R.id.welcome_name);
        SignIn = (SignInButton) findViewById(R.id.sign_in_button);
        ProfPic = (CircleImageView) findViewById(R.id.login_profile_image);


        SignIn.setOnClickListener(this);

        // Configure sign-in to request the user's ID, email address, and basic
        // profile. ID and basic profile are included in DEFAULT_SIGN_IN.
        GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DEFAULT_SIGN_IN)
                .requestEmail()
                .build();


// Build a GoogleSignInClient with the options specified by gso.
        mGoogleSignInClient = GoogleSignIn.getClient(this, gso);

        SignInButton signInButton = findViewById(R.id.sign_in_button);
        TextView textView = (TextView) signInButton.getChildAt(0);
        textView.setText("Sign In with Google          ");

        final EditText user_name = (EditText) findViewById(R.id.login_user_name);

        user_name.addTextChangedListener(new TextWatcher() {

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {


            }

            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {
            }

            @Override
            public void afterTextChanged(Editable s) {
                if (user_name.getText().toString().length() <= 0) {
                    user_name.setError("Enter Username");
                } else {
                    user_name.setError(null);
                }

                if (user_name.getText().toString().length() >= 15) {
                    Toast.makeText(MainActivity.this, "Max 15 Character Allowed", Toast.LENGTH_SHORT).show();
                }
            }
        });


    }


    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.sign_in_button:
                signIn();
                break;

        }
    }

    @Override
    public void onStart() {
        super.onStart();


        // [START on_start_sign_in]
        // Check for existing Google Sign In account, if the user is already signed in
        // the GoogleSignInAccount will be non-null.
        GoogleSignInAccount account = GoogleSignIn.getLastSignedInAccount(this);
//        Name.setText(profile_data.getString("name", ""));
//        Email.setText(profile_data.getString("mail", ""));
//        Glide.with(this).load(profile_data.getString("image", "")).into(ProfPic);
//
//        updateUI(account);
        if (account != null) {

            start();
        }
        // [END on_start_sign_in]
    }


    private void signIn() {
        Intent signInIntent = mGoogleSignInClient.getSignInIntent();
        startActivityForResult(signInIntent, RC_SIGN_IN);
    }


    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        // Result returned from launching the Intent from GoogleSignInClient.getSignInIntent(...);
        if (requestCode == RC_SIGN_IN) {
            // The Task returned from this call is always completed, no need to attach
            // a listener.
            Task<GoogleSignInAccount> task = GoogleSignIn.getSignedInAccountFromIntent(data);
            handleSignInResult(task);
        }
    }


    private void handleSignInResult(Task<GoogleSignInAccount> completedTask) {
        try {
            GoogleSignInAccount account = completedTask.getResult(ApiException.class);
            if (account != null) {
                personEmail = account.getEmail();
                personName = "Welcome " + ((account.getDisplayName()).substring(0, (account.getDisplayName()).indexOf(' '))).toUpperCase();
                if (account.getPhotoUrl() != null)
                    personPhoto = account.getPhotoUrl().toString();
                else
                    personPhoto = (Uri.parse("android.resource://com.example.satya.quiz/drawable/user")).toString();

                SharedPreferences.Editor editor = profile_data.edit();
                editor.putString("name", personName);
                editor.putString("mail", personEmail);
                editor.putString("image", personPhoto);

                editor.putString("username", "");//setting username null

                editor.apply();
                Name.setText(profile_data.getString("name", ""));
                Email.setText(profile_data.getString("mail", ""));
                Glide.with(this).load(profile_data.getString("image", "")).into(ProfPic);

                registerUser();
                updateUI(account);

            }

            // Signed in successfully, show authenticated UI.
            //  updateUI(account);
        } catch (ApiException e) {
            // The ApiException status code indicates the detailed failure reason.
            Log.w(TAG, "signInResult:failed code=" + e.getStatusCode());
            updateUI(null);
        }
    }


    private void updateUI(@Nullable GoogleSignInAccount account) {
        if (account != null) {
            findViewById(R.id.sign_in_button).setVisibility(View.GONE);
            findViewById(R.id.login_user_name).setVisibility(View.VISIBLE);
        } else {
            personPhoto = (Uri.parse("android.resource://com.example.satya.quiz/drawable/quiz")).toString();
            personEmail = "Boost Your Knowledge";
            personName = "Welcome to Quiz";
            SharedPreferences.Editor editor = profile_data.edit();
            editor.putString("name", personName);
            editor.putString("mail", personEmail);
            editor.putString("image", personPhoto);
            editor.apply();

            findViewById(R.id.sign_in_button).setVisibility(View.VISIBLE);
            findViewById(R.id.login_user_name).setVisibility(View.GONE);
        }
    }

    public void setUsername(View v) {
        user = (EditText) findViewById(R.id.login_user_name);
        SharedPreferences.Editor editor = profile_data.edit();
        editor.putString("username", user.getText().toString());
        editor.apply();
        registerUser();
    }

    public void abc(View v) {
        setContentView(R.layout.activity_profile);
        CircleImageView profile_image = (CircleImageView) findViewById(R.id.profile_image_ps);
        TextView user_name = (TextView) findViewById(R.id.user_name_ps);
        TextView user_email = (TextView) findViewById(R.id.user_email_ps);

        user_name.setText(profile_data.getString("username", ""));
        user_email.setText(profile_data.getString("mail", ""));
        Glide.with(this).load(profile_data.getString("image", "")).into(profile_image);

        final CollapsingToolbarLayout collapsingToolbarLayout = (CollapsingToolbarLayout) findViewById(R.id.collapsing_toolbar);
        final TextView header_view_title = (TextView) findViewById(R.id.header_view_title);
        AppBarLayout appBarLayout = (AppBarLayout) findViewById(R.id.app_bar_layout);
        appBarLayout.addOnOffsetChangedListener(new AppBarLayout.OnOffsetChangedListener() {
            boolean isShow = true;
            int scrollRange = -1;

            @Override
            public void onOffsetChanged(AppBarLayout appBarLayout, int verticalOffset) {
                if (scrollRange == -1) {
                    scrollRange = appBarLayout.getTotalScrollRange();
                }
                if (scrollRange + verticalOffset == 0) {
                    header_view_title.setText(profile_data.getString("username", ""));
                    header_view_title.setVisibility(View.VISIBLE);
                    isShow = true;
                } else if(isShow) {
                    header_view_title.setVisibility(View.INVISIBLE);
                    isShow = false;
                }
            }
        });



        RecyclerView recyclerView=(RecyclerView)findViewById(R.id.recyclerView);


        //recyclerview
        LinearLayoutManager llm = new LinearLayoutManager(this);
        llm.setOrientation(LinearLayoutManager.VERTICAL);
        recyclerView.setLayoutManager(llm);
        recyclerView.setHasFixedSize(true);
        initializeData();
        adapter = new CardAdapter(getApplicationContext(), users);
        recyclerView.setAdapter(adapter);




    }

    private void initializeData() {
        users = new ArrayList<>();
        users.add(new User("satyaswarup98","Rank - 1", R.drawable.user));
        users.add(new User("User 2","Rank - 2", R.drawable.user));
        users.add(new User("User 3","Rank - 3", R.drawable.user));
        users.add(new User("User 4","Rank - 4", R.drawable.user));
        users.add(new User("User 5","Rank - 5", R.drawable.user));
        users.add(new User("User 6","Rank - 6", R.drawable.user));
        users.add(new User("User 7","Rank - 7", R.drawable.user));
        users.add(new User("User 8","Rank - 8", R.drawable.user));
        users.add(new User("User 9","Rank - 9", R.drawable.user));
        users.add(new User("User 10","Rank - 10", R.drawable.user));

    }

    public void setBack(View v) {
        start();
    }



    public void start() {


        setContentView(R.layout.activity_main);
//        // final TextView question_attend = (TextView) findViewById(R.id.question_attend);

        CircleImageView profile_image = (CircleImageView) findViewById(R.id.profile_image);
        TextView user_name = (TextView) findViewById(R.id.user_name);
        TextView user_email = (TextView) findViewById(R.id.user_email);

        user_name.setText(profile_data.getString("username", ""));
        user_email.setText(profile_data.getString("mail", ""));
        Glide.with(this).load(profile_data.getString("image", "")).into(profile_image);

        final RadioGroup radioGroup = (RadioGroup) findViewById(R.id.radio_group);

        spinner = (Spinner) findViewById(R.id.spinner);                                                                                        // Create an ArrayAdapter using the string array and a default spinner layout
        ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(this, R.array.question_section, R.layout.spinner_item);          // Specify the layout to use when the list of choices appears
        adapter.setDropDownViewResource(R.layout.spinner_item);                                                                                    // Apply the adapter to the spinner
        spinner.setAdapter(adapter);
        spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                section = Character.getNumericValue((parent.getItemAtPosition(position).toString()).charAt(8));
                // Toast.makeText(MainActivity.this,section+"",Toast.LENGTH_SHORT).show();
                int aid = R.id.bt1;
                for (int i = 1; i <= 10; i++) {
                    ((Button) findViewById(aid + (i - 1))).setBackgroundDrawable(ContextCompat.getDrawable(MainActivity.this, R.drawable.button_style));
                    ((Button) findViewById(aid + (i - 1))).setTextColor(Color.parseColor("#540091"));

                    if (answers[1][(i + ((section - 1) * 10)) - 1] != null)
                        buttonColorChange(i);
                }

                resetRadioStatus();
                questionChangeDisplay();

                if (chosenId[(question_no + ((section - 1) * 10))] < 1) {
                    if ((question_no + ((section - 1) * 10)) != 30 || chosenId[(question_no + ((section - 1) * 10)) - 1] < 1) {
                        final RadioButton none_checkbox = (RadioButton) findViewById(R.id.none);
                        none_checkbox.setChecked(true);
                    }
                }

            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {
                section = 1;
                questionChangeDisplay();
            }
        });


        startTimer();

        radioGroup.setOnCheckedChangeListener(new RadioGroup.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(RadioGroup group, int checkedId) {

                selectedId = radioGroup.getCheckedRadioButtonId();
                if (!((RadioButton) findViewById(selectedId)).getText().toString().equals("")) {

                    if (((RadioButton) findViewById(selectedId)).getText().toString().equals("##"))
                        answers[1][(question_no + ((section - 1) * 10)) - 1] = "##";

                    else
                        answers[1][(question_no + ((section - 1) * 10)) - 1] = ((RadioButton) findViewById(selectedId)).getText().toString();
                    chosenId[(question_no + ((section - 1) * 10)) - 1] = selectedId;

                }
                buttonColorChange(question_no);

//              CODES FOR QUESTION ANSWERED DISPLAY
//                int questionAnswered =0;
//                for(int i=0;i<26;i++)
//                {
//                    if (chosenId[i]>0 && chosenId[i]!=R.id.none) {
//                        questionAnswered += 1;
//                    }
//                }
//               question_attend.setText(questionAnswered + "/24");

            }
        });

        bookmark = (CheckBox) findViewById((R.id.bookmark_ckeckbox));

        bookmark.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if (bookmark.isChecked() == true)
                    bookmarkCheck[(question_no + ((section - 1) * 10)) - 1] = 1;
                else
                    bookmarkCheck[(question_no + ((section - 1) * 10)) - 1] = 0;

                buttonColorChange(question_no);
            }
        });

    }


    void startTimer() {
        final TextView clock_textview = (TextView) findViewById(R.id.clock_textbox);
        cTimer = new CountDownTimer(1800000, 1000) {

            public void onTick(long millisUntilFinished) {
                long min = (millisUntilFinished / 1000) / 60;
                long sec = (millisUntilFinished / 1000) % 60;

                if (min > 9 && sec > 9)
                    clock_textview.setText(min + ":" + sec);
                if (min > 9 && sec < 10)
                    clock_textview.setText(min + ":0" + sec);
                if (min < 9 && sec > 9)
                    clock_textview.setText("0" + min + ":" + sec);
                if (min < 9 && sec < 9)
                    clock_textview.setText("0" + min + ":0" + sec);
            }

            public void onFinish() {
                clock_textview.setText("00:00");
            }
        }.start();

    }

    void cancelTimer() {
        if (cTimer != null)
            cTimer.cancel();
    }

    //        ------ CODES FOR BUTTON COLOR CHANGE -------
    public void buttonColorChange(int q_no) {
        // CheckBox bookmark = (CheckBox) findViewById((R.id.bookmark_ckeckbox));
        int aid = R.id.bt1;
        if (bookmarkCheck[(q_no + ((section - 1) * 10)) - 1] == 1) {
            if (answers[1][(q_no + ((section - 1) * 10)) - 1] == "##") {
                ((Button) findViewById(aid + (q_no - 1))).setBackgroundDrawable(ContextCompat.getDrawable(this, R.drawable.button_style10));
                ((Button) findViewById(aid + (q_no - 1))).setTextColor(Color.parseColor("#ffffff"));
            } else {
                ((Button) findViewById(aid + (q_no - 1))).setBackgroundDrawable(ContextCompat.getDrawable(this, R.drawable.button_style11));
                ((Button) findViewById(aid + (q_no - 1))).setTextColor(Color.parseColor("#ffffff"));
            }
        } else {
            if (answers[1][(q_no + ((section - 1) * 10)) - 1] == "##") {
                ((Button) findViewById(aid + (q_no - 1))).setBackgroundDrawable(ContextCompat.getDrawable(this, R.drawable.button_style00));
                ((Button) findViewById(aid + (q_no - 1))).setTextColor(Color.parseColor("#ffffff"));
            } else {
                ((Button) findViewById(aid + (q_no - 1))).setBackgroundDrawable(ContextCompat.getDrawable(this, R.drawable.button_style01));
                ((Button) findViewById(aid + (q_no - 1))).setTextColor(Color.parseColor("#ffffff"));
            }

        }
        if (bookmarkCheck[(question_no + ((section - 1) * 10)) - 1] != 1) {
            bookmark.setChecked(false);
        }
    }

    //        ------ CODES FOR INCREMENT QUESTION AND DISPLAY -------

    public void incrementQuestion(View v) {

        next = (Button) findViewById(R.id.next_question);
        next.setEnabled(false);

        resetRadioStatus();

        final RadioButton none_checkbox = (RadioButton) findViewById(R.id.none);
        // Toast.makeText(this, answers[0][(question_no+((section-1)*10)) - 1] + "  :  " + answers[1][(question_no+((section-1)*10)) - 1], Toast.LENGTH_SHORT).show();

        buttonColorChange(question_no);

        int score = 0;
        if ((question_no + ((section - 1) * 10)) < 30) {
            if (question_no == 10) {
                spinner.setSelection(section);
            }
            question_no += 1;
            questionChangeDisplay();

            if (chosenId[(question_no + ((section - 1) * 10))] < 1) {
                if ((question_no + ((section - 1) * 10)) != 30 || chosenId[(question_no + ((section - 1) * 10)) - 1] < 1) {

                    none_checkbox.setChecked(true);
                }
            }

        } else {
            Button bt = (Button) findViewById(v.getId());
            bt.setText("SUBMIT");
            bt.setEnabled(true);

            for (int i = 0; i < 30; i++) {

                try {
                    if (answers[0][i].equals(answers[1][i])) {
                        score++;
                    }
                } catch (Exception e) {
                    //e.printStackTrace();
                }
            }

            Toast.makeText(this, "This is Last Question !!  " + score, Toast.LENGTH_SHORT).show();

        }

    }

    //        ------ CODES FOR DECREMENT QUESTION AND DISPLAY -------

    public void decrementQuestion(View v) {

        prev = (Button) findViewById(R.id.prev_question);
        next.setEnabled(false);

        resetRadioStatus();

        buttonColorChange(question_no);

        if ((question_no + ((section - 1) * 10)) > 1) {
            if (question_no == 1) {
                spinner.setSelection(section - 2);
                question_no = 11;
            }
            question_no -= 1;
            questionChangeDisplay();

            if (chosenId[(question_no + ((section - 1) * 10))] < 1) {
                if ((question_no + ((section - 1) * 10)) != 30 || chosenId[(question_no + ((section - 1) * 10)) - 1] < 1) {
                    final RadioButton none_checkbox = (RadioButton) findViewById(R.id.none);
                    none_checkbox.setChecked(true);
                }
            }
        } else
            Toast.makeText(this, "This is First Question !!", Toast.LENGTH_SHORT).show();

    }

    //        ------ CODES FOR GOTO A SPECIFIC QUESTION AND DISPLAY -------

    public void gotoQuestion(View v) {
        resetRadioStatus();
        buttonColorChange(question_no);

        Button bt = (Button) findViewById(v.getId());
        question_no = Integer.parseInt(bt.getText().toString());

        questionChangeDisplay();
        if (chosenId[(question_no + ((section - 1) * 10))] < 1) {
            if ((question_no + ((section - 1) * 10)) != 30 || chosenId[(question_no + ((section - 1) * 10)) - 1] < 1) {
                final RadioButton none_checkbox = (RadioButton) findViewById(R.id.none);
                none_checkbox.setChecked(true);
            }
        }

    }


//    public void questionAnswered(View v) {
//        for (int i = 0; i < 10; i++) {
//            if(answers[0][i].equals(answers[1][i])
//            if (answers[0][i].equals(answers[1][i])) {
//                score++;
//            }
//        }
//    }


    //        ------ CODES FOR CLEAR RADIO BUTTON AND DISPLAY -------

    public void radioClean1(View v) {
        RadioButton radio_button_1 = (RadioButton) findViewById(R.id.answer_1);
        RadioButton radio_button_5 = (RadioButton) findViewById(R.id.none);

        if (radio_button_1.isChecked() == true)
            radio_button_1_status = (radio_button_1_status + 1) % 2;

        radio_button_2_status = 0;
        radio_button_3_status = 0;
        radio_button_4_status = 0;

        if (radio_button_1_status == 0)
            radio_button_5.setChecked(true);

    }


    public void radioClean2(View v) {
        RadioButton radio_button_2 = (RadioButton) findViewById(R.id.answer_2);
        RadioButton radio_button_5 = (RadioButton) findViewById(R.id.none);

        if (radio_button_2.isChecked() == true)
            radio_button_2_status = (radio_button_2_status + 1) % 2;

        radio_button_1_status = 0;
        radio_button_3_status = 0;
        radio_button_4_status = 0;

        if (radio_button_2_status == 0)
            radio_button_5.setChecked(true);
    }


    public void radioClean3(View v) {
        RadioButton radio_button_3 = (RadioButton) findViewById(R.id.answer_3);
        RadioButton radio_button_5 = (RadioButton) findViewById(R.id.none);

        if (radio_button_3.isChecked() == true)
            radio_button_3_status = (radio_button_3_status + 1) % 2;

        radio_button_1_status = 0;
        radio_button_2_status = 0;
        radio_button_4_status = 0;

        if (radio_button_3_status == 0)
            radio_button_5.setChecked(true);
    }


    public void radioClean4(View v) {
        RadioButton radio_button_4 = (RadioButton) findViewById(R.id.answer_4);
        RadioButton radio_button_5 = (RadioButton) findViewById(R.id.none);

        if (radio_button_4.isChecked() == true)
            radio_button_4_status = (radio_button_4_status + 1) % 2;

        radio_button_1_status = 0;
        radio_button_2_status = 0;
        radio_button_3_status = 0;

        if (radio_button_4_status == 0)
            radio_button_5.setChecked(true);
    }

    public void resetRadioStatus() {
        radio_button_1_status = 0;
        radio_button_2_status = 0;
        radio_button_3_status = 0;
        radio_button_4_status = 0;
    }

    //        ------ IMPORTANT FUNCTION RETRIVE AND DISPLAY QUESTION AND OTHER WORKS-------

    public void questionChangeDisplay() {

        if (question_no > 20) {
            question_no %= 20;
        }
        if (question_no > 10) {
            question_no %= 10;
        }
        next = (Button) findViewById(R.id.next_question);
        prev = (Button) findViewById(R.id.prev_question);

        if ((question_no + ((section - 1) * 10)) < 30) {
            next.setText("NEXT");
        } else {
            next.setText("SUBMIT");
            next.setEnabled(true);
        }

        if (dialogStatus == 0) {
            dialog = ProgressDialog.show(this, "", "Loading. Please wait...", true);
            dialogStatus = 1;
        }

        final RadioGroup r1 = (RadioGroup) findViewById(R.id.radio_group);
        final TextView question_no_textview = (TextView) findViewById(R.id.question_no_textview);
        final RadioButton answer_1_checkbox = (RadioButton) findViewById(R.id.answer_1);
        final RadioButton answer_2_checkbox = (RadioButton) findViewById(R.id.answer_2);
        final RadioButton answer_3_checkbox = (RadioButton) findViewById(R.id.answer_3);
        final RadioButton answer_4_checkbox = (RadioButton) findViewById(R.id.answer_4);
        final TextView question = (TextView) findViewById(R.id.question_textview);


        Response.Listener<String> responseListener = new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {           // Response received from the server
                try {
                    JSONObject jsonResponse = new JSONObject(response);
                    boolean success = jsonResponse.getBoolean("success");

                    if (success) {
                        Log.v("MainActivity.this", "2");
                        question_no_textview.setText("Question " + (question_no + ((section - 1) * 10)));
                        question.setText(jsonResponse.getString("questions"));
                        answer_1_checkbox.setText(jsonResponse.getString("answer_1"));
                        answer_2_checkbox.setText(jsonResponse.getString("answer_2"));
                        answer_3_checkbox.setText(jsonResponse.getString("answer_3"));
                        answer_4_checkbox.setText(jsonResponse.getString("answer_4"));

                        if (dialogStatus == 1) {
                            dialog.dismiss();
                            dialogStatus = 0;
                        }

                        if (chosenId[(question_no + ((section - 1) * 10)) - 1] > 0) {        //SET RADIO BUTTON TO USER CHOICE
                            r1.check(chosenId[(question_no + ((section - 1) * 10)) - 1]);
                        } else {                                                       //ELSE SET IT TO NONE
                            chosenId[(question_no + ((section - 1) * 10)) - 1] = R.id.none;
                            answers[1][(question_no + ((section - 1) * 10)) - 1] = "##";
                        }

                        //inputting correct answer to the string
                        answers[0][(question_no + ((section - 1) * 10)) - 1] = (jsonResponse.getString("correct_answer"));

                        // if(next.isEnabled())
                        next.setEnabled(true);
                        // if(prev.isEnabled())
                        next.setEnabled(true);

                    } else {
                        // question_no_textview.setText("Question ");
                        question.setText("failed");

                    }

                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }
        };
        //question_no_textview.setText(question_no+"Qu"+section);
        LoginRequest loginRequest = new LoginRequest(question_no, section, responseListener);
        RequestQueue queue = Volley.newRequestQueue(MainActivity.this);
        queue.add(loginRequest);

    }


    public void registerUser() {


        if (dialogStatus == 0) {
            dialog = ProgressDialog.show(this, "", "Loading. Please wait...", true);
            dialogStatus = 1;
        }


        Response.Listener<String> responseListener = new Response.Listener<String>() {

            @Override
            public void onResponse(String response) {
                try {
                    JSONObject jsonResponse = new JSONObject(response);
                    boolean success = jsonResponse.getBoolean("success");
                    if (success) {
                        // setContentView(R.layout.activity_main);
                        dialog.dismiss();
                        dialogStatus = 0;

                        SharedPreferences.Editor editor = profile_data.edit();
                        editor.putString("username", jsonResponse.getString("username"));
                        editor.apply();

                        start();

                    } else {
                        dialog.dismiss();
                        dialogStatus = 0;
                    }

                } catch (JSONException e) {
                    e.printStackTrace();

                }
            }
        };
        Log.v("MainActivity.this", profile_data.getString("username", ""));
        RegisterRequest registerRequest = new RegisterRequest(profile_data.getString("mail", ""), profile_data.getString("username", ""), profile_data.getString("image", ""), responseListener);
        RequestQueue queue = Volley.newRequestQueue(MainActivity.this);
        queue.add(registerRequest);
    }
}
