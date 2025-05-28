import { useEffect, useState } from "react";
import { ApiClient, Song } from "../../api/client";
import axios from "axios";


type playListProps = {
    id: number;
    name: string;
    songs: Song[]
}

const PlayList = () => {
    const [playLists, setPlayLists] = useState<playListProps[]>([]);
    const [songs, setSongs] = useState<Song[]>([]);
    const [selectPlayLists, setSelectPlayLists] = useState<playListProps | null>(null);
    const [newName, setNewName] = useState('');
    const [error, setError] = useState('');

    const fetchPlaylists = async () => {
        try {
            const res = await axios.get('https://localhost:7208/api/playlists');
            if (Array.isArray(res.data)) {
                setPlayLists(res.data);
            } else {
                setError('Failed to fetch playlists');
            }
        } catch {
            setError('Failed to fetch playlists');
        }
    };
    const fetchSongs = async () => {
        try {
            const apiClient = new ApiClient("http://localhost:5048");
            apiClient.songAll().then(setSongs);
        } catch (err) {
            setError('Failed to fetch songs');
        }
    }

    useEffect(() => {
        fetchSongs();
    })
    return (<>
        <h2>My PlayList</h2>
    </>
    );
}
export default PlayList;