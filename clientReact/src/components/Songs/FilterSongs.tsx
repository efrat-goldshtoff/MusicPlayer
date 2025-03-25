// import { Box, Button, Card, CardContent, TextField } from "@mui/material";
// import { useRef } from "react";

// const FilterSongs = ({ onFilter }: { onFilter: Function }) => {
// const [singer, setSinger] = useState('');
// const [genre, setGenre] = useState('');
//     const singerRef = useRef<HTMLInputElement>(null);
//     const genreRef = useRef<HTMLInputElement>(null);

//     return (<>
//         <Box>
//             <Card>
//                 <CardContent>
//                     <TextField label="Search by singer"
//                         inputRef={singerRef}
//                     />
//                     <TextField label="Search by genre"
//                         inputRef={genreRef}
//                     /><div></div>
//                     <Button
//                         type="submit"
//                         onClick={() => onFilter(singerRef, genreRef)}
//                     >
//                         Search 🔎
//                     </Button>
//                 </CardContent>
//             </Card>
//         </Box>
//     </>)
// }
// export default FilterSongs;