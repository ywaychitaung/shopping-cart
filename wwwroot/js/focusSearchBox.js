document.onkeydown = checkShortcuts;

function checkShortcuts(event) {
    if (event.keyCode == 191) { 
        let text_input = document.getElementById ('searchString');
        text_input.focus();
        text_input.select();
        return false;
    }
}