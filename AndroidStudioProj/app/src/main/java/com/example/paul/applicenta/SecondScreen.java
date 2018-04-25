package com.example.paul.applicenta;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothServerSocket;
import android.bluetooth.BluetoothSocket;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.IntentFilter;
import android.graphics.Color;
import android.os.Bundle;
import android.os.Message;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.util.Log;
import android.content.Intent;
import android.widget.ListView;
import android.widget.Toast;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.UUID;


import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;

public class SecondScreen extends AppCompatActivity {

    UUID my_uuid = UUID.fromString("408cb20a-4740-11e8-842f-0ed5f89f718b");
    private static final String TAG = "SecondScreen";
    Button b_on, b_off, b_disc, b_list;
    ListView list;
    Intent b_EnablingIntent;

    SendReceive sendReceive;

    BluetoothAdapter bluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
    private static final int REQUEST_ENABLED = 1;
    private static final int REQUEST_DISCOVERABLE = 0;

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        if (requestCode == REQUEST_ENABLED) {

            if (resultCode == RESULT_OK) {
                Toast.makeText(getApplicationContext(), "Bluetooth is enabled", Toast.LENGTH_LONG).show();
            } else if (resultCode == RESULT_CANCELED) {
                Toast.makeText(getApplicationContext(), "BLuetooth Enabling Cancelled", Toast.LENGTH_LONG).show();
            }

        }
    }

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.connections_layout);

        Log.d(TAG, "onCreate:Starting.");
        Button btnNavToFirst = (Button) findViewById(R.id.btnBackToMain);

        btnNavToFirst.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Log.d(TAG, "onClick: clicked btnNavToFirst.");

                Intent intent = new Intent(SecondScreen.this, MainActivity.class);
                startActivity(intent);
            }
        });

        b_on = (Button) findViewById(R.id.btnON);
        b_off = (Button) findViewById(R.id.btnOFF);
        b_disc = (Button) findViewById(R.id.btnDiscoverable);
        b_list = (Button) findViewById(R.id.btnList);

        list = (ListView) findViewById(R.id.list);

        b_EnablingIntent = new Intent((BluetoothAdapter.ACTION_REQUEST_ENABLE));

        //bluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
        //check if bluettooth supported
        if (bluetoothAdapter == null) {
            Toast.makeText(this, "Bluetooth not supported", Toast.LENGTH_SHORT).show();
            finish();
        }


        b_on.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //turn on bluetooth
                Intent intent = new Intent((BluetoothAdapter.ACTION_REQUEST_ENABLE));
                startActivityForResult(intent, REQUEST_ENABLED);
            }
        });

        b_off.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //turns off bluetooth
                bluetoothAdapter.disable();
                Toast.makeText(getApplicationContext(), "Bluetooth is disabled", Toast.LENGTH_LONG).show();

            }
        });

       /* b_disc.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!bluetoothAdapter.isDiscovering()) {
                    //make the device discoverable
                    Intent intent = new Intent((BluetoothAdapter.ACTION_REQUEST_DISCOVERABLE));
                    intent.putExtra(BluetoothAdapter.EXTRA_DISCOVERABLE_DURATION, 300);
                    startActivityForResult(intent, REQUEST_DISCOVERABLE);
                    Toast.makeText(getApplicationContext(), "Bluetooth is discoverable", Toast.LENGTH_LONG).show();
                }
            }
        });*/

       b_disc.setOnClickListener(new View.OnClickListener() {
           @Override
           public void onClick(View v) {
                String string = String.valueOf("paul");
                sendReceive.write(string.getBytes());

           }
       });

        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
               // ClientClass clientClass = new ClientClass(stringArrayList);
               // clientClass.start();


            }
        });


        b_list.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //list paired devices
               /* Set<BluetoothDevice> pairedDevices =  bluetoothAdapter.getBondedDevices();
                bluetoothAdapter.startDiscovery();
                ArrayList<String> devices = new ArrayList<String>();

                for(BluetoothDevice bt : pairedDevices)
                {
                    devices.add(bt.getName());
                }
                ArrayAdapter arrayAdapter = new ArrayAdapter(SecondScreen.this,android.R.layout.simple_list_item_1,devices); ///sau getApplicationContext()
                list.setAdapter(arrayAdapter);
                Toast.makeText(getApplicationContext(),"List of DEVICES",Toast.LENGTH_LONG).show();
                */
                ArrayList<String> emptyArrList = new ArrayList<String>();
                ArrayAdapter<String> emptyArrayAd = new ArrayAdapter<String>(getApplicationContext(), android.R.layout.simple_list_item_1, emptyArrList);
                list.setAdapter(emptyArrayAd);
                stringArrayList.clear();
                bluetoothAdapter.startDiscovery();
                list.setAdapter(arrayAdapter);

            }
        });
        IntentFilter intentFilter = new IntentFilter(BluetoothDevice.ACTION_FOUND);

        registerReceiver(myReceiver, intentFilter);
        arrayAdapter = new ArrayAdapter<String>(getApplicationContext(), android.R.layout.simple_list_item_1, stringArrayList);
        list.setAdapter(arrayAdapter);
        list.setBackgroundColor(Color.parseColor("black")); //black

    }

    ArrayList<String> stringArrayList = new ArrayList<String>();
    ArrayAdapter<String> arrayAdapter;


    BroadcastReceiver myReceiver = new BroadcastReceiver() {
        @Override
        public void onReceive(Context context, Intent intent) {
            try {
                String action = intent.getAction();
                if (BluetoothDevice.ACTION_FOUND.equals(action)) {
                    BluetoothDevice device = intent.getParcelableExtra(BluetoothDevice.EXTRA_DEVICE);
                    stringArrayList.add(device.getName());
                    arrayAdapter.notifyDataSetChanged();
                }
            } catch (Exception ex) {
                Toast.makeText(getApplicationContext(), ex.getMessage(), Toast.LENGTH_LONG).show();
            }
        }
    };

    private class ServerClass extends Thread //SERVER
    {
        private BluetoothServerSocket serverSocket;

        public ServerClass() {
            try {
                serverSocket = bluetoothAdapter.listenUsingInsecureRfcommWithServiceRecord("Remote Control", my_uuid);
            } catch (IOException e) {
                e.printStackTrace();
            }
        }

        public void run() {
            BluetoothSocket socket = null;
            while (socket == null) {
                try {
                    Message message = Message.obtain();
                    message.what = 2; //STATE_CONNECTING

                    socket = serverSocket.accept();
                } catch (IOException e) {
                    e.printStackTrace();
                }

                if (socket != null) {
                    Message message = Message.obtain();
                    message.what = 3; //STATE_CONNECTED

                    //code for send/receive
                    sendReceive = new SendReceive(socket);
                    sendReceive.start();
                    break;
                }

            }
        }


    }

    private class ClientClass extends Thread {
        private BluetoothDevice device;
        private BluetoothSocket socket;

        public ClientClass(BluetoothDevice device1) {
            device = device1;
            try {
                socket = device.createRfcommSocketToServiceRecord(my_uuid);
            } catch (IOException e) {
                e.printStackTrace();
            }
        }

        public void run() {
            try {
                socket.connect();
                Message message = Message.obtain();
                message.what = 3; //CONNECTED
                //handler.sendMessage.....

                sendReceive = new SendReceive(socket);
                sendReceive.start();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }

    private class SendReceive extends Thread
    {
        private  final BluetoothSocket bluetoothSocket;
        private final InputStream inputStream;
        private final OutputStream outputStream;

        public SendReceive(BluetoothSocket socket)
        {
            bluetoothSocket = socket;
            InputStream tempIn = null;
            OutputStream tempOut = null;

            try {
                tempIn = bluetoothSocket.getInputStream();
            } catch (IOException e) {
                e.printStackTrace();
            }
            try {
                tempOut =bluetoothSocket.getOutputStream();
            } catch (IOException e) {
                e.printStackTrace();
            }

            inputStream = tempIn;
            outputStream = tempOut;
        }

        public void run() //for receiving - trebuie pe thread separat
        {
            byte [] buffer = new byte[1024];
            int bytes;

            while(true)
            {
                try {
                    bytes = inputStream.read(buffer); // buffer -mesajul   bytes = nr de bytes
                } catch (IOException e) {
                    e.printStackTrace();
                }

            }
        }

        public void write(byte[] bytes)
        {
            try {
                outputStream.write(bytes);
            } catch (IOException e) {
                e.printStackTrace();
            }

        }


    }


}


///408cb20a-4740-11e8-842f-0ed5f89f718b