import { TestBed } from '@angular/core/testing';

import { ClientservicesService } from './clientservices.service';

describe('ClientservicesService', () => {
  let service: ClientservicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClientservicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
