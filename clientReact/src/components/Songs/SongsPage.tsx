import { useEffect, useRef, useState } from "react"
import { ApiClient, Song } from "../../api/client"
import { Box, Button, Card, CardContent, TextField } from "@mui/material";
import Music from "./Music";
import AllSongs from "./AllSongs";

const SongsPage = () => {
    const [songs, setSongs] = useState<Song[]>([]);
    const [filteredS, setFilteredS] = useState<Song[]>([]);
    const [current, setCurrent] = useState<string | null>(null);

    const singerRef = useRef<HTMLInputElement>(null);
    const genreRef = useRef<HTMLInputElement>(null);

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
        <h2 style={{ marginBottom: '0px' }}>🎶 Play Me 🎶</h2>
        <Box
            sx={{
                marginBottom: '4px'
            }}>
            <Card
                sx={{
                    maxHeight: '180px'
                }}>
                <CardContent>
                    <TextField fullWidth
                        label="Search by singer"
                        inputRef={singerRef}
                        sx={{
                            marginBottom: '6px'
                        }}
                    />
                    <TextField fullWidth
                        label="Search by genre"
                        inputRef={genreRef}
                    />
                    <div></div>
                    <Button
                        sx={{
                            color: 'purple',
                            border: '1px solid purple'
                        }}
                        type="submit"
                        onClick={() =>
                            filterS(
                                singerRef.current?.value ?? '',
                                genreRef.current?.value ?? ''
                            )
                        }
                    >
                        Search 🔎
                    </Button>
                </CardContent>
            </Card>
        </Box>
        <Box>
            {/* <FilterSongs onFilter={filterS} /> */}
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