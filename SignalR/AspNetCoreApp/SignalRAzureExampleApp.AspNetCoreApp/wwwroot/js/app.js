'use strict';

var airConditioner = {
    on: 1,
    off: 0
};

function UI(hubConnection) {
    var self = this;
    var jq = $;
    var btnSendMessage = '#btnSendMessage';
    var chckStatus = '#chckStatus';

    this.loadEvents = function () {
        jq(btnSendMessage).click(self.sendMessageOnClick);
    };

    this.sendMessageOnClick = function () {
        var airConditionerStatus = jq(chckStatus).is(':checked') === true ? airConditioner.on : airConditioner.off;
        console.log('Air conditioner status = ' + airConditionerStatus);
        hubConnection.invoke('ChangeStateMessage', airConditionerStatus);
    };

    (function () {
        self.loadEvents();
    })();
}

(function () {
    var connection = new signalR.HubConnectionBuilder()
        .withUrl("/air-conditioner")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.start().then(function () {
        console.log("connected");
    });

    var ui = new UI(connection);

})();