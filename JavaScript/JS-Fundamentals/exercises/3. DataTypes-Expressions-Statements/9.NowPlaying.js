function displayTrackInfo(input) {
    let trackName = input[0];
    let artistName = input[1];
    let duration = input[2];

    console.log(`Now Playing: ${artistName} - ${trackName} [${duration}]`);
}

displayTrackInfo(['Number One', 'Nelly', '4:09']);