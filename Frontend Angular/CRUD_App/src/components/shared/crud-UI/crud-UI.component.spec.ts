/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CrudUIComponent } from './crud-UI.component';

describe('CrudUIComponent', () => {
  let component: CrudUIComponent;
  let fixture: ComponentFixture<CrudUIComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrudUIComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrudUIComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
