import { Box } from "@mui/material";

const Music = ({ link }: { link: string }) => {

    return (<>
        <Box>
            <h3>🎶 Playing now 🎶</h3>
            <audio controls src={link} autoPlay />
        </Box>
    </>)
}
export default Music;