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
    </>)
}
export default FilterSongs;