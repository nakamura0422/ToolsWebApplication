// Write your JavaScript code.

$(function () {
    // ドラッグ&ドロップに必要な処理を記述しますよ.
    var droppable = $("#droppable");

    // File API が使用できない場合は諦めます.
    if (!window.FileReader) {
        alert("File API がサポートされていません。");
        return false;
    }

    // イベントをキャンセルするハンドラです.
    var cancelEvent = function (event) {
        event.preventDefault();
        event.stopPropagation();
        return false;
    }

    // dragenter, dragover イベントのデフォルト処理をキャンセルします.
    droppable.bind("dragenter", cancelEvent);
    droppable.bind("dragover", cancelEvent);
    
    // ドロップ時のイベントハンドラを設定します.
    var handleDroppedFile = function (event) {
        // ファイルは複数ドロップされる可能性がありますが, ここでは 1 つ目のファイルを扱います.
        var file = event.originalEvent.dataTransfer.files[0];
        // ファイルの内容は FileReader で読み込みます.
        var fileReader = new FileReader();
        fileReader.onload = function (event) {
            // event.target.result に読み込んだファイルの内容が入っています.
            // filename　でファイルの名前もとれます.
            $("#droppable").val(event.target.result.split("\n"));
        }
        // テキストはs-jisとして扱います.
        // 文字コードが異なると文字化けします.
        fileReader.readAsText(file, "shift-jis");
        // デフォルトの処理をキャンセルします.
        cancelEvent(event);
        return false;
    }
    // ドロップ時のイベントハンドラを設定します.
    droppable.bind("drop", handleDroppedFile);
});
