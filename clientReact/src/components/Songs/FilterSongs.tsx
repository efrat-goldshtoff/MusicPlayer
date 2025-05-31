import {
    Box,
    Button,
    Card,
    CardContent,
    Grid2 as Grid,
    TextField
} from "@mui/material";
import { useRef } from "react";
import SearchIcon from '@mui/icons-material/Search';



const FilterSongs = ({ onFilter }: { onFilter: Function }) => {
    const singerRef = useRef<HTMLInputElement>(null);
    const genreRef = useRef<HTMLInputElement>(null);

    return (<>
        <Box sx={{ mb: 3 }}>
            <Card sx={{ maxWidth: 600, mx: "auto", borderRadius: 2, p: 2 }}>
                <CardContent>
                    <Grid container spacing={2}>
                        <Grid size={12}>
                            <TextField
                                fullWidth
                                label="Search by singer"
                                inputRef={singerRef}
                                variant="outlined"
                            />
                        </Grid>
                        <Grid size={12}>
                            <TextField
                                fullWidth
                                label="Search by genre"
                                inputRef={genreRef}
                                variant="outlined"
                            />
                        </Grid>
                        <Grid size={12} textAlign="right">
                            <Button
                                variant="contained"
                                color="secondary"
                                startIcon={<SearchIcon />}
                                onClick={() =>
                                    onFilter(
                                        singerRef.current?.value ?? '',
                                        genreRef.current?.value ?? ''
                                    )
                                }
                            >
                                Search
                            </Button>  
                        </Grid>
                    </Grid>
                </CardContent>
            </Card>
        </Box>
        {/* <Box
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
                            onFilter(
                                singerRef.current?.value ?? '',
                                genreRef.current?.value ?? ''
                            )
                        }
                    >
                        Search 🔎
                    </Button>
                </CardContent>
            </Card>
        </Box> */}
    </>)
}
export default FilterSongs;