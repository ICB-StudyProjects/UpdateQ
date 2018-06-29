import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { Router } from '@angular/router';

import { InfoNode } from '../models/info-node.model';
import { infoNodesService } from '../info-nodes.service';
import { TimeSeriesNode } from '../models/time-series-node.model';
//import { TimeSeriesNode } from '../../models/time-series-node.model';

@Component({
    selector: 'app-sidebar-nodes',
    templateUrl: 'info-node-list.component.html',
    styleUrls: ['info-node-list.component.css']
})
export class InfoNodeListComponent implements OnInit {
    public InfoNodes: InfoNode[] = [];
    public items: MenuItem[] = [];

    constructor(
        private _infoNodesService: infoNodesService,
        private router: Router
    ) { }

    ngOnInit() {
        this.getData();
    }

    private getData(): void {
        this._infoNodesService.getAll()
            .subscribe(data => this.InfoNodes = data,
                error => console.log(error),
                () => {
                    this.modelSidebarData();
                });
    }

    private modelSidebarData(): void {
        while (this.InfoNodes.length) {
            let node: InfoNode = this.InfoNodes.shift();

            // node (info-node) -> MenuItem
            let menuItemNode: MenuItem = this.factoryMenuItem(node);

            // Process the node childs (parent.items)
            this.processAndAddMenuNodes(menuItemNode, node);

            // Add the parent node to the this.items (main MenuItem[])
            this.items.push(menuItemNode);
        }
    }

    // TODO: Make this method a service
    private processAndAddMenuNodes(parentMenuNode: MenuItem, parentNode: InfoNode) : void {
        for (let child of parentNode.items) {
            // child (info-node) -> MenuItem
            let childMenuItemNode: MenuItem = this.factoryMenuItem(child);

            // Recursion!!!
            this.processAndAddMenuNodes(childMenuItemNode, child);

            (parentMenuNode.items as MenuItem[]).push(childMenuItemNode);
        }

        // Then process and add to parentMenuNode.items, tsNode MenuItems
        for (let tsNode of parentNode.tsNodes) {
            // timeseries node -> MenuItem
            let tsMenuItemNode: MenuItem = this.factoryMenuItem(tsNode, 'timeseries');

            (parentMenuNode.items as MenuItem[]).push(tsMenuItemNode);
        }

        // Return to previous callback
        return;
    }

    // TODO: Factoru = service?
    private factoryMenuItem(node: InfoNode | TimeSeriesNode, nodeType?: string) : MenuItem {
        let menuItem: MenuItem;

        if (nodeType === 'timeseries') {
            let tsNode = node as TimeSeriesNode

            menuItem = {
                label: tsNode.name,
                icon: 'fa fa-star-o',
                command: (click: MouseEvent) => this.handleTSNode(click, tsNode)
            };
        } else {
            let infoNode = node as InfoNode

            menuItem = {
                label: infoNode.label,
                icon: 'fa fa-fw fa-arrow-circle-right',
                items: [],
                command: (click: MouseEvent) => this.changeIconInfoNode(click)
            };
        }

        return menuItem;
    }

    private changeIconInfoNode(event) : void {
        let item = event.item

        if (item.expanded && item.items.length) {
            item.icon = 'fa fa-fw fa-arrow-circle-down'
        } else {
            item.icon = 'fa fa-fw fa-arrow-circle-right'
        }
    }

    private handleTSNode(event, tsNode: TimeSeriesNode) {
        let item = event.item

        if (item.expanded) {
            item.icon = 'fa fa-star'
        } else {
            item.icon = 'fa fa-star-o'
        }

        this.router.navigate(['/dashboard']);

        console.log(tsNode.sensorId)
    }

    private getChartTSData() {

    }
}
