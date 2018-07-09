import { Component, OnInit, OnDestroy } from '@angular/core';
import { SignalRService } from '../../_core/signalr.service';

@Component({
  selector: 'app-chart-container',
  template: `
        <app-chart></app-chart>
    `
})
export class ChartContainer implements OnInit, OnDestroy {
  constructor(private signalRService: SignalRService) {}

  ngOnInit() {
    this.signalRService.startsListeningForSensorData();
  }

  ngOnDestroy(): void {
    this.signalRService.stopListeningForSensorData();
  }
}
