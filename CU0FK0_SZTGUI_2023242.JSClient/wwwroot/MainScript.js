let artists = [];
let albums = [];
let songs = [];
let connection = null;

let artistIdToUpdate = -1;
let albumIdToUpdate = -1;
let songIdToUpdate = -1;
getArtist();
getAlbum();
getSong();
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
        getAlbum();
    });

    connection.on("AlbumDeleted", (user, message) => {
        getAlbum();
    });
    connection.on("AlbumUpdated", (user, message) => {
        getAlbum();
    });
    connection.on("SongCreated", (user, message) => {
        getSong();
    });

    connection.on("SongDeleted", (user, message) => {
        getSong();
    });
    connection.on("SongUpdated", (user, message) => {
        getSong();
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
async function getSong() {
    await fetch('http://localhost:17161/Song')
        .then(x => x.json())
        .then(y => {
            songs = y;
            console.log(songs);
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
        //elobb get data es utana display
        .catch((error) => { console.error('Error', error); });
}
function removeSong(id) {
    fetch('http://localhost:17161/Song/' + id,
        {
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json', },
            body: null,
        })
        .then(response => response)
        .then(data => {
            console.log('Success', data);
            return getSong();
        })
        .then(() => showSong())
        //elobb get data es utana display
        .catch((error) => { console.error('Error', error); });
}
function removeAlbum(id) {
    fetch('http://localhost:17161/Album/' + id,
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
    document.getElementById('createArtistformdiv').style.display = 'none';
    document.getElementById('createSongformdiv').style.display = 'none';
    
    document.getElementById('formdiv').style.display = 'flex';
    document.getElementById('createAlbumformdiv').style.display = 'flex';
     return getAlbum().then(() => {
         document.getElementById('resultarea').innerHTML = "";
         albums.forEach(t => {
             document.getElementById('resultarea').innerHTML +=
                 "<tr><td>" + t.albumID + "</td><td>" +
                 t.albumTitle + "</td><td>" +
                 `<button type=button onclick="removeAlbum(${t.albumID})">Delete</button>` +
                 `<button type=button onclick="showAlbumupdate(${t.albumID})">Update</button>`
                 + "</td></tr>";
         });
     });
     
    
}
function showSong() {
    
    document.getElementById('createArtistformdiv').style.display = 'none';
    document.getElementById('createAlbumformdiv').style.display = 'none';
    
    document.getElementById('formdiv').style.display = 'flex';
    document.getElementById('createSongformdiv').style.display = 'flex';

    return getSong().then(() => {
        document.getElementById('resultarea').innerHTML = "";
        songs.forEach(t => {
            document.getElementById('resultarea').innerHTML +=
                "<tr><td>" + t.songID + "</td><td>" +
                t.songTitle + "</td><td>" +
                `<button type=button onclick="removeSong(${t.songID})">Delete</button>` +
                `<button type=button onclick="showSongupdate(${t.songID})">Update</button>`
                + "</td></tr>";
        });
    });

}
function showArtist() {
    document.getElementById('createAlbumformdiv').style.display = 'none';
    document.getElementById('createSongformdiv').style.display = 'none';
    
    document.getElementById('formdiv').style.display = 'flex';
    document.getElementById('createArtistformdiv').style.display = 'flex';

    return getArtist().then(() => {
        document.getElementById('resultarea').innerHTML = "";
        artists.forEach(t => {
            document.getElementById('resultarea').innerHTML +=
                "<tr><td>" + t.artistID + "</td><td>" +
                t.artistName + "</td><td>" +
                `<button type=button onclick="removeArtist(${t.artistID})">Delete</button>` +
                `<button type=button onclick="showArtistupdate(${t.artistID})">Update</button>`
                + "</td></tr>";
        });
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

    fetch('http://localhost:17161/Artist/',
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

function showSongupdate(id) {
    document.getElementById('songNameToUpdate').value = songs.find(t => t['songID'] == id)['songTitle'];
    document.getElementById('updateSongformdiv').style.display = 'flex';
    songIdToUpdate = id;
}
function updateSong() {
    document.getElementById('updateSongformdiv').style.display = 'none';
    let name = document.getElementById('songNameToUpdate').value;

    fetch('http://localhost:17161/Song/',
        {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify({ songTitle: name, songID: songIdToUpdate }),
        })
        .then(response => response)
        .then(data => {
            console.log('Success', data);
            return getSong();
        })
        .then(() => showSong())
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

    fetch('http://localhost:17161/Album/',
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





function createArtist() {
    let name = document.getElementById('artistName').value;
    fetch('http://localhost:17161/artist',
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify({ artistName: name }),
        })
        .then(response => response)
        .then(data => {
            console.log('Success', data);
            return getArtist();
        })
        .then(()=>showArtist())
        .catch((error) => { console.error('Error', error); });
}
function createAlbum() {
    let name = document.getElementById('albumName').value;
    let id = document.getElementById('artistId').value;
    fetch('http://localhost:17161/album',
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify({
                albumTitle: name,
                artistId: id
            }),
        })
        .then(response => response)
        .then(data => {
            console.log('Success', data);
            getAlbum();
        })
        .then(()=>showAlbum())
        .catch((error) => { console.error('Error', error); });
}
function createSong() {
    let name = document.getElementById('songName').value;
    let id = document.getElementById('albumId').value;
    fetch('http://localhost:17161/song',
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify({ songTitle: name,albumID: id }),
        })
        .then(response => response)
        .then(data => {
            console.log('Success', data);
            getSong();
        })
        .then(() => showSong())
        .catch((error) => { console.error('Error', error); });
}
