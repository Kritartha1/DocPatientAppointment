import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorCardListComponent } from './doctor-card-list.component';

describe('DoctorCardListComponent', () => {
  let component: DoctorCardListComponent;
  let fixture: ComponentFixture<DoctorCardListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DoctorCardListComponent]
    });
    fixture = TestBed.createComponent(DoctorCardListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
