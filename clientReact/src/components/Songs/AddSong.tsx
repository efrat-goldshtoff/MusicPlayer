import { Box, Button, Modal, TextField } from "@mui/material";
import { FormEvent, useContext, useRef, useState } from "react";
import { UserContext } from "../Login/UserContext";


const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%,-50%)',
    width: 400,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4
}

const AddSong = ({ successAdding, close, addSong }:
    { successAdding: Function; close: Function, addSong: Function }) => {

    const context = useContext(UserContext);
    const nameRef = useRef<HTMLInputElement>(null);
    const linkRef = useRef<HTMLInputElement>(null);

    const [open, setOpen] = useState(true);
    const [userId, setUserId] = useState<string>();

    const handleSubmitAddSong = async (e: FormEvent) => {
        e.preventDefault();

        addSong({ nameRef, linkRef })

        setOpen(false)
        successAdding();

    }

    return (<>
        <Modal
            open={open}
            onClose={() => close()}
            aria-labelledby='modal-modal-title'
            aria-describedby="modal-modal-description"
        >
            <Box sx={style}>
                <form onSubmit={handleSubmitAddSong}>
                    <TextField label='name'
                        inputRef={nameRef}
                        fullWidth
                        sx={{ mb: 2 }} />

                    <TextField label='link'
                        inputRef={linkRef}
                        fullWidth
                        sx={{ mb: 2 }} />

                    <Button
                        type="submit"
                        variant="contained"
                        sx={{
                            background: 'black',
                            color: 'white',
                            borderRadius: '10px',
                            border: '2px solid white'
                        }}>
                        Add Song
                    </Button>
                </form>
            </Box>

        </Modal>
    </>)
}
export default AddSong;
