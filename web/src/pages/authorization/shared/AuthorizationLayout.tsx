import { makeStyles } from "@mui/styles";
import React, { FC } from "react";
import { Paper } from "@mui/material";

const useStyles = makeStyles({
    authPaper: {
        height: 250,
        width: 400,
    },
});

export const AuthorizationLayout: FC = ({ children }) => {
    const classes = useStyles();
    return (
        <Paper className={classes.authPaper} elevation={3}>
            {children}
        </Paper>
    );
};
