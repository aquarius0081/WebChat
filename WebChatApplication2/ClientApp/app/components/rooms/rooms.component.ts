import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotificationsService } from 'angular4-notify';

import { Room } from '../../Room';
import { RoomService } from '../../room.service';

@Component({
    selector: 'rooms',
    templateUrl: './rooms.component.html'
})
export class RoomsComponent implements OnInit {
    rooms:Room[];

    constructor(
        private roomService: RoomService,
        private router: Router,
        protected notificationsService: NotificationsService
    ) { }

    ngOnInit() {
        if (!sessionStorage.getItem("userName")) {
            this.router.navigateByUrl('/login');
            return;
        }
        this.getRooms();
    }

    getRooms(): void {
        this.roomService
            .getRooms()
            .then(rooms => this.rooms = rooms);
    }

    add(name: string): void {
        name = name.trim();
        if (!name) { return; }
        this.roomService.create(name)
            .then(room => {
                this.rooms.push(room);
            }).catch(err => this.notificationsService.addError('Error during creation of room on server!'));
    }
}
