import { createTheme } from "@mui/material/styles";

export const theme = createTheme({
    palette: {
        primary: {
            main: "#006AB3",
        },
        secondary: {
            main: "#BFCE00",
        },
        background: {
            default: "#FCFCFB",
        },
    },
    shape: {
        borderRadius: 5,
    },
    typography: {
        fontFamily: ['"Baloo 2"', "sans-serif"].join(","),
    },
});
