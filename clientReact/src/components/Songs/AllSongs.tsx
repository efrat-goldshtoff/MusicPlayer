import { Box, Button, Card, CardContent, Typography } from "@mui/material";
// import { useState } from "react";
// import AddSong from "./AddSong";
// import { Song } from "./Song";
// import { Song } from "./Song";
// import axios from "axios";


// const style = {
//     position: 'absolute',
//     top: '50%',
//     left: '50%',
//     transform: 'translate(-50%,-50%)',
//     width: 400,
//     bgcolor: 'background.paper',
//     border: '2px solid #000',
//     boxShadow: 24,
//     p: 4
// }
const AllSongs = () => {

    // const ApiUrl='';
    // const songs=await axios.get(ApiUrl)
    // const [isOpen, setIsOpen] = useState(false);
    // const [, setIsAdd] = useState(false);

    const songs = [
        {
            id: "1",
            name: "Acheinu",
            link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.1&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo8vz80&zw"
        },
        {
            id: "2",
            name: "Simcha",
            link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.3&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo9m9b1&zw"
        },
        {
            id: "3",
            name: "Tov",
            link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.2&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo9m9h2&zw"
        }, {
            id: '4',
            name: 'Zanvil',
            link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.4&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo9m9k3&zw"
        },
        {
            id: "3",
            name: "Tov",
            link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.2&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo9m9h2&zw"
        }, {
            id: '4',
            name: 'Zanvil',
            link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.4&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo9m9k3&zw"
        }
    ]

    // const setSongs = (song: Song) => {
    //     songs.push(song);
    // }

    // const handleSuccessAddSong = () => {
    //     setIsAdd((now1) => {
    //         if (!now1)
    //             setIsOpen(false);
    //         return now1;
    //     })
    // }

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
            <Box
                display="flex"
                flexDirection="column"
                gap="16px"
                sx={{
                    maxHeight: '550px',
                    overflowY: 'auto',
                    padding: '10px',
                    border: '1px solid #ccc',
                    borderRadius: '15px',
                    backgroundColor: '#fff'
                }}
            >
                {songs.map((song, index) => (
                    <Card key={index}
                        sx={{
                            minHeight: 130,
                            // maxWidth: 350,
                            borderRadius: '15px'
                        }}>
                        <CardContent>
                            <Typography variant="h6" gutterBottom>
                                {song.name}
                            </Typography>
                            <audio
                                controls
                                style={{
                                    width: '300px',
                                    height: '50px',
                                    marginBottom: '10px'
                                }}
                            >
                                <source src={song.link} type="audio/mp3" />
                                Your browser does not support the audio element.
                            </audio>
                        </CardContent>
                    </Card>
                ))}
            </Box>
            {/* <Button
                variant="contained"
                color="secondary"
                sx={{ mx: 2 }}
            onClick={() => setIsOpen(true)}
            >
                Add Song
            </Button>*/}
        </div>

        {/* {isOpen &&
            <AddSong
                successAdding={handleSuccessAddSong}
                close={() => setIsOpen(false)}
                addSong={() => setSongs}
            />*/
        }
    </>)
}

export default AllSongs;