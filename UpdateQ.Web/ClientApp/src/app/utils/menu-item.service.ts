import { Injectable } from "@angular/core";
import { InfoNode } from "../infonodes/models/info-node.model";
import { MenuItem } from "primeng/api";


@Injectable()
export class MenuItemFactory {
    createMenuItemType(menuType: string, node: InfoNode): MenuItem {
        if (menuType === 'ts') {
            return this.createTimeSeriesMenuItem(node);
        } else {

        }
    }

    createTimeSeriesMenuItem(node: InfoNode): MenuItem {
        let menuItem: MenuItem = {
            label: node.label,
            icon: 'fa fa-star',
            // command: (click: MouseEvent) => 
        }

        return menuItem;
    }
}