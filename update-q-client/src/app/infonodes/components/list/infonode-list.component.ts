import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

import { InfoNode } from '../../models/infonode';
import { infoNodesService } from '../../infonodes.service';
import { TimeSeriesNode } from '../../models/time-series-node.model';

@Component({
    selector: 'app-sidebar-nodes',
    templateUrl: 'infonode-list.component.html',
    styleUrls: [ 'infonode-list.component.css' ]
})
export class InfoNodeListComponent implements OnInit {
    public InfoNodes: InfoNode[] = [];
    public items: MenuItem[] = [];

    constructor(
        private _infoNodesService: infoNodesService
    ) { }

    ngOnInit() {
        this.getData();

        // this.items = [
        //     {
        //         label: 'File',
        //         icon: 'fa fa-fw fa-arrow-circle-right',
        //         items: [{ 
        //                 label: 'New', 
        //                 icon: 'fa fa-fw fa-arrow-circle-right',
        //                 items: [
        //                     { 
        //                         label: 'Project', 
        //                         icon: 'fa fa-fw fa-arrow-circle-right',
        //                         items: [{
        //                             label: 'New', 
        //                             icon: 'fa fa-fw fa-arrow-circle-right',
        //                             items: [
        //                                 { 
        //                                     label: 'Project', 
        //                                     icon: 'fa fa-fw fa-star'
        //                                 },
        //                                 {
        //                                     label: 'Other',
        //                                     icon: 'fa fa-fw fa-star'
        //                                 },
        //                             ]
        //                         },
        //                         {label: 'Open', icon: 'fa fa-fw fa-star'},
        //                         {label: 'Quit', icon: 'fa fa-fw fa-star'}
        //                     ]
        //                     },
        //                     {
        //                         label: 'Other',
        //                         icon: 'fa fa-fw fa-star'
        //                     },
        //                 ]
        //             },
        //             {label: 'Open', icon: 'fa fa-fw fa-arrow-circle-right', items: [
        //                 { 
        //                     label: 'Project', 
        //                     icon: 'fa fa-fw fa-arrow-circle-right',
        //                     items: [{
        //                         label: 'New', 
        //                         icon: 'fa fa-fw fa-arrow-circle-right',
        //                         items: [
        //                             { 
        //                                 label: 'Project', 
        //                                 icon: 'fa fa-fw fa-star'
        //                             },
        //                             {
        //                                 label: 'Other',
        //                                 icon: 'fa fa-fw fa-star'
        //                             },
        //                         ]
        //                     },
        //                     {label: 'Open', icon: 'fa fa-fw fa-star'},
        //                     {label: 'Quit', icon: 'fa fa-fw fa-star'}
        //                 ]
        //                 },
        //                 {
        //                     label: 'Other',
        //                     icon: 'fa fa-fw fa-star'
        //                 },
        //             ]},
        //             {label: 'Quit', icon: 'fa fa-fw fa-star'}
        //         ]
        //     },
        //     {
        //         label: 'Edit',
        //         icon: 'fa fa-fw fa-edit',
        //         items: [
        //             {label: 'Undo', icon: 'fa fa-fw fa-mail-forward'},
        //             {label: 'Redo', icon: 'fa fa-fw fa-mail-reply'}
        //         ]
        //     },
        //     {
        //         label: 'Help',
        //         icon: 'fa fa-fw fa-question',
        //         items: [
        //             {
        //                 label: 'Contents'
        //             },
        //             {
        //                 label: 'Search', 
        //                 icon: 'fa fa-fw fa-search', 
        //                 items: [
        //                     {
        //                         label: 'Text', 
        //                         items: [
        //                             {
        //                                 label: 'Workspace'
        //                             }
        //                         ]
        //                     },
        //                     {
        //                         label: 'File'
        //                     }
        //             ]}
        //         ]
        //     },
        //     {
        //         label: 'Actions',
        //         icon: 'fa fa-fw fa-gear',
        //         items: [
        //             {
        //                 label: 'Edit',
        //                 icon: 'fa fa-fw fa-refresh',
        //                 items: [
        //                     {label: 'Save', icon: 'fa fa-fw fa-save'},
        //                     {label: 'Update', icon: 'fa fa-fw fa-save'},
        //                 ]
        //             },
        //             {
        //                 label: 'Other',
        //                 icon: 'fa fa-fw fa-phone',
        //                 items: [
        //                     {label: 'Delete', icon: 'fa fa-fw fa-minus'}
        //                 ]
        //             }
        //         ]
        //     }
        // ];
    }

  private getData() {
      //console.log('Inside getData method!')
        this._infoNodesService
            .getAll()
            .subscribe(data => this.InfoNodes = data,
                error => console.log(error),
                () => {
                    this.modelSidebarData();
                    console.log('GET all nodes is completed!')
                });
    }

    private modelSidebarData() {
        for (let node of this.InfoNodes) {
            let nodeObjUi: MenuItem = {
                label: node.label,
                items: node.items,
                icon: 'fa fa-fw fa-arrow-circle-right'
            }

            this.items.push(nodeObjUi)

            // Recursion obj.items to model other props
            this.modelChildNodes(nodeObjUi, node)
            // Add the timeseries nodes to the main obj.items arr
            // if (node.tsNodes.length) {
            //     // Add timeseries to this.items w/ command
            //     nodeObjUi.icon = 'fa fa-fw fa-star'
            // }

        }
    }

    private modelChildNodes(parentUiNode: MenuItem, infoNode: InfoNode) {
        let nodeObjUi: MenuItem  = {}
        
        for (let node of infoNode.items) {
            if (node.items.length) {
                this.modelChildNodes(nodeObjUi, node);
            }
            // let nodeObjUi: MenuItem  = {
            //     label: node.label,
            //     items: node.items,
            //     icon: 'fa fa-fw fa-arrow-circle-right'
            // }
            // Model the node
            // nodeUiObj = {
            //     label: node.label,
            //     items: node.items,
            //     icon: 'fa fa-fw fa-arrow-circle-right'
            // }

            // Call recursivly the node.items if there are more obj.items
            // if (node.items) {
            //     //this.modelChildNodes(node)
            // }
            

            // After modeling the info-nodes model and add the time-series nodes to node.items
            this.modelTimeSeriesNodes(node)
        }
    }

    private modelTimeSeriesNodes(node) {
        // for (let tsNode of timeSeriesNodesArr) {
            
        // }
    }
}
