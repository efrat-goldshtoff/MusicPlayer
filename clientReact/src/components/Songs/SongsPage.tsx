import { useEffect, useState } from "react"
import { ApiClient, Song } from "../../api/client"
import { Box } from "@mui/material";
import Music from "./Music";
import AllSongs from "./AllSongs";
import { MusicNoteRounded } from "@mui/icons-material";
import FilterSongs from "./FilterSongs";

const SongsPage = () => {
    const [songs, setSongs] = useState<Song[]>([]);
    const [filteredSongs, setFilteredSongs] = useState<Song[]>([]);
    const [currentPlayingSongLink, setCurrentPlayingSongLink] = useState<string | null>(null);
    const apiClient = new ApiClient("https://coursesangularserver.onrender.com/");
    const fetchAllSongs = async () => {
        try {
            const fetchedSongs = await apiClient.songAll();
            setSongs(fetchedSongs);
            setFilteredSongs(fetchedSongs);
        } catch (error) {
            console.error("Failed to fetch songs:", error);
        }
    };

    useEffect(() => {
        fetchAllSongs();
        apiClient.songAll().then(setSongs);
    }, [fetchAllSongs]);

    const filterSongs = async (singerName: string, genreQuery: string) => {
        let tempFiltered: Song[] = songs;
        if (singerName) {
            tempFiltered = tempFiltered.filter(song =>
                song.singer?.name?.toLowerCase().includes(singerName.toLowerCase())
            );
        }
        if (genreQuery) {
            try {
                const aiFiltered = await apiClient.searchByAI(genreQuery);
                tempFiltered = tempFiltered.filter(s => aiFiltered.some(aiS => aiS.id === s.id));
            } catch (error) {
                console.error("AI genre search failed, falling back to exact match:", error);
                tempFiltered = tempFiltered.filter(song =>
                    song.genre?.toLowerCase().includes(genreQuery.toLowerCase())
                );
            }
        }
        setFilteredSongs(tempFiltered);
    }
    return (<>
        <h2 style={{ marginBottom: '0px', color: 'purple' }}>
            <MusicNoteRounded sx={{ color: 'purple' }} />
            Play Me
            <MusicNoteRounded sx={{ color: 'purple' }} />
        </h2>
        <Box>
            <FilterSongs onFilter={filterSongs} />
            <AllSongs
                songs={filteredSongs.length > 0 ?
                    filteredSongs :
                    songs}
                onPlay={setCurrentPlayingSongLink}
            />
            {currentPlayingSongLink &&
                <Music link={currentPlayingSongLink} />}
        </Box>
    </>)
}
export default SongsPage;