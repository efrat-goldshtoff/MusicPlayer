import { Box, Button, Card, CardContent, Typography } from "@mui/material";
import { Song } from "../../api/client";

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
                fontSize: '15px'
            }}>My Songs
            </header>
            <Box display="flex"
                flexDirection="column"
                gap="16px"
                sx={{
                    maxHeight: '550px',
                    overflowY: 'auto',
                    padding: '10px',
                    border: '1px solid #ccc',
                    borderRadius: '15px',
                    backgroundColor: '#fff'
                }}>
                {songs?.map((song, index) => (
                    <Card key={index}
                        sx={{
                            minHeight: 130,
                            borderRadius: '15px'
                        }}>
                        <CardContent>
                            <Typography variant="h6" gutterBottom>
                                {song.name}
                            </Typography>
                            <Button
                                sx={{
                                    border: '1px solid blue',
                                    marginRight: '3px'
                                }}
                                onClick={() => onPlay(song?.link ?? "no link")}>
                                Play 🔵
                            </Button>
                            <a href={song.link} download={song.name + '.mp3'}>
                                <Button
                                    sx={{
                                        border: '1px solid blue'
                                    }}>
                                    Download 🔽
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


// const songs = [
//     {
//         id: "1",
//         name: "Acheinu",
//         link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.1&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo8vz80&zw"
//     },
//     {
//         id: "2",
//         name: "Simcha",
//         link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.3&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo9m9b1&zw"
//     },
//     {
//         id: "3",
//         name: "Tov",
//         link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.2&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo9m9h2&zw"
//     }, {
//         id: '4',
//         name: 'Zanvil',
//         link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.4&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo9m9k3&zw"
//     },
//     {
//         id: "5",
//         name: "Tov",
//         link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.2&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo9m9h2&zw"
//     }, {
//         id: '6',
//         name: 'Zanvil',
//         link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.4&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo9m9k3&zw"
//     },
//     {
//         id: "7",
//         name: "Acheinu",
//         link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.1&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo8vz80&zw"
//     },
//     {
//         id: "8",
//         name: "Simcha",
//         link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.3&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo9m9b1&zw"
//     }
// ]
