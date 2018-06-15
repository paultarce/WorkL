package com.example.paul.remotecontrol;

import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.Intent;
import android.os.Build;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import java.io.IOException;
import java.io.OutputStream;
import java.lang.reflect.Method;
import java.util.UUID;

public class MainActivity extends Activity {
    private static final String TAG = "bluetooth1";

    Button btnOn, btnOff,btnZoomIn,btnZoomOut,btnEsc,btnRotateLeft,btnRotateRight,btnMoveUp,btnMoveDown,btnMoveRight,btnMoveLeft;
    Button btnPrevious,btnNext,btnDelete,btnFullScreen,btnSave,btnCapture;
    EditText txtGrades;

    private BluetoothAdapter btAdapter = null;
    private BluetoothSocket btSocket = null;
    private OutputStream outStream = null;

    // SPP UUID service
    private static final UUID MY_UUID = UUID.fromString("00001101-0000-1000-8000-00805F9B34FB");

    // MAC-address of Bluetooth module (you must edit this line)
    private static String address = "00:21:13:04:1F:F7"; // taken from mobile when trying to connect with module

    private void findButtonsByID()
    {
        btnOn = (Button) findViewById(R.id.btnZoomIn);
        btnOff = (Button) findViewById(R.id.btnZoomOut);
        btnCapture = (Button) findViewById(R.id.btnCapture2);
        btnDelete = (Button) findViewById(R.id.btnDelete);
        btnFullScreen = (Button) findViewById(R.id.btnFullScreen);
        btnSave = (Button) findViewById(R.id.btnSave);
        btnMoveDown = (Button) findViewById(R.id.btnMoveDown);
        btnMoveUp = (Button) findViewById(R.id.btnMoveUp);
        btnMoveRight = (Button) findViewById(R.id.btnMoveRight);
        btnMoveLeft = (Button) findViewById(R.id.btnMoveLeft);
        btnRotateLeft = (Button) findViewById(R.id.btnRotateLeft);
        btnRotateRight = (Button) findViewById(R.id.btnRotateRight);
        btnNext = (Button) findViewById(R.id.btnNext);
        btnPrevious = (Button) findViewById(R.id.btnPrevious);
        btnEsc = (Button) findViewById(R.id.btnEsc);
        txtGrades = (EditText) findViewById(R.id.txtGrades);

    }

