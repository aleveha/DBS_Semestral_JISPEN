import React, { FC } from "react";
import { Layout } from "../../../components/Layout";
import { AuthorizationLayout } from "../shared/AuthorizationLayout";

export const LoginPage: FC = () => {
    return (
        <Layout>
            <AuthorizationLayout />
        </Layout>
    );
};
