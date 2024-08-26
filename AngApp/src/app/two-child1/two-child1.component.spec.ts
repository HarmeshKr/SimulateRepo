import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TwoChild1Component } from './two-child1.component';

describe('TwoChild1Component', () => {
  let component: TwoChild1Component;
  let fixture: ComponentFixture<TwoChild1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TwoChild1Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TwoChild1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
