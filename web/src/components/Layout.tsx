import React, { FC } from "react";
import { makeStyles } from "@mui/styles";
import { theme } from "./theme/Theme";

const useStyles = makeStyles({
    root: {
        backgroundColor: theme.palette.background.default,
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        height: "100vh",
        width: "100vw",
    },
});

export const Layout: FC = ({ children }) => {
    const classes = useStyles();
    return <div className={classes.root}>{children}</div>;
};
