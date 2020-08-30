package com.example.satya.quiz;

import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;


/**
 * Created by vrs on 3/9/15.
 */
public class CardAdapter extends RecyclerView.Adapter<CardAdapter.ViewHolder> {

    private Context mContext;
    List<User> list = new ArrayList<>();


    public CardAdapter(Context mContext, List<User> list) {
        this.mContext = mContext;
        this.list = list;
    }


    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View itemView = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.card_view, parent, false);
        return new ViewHolder(itemView);
    }

    @Override
    public void onBindViewHolder(ViewHolder holder, int position) {

        holder.User=getItem(position);
        holder.cardtitle.setText(list.get(position).name);
        holder.cardrank.setText(list.get(position).rank);
        holder.cardimage.setImageResource(list.get(position).id);
    }

    @Override
    public void onAttachedToRecyclerView(RecyclerView recyclerView) {
        super.onAttachedToRecyclerView(recyclerView);
    }

    @Override
    public int getItemCount() {
        return list.size();
    }

    public User getItem(int i) {
        return list.get(i);
    }





    public class ViewHolder extends RecyclerView.ViewHolder {

        ImageView cardimage;
        TextView cardtitle;
        TextView cardrank;
        User User;

        public ViewHolder(View itemView) {
            super(itemView);

            cardimage = (ImageView) itemView.findViewById(R.id.card_user_image);
            cardtitle = (TextView) itemView.findViewById(R.id.card_user_title);
            cardrank = (TextView) itemView.findViewById(R.id.card_user_rank);
        }
    }


}

