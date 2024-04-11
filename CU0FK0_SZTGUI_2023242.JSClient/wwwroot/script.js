let artists = [];
let connection = null;

let artistIdToUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:17161/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ArtistCreated", (user, message) => {
        getdata();
    });

    connection.on("ArtistDeleted", (user, message) => {
        getdata();
    });
    connection.on("ArtistUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
}

async function getdata() {
    await fetch('http://localhost:17161/Artist')
        .then(x => x.json())
        .then(y => {
            artists = y;
            //console.log(artists);
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
        `<button type=button onclick="remove(${t.artistID})">Delete</button>` +
        `<button type=button onclick="showupdate(${t.artistID})">Update</button>`
            + "</td></tr>";
    });
}


function showupdate(id) {
    document.getElementById('artistNameToUpdate').value = artists.find(t => t['artistID'] == id)['artistName'];
    document.getElementById('updateformdiv').style.display = 'flex';
    artistIdToUpdate = id;
}
function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('artistNameToUpdate').value;

    fetch('http://localhost:17161/Artist',
        {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify({ artistName: name,artistID:artistIdToUpdate }),
        })
        .then(response => response)
        .then(data => {
            console.log('Success', data);
            getdata();
        })
        .catch((error) => { console.error('Error', error); });


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
