import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { SensorDto } from '../../infonodes/models/sensor-dto.model';
import { UIChart } from 'primeng/primeng';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent {
  @ViewChild("sensorChart") sensorChart: UIChart;

  private data: any = {
    labels: [],
    datasets: []
  };

  private sensorDataSet: any = {
    label: '',
    fill: false,
    borderColor: '#1E88E5',
    data: []
  };

  constructor(private route: ActivatedRoute) {
    const sensorId = route.snapshot.params['id'];

    this.sensorDataSet.label = `Sensor ${sensorId}`;

    this.data.datasets.push(this.sensorDataSet);
  }

  updateChart(sensorData: number) {
    // TODO: Get the date from the DTO
    const dateTimeNow = new Date().toLocaleTimeString();

    if (this.data.labels.length >= 10) {
      this.data.labels.shift();
      this.sensorDataSet.data.shift();
    }
    
    this.data.labels.push(dateTimeNow);
    this.sensorDataSet.data.push(sensorData);

    this.sensorChart.refresh();
  }
}
