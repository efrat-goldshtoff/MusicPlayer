import { MusicNoteRounded } from "@mui/icons-material";
import { Box } from "@mui/material";

const Music = ({ link }: { link: string }) => {

    return (<>

        <Box sx={{ textAlign: 'center', padding: '20px', borderRadius: '10px', boxShadow: '0 4px 8px rgba(0, 0, 0, 0.1)' }}>
            <h3 style={{ color: 'purple', display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
                <MusicNoteRounded sx={{ color: 'purple', marginRight: 1 }} />
                Playing now
                <MusicNoteRounded sx={{ color: 'purple', marginLeft: 1 }} />
            </h3>
            <audio controls src={link} autoPlay style={{ width: '100%', borderRadius: '8px' }} />
        </Box>

        {/* <Box>
            <h3 style={{ color: 'purple' }}>
                <MusicNoteRounded sx={{ color: 'purple' }} />
                Playing now
                <MusicNoteRounded sx={{ color: 'purple' }} />
            </h3>
            <audio controls src={link} autoPlay />
        </Box> */}
    </>)
}
export default Music;