import 'rxjs/add/operator/switchMap';
import { Component, Input, OnInit, AfterViewChecked, ElementRef, ViewChild } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Location } from '@angular/common';
import { HubConnection, TransportType } from '@aspnet/signalr-client';
import { NotificationsService } from 'angular4-notify';

import { Room } from '../../Room';
import { Message } from '../../Message';
import { RoomService } from '../../room.service';

@Component({
    selector: 'room',
    templateUrl: './room.component.html',
    styleUrls: ['./room.component.css']
})
export class RoomComponent implements OnInit, AfterViewChecked {
    @Input() room: Room;
    private hubConnection: HubConnection;
    @ViewChild('divMessages') private myScrollContainer: ElementRef;

    constructor(
        private roomService: RoomService,
        private route: ActivatedRoute,
        private location: Location,
        private router: Router,
        protected notificationsService: NotificationsService
    ) { }

    ngOnInit(): void {
        if (!sessionStorage.getItem("userName")) {
            this.router.navigateByUrl('/login');
            return;
        }
        this.hubConnection = new HubConnection('http://localhost:53896/chat', { transport: TransportType.LongPolling });

        this.hubConnection
            .start()
            .then(() => this.notificationsService.addInfo('Connection to Web Chat established!'))
            .catch(err => this.notificationsService.addError('Error while establishing connection to Web Chat!'));

        this.hubConnection.on('sendToAll', (message: Message) => {
            if (message.roomId == this.room.id) {
                this.room.messages.push(message);
            }
        });

        this.route.paramMap
            .switchMap((params: ParamMap) => this.roomService.getRoom(+params.get('id')!))
            .subscribe(room => this.room = room);
        this.scrollToBottom();
    }

    goBack(): void {
        this.location.back();
    }
    addMessage(messageText: string): void {
        messageText = messageText.trim();
        if (!messageText) {
            return;
        }
        const errorMessage = 'Error during sending message to server!';
        this.roomService.addMessage(messageText, this.room.id)
            .then(message => {
                this.hubConnection
                    .invoke('sendToAll', message)
                    .catch(err => this.notificationsService.addError(errorMessage));

            }).catch(err => this.notificationsService.addError(errorMessage));
    }

    ngAfterViewChecked() {
        this.scrollToBottom();
    }

    scrollToBottom(): void {
        try {
            this.myScrollContainer.nativeElement.scrollTop = this.myScrollContainer.nativeElement.scrollHeight;
        } catch (err) { }
    }
}
