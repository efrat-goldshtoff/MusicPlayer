import { Box, Button, Card, CardContent, Typography } from "@mui/material";
import { Song } from "../../api/client";
import { Download, PlayArrow } from "@mui/icons-material";

const AllSongs = ({ songs, onPlay }: { songs: Song[], onPlay: (link: string) => void }) => {

    return (<>
        <div
            style={{
                padding: '20px',
                backgroundColor: '#f5f5f5',
                borderRadius: '15px'
            }}>
            <header style={{
                fontWeight: 'bold',
                fontSize: '15px',
                color: 'purple'
            }}>My Songs
            </header>
            <Box display="flex"
                flexDirection="column"
                gap="16px"
                sx={{
                    maxHeight: '220px',
                    overflowY: 'auto',
                    padding: '4px',
                    border: '1px solid #ccc',
                    borderRadius: '15px',
                    backgroundColor: '#fff'
                }}>
                {songs?.map((song, index) => (
                    <Card key={index}
                        sx={{
                            minHeight: 90,
                            borderRadius: '15px'
                        }}>
                        <CardContent>
                            <Typography variant="h6"
                                sx={{
                                    color: 'purple'
                                }}>
                                {song.name}
                            </Typography>
                            <Button
                                sx={{
                                    color: 'purple',
                                    border: '1px solid purple',
                                    marginRight: '3px'
                                }}
                                onClick={() => onPlay(song?.link ?? "no link")}>
                                Play <PlayArrow />
                            </Button>
                            <a href={song.link} download={song.name
                                //  + '.mp3'
                                 }>
                                <Button
                                    sx={{
                                        color: 'purple',
                                        border: '1px solid purple'
                                    }}>
                                    Download <Download />
                                </Button>
                            </a>
                        </CardContent>
                    </Card>
                ))}
            </Box>
        </div>
    </>);
}
export default AllSongs;
