import create from "zustand";
import { IUser } from "../types/types";

interface IUserState {
    user: IUser | null;
    changeUser: (value: IUser | null) => void;
}

export const useUserStore = create<IUserState>((set) => ({
    user: null,
    changeUser: (value) => set(() => ({ user: value })),
}));
