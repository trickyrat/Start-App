import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { NavigationNode } from '../navigation/navigation.model';

@Component({
  selector: 'nav-item',
  templateUrl: './nav-item.component.html',
  styleUrls: ['./nav-item.component.css']
})
export class NavItemComponent implements OnChanges {

  @Input() isWide = false;
  @Input() level = 1;
  @Input() node: NavigationNode;
  @Input() isParentExpanded = true;
  @Input() selectedNodes: NavigationNode[] | undefined;

  isExpanded = false;
  isSelected = false;
  classes: { [index: string]: boolean };
  nodeChildren: NavigationNode[];

  constructor() { }

  ngOnChanges(): void {
    this.nodeChildren = this.node && this.node.children ? this.node.children.filter(n => !n.hidden) : [];

    if (this.selectedNodes) {
      const index = this.selectedNodes.indexOf(this.node);
      this.isSelected = index !== -1;
      this.isExpanded = this.isParentExpanded && (this.isSelected || (this.isWide && this.isExpanded));
    } else {
      this.isSelected = false;
    }
    this.setClasses();
  }

  setClasses() {
    this.classes = {
      ['level-' + this.level]: true,
      collapsed: !this.isExpanded,
      expanded: this.isExpanded,
      selected: this.isSelected
    };
  }

  headerClicked() {
    this.isExpanded = !this.isExpanded;
    this.setClasses();
  }

}
