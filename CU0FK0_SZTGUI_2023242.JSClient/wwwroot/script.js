let artists = [];

getdata();

async function getdata() {
    await fetch('http://localhost:17161/Artist')
        .then(x => x.json())
        .then(y => {
            artists = y;
            console.log(artists);
            display();
        });
}

function remove(id) {
    fetch('http://localhost:17161/Artist/' + id,
        {
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json', },
            body: null,
        })
        .then(response => response)
        .then(data => {
            console.log('Success', data);
            getdata();
        })
        .catch((error) => { console.error('Error', error); });
}


function display() {
    document.getElementById('resultarea').innerHTML = "";
    artists.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.artistID + "</td><td>" +
            t.artistName + "</td><td>" +
            `<button type=button onclick="remove(${t.artistID})">Delete</button"` + "</td></tr>";
    });
}

function create() {
    let name = document.getElementById('artistName').value;
    fetch('http://localhost:17161/Artist',
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify({ artistName: name }),
        })
        .then(response => response)
        .then(data =>
        {
            console.log('Success', data);
            getdata();
        })
        .catch((error) => { console.error('Error', error); });
}
