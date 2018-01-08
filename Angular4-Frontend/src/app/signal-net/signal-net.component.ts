import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
declare const $;
@Component({
    selector: 'app-signal-net',
    templateUrl: './signal-net.component.html',
    styleUrls: ['./signal-net.component.css']
})
export class SignalNetComponent implements OnInit {
    constructor(private detect: ChangeDetectorRef) { }

    ngOnInit() {
        this.conneciton.hub.url = 'http://localhost:56788/signalr';
        this.chatHub.client.Login = (clients: string[]) => {
            this.userIds = clients.filter(m => m != this.conneciton.hub.id);
            this.detect.detectChanges();
        };
        this.chatHub.client.onMessage = (name, message) => {
            this.messages.push({ name, message });
            this.detect.detectChanges();
        };
        this.conneciton.hub.start().done(() => {
            this.form.login = this.conneciton.hub.id;
            this.detect.detectChanges();
        });
    }

    conneciton = $.connection;
    chatHub = this.conneciton.chatHub;
    userIds: string[] = [];
    messages: { name: string, message: string }[] = [];
    form = {
        login: null,
        message: '',
        client: 'all'
    };

    onSubmit() {
        if (this.form.message.trim() == '') return;
        this.chatHub.server.onMessage(this.form.client, this.form.message);
        this.form.message = '';
    }
}
