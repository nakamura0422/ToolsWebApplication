// Write your JavaScript code.

// downloadBtn class の location に downloadBtn の id を パラメータとして付与する
$(".downloadBtn").click(function () {
    // 今のurlのstringが欲しい
    var documentUrl = document.URL;
    // 二重パラメータの付与をチェックしてるよ
    if (documentUrl.match(this.id)) {
        // 既にdocumentUrlがthis.idを含むときは何もしない
    } else {
        location.href = document.URL + this.id;
    }
});