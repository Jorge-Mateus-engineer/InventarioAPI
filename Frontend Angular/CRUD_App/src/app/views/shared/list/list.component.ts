import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
})
export class ListComponent implements OnChanges {
  @Input() modelsList: any[] = [];
  @Input() headersAndPropList: any[] = [];
  displayedColumns: string[] = [];

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['headersAndPropList']) {
      this.displayedColumns = this.headersAndPropList.map(
        (prop) => prop.property
      );
    }
  }
}
