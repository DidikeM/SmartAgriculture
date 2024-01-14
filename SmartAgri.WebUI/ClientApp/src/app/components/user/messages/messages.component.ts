import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormControl, AbstractControl, Validators } from '@angular/forms';
import { ReplyGuestMessageDto } from 'src/app/dtos/replyguestmessagedto';

import { GuestMessage } from 'src/app/models/guestmessage';
import { UserManagementService } from 'src/app/services/usermanagement.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent {
  messages: GuestMessage[] = [];
  isFetching: boolean = true; 
  selectedMessage: GuestMessage | null = null;

  @ViewChild('myModal') modalElement!: ElementRef;
  messageReplyForm!: FormGroup;

  constructor(private userManagementService: UserManagementService) {}

  ngOnInit(): void {
    this.userManagementService.getGuestMessages().subscribe(
      (data: GuestMessage[]) => {
        this.messages = data;
        this.isFetching = false;
      }
    )

    this.messageReplyForm = new FormGroup({
      'reply': new FormControl(null, [Validators.required]),
      'title': new FormControl(null, [Validators.required]),
    });
  }

  openModal(message: GuestMessage) {
    this.selectedMessage = message;
    if (this.modalElement) {
      this.modalElement.nativeElement.style.display = 'block';
    }
  }

  closeModal()
  {
    this.selectedMessage = null;
    if (this.modalElement)
    {
      this.modalElement.nativeElement.style.display = 'none';
      this.messageReplyForm.get('reply')?.setValue('');
      this.messageReplyForm.get('title')?.setValue('');
    }
  }

  onSubmit() {
    const reply = this.messageReplyForm.get('reply')?.value;
    const title = this.messageReplyForm.get('title')?.value;

    const replyBody: ReplyGuestMessageDto = {
      guestMessageId: this.selectedMessage!.id,
      message: reply,
      title: title,
    }

    this.userManagementService.replyGuestMessage(replyBody).subscribe(() => {
      console.log('Reply submitted successfully');

      this.messageReplyForm.get('reply')?.setValue('');
      this.messageReplyForm.get('title')?.setValue('');

      this.closeModal();
    });;
  }
}
