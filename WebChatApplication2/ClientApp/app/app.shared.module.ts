import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { NotificationsModule, NotificationsService } from 'angular4-notify';

import { AppComponent } from './components/app/app.component';
import { LoginComponent } from './components/login/login.component';
import { RoomsComponent } from './components/rooms/rooms.component';
import { RoomComponent } from './components/room/room.component';

import { RoomService } from './room.service';

@NgModule({
    declarations: [
        AppComponent,
        RoomComponent,
        RoomsComponent,
        LoginComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'login', pathMatch: 'full' },
            { path: 'room/:id', component: RoomComponent },
            { path: 'rooms', component: RoomsComponent },
            { path: 'login', component: LoginComponent },
            { path: '**', redirectTo: 'login' }
        ]),
        NotificationsModule
    ],
    providers: [
        RoomService,
        NotificationsService
    ]
})
export class AppModuleShared {
}
