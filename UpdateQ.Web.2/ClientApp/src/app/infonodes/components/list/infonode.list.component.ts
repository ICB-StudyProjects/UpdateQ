import { Component, OnInit } from '@angular/core';

import { InfoNode } from '../../models/infonode';
import { infoNodesService } from '../../infonodes.service';

@Component({
    selector: 'app-sidebar-nodes',
    templateUrl: 'infonode.list.component.html',
    styleUrls: [ 'infonode.list.component.css' ]
})
export class InfoNodeListComponent implements OnInit {
    public InfoNodes: InfoNode[] = [];

    constructor(
        private _infoNodesService: infoNodesService
    ) { }

    ngOnInit() {
        this.getData();
    }

    private getData() {
        this._infoNodesService
            .getAll()
            .subscribe(data => this.InfoNodes = data,
                error => console.log(error),
                () => console.log('GET all nodes is completed!'));
    }
}