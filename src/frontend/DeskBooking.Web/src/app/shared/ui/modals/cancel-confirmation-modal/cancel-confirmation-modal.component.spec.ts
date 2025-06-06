import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CancelConfirmationModalComponent } from './cancel-confirmation-modal.component';

describe('CancelConfirmationModalComponent', () => {
  let component: CancelConfirmationModalComponent;
  let fixture: ComponentFixture<CancelConfirmationModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CancelConfirmationModalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CancelConfirmationModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
