import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { Router } from '@angular/router';

import { InfoNode } from '../models/info-node.model';
import { InfoNodesService } from '../info-nodes.service';
import { TimeSeriesNode } from '../models/time-series-node.model';
// import { TimeSeriesNode } from '../../models/time-series-node.model';

@Component({
    selector: 'app-sidebar-nodes',
    templateUrl: 'info-node-list.component.html',
    styleUrls: ['info-node-list.component.css']
})
export class InfoNodeListComponent implements OnInit {
    public InfoNodes: InfoNode[] = [];
    public items: MenuItem[] = [];

    constructor(
        private _infoNodesService: InfoNodesService,
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
            const node: InfoNode = this.InfoNodes.shift();

            // node (info-node) -> MenuItem
            const menuItemNode: MenuItem = this.factoryMenuItem(node);

            // Process the node childs (parent.items)
            this.processAndAddMenuNodes(menuItemNode, node);

            // Add the parent node to the this.items (main MenuItem[])
            this.items.push(menuItemNode);
        }
    }

    // TODO: Make this method a service
    private processAndAddMenuNodes(parentMenuNode: MenuItem, parentNode: InfoNode): void {
        for (const child of parentNode.items) {
            // child (info-node) -> MenuItem
            const childMenuItemNode: MenuItem = this.factoryMenuItem(child);

            // Recursion!!!
            this.processAndAddMenuNodes(childMenuItemNode, child);

            (parentMenuNode.items as MenuItem[]).push(childMenuItemNode);
        }

        // Then process and add to parentMenuNode.items, tsNode MenuItems
        for (const tsNode of parentNode.tsNodes) {
            // timeseries node -> MenuItem
            const tsMenuItemNode: MenuItem = this.factoryMenuItem(tsNode, 'timeseries');

            (parentMenuNode.items as MenuItem[]).push(tsMenuItemNode);
        }

        // Return to previous callback
        return;
    }

    // TODO: Factoru = service?
    private factoryMenuItem(node: InfoNode | TimeSeriesNode, nodeType?: string): MenuItem {
        let menuItem: MenuItem;

        if (nodeType === 'timeseries') {
            const tsNode = node as TimeSeriesNode;

            menuItem = {
                label: tsNode.name,
                icon: 'fa fa-star-o',
                command: (click: MouseEvent) => this.handleTSNode(click, tsNode)
            };
        } else {
            const infoNode = node as InfoNode;

            menuItem = {
                label: infoNode.label,
                icon: 'fa fa-fw fa-arrow-circle-right',
                items: [],
                command: (click: MouseEvent) => this.changeIconInfoNode(click, infoNode)
            };
        }

        return menuItem;
    }

    private changeIconInfoNode(event, infoNode: InfoNode): void {
        const item = event.item;

        if (item.expanded && item.items.length) {
            item.icon = 'fa fa-fw fa-arrow-circle-down';
        } else {
            item.icon = 'fa fa-fw fa-arrow-circle-right';
        }

        // this.router.navigate(['/node/create']);
    }

    private handleTSNode(event, tsNode: TimeSeriesNode) {
        const item = event.item;

        if (item.expanded) {
            item.icon = 'fa fa-star';
        } else {
            item.icon = 'fa fa-star-o';
        }

        this.router.navigate(['/dashboard', tsNode.sensorId]);

        console.log(tsNode.sensorId);
    }

    private getChartTSData() {

    }
}
