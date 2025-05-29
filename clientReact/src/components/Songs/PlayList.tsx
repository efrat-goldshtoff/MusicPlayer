import { useContext, useEffect, useState } from "react";
import { ApiClient, PlayListDto, Song } from "../../api/client";
import { UserContext } from "../Login/UserContext";
import { Box, Button, Card, CardContent, FormControl, IconButton, InputLabel, List, ListItem, ListItemText, MenuItem, Select, TextField, Typography } from "@mui/material";
import { Add, Delete, Remove } from "@mui/icons-material";
import { Grid2 as Grid } from "@mui/material";

type PlayListType = {
    id: number;
    name: string;
    userId: number;
    songs: Song[];
}

const PlayList = () => {
    const context = useContext(UserContext);
    const currentUserId = context?.user.id ? parseInt(context.user.id) : null;

    const [playLists, setPlayLists] = useState<PlayListType[]>([]);
    const [allSongs, setAllSongs] = useState<Song[]>([]);
    const [selectedPlaylist, setSelectedPlaylist] = useState<PlayListType | null>(null);
    const [newPlayListName, setNewPlayListName] = useState('');
    const [selectedSongToAdd, setSelectedSongToAdd] = useState<number | ''>('');
    const [error, setError] = useState('');

    const apiClient = new ApiClient("http://localhost:5048");

    const fetchPlaylists = async () => {
        if (!currentUserId) return;
        try {
            const result = await apiClient.playListAll();
            setPlayLists(result as PlayListType[]);
        } catch (error) {
            setError('Failed to fetch playlists');
            console.error("Error fetching playlists:", error);
        }
    };
    const fetchAllSongs = async () => {
        try {
            const fetchedSongs = await apiClient.songAll();
            setAllSongs(fetchedSongs);
        } catch (error) {
            setError('Failed to fetch all songs');
            console.error("Error fetching all songs:", error);
        }
    };

    useEffect(() => {
        if (currentUserId) {
            fetchPlaylists();
            fetchAllSongs();
        }
    }, [currentUserId]);

    const handleCreatePlaylist = async () => {
        setError(''); // Reset error state
        if (!newPlayListName.trim() || !currentUserId) return;
        try {
            const playListDto = new PlayListDto();
            playListDto.name = newPlayListName;
            playListDto.userId = currentUserId;
            const newPlaylist = await apiClient.playListPOST(playListDto);
            setPlayLists(prev => [...prev, newPlaylist as PlayListType]);
            setNewPlayListName('');
        } catch (error) {
            setError('Failed to create playlist');
            console.error("Error creating playlist:", error);
        }
    };
    const handleDeletePlaylist = async (id: number) => {
        try {
            await apiClient.playListDELETE(id);
            setPlayLists(prev => prev.filter(p => p.id !== id));
            if (selectedPlaylist?.id === id) {
                setSelectedPlaylist(null);
            }
        } catch (err) {
            setError('Failed to delete playlist');
            console.error("Error deleting playlist:", err);
        }
    };
    const handleAddSongToPlaylist = async () => {
        if (!selectedPlaylist || !selectedSongToAdd) return;
        try {
            await apiClient.addsong(selectedPlaylist.id, selectedSongToAdd as number);
            // Refresh selected playlist to show the new song
            const updatedPlaylist = await apiClient.playListGET(selectedPlaylist.id);
            setSelectedPlaylist(updatedPlaylist as PlayListType);
            setSelectedSongToAdd(''); // Clear selection
        } catch (err) {
            setError('Failed to add song to playlist');
            console.error("Error adding song:", err);
        }
    };
    const handleRemoveSongFromPlaylist = async (songId: number) => {
        if (!selectedPlaylist) return;
        try {
            await apiClient.removesong(selectedPlaylist.id, songId);
            // Refresh selected playlist
            const updatedPlaylist = await apiClient.playListGET(selectedPlaylist.id);
            setSelectedPlaylist(updatedPlaylist as PlayListType);
        } catch (err) {
            setError('Failed to remove song from playlist');
            console.error("Error removing song:", err);
        }
    };
    if (!currentUserId) {
        return (
            <Typography variant="h6" color="error">
                Please log in to view and manage playlists.
            </Typography>
        )
    }


    return (<>
        <Box sx={{ p: 3 }}>
            <Typography variant="h4" gutterBottom> My Playlists</Typography>
            {error && <Typography color="error">{error}</Typography>}
            <Box sx={{ mb: 4, display: 'flex', gap: 2, alignItems: 'center' }}>
                <TextField
                    label="New Playlist Name"
                    value={newPlayListName}
                    onChange={(e) => setNewPlayListName(e.target.value)}
                    variant="outlined"
                    fullWidth
                    sx={{ maxWidth: 300 }}
                />
                <Button
                    variant="contained"
                    color="primary"
                    onClick={handleCreatePlaylist}
                    startIcon={<Add />}
                >
                    Create Playlist
                </Button>
            </Box>
            <Grid container spacing={4}>
                <Grid size={12}>
                    <Card variant="outlined">
                        <CardContent>
                            <Typography variant="h5" gutterBottom>Your Playlists</Typography>
                            <List sx={{ maxHeight: 300, overflow: 'auto', border: '1px solid #eee', borderRadius: 1 }}>
                                {playLists.length === 0 ? (
                                    <ListItem><ListItemText primary="No playlists found. Create one!" /></ListItem>
                                ) : (
                                    playLists.map((playlist) => (
                                        <ListItem
                                            key={playlist.id}
                                            secondaryAction={
                                                <IconButton edge="end" aria-label="delete" onClick={() => handleDeletePlaylist(playlist.id)}>
                                                    <Delete />
                                                </IconButton>
                                            }
                                            sx={{ '&:hover': { backgroundColor: '#f5f5f5' }, cursor: 'pointer' }}
                                            onClick={() => setSelectedPlaylist(playlist)}
                                        >
                                            <ListItemText primary={playlist.name} />
                                        </ListItem>
                                    ))
                                )}
                            </List>
                        </CardContent>
                    </Card>
                </Grid>
                <Grid size={12}>
                    {selectedPlaylist && (
                        <Card variant="outlined">
                            <CardContent>
                                <Typography variant="h5" gutterBottom>
                                    {selectedPlaylist.name} Songs
                                </Typography>
                                <List sx={{
                                    maxHeight: 300,
                                    overflow: 'auto',
                                    border: '1px solid #eee',
                                    borderRadius: 1
                                }}>
                                    {selectedPlaylist.songs.length === 0 ? (
                                        <ListItem><ListItemText primary="No songs in this playlist." /></ListItem>
                                    ) : (
                                        selectedPlaylist.songs.map((song) => (
                                            <ListItem key={song.id}
                                                secondaryAction={
                                                    <IconButton edge="end" aria-label="remove" onClick={() => handleRemoveSongFromPlaylist(song.id!)}>
                                                        <Remove />
                                                    </IconButton>
                                                }>
                                                <ListItemText primary={song.name} secondary={song.singer?.name || 'Unknown Singer'} />
                                            </ListItem>
                                        ))
                                    )}

                                </List>
                                <Box sx={{ mt: 3, display: 'flex', gap: 2, alignItems: 'center' }}>
                                    <FormControl fullWidth size="small">
                                        <InputLabel>Add Song</InputLabel>
                                        <Select value={selectedSongToAdd}
                                            label="Add Song"
                                            onChange={(e) => setSelectedSongToAdd(e.target.value as number)}>
                                            <MenuItem value="">
                                                <em>None</em>
                                            </MenuItem>
                                            {allSongs.map((song) => (
                                                <MenuItem key={song.id} value={song.id}>
                                                    {song.name} by {song.singer?.name || 'Unknown'}
                                                </MenuItem>
                                            ))}
                                        </Select>
                                    </FormControl>
                                    <Button
                                        variant="contained"
                                        color="secondary"
                                        onClick={handleAddSongToPlaylist}
                                        startIcon={<Add />}
                                        disabled={!selectedSongToAdd}
                                    >
                                        Add
                                    </Button>
                                </Box>
                            </CardContent>
                        </Card>
                    )}
                </Grid>
            </Grid>
        </Box>
    </>
    );
}
export default PlayList;