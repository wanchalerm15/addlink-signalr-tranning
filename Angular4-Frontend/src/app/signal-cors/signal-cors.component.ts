import { Component, OnInit } from '@angular/core';
import { HubConnection } from '@aspnet/signalr-client';

@Component({
    selector: 'app-signal-cors',
    templateUrl: './signal-cors.component.html',
    styleUrls: ['./signal-cors.component.css']
})
export class SignalCorsComponent implements OnInit {
    signalRHub = new HubConnection('http://localhost:56751/ChatHub');

    ngOnInit() {
        this.signalRHub.on('Login', (clients: any[]) => {
            this.userIds = clients.filter(m => m != this.form.login);
        });
        this.signalRHub.on('onMessage', (name, message) => {
            this.messages.push({ name, message });
        })
        this.signalRHub.start().then(() => {
            this.form.login = this.signalRHub['connection']['connectionId'];
        });
    }

    userIds: string[] = [];
    messages: { name: string, message: string }[] = [];
    form = {
        login: null,
        message: '',
        client: 'all'
    };

    onSubmit() {
        if (this.form.message.trim() == '') return;
        this.signalRHub.invoke('onMessage', this.form.client, this.form.message);
        this.form.message = '';
    }
}
