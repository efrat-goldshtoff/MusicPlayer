import { useEffect, useState } from "react"
import { ApiClient, Song } from "../../api/client"
import { Box } from "@mui/material";
import Music from "./Music";
import AllSongs from "./AllSongs";
import { MusicNoteRounded } from "@mui/icons-material";
import FilterSongs from "./FilterSongs";

const SongsPage = () => {
    const [songs, setSongs] = useState<Song[]>([]);
    const [filteredS, setFilteredS] = useState<Song[]>([]);
    const [current, setCurrent] = useState<string | null>(null);

    useEffect(() => {
        const apiClient = new ApiClient("http://localhost:5048");
        apiClient.songAll().then(setSongs);
    }, []);

    const filterS = (singer: string, genre: string) => {
        let filtered = songs;
        if (singer)
            filtered = filtered.filter(song => song.singer?.name === singer);
        if (genre)
            filtered = filtered.filter(song => song.genre == genre);
        console.log(filtered);
        setFilteredS(filtered);
    }
    return (<>
        <h2 style={{ marginBottom: '0px', color: 'purple' }}>
            <MusicNoteRounded sx={{ color: 'purple' }} />
            Play Me
            <MusicNoteRounded sx={{ color: 'purple' }} />
        </h2>
        <Box>
            <FilterSongs onFilter={filterS} />
            <AllSongs
                songs={filteredS.length > 0 ?
                    filteredS :
                    songs}
                onPlay={setCurrent}
            />
            <Music link={current!} />
            {/* {current &&  <Music link={current} /> }  */}
        </Box>
    </>)
}
export default SongsPage;