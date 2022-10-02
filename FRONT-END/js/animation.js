const _displayMode = { Edit: 'note-edit', Display: 'note-display', Insert: 'note-create' }

function auto_grow(element) {
    element.style.height = "5px";
    element.style.height = (element.scrollHeight) + "px";
}

const noteDisplay = (id, displayMode) => {
    var div = document.createElement('div');
    div.id = 'noteParent' + id;
    div.className = displayMode;
    return div;
}

const noteItem = (id) => {
    var div = document.createElement('div');
    div.id = 'noteItem' + id;
    div.className = 'note-item';
    return div;
}

const noteTitle = (id) => {
    var title = document.createElement('input');
    title.id = 'noteTitle' + id;
    title.setAttribute('name', 'noteTitle');
    title.setAttribute('placeholder', 'Pavadinimas');
    return title;
}

const noteText = (id) => {
    var text = document.createElement('textarea');
    text.id = 'noteText' + id;
    text.setAttribute('name', 'noteText');
    text.setAttribute('placeholder', 'Tekstas');
    // text.addEventListener('change',(e)=>{
    //     auto_grow(e.target)
    // })
    return text;
}

const createNote = (id, displayMode, noteFields) => {
    var displayItem = noteDisplay(id, displayMode);
    var item = noteItem(id);

    var element;
    if (noteFields.title !== '') {
        element = noteTitle(id);
        element.value = 'tai sugeneruota atraste' + id;
        item.append(element);
    }
    element = noteText(id);
    element.textContent = 'tai sugenertuotas tekstas';
    item.append(element);
    displayItem.append(item);
    displayItem.addEventListener('click', (e) => {
        if (e.currentTarget.className === 'note-display') {
            e.currentTarget.className = 'note-edit';
        }
        if (e.currentTarget.id === e.target.id) {
            e.currentTarget.className = 'note-display';
        }
    })

    return displayItem;
}

var noteHolder = document.getElementById('defaultNotesHolder');
for (var i = 0; i < 50; i++) {
    noteHolder.append(createNote(i + 10, _displayMode.Display, ''));
}
