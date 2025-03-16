import { Box, Button, Card, CardContent, Stack, Typography } from "@mui/material";
// import { Song } from "./Song";
// import axios from "axios";

const AllSongs = () => {
    // const ApiUrl='';
    // const songs=await axios.get(ApiUrl)
    const songs = [
        {
            id: "1",
            name: "Ilan",
            link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.1&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo8vz80&zw"
        },
        {
            id: "2",
            name: "Tov",
            link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.3&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo9m9b1&zw"
        },
        {
            id: "3",
            name: "Shabat",
            link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.2&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo9m9h2&zw"
        }, {
            id: '4',
            name: 'Tami',
            link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.4&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo9m9k3&zw"
        },
        {
            id: "3",
            name: "Shabat",
            link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.2&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo9m9h2&zw"
        }, {
            id: '4',
            name: 'Tami',
            link: "https://mail.google.com/mail/u/0?ui=2&ik=3ff0f85931&attid=0.4&permmsgid=msg-a:r6551807614108487557&view=att&disp=safe&realattid=f_m8bo9m9k3&zw"
        }
    ]

    return (<>
        <div style={{ padding: '20px', backgroundColor: '#f5f5f5' }}>
            <Box
                display="flex"
                flexDirection="column"
                gap="16px"
                sx={{
                    maxHeight: '550px',
                    overflowY: 'auto',
                    padding: '10px',
                    border: '1px solid #ccc',
                    borderRadius: '10px',
                    backgroundColor: '#fff'
                }}
            >
                {songs.map((song, index) => (
                    <Card key={index}
                        sx={{
                            minHeight: 130,
                            maxWidth: 350,
                            borderRadius: '10px'
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
        </div>
        <Button variant="contained" color="secondary" sx={{ mx: 2 }}>
            Add Song
        </Button>
        {/* <div style={{ padding: '20px', backgroundColor: '#f5f5f5' }}>
            <Stack
                direction="row"
                spacing={3}
                flexWrap="wrap"
                justifyContent="flex-start"
            >
                {songs.map((song, index) => (
                    <Card key={index} sx={{ maxWidth: 345, borderRadius: '10px' }}>
                        <CardContent>
                            <Typography variant="h6" gutterBottom>
                                {song.name}
                            </Typography>
                            <audio controls style={{ width: '100%' }}>
                                <source src={song.link} type="audio/mp3" />
                                Your browser does not support the audio element.
                            </audio>
                        </CardContent>
                    </Card>
                ))}
            </Stack>
        </div>
        <Button variant="contained" color="secondary" sx={{ mx: 2 }}>
            Add Song
        </Button> */}
        {/* <div style={{ padding: '20px', backgroundColor: '#f5f5f5' }}>
                <Box 
                    display="flex" 
                    flexWrap="wrap" 
                    justifyContent="space-between" 
                    gap="16px"
                >
                    {songs.map((song, index) => (
                        <Box key={index} sx={{ maxWidth: 345, borderRadius: '10px' }}>
                            <Card sx={{ maxWidth: 345, borderRadius: '10px' }}>
                                <CardContent>
                                    <Typography variant="h6" gutterBottom>
                                        {song.name}
                                    </Typography>
                                    <audio controls style={{ width: '100%' }}>
                                        <source src={song.link} type="audio/mp3" />
                                        Your browser does not support the audio element.
                                    </audio>
                                </CardContent>
                            </Card>
                        </Box>
                    ))}
                </Box>
            </div>
            <Button variant="contained" color="secondary" sx={{ mx: 2 }}>
                Add Song
            </Button> */}
        {/* <div style={{ padding: '20px', backgroundColor: '#f5f5f5' }}>
            <Grid2 container spacing={3}>
                {songs.map((song, index) => (
                    <Grid2 component="div" item xs={12} sm={6} md={4} key={index} sx={{ maxWidth: 345, borderRadius: '10px' }}>
                        <Card sx={{ maxWidth: 345, borderRadius: '10px' }}>
                            <CardContent>
                                <Typography variant="h6" gutterBottom>
                                    {song.name}
                                </Typography>
                                <audio controls style={{ width: '100%' }}>
                                    <source src={song.link} type="audio/mp3" />
                                    Your browser does not support the audio element.
                                </audio>
                            </CardContent>
                        </Card>

                    </Grid2>
                ))}
            </Grid2>
        </div>
        <Button variant="contained"
            color="secondary"
            sx={{ mx: 2 }}>
            Add Song
        </Button> */}
        {/* <div >
            {songs.map((song, index) => {
                return (
                    <div key={index}>
                        <label>{song.name}</label>
                        <audio controls>
                            <source src={song.link} type="audio/mp3" />
                            Your browser does not support the audio element.
                        </audio>
                    </div>
                )
            })}
        </div>
        <Button variant="contained"
            color="secondary"
            sx={{ mx: 2 }}>
            Add Song
        </Button> */}
    </>)
}

export default AllSongs;