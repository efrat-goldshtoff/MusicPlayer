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
        const apiClient = new ApiClient("http://localhost:5048");
        try {
            let result: any;
            if (typeAction === 'Sign') {
                const registerDto = new UserDto();
                registerDto.name = nameRef.current?.value || '';
                registerDto.password = passwordRef.current?.value || '';
                registerDto.email = emailRef.current?.value || '';
                registerDto.role = 'User';

                result = await apiClient.register(registerDto);
                context?.userDispatch({
                    type: 'CREATE',
                    data: {
                        id: result.user.id,
                        firstName: result.user.name,
                        email: result.user.email,
                        password: registerDto.password,
                        lastName: ''
                    }
                });
                localStorage.setItem('token', result.token);
            }
            else {
                const loginM = new LoginM();
                loginM.name = nameRef.current?.value || '';
                loginM.password = passwordRef.current?.value || '';
                result = await apiClient.login(loginM);
                const tokenPayLoad = JSON.parse(atob(result.token.split('.')[1]));
                context?.userDispatch({
                    type: 'CREATE',
                    data: {
                        id: tokenPayLoad.id,
                        firstName: tokenPayLoad.unique_name,
                        email: tokenPayLoad.email,
                        password: loginM.password,
                        role: tokenPayLoad.role
                    }
                });
                localStorage.setItem('token', result.token);
            }
            setOpen(false);
            successLogin();
           
        } catch (error: any) {
            if (error.status === 400 && typeAction === 'Sign') {
                alert(`Registration failed: ${error.result}`);
            } else if (error.status === 401 && typeAction === 'Login') {
                alert('Login failed: Invalid credentials');
            } else {
                alert('An unexpected error occurred. Please try again.');
            }
            console.error(error); // Log error for debugging
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
                    <TextField label='Name'
                        inputRef={nameRef}
                        fullWidth
                        sx={{ mb: 2 }} />
                        {typeAction==='Sign'&&(
                            <TextField label='Email'
                            inputRef={emailRef}
                            type="email"
                            fullWidth
                            sx={{ mb: 2 }} />
                        )}
                    <TextField label='Password'
                        inputRef={passwordRef}
                        type="password"
                        fullWidth
                        sx={{ mb: 2 }} />

                    <Button
                        type="submit"
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