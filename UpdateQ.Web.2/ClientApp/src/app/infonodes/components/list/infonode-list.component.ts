import { Component, OnInit } from '@angular/core';
//import { MenuItem } from 'primeng/api';

import { InfoNode } from '../../models/infonode';
import { infoNodesService } from '../../infonodes.service';

@Component({
  selector: 'app-sidebar-nodes',
  templateUrl: 'infonode-list.component.html',
  styleUrls: ['infonode-list.component.css']
})
export class InfoNodeListComponent implements OnInit {
  public InfoNodes: InfoNode[] = [];
  public items: MenuItem[] = [];

  constructor(
    private _infoNodesService: infoNodesService
  ) { }

  ngOnInit() {
    this.getData();

    this.items = [
      {
        label: 'File',
        items: [{
          label: 'New',
          icon: 'fa fa-fw fa-plus',
          items: [
            { label: 'Project' },
            { label: 'Other' },
          ]
        },
        { label: 'Open' },
        { label: 'Quit' }
        ]
      },
      {
        label: 'Edit',
        icon: 'fa fa-fw fa-edit',
        items: [
          { label: 'Undo', icon: 'fa fa-fw fa-mail-forward' },
          { label: 'Redo', icon: 'fa fa-fw fa-mail-reply' }
        ]
      }
    ];
  }

  private getData() {
    console.log('Inside getData method!')
    this._infoNodesService
      .getAll()
      .subscribe(data => this.InfoNodes = data,
        error => console.log(error),
        () => console.log('GET all nodes is completed!'));
  }
}
