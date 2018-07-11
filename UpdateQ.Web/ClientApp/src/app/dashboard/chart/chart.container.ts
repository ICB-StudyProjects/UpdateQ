import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { SignalRService } from '../../_core/signalr.service';
import { SensorDto } from '../../infonodes/models/sensor-dto.model';
import { ChartComponent } from './chart.component';

@Component({
  selector: 'app-chart-container',
  template: `
        <app-chart></app-chart>
    `
})
export class ChartContainer implements OnInit, OnDestroy {
  @ViewChild(ChartComponent) chartComponent: ChartComponent;

  private currentSensorIdView: string;

  constructor(private signalRService: SignalRService,
    private route: ActivatedRoute) {
    this.currentSensorIdView = this.route.snapshot.params['id']

    signalRService.sensorDataCallback$.subscribe((sensor: SensorDto) => {
      this.updateSensorData(sensor);
    })
  }

  updateSensorData(sensor: SensorDto): void {
    const sensorToUpdate = sensor.sensorId;

    if (this.currentSensorIdView !== sensorToUpdate) {
      return;
    }

    this.chartComponent.updateChart(sensor.currentData);
  }

  ngOnInit(): void {
    this.signalRService.startsListeningForSensorData();
  }

  ngOnDestroy(): void {
    this.signalRService.stopListeningForSensorData();
  }
}
