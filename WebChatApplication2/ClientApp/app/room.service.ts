import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { Room } from './Room';
import { Message } from './Message';

@Injectable()
export class RoomService {

    private headers = new Headers({ 'Content-Type': 'application/json' });
    private roomsUrl = 'api/Rooms';
    private messagesUrl = 'api/Messages';

    constructor(private http: Http) { }

    getRooms(): Promise<Room[]> {
        return this.http.get(this.roomsUrl)
            .toPromise()
            .then(response => response.json() as Room[])
            .catch(this.handleError);
    }

    getRoom(id: number): Promise<Room> {
        const url = `${this.roomsUrl}/${id}`;
        return this.http.get(url)
            .toPromise()
            .then(response => response.json() as Room)
            .catch(this.handleError);
    }

    create(name: string): Promise<Room> {
        return this.http
            .post(this.roomsUrl, JSON.stringify({ name: name }), { headers: this.headers })
            .toPromise()
            .then(res => res.json() as Room)
            .catch(this.handleError);
    }

    addMessage(messageText: string, roomId: number): Promise<Message> {
        return this.http
            .post(this.messagesUrl, JSON.stringify({ text: messageText, roomId: roomId, author: sessionStorage.getItem("userName") }), { headers: this.headers })
            .toPromise()
            .then(res => res.json() as Message)
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred in RoomService', error);
        return Promise.reject(error.message || error);
    }
}