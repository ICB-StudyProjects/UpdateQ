import { TimeSeriesNode } from "./time-series-node.model";

export class InfoNode {
    id = 0;
    label = '';
    items = [];
    tsNodes: TimeSeriesNode[] = [];
}