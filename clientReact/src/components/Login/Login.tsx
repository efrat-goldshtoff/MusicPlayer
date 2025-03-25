import { FormEvent, useContext, useRef, useState } from "react";
import { UserContext } from "./UserContext";
import { Box, Button, Modal, TextField } from "@mui/material";
import { ApiClient, LoginM, UserDto } from "../../api/client";

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

const Login = ({ successLogin, typeAction, close }:
    { successLogin: Function; typeAction: string, close: Function }
) => {
    const context = useContext(UserContext);
    const nameRef = useRef<HTMLInputElement>(null);
    const passwordRef = useRef<HTMLInputElement>(null);
    const emailRef = useRef<HTMLInputElement>(null);
    const [open, setOpen] = useState(true);

    const handleSubmitLogin = async (e: FormEvent) => {
        e.preventDefault();
        const apiClient = new ApiClient("https://localhost:5048");
        try {
            let result: any;
            if (typeAction === 'Sign') {
                const registerM = new UserDto();
                registerM.name = nameRef.current?.value || '';
                registerM.password = passwordRef.current?.value || '';
                registerM.email = emailRef.current?.value || '';

                // result = await apiClient.register(registerM);
                if (!result || !result.token || !result.message) {
                    console.error("Missing Token or Message ", result);
                }
                else {
                    console.log('Registered success ', result);
                }
            }
            else if (typeAction === 'Login') {
                const loginM = new LoginM();
                loginM.name = nameRef.current?.value || '';
                loginM.password = passwordRef.current?.value || '';
                result = await apiClient.login(loginM);
            }
            if (result && (result.token || result.message)) {
                context?.userDispatch({
                    type: 'CREATE',
                    data: {
                        id: nameRef.current?.value || '',
                        firstName: nameRef.current?.value || '',
                        password: passwordRef.current?.value || ''
                    }
                });
                setOpen(false);
                successLogin();
            } else {
                alert('Something wrong, Please try again');
            }
        } catch (error: any) {
            alert(typeAction === 'Sign' ? 'User Already Exists' :
                'User Not Found'
            );
        }
    }

    return (<>
        <Modal
            open={open}
            onClose={() => close()}
            aria-labelledby='modal-modal-title'
            aria-describedby="modal-modal-description"
        >
            <Box sx={style}>
                <form onSubmit={handleSubmitLogin}>
                    <TextField label='name'
                        inputRef={nameRef}
                        fullWidth
                        sx={{ mb: 2 }} />
                    <TextField label='password'
                        inputRef={passwordRef}
                        fullWidth
                        sx={{ mb: 2 }} />

                    <Button
                        type="submit"
                        // variant="contained"
                        sx={{
                            color: 'purple',
                            border: '1px solid purple'
                        }}>
                        {typeAction}
                    </Button>
                </form>
            </Box>
        </Modal>
    </>)
}
export default Login;