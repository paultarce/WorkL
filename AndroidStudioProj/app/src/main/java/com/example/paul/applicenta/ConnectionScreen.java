package com.example.paul.applicenta;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothServerSocket;
import android.bluetooth.BluetoothSocket;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.support.annotation.ArrayRes;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

import org.w3c.dom.Text;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.Set;
import java.util.UUID;

public class ConnectionScreen extends AppCompatActivity{


    private static final String TAG = "ConnectionScreen";
    Button b_on, b_off, b_disc, b_list;
    ListView list;
    Intent b_EnablingIntent;

    //SendReceive sendReceive;

    BluetoothAdapter bluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
    BluetoothDevice[] btArray;
    SendReceive sendReceive;

    private static final int REQUEST_ENABLED = 1;
    private static final int REQUEST_DISCOVERABLE = 0;


    Button listen,send,listDevices;
    ListView listView ;
    TextView status;
    EditText writemsg;

    static final int STATE_LISTENING = 1;
    static final int STATE_CONNECTING = 2;
    static final int STATE_CONNECTED = 3;
    static final int STATE_CONNCECTION_FAILED = 4;
    static final int STATE_MESSAGE_RECEIVED = 5;
    int REQUERST_ENABLE_BLUETOOTH = 1;

    private static final String APP_NAME = "RemoteControl";
    private UUID my_uuid = UUID.fromString("408cb20a-4740-11e8-842f-0ed5f89f718b");

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.connections_layout);

        Log.d(TAG, "onCreate:Starting.");
        Button btnNavToFirst = (Button) findViewById(R.id.btnBackToMain);

        findViewByIdes();

        btnNavToFirst.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Log.d(TAG, "onClick: clicked btnNavToFirst.");

                Intent intent = new Intent(ConnectionScreen.this, MainActivity.class);
                startActivity(intent);
            }
        });

        if(!bluetoothAdapter.isEnabled() == true)
        {
               Intent enableIntent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
               startActivityForResult(enableIntent,REQUERST_ENABLE_BLUETOOTH);
        }

        implementListeners();

    }


    Handler handler = new Handler(new Handler.Callback() {
        @Override
        public boolean handleMessage(Message msg) {
            switch (msg.what)
            {
                case STATE_LISTENING:
                    status.setText("Listening");
                    break;
                case STATE_CONNECTING:
                    status.setText("Connecting");
                    break;
                case STATE_CONNECTED:
                    status.setText("Connected");
                    break;
                case STATE_CONNCECTION_FAILED:
                    status.setText("Connection failed");
                    break;
                case STATE_MESSAGE_RECEIVED:
                    // to be
                    byte[] readBuff = (byte[]) msg.obj;
                    String tempMsg = new String(readBuff,0,msg.arg1);
                    String messReceived = tempMsg;  //aici primesc mesajul!!!!!!!!!!!!!!!!!!!!!!!!!!
                    break;
            }

            return true;
        }

    });



    private void findViewByIdes()
    {
        listen =(Button) findViewById(R.id.btnDiscoverable);
        send = (Button) findViewById(R.id.btnON);      /// cand apas asta ..sa trimit ceva prin bluetooth
        listView = (ListView) findViewById(R.id.list);
        status = (TextView) findViewById(R.id.status);
        listDevices = (Button) findViewById(R.id.btnList);
    }

    private void implementListeners()
    {
        listDevices.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                    Set<BluetoothDevice> bt = bluetoothAdapter.getBondedDevices();
                    String[] strings = new String[bt.size()];
                    int index = 0;
                    btArray = new BluetoothDevice[bt.size()];
                    if(bt.size() > 0)
                    {
                        for(BluetoothDevice device : bt)
                        {
                            btArray[index] = device;
                            strings[index] = device.getName(); // numele Dispozitivelor gpsite prin getBondedDevices
                            index ++ ;
                        }
                        ArrayAdapter<String> arrayAdapter = new ArrayAdapter<String>(getApplicationContext(),android.R.layout.simple_list_item_1,strings);
                        listView.setAdapter(arrayAdapter);
                    }
            }
        });

        listen.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                    ServerClass serverClass = new ServerClass();
                    serverClass.start();
            }
        });

        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int i, long id) {
                    ClientClass clientClass = new ClientClass(btArray[i]);
                    clientClass.start();
                    status.setText("Connecting");
            }
        });


        send.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String string = String.valueOf("Paul");
                sendReceive.write(string.getBytes());
            }
        });

    }

    private class ServerClass extends Thread //SERVER
    {
        private BluetoothServerSocket serverSocket;

        public ServerClass() {
            try {
                serverSocket = bluetoothAdapter.listenUsingInsecureRfcommWithServiceRecord(APP_NAME, my_uuid);
            } catch (IOException e) {
                e.printStackTrace();
            }
        }

        public void run() {
            BluetoothSocket socket = null;
            while (socket == null) {
                try {
                    Message message = Message.obtain();
                    message.what = STATE_CONNECTING;
                    handler.sendMessage(message);

                    socket = serverSocket.accept();

                } catch (IOException e) {
                    Message message = Message.obtain();
                    message.what = STATE_CONNCECTION_FAILED;
                    handler.sendMessage(message);
                    e.printStackTrace();
                }

                if (socket != null) {
                    Message message = Message.obtain();
                    message.what = STATE_CONNECTED; //STATE_CONNECTED
                    handler.sendMessage(message);
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
                message.what = STATE_CONNECTED;
                handler.sendMessage(message);
                //handler.sendMessage.....

                sendReceive = new SendReceive(socket);
                sendReceive.start();

            } catch (IOException e) {
                e.printStackTrace();
                Message message = Message.obtain();
                message.what = STATE_CONNCECTION_FAILED;
                handler.sendMessage(message);

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
                    handler.obtainMessage(STATE_MESSAGE_RECEIVED,bytes,-1,buffer).sendToTarget();

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
