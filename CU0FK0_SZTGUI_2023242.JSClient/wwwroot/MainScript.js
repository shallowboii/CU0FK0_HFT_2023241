let artists = [];
let albums = [];
let songs = [];
let connection = null;

let artistIdToUpdate = -1;
let albumIdToUpdate = -1;
getArtist();
getAlbum();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:17161/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ArtistCreated", (user, message) => {
        getArtist();
    });

    connection.on("ArtistDeleted", (user, message) => {
        getArtist();
    });
    connection.on("ArtistUpdated", (user, message) => {
        getArtist();
    });

    connection.on("AlbumCreated", (user, message) => {
        getArtist();
    });

    connection.on("AlbumDeleted", (user, message) => {
        getArtist();
    });
    connection.on("AlbumUpdated", (user, message) => {
        getArtist();
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

async function getArtist() {
    await fetch('http://localhost:17161/Artist')
        .then(x => x.json())
        .then(y => {
            artists = y;
            console.log(artists);
        });
}

async function getAlbum() {
    await fetch('http://localhost:17161/Album')
        .then(x => x.json())
        .then(y => {
            albums = y;
            console.log(albums);
        });
}
 function removeArtist(id) {
    fetch('http://localhost:17161/Artist/' + id,
        {
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json', },
            body: null,
        })
        .then(response => response)
        .then(data => {
            console.log('Success', data);
            return getArtist();
        })
        .then(() => showArtist() )
        .then(()=> getAlbum())
        //elobb get data es utana display
        .catch((error) => { console.error('Error', error); });
}
function removeAlbum(id) {
    fetch('http://localhost:17161/Album' + id,
        {
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json', },
            body: null,
        })
        .then(response => response)
        .then(data => {
            console.log('Success', data);
            return getAlbum();
        })
        .then(() => showAlbum())
        
        //elobb get data es utana display
        .catch((error) => { console.error('Error', error); });
}

function showAlbum() {
    document.getElementById('resultarea').innerHTML = "";
    albums.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.albumID + "</td><td>" +
            t.albumTitle + "</td><td>" +
            `<button type=button onclick="removeAlbum(${t.albumID})">Delete</button>` +
            `<button type=button onclick="showAlbumupdate(${t.albumID})">Update</button>`
            + "</td></tr>";
    });
    
}


function showArtist() {
    document.getElementById('resultarea').innerHTML = "";
    document.getElementById('formdiv').style.display = 'flex';
    artists.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.artistID + "</td><td>" +
            t.artistName + "</td><td>" +
            `<button type=button onclick="removeArtist(${t.artistID})">Delete</button>` +
            `<button type=button onclick="showArtistupdate(${t.artistID})">Update</button>`
            + "</td></tr>";
    });
    
}



function showArtistupdate(id) {
    document.getElementById('artistNameToUpdate').value = artists.find(t => t['artistID'] == id)['artistName'];
    document.getElementById('updateArtistformdiv').style.display = 'flex';
    artistIdToUpdate = id;
}
function updateArtist() {
    document.getElementById('updateArtistformdiv').style.display = 'none';
    let name = document.getElementById('artistNameToUpdate').value;

    fetch('http://localhost:17161/Artist',
        {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify({ artistName: name, artistID: artistIdToUpdate }),
        })
        .then(response => response)
        .then(data => {
            console.log('Success', data);
            return getArtist();
        })
        .then(() => showArtist())
        .catch((error) => { console.error('Error', error); });


}


function showAlbumupdate(id) {
    document.getElementById('albumNameToUpdate').value = albums.find(t => t['albumID'] == id)['albumTitle'];
    document.getElementById('updateAlbumformdiv').style.display = 'flex';
    albumIdToUpdate = id;
}
function updateAlbum() {
    document.getElementById('updateAlbumformdiv').style.display = 'none';
    let name = document.getElementById('albumNameToUpdate').value;

    fetch('http://localhost:17161/Album',
        {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify({ albumTitle: name, albumID: albumIdToUpdate }),
        })
        .then(response => response)
        .then(data => {
            console.log('Success', data);
            return getAlbum();
        })
        .then(() => showAlbum())
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
        .then(data => {
            console.log('Success', data);
            getdata();
        })
        .catch((error) => { console.error('Error', error); });
}
