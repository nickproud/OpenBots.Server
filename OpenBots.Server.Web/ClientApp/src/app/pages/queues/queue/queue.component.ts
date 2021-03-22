import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpService } from '../../../@core/services/http.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Name_Regex } from '../../../@auth/components';
import { HelperService } from '../../../@core/services/helper.service';
import { QueuesApiUrls } from '../../../webApiUrls';

@Component({
  selector: 'ngx-queue',
  templateUrl: './queue.component.html',
  styleUrls: ['./queue.component.scss'],
})
export class AddQueueComponent implements OnInit {
  queueForm: FormGroup;
  isSubmitted = false;
  urlId: string;
  title = 'Add';
  eTag: string;
  constructor(
    private fb: FormBuilder,
    private httpService: HttpService,
    private router: Router,
    private route: ActivatedRoute,
    private helperService: HelperService
  ) {}

  ngOnInit(): void {
    this.urlId = this.route.snapshot.params['id'];
    this.queueForm = this.initializeQueueForm();
    if (this.urlId) {
      this.getQueueById();
      this.title = 'Update';
    }
  }

  get formControls() {
    return this.queueForm.controls;
  }
  initializeQueueForm() {
    return this.fb.group({
      name: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(100),
          Validators.pattern(Name_Regex),
        ],
      ],
      maxRetryCount: [0, [Validators.pattern(/^-?([0-9]|[0-9][0-9]d*)?$/)]],
      description: [''],
    });
  }

  onSubmit() {
    this.isSubmitted = true;
    if (this.urlId) this.updateQueue();
    else this.addQueue();
  }

  addQueue(): void {
    this.httpService
      .post(`${QueuesApiUrls.Queues}`, this.queueForm.value, {
        observe: 'response',
      })
      .subscribe(
        (response) => {
            this.isSubmitted = false;
            this.httpService.success('New Queue created successfully');
            this.router.navigate(['pages/queueslist']);
            this.queueForm.reset();
        },
        () => (this.isSubmitted = false)
      );
  }

  updateQueue() {
    const headers = this.helperService.getETagHeaders(this.eTag);
    this.httpService
      .put(`${QueuesApiUrls.Queues}/${this.urlId}`, this.queueForm.value, {
        observe: 'response',
        headers,
      })
      .subscribe(
        (response) => {
          if (response && response.status == 200) {
            this.isSubmitted = false;
            this.httpService.success('Queue updated successfully');
            this.router.navigate(['pages/queueslist']);
            this.queueForm.reset();
          }
        },
        (error) => {
          if (error && error.error && error.error.status === 409) {
            this.isSubmitted = false;
            this.httpService.error(error.error.serviceErrors);
            this.getQueueById();
          }
        }
      );
  }

  getQueueById(): void {
    this.httpService
      .get(`${QueuesApiUrls.Queues}/${this.urlId}`, { observe: 'response' })
      .subscribe((response) => {
        if (response && response.body) {
          this.eTag = response.headers.get('etag');
          this.queueForm.patchValue({ ...response.body });
        }
      });
  }
}
