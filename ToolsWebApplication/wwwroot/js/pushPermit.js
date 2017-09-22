// Write your JavaScript code.

//プッシュ通知の許可を聞くjs 
window.addEventListener('load', function () {
    if ('serviceWorker' in navigator) {
        navigator.serviceWorker.register('/serviceWorker.js')
            .then(function (registration) {
                return registration.pushManager.getSubscription().then(function (subscription) {
                    if (subscription) {
                        return subscription
                    }
                    return registration.pushManager.subscribe({
                        userVisibleOnly: true
                    })
                })
            }).then(function (subscription) {
                var endpoint = subscription.endpoint
                console.log("pushManager endpoint:", endpoint) // https://android.googleapis.com/gcm/send/******:******......
            }).catch(function (error) {
                console.warn("serviceWorker error:", error)
            })
    }
})