    private void ClickListeners()
    {
        btnOn.setOnClickListener(new OnClickListener() {
            public void onClick(View v) {
                sendData("zoomin\n");
                Toast.makeText(getBaseContext(), "Zoom In", Toast.LENGTH_SHORT).show(); // SHORT -> it is the duration
            }
        });

        btnOff.setOnClickListener(new OnClickListener() {
            public void onClick(View v) {
                sendData("zoomout\n");
                Toast.makeText(getBaseContext(), "Zoom Out", Toast.LENGTH_SHORT).show();
            }
        });

        btnCapture.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                    sendData("capture\n");
                    Toast.makeText(getBaseContext(),"Capture",Toast.LENGTH_SHORT).show();
            }
        });
        btnSave.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                sendData("save\n");
                Toast.makeText(getBaseContext(),"Save",Toast.LENGTH_SHORT).show();
            }
        });
        btnFullScreen.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                sendData("fullscreen\n");
                Toast.makeText(getBaseContext(),"Full Screen",Toast.LENGTH_SHORT).show();
            }
        });
        btnDelete.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                sendData("delete\n");
                Toast.makeText(getBaseContext(),"Delete",Toast.LENGTH_SHORT).show();
            }
        });
        btnMoveRight.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                sendData("moveright\n");
                Toast.makeText(getBaseContext(),"Move Right",Toast.LENGTH_SHORT).show();
            }
        });
        btnMoveLeft.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                sendData("moveleft\n");
                Toast.makeText(getBaseContext(),"Move Left",Toast.LENGTH_SHORT).show();
            }
        });
        btnMoveUp.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                sendData("moveup\n");
                Toast.makeText(getBaseContext(),"Move Up",Toast.LENGTH_SHORT).show();
            }
        });
        btnMoveDown.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                sendData("movedown\n");
                Toast.makeText(getBaseContext(),"Move Down",Toast.LENGTH_SHORT).show();
            }
        });

        btnRotateRight.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                int gr = Integer.parseInt(txtGrades.getText().toString());
                if(gr <= 360) {
                    sendData("rotateright/" + txtGrades.getText().toString() + "|\n");
                    Toast.makeText(getBaseContext(), "Rotate Right", Toast.LENGTH_SHORT).show();
                }
                else
                {
                    Toast.makeText(getBaseContext(),"Angle should be MAXIMUM 360!",Toast.LENGTH_SHORT).show();
                }
            }
        });
        btnRotateLeft.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                int gr = Integer.parseInt(txtGrades.getText().toString());
                if(gr <= 360) {
                    sendData("rotateleft/" + txtGrades.getText().toString() + "|\n");
                    Toast.makeText(getBaseContext(), "Rotate Left", Toast.LENGTH_SHORT).show();
                }
                else {
                    Toast.makeText(getBaseContext(),"Angle should be MAXIMUM 360!",Toast.LENGTH_SHORT).show();
                }
            }
        });
        btnNext.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                sendData("next\n");
                Toast.makeText(getBaseContext(),"Next",Toast.LENGTH_SHORT).show();
            }
        });
        btnPrevious.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                sendData("previous\n");
                Toast.makeText(getBaseContext(),"Previous",Toast.LENGTH_SHORT).show();
            }
        });
        btnEsc.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                sendData("esc\n");
                Toast.makeText(getBaseContext(),"Escape",Toast.LENGTH_SHORT).show();
            }
        });



    }
    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_main);

         findButtonsByID();

        btAdapter = BluetoothAdapter.getDefaultAdapter();
        checkBTState();

        ClickListeners();

    }

    private BluetoothSocket createBluetoothSocket(BluetoothDevice device) throws IOException {
        if(Build.VERSION.SDK_INT >= 10){
            try {
                final Method  m = device.getClass().getMethod("createInsecureRfcommSocketToServiceRecord", new Class[] { UUID.class });
                return (BluetoothSocket) m.invoke(device, MY_UUID);
            } catch (Exception e) {
                Log.e(TAG, "Could not create Insecure RFComm Connection",e);
            }
        }
        return  device.createRfcommSocketToServiceRecord(MY_UUID);
    }

    @Override
    public void onResume() {
        super.onResume();

        Log.d(TAG, "...onResume - try connect...");

        // Set up a pointer to the remote node using it's address.
        BluetoothDevice device = btAdapter.getRemoteDevice(address);

        // Two things are needed to make a connection:
        //   A MAC address, which we got above.
        //   A Service ID or UUID.  In this case we are using the
        //     UUID for SPP.

        try {
            btSocket = createBluetoothSocket(device);
        } catch (IOException e1) {
            errorExit("Fatal Error", "In onResume() and socket create failed: " + e1.getMessage() + ".");
        }

        // Discovery is resource intensive.  Make sure it isn't going on
        // when you attempt to connect and pass your message.
        btAdapter.cancelDiscovery();

        // Establish the connection.  This will block until it connects.
        Log.d(TAG, "...Connecting...");
        try {
            btSocket.connect();
            Log.d(TAG, "...Connection ok...");
        } catch (IOException e) {
            try {
                btSocket.close();
            } catch (IOException e2) {
                errorExit("Fatal Error", "In onResume() and unable to close socket during connection failure" + e2.getMessage() + ".");
            }
        }

        // Create a data stream so we can talk to server.
        Log.d(TAG, "...Create Socket...");

        try {
            outStream = btSocket.getOutputStream();
        } catch (IOException e) {
            errorExit("Fatal Error", "In onResume() and output stream creation failed:" + e.getMessage() + ".");
        }
    }

    @Override
    public void onPause() {
        super.onPause();

        Log.d(TAG, "...In onPause()...");

        if (outStream != null) {
            try {
                outStream.flush();
            } catch (IOException e) {
                //errorExit("Fatal Error", "In onPause() and failed to flush output stream: " + e.getMessage() + ".");
                errorExit("FlushError!","Activate Bluetooth,Connect to Arduino Bluetooth and restart this application");
            }
        }

        try     {
            btSocket.close();
        } catch (IOException e2) {
            errorExit("Fatal Error", "In onPause() and failed to close socket." + e2.getMessage() + ".");
        }
    }

    private void checkBTState() {
        // Check for Bluetooth support and then check to make sure it is turned on
        // Emulator doesn't support Bluetooth and will return null
        if(btAdapter==null) {
            errorExit("Fatal Error", "Bluetooth not support");
        } else {
            if (btAdapter.isEnabled()) {
                Log.d(TAG, "...Bluetooth ON...");
            } else {
                //Prompt user to turn on Bluetooth
                Intent enableBtIntent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
                startActivityForResult(enableBtIntent, 1);
            }
        }
    }

    private void errorExit(String title, String message){
        Toast.makeText(getBaseContext(), title + " - " + message, Toast.LENGTH_LONG).show();
        finish();
    }

    private void sendData(String message) {
        byte[] msgBuffer = message.getBytes();

        Log.d(TAG, "...Send data: " + message + "...");

        try {
            outStream.write(msgBuffer);
        } catch (IOException e) {
           /* String msg = "In onResume() and an exception occurred during write: " + e.getMessage();
            if (address.equals("00:00:00:00:00:00"))
                msg = msg + ".\n\nUpdate your server address from 00:00:00:00:00:00 to the correct address on line 35 in the java code";
            msg = msg +  ".\n\nCheck that the SPP UUID: " + MY_UUID.toString() + " exists on server.\n\n";*/

            errorExit("Eroare Trimitere Date", "Activate Bluetooth,Connect to Arduino Bluetooth and restart this application");
        }
    }
}