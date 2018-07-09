import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bla',
  template: `
    <section class="ui-g-11 ui-g-offset-1">
        <h1>New Component</h1>
    </section>`
})
export class BlaComponent implements OnInit {
  constructor() {
   }

  ngOnInit() {
    console.log('new component');
  }
}
