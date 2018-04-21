package com.example.paul.applicenta;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.util.Log;
import android.content.Intent;
import android.widget.ListView;
import android.widget.Toast;



import java.util.ArrayList;
import java.util.List;
import java.util.Set;

public class SecondScreen extends AppCompatActivity {

    private  static final String TAG = "SecondScreen";
    Button b_on,b_off,b_disc,b_list;
    ListView list;

    BluetoothAdapter bluetoothAdapter;
    private static final int REQUEST_ENABLED = 0;
    private static final int REQUEST_DISCOVERABLE = 0;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.connections_layout);

        Log.d(TAG,"onCreate:Starting.");
        Button btnNavToFirst = (Button) findViewById(R.id.btnBackToMain);

        btnNavToFirst.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                    Log.d(TAG,"onClick: clicked btnNavToFirst.");

                    Intent intent = new Intent(SecondScreen.this,MainActivity.class);
                    startActivity(intent);
            }
        });

        b_on = (Button)findViewById(R.id.btnON);
        b_off = (Button)findViewById(R.id.btnOFF);
        b_disc = (Button)findViewById(R.id.btnDiscoverable);
        b_list = (Button)findViewById(R.id.btnList);

        list = (ListView) findViewById(R.id.list);

        bluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
        //check if bluettooth supportedn
        if(bluetoothAdapter == null)
        {
            Toast.makeText(this, "Bluetooth not supported", Toast.LENGTH_SHORT).show();
            finish();
        }

        b_on.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //turn on bluetooth
                Intent intent = new Intent((BluetoothAdapter.ACTION_REQUEST_ENABLE));
                startActivityForResult(intent,REQUEST_ENABLED);
            }
        });

        b_off.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //turns off bluetooth
                bluetoothAdapter.disable();

            }
        });

        b_disc.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(!bluetoothAdapter.isDiscovering())
                {
                    //make the device discoverable
                    Intent intent = new Intent((BluetoothAdapter.ACTION_REQUEST_DISCOVERABLE));
                    startActivityForResult(intent,REQUEST_DISCOVERABLE);
                }
            }
        });

        b_list.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //list paired devices
                Set<BluetoothDevice> pairedDevices =  bluetoothAdapter.getBondedDevices();

                ArrayList<String> devices = new ArrayList<String>();

                for(BluetoothDevice bt : pairedDevices)
                {
                    devices.add(bt.getName());
                }
                ArrayAdapter arrayAdapter = new ArrayAdapter(SecondScreen.this,android.R.layout.simple_list_item_1);

                list.setAdapter(arrayAdapter);
            }
        });
    }
}
