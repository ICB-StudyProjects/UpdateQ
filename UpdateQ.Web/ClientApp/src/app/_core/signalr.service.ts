import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

import { SensorDto } from '../infonodes/models/sensor-dto.model';

@Injectable({
    providedIn: 'root'
})
export class SignalRService {

    private _hubConnection: HubConnection

    get HubConnection(): HubConnection {
        return this._hubConnection;
    }

    constructor() {
    }

    registerHub() {
        this._hubConnection = new HubConnectionBuilder().withUrl('http://localhost:50456/hub/sensors').build();

        this._hubConnection.on("ReceiveSensorData", (sensor: SensorDto) => {
            console.log(`SensorId ${sensor.sensorId}; Current data ${sensor.currentData}`);
        });
    }

    startsListeningForSensorData() {
        this._hubConnection.start()
            .then(() => console.log('Starts listening for sensor.'))
            .catch(() => console.error('Could not connect to SignalR.'));
    }

    stopListeningForSensorData() {
        this._hubConnection.stop().then(() => console.log('Stoped listening for sensor data.'));
    }
}
